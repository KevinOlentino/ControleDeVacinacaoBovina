using System;
using System.ComponentModel.DataAnnotations;

namespace ControleDeVacinacaoBovina.Models.Dtos
{
    public class PropriedadeDto
    {

        public int IdPropriedade { get; set; }
        [Required(ErrorMessage = ("O nome não pode ser nulo"))]
        public string Nome { get; set; }
        [Required(ErrorMessage = ("O produtor não pode ser nulo"))]
        public int IdProdutor { get; set; }
        [Required(ErrorMessage = ("O Endereco não pode ser nulo"))]
        public EnderecoDto Endereco { get; set; }
        private string InscricaoEstadual { get; set; }

        public Propriedade DtoToPropriedade(PropriedadeDto propriedade)
        {
            return new Propriedade
            {
                IdPropriedade = propriedade.IdPropriedade,
                InscricaoEstadual = propriedade.InscricaoEstadual,
                Nome = propriedade.Nome,
                IdProdutor = propriedade.IdProdutor,
                Endereco = propriedade.Endereco.DtoToEndereco(propriedade.Endereco)
            };
        }

        public void SetInscricaoEstadual()
        {
            Random rng = new();
            InscricaoEstadual = rng.Next(285000000, 999999999).ToString();
        }

        public void LockInscricaoEstadual(string inscricaoEstadual)
        {
            this.InscricaoEstadual = inscricaoEstadual;
        }
    }
}
