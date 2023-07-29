using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Family : Common
    { 
        public string? name { get; set; }
        public string? email { get; set; }
        public string? phone { get; set; }
        public string? address { get; set; }
        public decimal money { get; set; }
        public string? members { get; set; }


        public Family()
        {
            this.money = 0;
        }
    }
}
