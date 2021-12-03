using System;

namespace DataEntities
{
    public class Activity
    {
        public int activity_id { get; set; }
        public int property_id { get; set; }
        public DateTime schedule { get; set; }
        public string title { get; set; }
        public DateTime created_at { get; set; }
        public DateTime update_at { get; set; }
        public string status { get; set; }
    }
}
