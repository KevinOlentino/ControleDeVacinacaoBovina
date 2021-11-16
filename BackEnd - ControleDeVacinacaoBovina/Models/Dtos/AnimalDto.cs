﻿using System.ComponentModel.DataAnnotations;

namespace ControleDeVacinacaoBovina.Models.Dtos
{
    public class AnimalDto
    {
        public int IdAnimal { get; set; }
        [Required(ErrorMessage = "Quantidade Total não pode ser nulo")]
        [Range(1, int.MaxValue, ErrorMessage = ("Quantidade Total não pode ser menor que 1"))]
        public int QuantidadeTotal { get; set; }
        [Required(ErrorMessage = "Quantidade Vacinada não pode ser nulo")]
        public int QuantidadeVacinada { get; set; }
        [Required(ErrorMessage = "Id Especie não pode ser nula")]
        [Range(1, int.MaxValue, ErrorMessage = ("Íd Especie não pode ser menor que 1"))]
        public int IdEspecie { private get; set; }
        [Required(ErrorMessage = "Id Propriedade não pode ser nula")]
        [Range(1, int.MaxValue, ErrorMessage = ("Íd Propriedade não pode ser menor que 1"))]
        public int IdPropriedade { private get; set; }

        public Animal DtoToAnimal(AnimalDto animal)
        {
            return new Animal
            {
                IdAnimal = animal.IdAnimal,
                QuantidadeTotal = animal.QuantidadeTotal,
                QuantidadeVacinada = animal.QuantidadeVacinada,
                IdEspecie = animal.IdEspecie,
                IdPropriedade = animal.IdPropriedade
            };
        }

    }
}
