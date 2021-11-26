using System;
using System.ComponentModel.DataAnnotations;

namespace ControleDeVacinacaoBovina.Models.Dtos
{
    public class VendaDto
    {
        public int IdVenda { get; set; }
        [Required(ErrorMessage = ("Quantidade não pode ser nula"))]
        [Range(1, int.MaxValue, ErrorMessage = "Quantidade não pode ser menor que 1")]
        public int Quantidade { get; set; }

        [Required(ErrorMessage = "Propriedade de Origem não pode ser nula")]
        [Range(1, int.MaxValue, ErrorMessage = "Propriedade de Origem não pode ser 0")]
        public int IdOrigem { get; set; }

        [Required(ErrorMessage = "Propriedade de Destino não pode ser nula")]
        [Range(1, int.MaxValue, ErrorMessage = "Propriedade de Destino não pode ser 0")]
        public int IdDestino { get; set; }

        [Required(ErrorMessage = "Especie não pode ser nula")]
        [Range(1, int.MaxValue, ErrorMessage = "Especie não pode ser 0")]
        public int IdRebanho { get; set; }

        [Required(ErrorMessage = "Finalidade de venda não pode ser nula")]
        [Range(1, int.MaxValue, ErrorMessage = "Finalidade de Venda não pode ser 0")]
        public int IdFinalidadeDeVenda { get; set; }
        public DateTime DataDeVenda { get; private set; } = DateTime.Now;

        public Venda DtoToVenda(VendaDto finalidadeDeVenda)
        {
            return new Venda
            {
                IdVenda = finalidadeDeVenda.IdVenda,
                Quantidade = finalidadeDeVenda.Quantidade,
                IdOrigem = finalidadeDeVenda.IdOrigem,
                IdDestino = finalidadeDeVenda.IdDestino,
                IdRebanho = finalidadeDeVenda.IdRebanho,
                IdFinalidadeDeVenda = finalidadeDeVenda.IdFinalidadeDeVenda,
                DataDeVenda = finalidadeDeVenda.DataDeVenda
            };
        }
    }
}
