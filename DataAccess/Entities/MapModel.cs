using System;

namespace DataAccess.Entities
{
    public class MapModel
    {
        public int id { get; set; }
        public int start_x { get; set; }
        public int start_y { get; set; }
        public int end_x { get; set; }
        public int end_y { get; set; }
        public DateTime time { get; set; }
    }
}