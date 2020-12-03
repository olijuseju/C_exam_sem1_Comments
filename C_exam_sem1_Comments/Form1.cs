using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Header;

namespace C_exam_sem1_Comments
{
    public partial class Form1 : Form
    {
        public Motorbikes motorbikes;//Object with the list of motorbikes
        public Form1()
        {
            InitializeComponent();
            update();//Read the data from JSON
            if (motorbikes.premium == true)//We check if the user is premium or not
            {
                button5.Enabled = false;
                button5.Text = "You are a premium client";
            }
        }

        public void update()
        {

            listBox1.Items.Clear();//Delete objects in listbox
            using (StreamReader sr = File.OpenText("data/Motorbikes.json"))//Read JSON and stores data is sr
            {
                string json = sr.ReadToEnd(); //The data is the JSON is converted in a string
                motorbikes = JsonConvert.DeserializeObject<Motorbikes>(json);//We convert the string into a MMOTORBIKES object
                foreach (Motorbike bike in motorbikes.motorbikes)//We add the motorbikes on the array into the listbox
                    //El array y el objeto motorbikes se llaman igual, sorry
                {
                    listBox1.Items.Add(bike.name);//In the listbox we add the names of each motorbike
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }


        private void exportToToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Export form2 = new Export();//Go to export form
            form2.Show();
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void aboutUsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Logo logo = new Logo();//Go to logo form
            logo.Show();
        }

        private void button2_Click(object sender, EventArgs e)//Button Añañin
        {
            string input = textBox3.Text;//The data from the textbox is stored here for the name
            try
            {
                Motorbike motorbike = new Motorbike();//We create a new empty motorbike object
                motorbike.id = this.motorbikes.motorbikes.Count;//The id of this motorbike is the leght of the motorbikes array
                motorbike.name = (string)misc.normalize(input);//Normalize the name
                motorbike.manufacturer = (string)misc.normalize(textBox4.Text);//The data from the textbox is stored here for the manufacturer and is normalized
                motorbike.description = textBox7.Text;//The data from the textbox is stored here for the descruption
                try// If there is no a decimal number the error will show
                {
                    double price = Double.Parse(textBox5.Text);
                    motorbike.price = (double)misc.adjust(price);//The data from the textbox is stored here for the price and is adjusted tu 2 decimals
                }
                catch (Exception nfe)
                {
                    MessageBox.Show("The price shoul be a decimal number");
                    textBox3.Text = "";
                    textBox4.Text = "";//The error will clean the textboxes
                    textBox5.Text = "";
                    textBox6.Text = "";
                    textBox7.Text = "";
                    return;
                }
                try
                {
                    int quantity = int.Parse(textBox6.Text);//The data from the textbox is stored here for the quantity
                    motorbike.stock = (int)misc.noNegative(quantity);//If the stock is negative it will be 0
                    motorbikes.motorbikes.Add(motorbike);//We add this object in the array in motorbikes
                    string jsonData = JsonConvert.SerializeObject(motorbikes);//We convert this list motorbikes in JSON
                    File.WriteAllText("data/Motorbikes.json", jsonData);//We add the data from the object in JSON motorbikes to the Json
                    listBox1.Items.Add(motorbike.name);//We add the new motorbike in the listbox
                    textBox3.Text = "";
                    textBox4.Text = "";//clean
                    textBox5.Text = "";
                    textBox6.Text = "";
                    textBox7.Text = "";
                }
                catch (Exception nfe)
                {
                    MessageBox.Show("insert a valid quantity");
                    textBox3.Text = "";
                    textBox4.Text = "";//The error from the stock
                    textBox5.Text = "";
                    textBox6.Text = "";
                    textBox7.Text = "";
                    return;
                }
            }    
            catch(Exception ex)
            {
                MessageBox.Show("Please read the HELP message");//general error
            }
            
            
        }

        private void button1_Click_1(object sender, EventArgs e)//H E L P
        {
            MessageBox.Show("Enter the following data" + Environment.NewLine + Environment.NewLine +
                "name" + Environment.NewLine +
                "manufacturer" + Environment.NewLine +
                "price" + Environment.NewLine +
                "description" + Environment.NewLine +
                "quantity on stock" + Environment.NewLine
                );//Help message
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)//Show the data from each motorbike in the textbox
        {
            try{//If we select an expty item the program will not crash
                int pos = listBox1.SelectedIndex;//We save the index in an Integer
                Motorbike mb = motorbikes.motorbikes[pos];//We search the motorbike by the position
                textBox1.Text = "";
                textBox1.Text += "Name: " + mb.name + Environment.NewLine;
                textBox1.Text += "Manufacturer: " + mb.manufacturer + Environment.NewLine;
                textBox1.Text += "Comment: " + mb.description + Environment.NewLine;
                textBox1.Text += "Price: " + mb.price.ToString() + "$" + Environment.NewLine;
                textBox1.Text += "Stock: " + mb.stock.ToString() + Environment.NewLine;
            }catch(Exception ex)
            {

            }
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if(motorbikes.premium == false)//   WE CHECK IF THE USER IS PREMIUM
            {
                foreach(Motorbike motorbike in motorbikes.motorbikes)
                {
                    double price = motorbike.price * 0.75;// WE DISCOUNT ALL PRICES
                    motorbike.price = (double)misc.adjust(price);// WE ADJUST THE PRICES TO 2 DECIMALS
                }
                motorbikes.premium = true;
                try
                {//ACTUALIZE THE TEXTBOX IN REAL TIME 
                    int pos = listBox1.SelectedIndex;
                    Motorbike mb = motorbikes.motorbikes[pos];
                    textBox1.Text = "";
                    textBox1.Text += "Name: " + mb.name + Environment.NewLine;
                    textBox1.Text += "Manufacturer: " + mb.manufacturer + Environment.NewLine;
                    textBox1.Text += "Comment: " + mb.description + Environment.NewLine;
                    textBox1.Text += "Price: " + mb.price.ToString() + "$" + Environment.NewLine;
                    textBox1.Text += "Stock: " + mb.stock.ToString() + Environment.NewLine;
                    button5.Enabled = false;
                    button5.Text = "You are a premium client";
                    string jsonData = JsonConvert.SerializeObject(motorbikes);
                    File.WriteAllText("data/Motorbikes.json", jsonData);
                    
                }
                catch (Exception nfe){// PER SI DE CAS COSÍ
                    button5.Enabled = false;
                    button5.Text = "You are a premium client";
                }
                MessageBox.Show("You have a discount of 25%");//MESSAGE OF CONFIRMATION

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                motorbikes.motorbikes.RemoveAt(listBox1.SelectedIndex);// WE REMOVE THE ITEM IN THE POSITION OF THE LISTBOX
                for (int i = 0; i < motorbikes.motorbikes.Count; i++)
                {
                    motorbikes.motorbikes[i].id = i;// ORDER AGAIN THE IDS OF THE MOTORBIKES
                }
                string jsonData = JsonConvert.SerializeObject(motorbikes);
                File.WriteAllText("data/Motorbikes.json", jsonData);// WRITE AGAIN THE JSON
                textBox1.Text = "";
                listBox1.Items.Clear();//AND CLEAN THE LISTBOX
                foreach (Motorbike bike in motorbikes.motorbikes)
                {
                    listBox1.Items.Add(bike.name);//WRITE AGAIN THE LISTBOX WITHOUT THE REMOVED OBJECT
                }
                MessageBox.Show("Product removed succesfully");//CONFIRMATION
            }
            catch(Exception ex)
            {
                MessageBox.Show("Please select an item");//SAQUESE ALV
            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                modifyMotorbike modifyMotorbike = new modifyMotorbike();//CREATE THE FORM
                modifyMotorbike.id = motorbikes.motorbikes[listBox1.SelectedIndex].id;//THE ID IS THE POSITION
                modifyMotorbike.textBox2.Text = motorbikes.motorbikes[listBox1.SelectedIndex].name;//WE PASS THE ATRIBUTES IN THE TEXTBOXES TO THE EXPORT FORM
                modifyMotorbike.textBox4.Text = motorbikes.motorbikes[listBox1.SelectedIndex].manufacturer;
                modifyMotorbike.textBox3.Text = motorbikes.motorbikes[listBox1.SelectedIndex].price.ToString();
                modifyMotorbike.textBox6.Text = motorbikes.motorbikes[listBox1.SelectedIndex].stock.ToString();
                modifyMotorbike.textBox5.Text = motorbikes.motorbikes[listBox1.SelectedIndex].description;
                modifyMotorbike.Show();//SHOW THE FORM
                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Please select an item");//MI LOCO SELECCIONE UN ITEM
            }
            
        }
    }
}
