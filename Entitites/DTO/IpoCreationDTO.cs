using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitites.DTO
{
    public class IpoCreationDTO
    {
        public DateTime? Open { get; set; }
        public DateTime? Close { get; set; }
        public int? LotSize { get; set; }
        public decimal? IssuePriceRs { get; set; }
        public decimal? IssueSizeRsCr { get; set; }

        public Guid SubscriptionId { get; set; }

        public virtual SubscriptionDTO Subscription { get; set; }
    }
}
