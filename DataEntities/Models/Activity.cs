using System;

namespace DataEntities
{
    public class Activity
    {
        public int id_activity { get; set; }
        public int id_property { get; set; }
        public DateTime schedule { get; set; }
        public string title { get; set; }
        public DateTime created_at { get; set; }
        public DateTime update_at { get; set; }
        public string status { get; set; }
        public virtual  string  Condition { get; set; }
         public virtual  string titleProp { get; set; }
        public virtual  string address { get; set; }

    }
}
