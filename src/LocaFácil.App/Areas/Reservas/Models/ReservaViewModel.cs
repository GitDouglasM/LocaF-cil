using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using LocaFácil.App.Areas.Clientes.Models;
using LocaFácil.App.Areas.Veiculos.Models;

namespace LocaFácil.App.Areas.Reservas.Models
{
    public class ReservaViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Data inicial / Hora")]
        public DateTime DataInicio { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Data final / Hora")]
        public DateTime DataFinal { get; set; }

        public bool Dinheiro { get; set; }

        [DisplayName("Cartão")]
        public bool Cartao { get; set; }

        [DisplayName("Deixe uma sujestão")]
        public string Comentario { get; set; }

        public bool Seguro { get; set; }

        public ClienteViewModel Cliente { get; set; }
        public IEnumerable<ClienteViewModel> Clientes { get; set; }
    }
}
