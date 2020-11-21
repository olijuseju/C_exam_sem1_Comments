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
        public List<Motorbike> motorbikes { get; set; }
    }

    
    class MotorbikeGreat
    {

        private int id;
        private string name;
        private string manufacturer;
        private string description;
        private double price;
        private int stock;

        public MotorbikeGreat(int id,string manufacturer, string description, int stock, double price, string name)
        {
            this.id = id;
            this.name = name;
            this.manufacturer = manufacturer;
            this.description = description;
            this.price = price;
            this.stock = stock;
        }

        public int ID
        {
            get { return this.id; }
        }


        public string Name
        {
            get { return this.name; }
            set
            {
                value = (string)misc.normalize(value);
                this.name = value;
            }
        }
        public double Price
        {
            get { return this.price; }
            set
            {
                value =(double) misc.adjust(value);
                this.price = value;
            }
        }

        public string Manufacturer
        {
            get { return this.manufacturer; }
            set
            {
                value = (string)misc.normalize(value);
                this.manufacturer = value;
            }
        }

        public int Stock
        {
            get { return this.stock; }
            set
            {
                value = (int)misc.noNegative(value);
                this.stock = value;
            }
        }

        public string Description
        {
            get { return this.description; }
            set
            {
                this.description = value;
            }
        }
    }


}
