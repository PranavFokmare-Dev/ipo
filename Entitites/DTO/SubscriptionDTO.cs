using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitites.DTO
{
    public class SubscriptionDTO
    {
        public Guid Id { get; set; }

        [Range(0, float.MaxValue, ErrorMessage = "The Subscription amount must be positive")]
        public float QualifiedInstitutional { get; set; }
        [Range(0, float.MaxValue, ErrorMessage = "The Subscription amount must be positive")]
        public float NonInstitutional { get; set; }
        [Range(0, float.MaxValue, ErrorMessage = "The Subscription amount must be positive")]
        public float RetailIndividual { get; set; }
        [Range(0, float.MaxValue, ErrorMessage = "The Subscription amount must be positive")]
        public float Employee { get; set; }
        [Range(0, float.MaxValue, ErrorMessage = "The Subscription amount must be positive")]
        public float Others { get; set; }
        [Range(0, float.MaxValue, ErrorMessage = "The Subscription amount must be positive")]
        public float Total { get; set; }
    }
}
