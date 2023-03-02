using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McTours.Business
{
    internal class ValidationResult
    {
        private List<string> _errors = new List<string>();

        public bool HasErrors => _errors.Any(); // Error'da herhangi bir kayıt yoksa geçerlidir demek.
        public IEnumerable<string> Errors => _errors;
        //{
        //    get
        //    {
        //        return _errors;
        //    }
        //}

        public string ErrorString
        {
            get
            {
                return string.Join(Environment.NewLine, Errors); // Error stringlerini alt alta birleştirir. 
            }
        }

        public void AddError(string error)
        {
            _errors.Add(error);
        }
    }
}
