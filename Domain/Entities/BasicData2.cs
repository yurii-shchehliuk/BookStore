using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class BasicData2
    {
        public int BasicData2Id { get; set; }
        public string Country{ get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string DeliveryPoint { get; set; }
        public Nullable<int> BasicData1Id { get; set; }
        public virtual BasicData1 BasicData1 { get; set; }
    }
}
