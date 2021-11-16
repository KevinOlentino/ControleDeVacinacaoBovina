using System.ComponentModel.DataAnnotations;

namespace ControleDeVacinacaoBovina.Models.Dtos
{
    public class ProdutorDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome não pode ser nulo")]
        [MaxLength(50, ErrorMessage ="Nome pode ser até 50 caracteres")]
        public string Nome { get; set; }
        [Required(ErrorMessage ="CPF não pode ser nulo")]
        [StringLength(11, ErrorMessage = "O CPF não pode ser maior ou menor que 11 caracteres")]
        public string CPF { get; set; }
        [Required(ErrorMessage = "Endereco não pode ser nulo!")]
        public EnderecoDto Endereco { get; set; }

        public Produtor DtoToProdutor(ProdutorDto produtor)
        {
            return new Produtor
            {
                IdProdutor = produtor.Id,
                Nome = produtor.Nome,
                CPF = produtor.CPF,
                Endereco = produtor.Endereco.DtoToEndereco(produtor.Endereco)
            };
        }
    }
}
