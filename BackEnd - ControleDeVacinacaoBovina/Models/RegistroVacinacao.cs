using System;

namespace ControleDeVacinacaoBovina.Models
{
    public class RegistroVacinacao
    {
        public int IdRegistroVacinacao { get; set; }
        public int Quantidade { get; set; }
        public DateTime DataDaVacina { get; set; }
        public int IdRebanho { get; set; }
        public int IdVacina { get; set; }
        public Rebanho Rebanho { get; set; }
        public Vacina Vacina { get; set; }
        public DateTime DataDeCadastro { get; set; } = DateTime.Now;
        public bool Ativo { get; private set; } = true;
        public void SetAtivo(bool ativo)
        {
            Ativo = ativo;
        }
    }
}
