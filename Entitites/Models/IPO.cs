using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Entitites.Models
{
    public class IPO:IEntity
    {
        [Key]
        [Column("IPOId")]
        public override Guid Id { get; set;}
        
        [MaxLength(100)]
        public string Name { get; set; }
        public DateTime? Open { get; set; }
        public DateTime? Close { get; set; }
        public int? LotSize { get; set; }
        public decimal? IssuePriceRs { get; set; }
        public decimal? IssueSizeRsCr { get; set; }

        public Guid? SubscriptionId { get; set; }

        public virtual Subscription Subscription { get; set; }
        public virtual ICollection<IPOExchange> IPOExchanges { get; set; }
    }
}
