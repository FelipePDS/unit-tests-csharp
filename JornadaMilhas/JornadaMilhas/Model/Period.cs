using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JornadaMilhas.Model
{
    public class Period : Validator
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public Period(DateTime startDate, DateTime endDate)
        {
            StartDate = startDate;
            EndDate = endDate;
            Validate();
        }

        protected override void Validate()
        {
            if (StartDate == DateTime.MinValue)
            {
                Errors.RegisterError("Erro: Data de ida não pode estar vazia.");
            }

            if (EndDate == DateTime.MinValue)
            {
                Errors.RegisterError("Erro: Data de volta não pode estar vazia.");
            }

            if (StartDate > EndDate)
            {
                Errors.RegisterError("Erro: Data de ida não pode ser maior que a data de volta.");
            }
        }
    }
}
