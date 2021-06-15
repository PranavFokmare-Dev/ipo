using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ipo.Models.Validation
{
    public class CheckValidator : ValidationAttribute
    {
        public List<object> ValidValues { get; set; }
        public CheckValidator(params object[] ValidValues)
        {
            this.ValidValues = new List<object>();
            this.ValidValues.AddRange(ValidValues);
        }
        public override bool IsValid(object value)
        {
            if (value == null || ValidValues.Count == 0)
            {
                return true;
            }
            return IsAllowed(value);
        }
        private bool IsAllowed(object input)
        {
            foreach(object validValue in ValidValues)
            {
                if(validValue.Equals(input))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
