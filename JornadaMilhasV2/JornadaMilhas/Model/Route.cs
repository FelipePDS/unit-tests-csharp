using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JornadaMilhas.Model
{
    public class Route : Validator
    {
        public int Id { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }

        public Route(string origin, string destination)
        {
            Origin = origin;
            Destination = destination;
            Validate();
        }

        protected override void Validate()
        {
            if (string.IsNullOrEmpty(this.Origin))
            {
                Errors.RegisterError("A rota não pode possuir uma origem nula ou vazia.");
            }

            if (string.IsNullOrEmpty(this.Destination))
            {
                Errors.RegisterError("A rota não pode possuir um destino nulo ou vazio.");
            }
        }
    }
}
