using System;
using System.Collections.Generic;

namespace LocFácil.Business.Models
{
    public class Reserva
    {
        public int Id { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFinal { get; set; }
        public bool Dinheiro { get; set; }
        public bool Cartao { get; set; }
        public string Comentario { get; set; }
        public bool Seguro { get; set; }

        public Cliente Cliente { get; set; }
        public Veiculo Veiculo { get; set; }
    }
}
