using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Entitites.Models
{
    public class FilterSubscription: IEntity
    {
        [Key]
        [Column("FilterSubscriptionId")]
        public override Guid Id { get; set; }

        [Range(0,float.MaxValue,ErrorMessage ="The Subscription amount must be positive")]
        public float MinQualifiedInstitutional { get; set; }

        [Range(0, float.MaxValue, ErrorMessage = "The Subscription amount must be positive")]
        public float MinNonInstitutional { get; set; }

        [Range(0, float.MaxValue, ErrorMessage = "The Subscription amount must be positive")]
        public float MinRetailIndividual { get; set; }

        [Range(0, float.MaxValue, ErrorMessage = "The Subscription amount must be positive")]
        public float MinEmployee { get; set; }

        [Range(0, float.MaxValue, ErrorMessage = "The Subscription amount must be positive")]
        public float MinOthers { get; set; }

        [Range(0, float.MaxValue, ErrorMessage = "The Subscription amount must be positive")]
        public float MinTotal { get; set; }

        [NotMapped]
        public Guid UserId { get; set; }
        public virtual User User { get; set; }
    }
}
