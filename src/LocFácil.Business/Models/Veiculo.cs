using System;
using System.Collections.Generic;

namespace LocFácil.Business.Models
{
    public class Veiculo
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cor { get; set; }
        public string Marca { get; set; }
        public string AnoFabricacao { get; set; }
        public int NumPortas { get; set; }
        public string TipoCombustivel { get; set; }
        public bool ArCondicionado { get; set; }
        public bool Direcao { get; set; }
        public bool FreioAbs { get; set; }
        public bool Trava { get; set; }
        public bool Airbag { get; set; }
        public int QtdLugar { get; set; }
        public bool Vidro { get; set; }
        public bool FarolNeblina { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public bool Situacao { get; set; } //"D"isponivel / "I"ndispovivel
        public string Imagem { get; set; }

        public IEnumerable<Reserva> Reservas { get; set; }
    }
}
