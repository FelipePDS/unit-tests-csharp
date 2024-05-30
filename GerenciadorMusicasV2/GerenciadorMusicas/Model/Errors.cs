using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JornadaMilhas.Model
{
    public class Errors : IEnumerable<Error>
    {
        private readonly ICollection<Error> errors = new List<Error>();

        public void RegisterError(string message) => errors.Add(new Error(message));

        public IEnumerator<Error> GetEnumerator()
        {
            return errors.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return errors.GetEnumerator();
        }

        public string Summary
        {
            get
            {
                var sb = new StringBuilder();
                foreach (var item in errors)
                {
                    sb.Append(item.ToString());
                }

                return sb.ToString();
            }
        }
    }
}
