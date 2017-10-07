using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Intellectus_mvc.Models
{
    public class Company : BaseModel
    {
        public int AdminId { get; set; }
        public string ComapanyName { get; set; }
        public string ComapanyPassword { get; set; }
        public string Address { get; set; }
        public int Industry { get; set; } // code of The industry in which the company operates.
    }
}