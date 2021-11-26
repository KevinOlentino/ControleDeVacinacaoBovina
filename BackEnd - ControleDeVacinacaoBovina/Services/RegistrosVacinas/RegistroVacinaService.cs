using ControleDeVacinacaoBovina.Models;
using ControleDeVacinacaoBovina.Models.Dtos;
using ControleDeVacinacaoBovina.Repositories.Animais;
using ControleDeVacinacaoBovina.Repositories.Rebanhos;
using ControleDeVacinacaoBovina.Repositories.RegistrosVacinas;
using ControleDeVacinacaoBovina.Repository.Vendas;
using ControleDeVacinacaoBovina.Services.Vacinas;
using ControleDeVacinacaoBovina.Services.Vendas;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeVacinacaoBovina.Services.RegistrosVacinas
{
    public class RegistroVacinaService : IRegistroVacinaService
    {
        private readonly IRegistroVacinaRepository registroVacinaRepository;
        private readonly IRebanhoRepository rebanhoRepository;
        private readonly IVacinaService vacinaService;

        public IVendaRepository vendaRepository { get; }

        public RegistroVacinaService(IRegistroVacinaRepository registroVacinaRepository, 
            IRebanhoRepository rebanhoRepository,
            IVacinaService vacinaService,
            IVendaRepository vendaRepository
            )
        {
            this.registroVacinaRepository = registroVacinaRepository;
            this.rebanhoRepository = rebanhoRepository;
            this.vacinaService = vacinaService;
            this.vendaRepository = vendaRepository;
        }

        public Task<ObjectResult> Cancelar(int id)
        {
            var response = new ResponseDto<RegistroVacinacao>(EStatusCode.NO_CONTENT, null);
            RegistroVacinacao registroVacinacao = registroVacinaRepository.GetById(id);

            if (registroVacinacao == null || registroVacinacao.Ativo == false)
            {
                response.StatusCode = EStatusCode.NOT_FOUND;
                return response.ResultAsync();
            }
            try
            {
                IEnumerable<Venda> venda = vendaRepository.GetByRebanho(registroVacinacao.IdRebanho);

                int registroBrucelose = registroVacinaRepository.ObterVacinasDesseAnoContagem(registroVacinacao.IdRebanho, 1);
                int registroAftosa = registroVacinaRepository.ObterVacinasDesseAnoContagem(registroVacinacao.IdRebanho, 2);
                int quantidade = registroAftosa < registroBrucelose ? registroAftosa : registroBrucelose;

                if (venda.Any())
                {
                    Venda lastVenda = venda.Last();
                    if(lastVenda.DataDeVenda.CompareTo(registroVacinacao.DataDeCadastro) > 0)
                    {
                        response.AddError("error", "Cancelamento invalido pois há uma venda depois deste registro!");
                        response.StatusCode = EStatusCode.BAD_REQUEST;
                        return response.ResultAsync();
                    }
                }
                if(quantidade > registroVacinacao.Quantidade)
                {
                    registroVacinaRepository.Cancelar(registroVacinacao);
                    registroVacinacao.Rebanho.QuantidadeVacinada -= registroVacinacao.Quantidade;
                }
                else
                {
                    registroVacinaRepository.Cancelar(registroVacinacao);
                    registroVacinacao.Rebanho.QuantidadeVacinada -= quantidade;
                }                
                
                rebanhoRepository.Editar(registroVacinacao.Rebanho);
            }
            catch (Exception ex)
            {
                response.AddException(ex, EStatusCode.BAD_REQUEST);
            }

            return response.ResultAsync();            
        }

        public async Task<ObjectResult> GetByPropriedade(int idPropriedade)
        {
            var response = new ResponseDto<IEnumerable<RegistroVacinacao>>(EStatusCode.OK, null);
            try
            {
                IEnumerable<RegistroVacinacao> registroVacinacao = registroVacinaRepository.GetByPropriedade(idPropriedade);
                response.Data = registroVacinacao;

                if (!registroVacinacao.Any())
                {
                    response.StatusCode = EStatusCode.NOT_FOUND;
                    return await response.ResultAsync();
                }
            }
            catch (Exception ex)
            {
                response.AddException(ex, EStatusCode.INTERNAL_SERVER_ERROR);
            }

            return await response.ResultAsync();            
        }

        public async Task<ObjectResult> Incluir(RegistroVacinacaoDto registroVacinacaoDto)
        {
            var response = new ResponseDto<RegistroVacinacao>(EStatusCode.NO_CONTENT, null);
            try
            {
                Rebanho rebanhoAVacinar = rebanhoRepository.GetById(registroVacinacaoDto.IdRebanho);
                RegistroVacinacao registroVacinacaoNovo = registroVacinacaoDto.DtoToRegistroVacinacao(registroVacinacaoDto);

                if (ValidarRegistroDeVacinas(registroVacinacaoNovo, rebanhoAVacinar, response))
                {
                    rebanhoAVacinar.QuantidadeVacinada += 
                        ObterContagemDeAnimaisAVacinar(rebanhoAVacinar.IdRebanho, registroVacinacaoNovo.Quantidade, registroVacinacaoNovo.IdVacina);
                    await registroVacinaRepository.Incluir(registroVacinacaoNovo);
                    rebanhoRepository.Editar(rebanhoAVacinar);
                }
            }
            catch(Exception ex)
            {
                response.AddException(ex, EStatusCode.BAD_REQUEST);
            }

            return await response.ResultAsync();
        }

        private bool ValidarRegistroDeVacinas(RegistroVacinacao registroVacinacao, Rebanho rebanhoAVacinar, ResponseDto<RegistroVacinacao> response)
        {            
            int restanteAVacinarTotal = rebanhoAVacinar.QuantidadeTotal - rebanhoAVacinar.QuantidadeVacinada;
            Vacina vacina = vacinaService.GetById(registroVacinacao.IdVacina);
            int quantidadeRestante;
            int registroBrucelose = registroVacinaRepository.ObterVacinasDesseAnoContagem(registroVacinacao.IdRebanho, 1);
            int registroAftosa = registroVacinaRepository.ObterVacinasDesseAnoContagem(registroVacinacao.IdRebanho, 2);
            int quantidadeVacinadaPorRegistro = registroAftosa < registroBrucelose ? registroAftosa:registroBrucelose;

            if (registroVacinacao.IdVacina == 1)
                quantidadeRestante = registroBrucelose - quantidadeVacinadaPorRegistro - restanteAVacinarTotal;
            else
                quantidadeRestante = registroAftosa - quantidadeVacinadaPorRegistro - restanteAVacinarTotal;

            if (restanteAVacinarTotal == 0)
            {
                response.AddError("error","Todos os animais já foram vacinados esse ano");
            }
            else if (quantidadeRestante == 0)
            {
                response.AddError("error", $"Todos os animais já foram vacinados contra {vacina.Doenca} esse ano");
            }
            else if (registroVacinacao.Quantidade > System.Math.Abs(quantidadeRestante))
            {
                response.AddError("error",
                    $"Valor não pode ser maior que a quantidade total de animais Restante a Vacinar contra {vacina.Doenca} Restante: " +
                    $"{System.Math.Abs(quantidadeRestante)}");                
            }

            if (response.Errors.Any())
            {
                response.StatusCode = EStatusCode.BAD_REQUEST;
                return false;
            }
            return true;
        }

        public int ObterContagemDeAnimaisAVacinar(int idRebanho,int Quantidade, int idVacina)
        {
            int registroBrucelose = registroVacinaRepository.ObterVacinasDesseAnoContagem(idRebanho, 1);
            int registroAftosa = registroVacinaRepository.ObterVacinasDesseAnoContagem(idRebanho, 2);

            int quantidadeAVacinar = System.Math.Abs(registroAftosa - registroBrucelose);

            if (registroAftosa == registroBrucelose)
                return 0;
            else if (idVacina == 1 && registroBrucelose > registroAftosa)
                return 0;
            else if (idVacina == 2 && registroAftosa > registroBrucelose)
                return 0;

                return quantidadeAVacinar < Quantidade ? quantidadeAVacinar : Quantidade;                                   
        }

    }
}
