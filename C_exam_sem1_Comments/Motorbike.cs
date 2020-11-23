using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_exam_sem1_Comments
{
    
    public class Motorbike
    {
        public int id { get; set; }
        public string name { get; set; }
        public string manufacturer { get; set; }
        public string description { get; set; }
        public double price { get; set; }
        public int stock { get; set; }
    }

    public class Motorbikes
    {
        public bool premium { get; set; }
        public List<Motorbike> motorbikes { get; set; }

    }

   


}
