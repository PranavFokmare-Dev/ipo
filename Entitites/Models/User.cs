using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Entitites.Models
{
    public class User:IEntity
    {
        [Key]
        [Column("UserId")]
        public override Guid Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [MaxLength(50)]
        [RegularExpression(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", ErrorMessage = "Invalid Email Id")]
        public string EmailId { get; set; }

        public Guid? FilterSubscriptionId { get; set; }
        public virtual FilterSubscription FilterSubscription { get; set; }
        
    }
}
