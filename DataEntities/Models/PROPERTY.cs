using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEntities.Models
{
    public class PROPERTY
    {
        public int id_PROPERTY { get; set; }
        public string TITLE { get; set; }
        public string ADDRESS { get; set; }
        public string DESCRIPTION { get; set; }
        public DateTime CREATED_AT { get; set; }
        public DateTime UPDATE_AT { get; set; }
        public DateTime DISABLED_AT { get; set; }
        public string STATUS { get; set; }
    }
}
