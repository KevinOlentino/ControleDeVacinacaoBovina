using System;
using System.ComponentModel.DataAnnotations;

namespace ControleDeVacinacaoBovina.Models.Dtos
{
    public class PropriedadeDto
    {
        public int IdPropriedade { get; set; }  
        [Required(ErrorMessage =("O nome não pode ser nulo"))]
        public string Nome { get; set; }
        [Required(ErrorMessage =("O produtor não pode ser nulo"))]
        public int IdProdutor { get; set; }
        [Required(ErrorMessage =("O Endereco não pode ser nulo"))]
        public EnderecoDto Endereco { get; set; }
        
        public Propriedade DtoToPropriedade(PropriedadeDto propriedade)
        {
            Random rng = new();

            return new Propriedade
            {
                IdPropriedade = propriedade.IdPropriedade,
                InscricaoEstadual = rng.Next(285000000, 999999999).ToString(),
                Nome = propriedade.Nome,
                IdProdutor = propriedade.IdProdutor,
                Endereco = propriedade.Endereco.DtoToEndereco(propriedade.Endereco)
            };
        }
    }
}
