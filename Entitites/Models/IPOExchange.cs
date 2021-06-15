using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Entitites.Models
{
    public class IPOExchange:IEntity
    {
        public override Guid Id { get; set; }
        public Guid IPOId { get; set; }
        public Guid ExchangeId { get; set; }
        public IPO IPO { get; set; }
        public Exchange Exchange { get; set; }
    }
}
