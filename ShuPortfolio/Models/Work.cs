using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShuPortfolio.Models
{
    public class Work
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime DataCreated { get; set; }
        public string Description { get; set; }
        public  string Image { get; set; }
        public int CategoryID { get; set; }
    }
}
