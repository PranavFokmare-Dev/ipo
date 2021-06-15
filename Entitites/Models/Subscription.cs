using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Entitites.Models
{
    public class Subscription:IEntity
    {
        [Key]
        [Column("SubscriptionId")]
        public override Guid Id { get; set; }

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

        [NotMapped]
        public Guid IPOId { get; set; }
        public virtual IPO IPO { get; set; }
    }
}
