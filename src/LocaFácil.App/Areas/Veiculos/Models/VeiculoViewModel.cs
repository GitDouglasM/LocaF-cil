using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using LocaFácil.App.Areas.Clientes.Models;
using Microsoft.AspNetCore.Http;

namespace LocaFácil.App.Areas.Veiculos.Models
{
    public class VeiculoViewModel
    {
        public int Id { get; set; }

        //[Required(ErrorMessage = "O campo {0} é obrigatório")]
        //[DisplayName("Cliente")]
        //public int ClienteId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Nome { get; set; }

        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Cor { get; set; }

        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Marca { get; set; }

        [StringLength(4, ErrorMessage = "O campo {0} precisa ter {1} caracteres", MinimumLength = 4)]
        [DisplayName("Ano de Fabricação")]
        public string AnoFabricacao { get; set; }

        //[StringLength(4, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        [DisplayName("Número de Portas")]
        public int NumPortas { get; set; }

        [StringLength(50, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        [DisplayName("Tipo de Combustível")]
        public string TipoCombustivel { get; set; }

        [DisplayName("Ar-condicionado")]
        public bool ArCondicionado { get; set; }

        [DisplayName("Direção")]
        public bool Direcao { get; set; }

        [DisplayName("Freio ABS")]
        public bool FreioAbs { get; set; }
        public bool Trava { get; set; }
        public bool Airbag { get; set; }

        [DisplayName("Quantidade de Lugares")]
        public int QtdLugar { get; set; }

        [DisplayName("Vidro Elétrico")]
        public bool Vidro { get; set; }

        [DisplayName("Farol de Neblina")]
        public bool FarolNeblina { get; set; }

        [DisplayName("Descrição")]
        public string Descricao { get; set; }

        //[Moeda]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public decimal Valor { get; set; }

        [DisplayName("Situação")]
        public bool Situacao { get; set; } //"D"isponivel / "I"ndispovivel

        [DisplayName("Imagem do Produto")]
        public IFormFile ImagemUpload { get; set; }

        public string Imagem { get; set; }



        public IEnumerable<VeiculoViewModel> Veiculos { get; set; }
    }
}
