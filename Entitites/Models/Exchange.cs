using ipo.Models.Validation;
using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Entitites.Models
{
    public class Exchange: IEntity
    {
        [Key]
        [Column("ExchangeId")]
        public override Guid Id { get; set; }
        [MaxLength(10)]
        [CheckValidator("BSE","NSE",ErrorMessage ="Exchange must be of type BSE or NSE")]
        public string ExchangeName { get; set; }

        public virtual ICollection<IPOExchange> IPOExchanges { get; set; }
        
    }
}
