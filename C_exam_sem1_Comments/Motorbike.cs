using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_exam_sem1_Comments
{
    
    public class Motorbike// Pojo Class
        //This class is for a single object
    {

        public int id { get; set; }
        public string name { get; set; }
        public string manufacturer { get; set; }
        public string description { get; set; }
        public double price { get; set; }
        public int stock { get; set; }
    }

    public class Motorbikes
    //Data from Json is stored in the atributes

    {
        public bool premium { get; set; }//A variable to check and create premium users
        public List<Motorbike> motorbikes { get; set; }//This is the array with the Motorbike objects

    }

   


}
