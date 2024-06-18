using JornadaMilhas.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JornadaMilhas.Model
{
    public abstract class Validator : IValidator
    {
        private readonly Errors errors = new();
        public bool IsValid => errors.Count() == 0;
        public Errors Errors => errors;
        protected abstract void Validate();
    }
}
