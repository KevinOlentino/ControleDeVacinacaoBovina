using System.ComponentModel.DataAnnotations;

namespace ControleDeVacinacaoBovina.Models.Dtos
{
    public class EnderecoDto
    {
        public int? IdEndereco { get; set; }

        [Required(ErrorMessage = "Rua não pode ser nula")]
        [MaxLength(150, ErrorMessage = "Rua não pode ter mais de 150 caracteres")]
        [MinLength(3, ErrorMessage = "Rua não pode ter menos de 3 caracteres")]
        public string Rua { get; set; }

        [Required(ErrorMessage = "Numero não pode ser nulo")]
        [MaxLength(20, ErrorMessage = "Numero não pode ter mais de 20 caracteres")]
        [MinLength(1, ErrorMessage = "Numero não pode ter menos de 1 caracteres")]
        public string Numero { get; set; }

        [Required(ErrorMessage = "Municipio não pode ser nulo")]
        [Range(1, int.MaxValue, ErrorMessage = "Municipio não pode ser menor que 1")]
        public int IdMunicipio { get; set; }

        public Endereco DtoToEndereco(EnderecoDto endereco)
        {
            return new Endereco
            {
                IdEndereco = endereco.IdEndereco,
                Rua = endereco.Rua,
                Numero = endereco.Numero,
                IdMunicipio = endereco.IdMunicipio
            };
        }
    }
}
