using System;
using System.ComponentModel.DataAnnotations;

namespace ControleDeVacinacaoBovina.Models.Dtos
{
    public class RegistroVacinacaoDto
    {
        public int IdRegistroVacinacao { get; set; }

        [Required(ErrorMessage = "Quantidade não pode ser nulo")]
        [Range(1, int.MaxValue, ErrorMessage = "Quantidade não pode ser menor que 1")]
        public int Quantidade { get; set; }

        [Required(ErrorMessage = "Data da vacina não pode ser nula")]
        public DateTime DataDaVacina { get; set; }

        [Required(ErrorMessage = "Id Animal não pode ser nulo")]
        [Range(1, int.MaxValue, ErrorMessage = "Id Animal não pode ser menor que 1")]
        public int IdAnimal { get; set; }

        [Required(ErrorMessage = ("Id Vacina não poder ser nulo"))]
        [Range(1, int.MaxValue, ErrorMessage = "Id Vacina não pode ser menor que 1")]
        public int IdVacina { get; set; }

        public RegistroVacinacao DtoToRegistroVacinacao(RegistroVacinacaoDto registroVacinacao)
        {
            return new RegistroVacinacao
            {
                IdRegistroVacinacao = registroVacinacao.IdRegistroVacinacao,
                Quantidade = registroVacinacao.Quantidade,
                DataDaVacina = registroVacinacao.DataDaVacina,
                IdAnimal = registroVacinacao.IdAnimal,
                IdVacina = registroVacinacao.IdVacina
            };
        }
    }
}
