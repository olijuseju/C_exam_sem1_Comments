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
        public Motorbikes motorbikes;
        public Form1()
        {
            InitializeComponent();
            using (StreamReader sr = File.OpenText("data/Motorbikes.json"))
            {
                string json = sr.ReadToEnd();
                motorbikes = JsonConvert.DeserializeObject<Motorbikes>(json);
                foreach(Motorbike bike in motorbikes.motorbikes)
                {
                    listBox1.Items.Add(bike.name);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }


        private void exportToToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Export form2 = new Export();
            form2.Show();
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void aboutUsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Logo logo = new Logo();
            logo.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string input = textBox2.Text;
            string[] result = input.Split("\n\r".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            Motorbike motorbike = new Motorbike();
            motorbike.id = this.motorbikes.motorbikes.Count;
            motorbike.name = (string)misc.normalize(result[0]);
            motorbike.manufacturer = (string)misc.normalize(result[1]);
            motorbike.description = result[2];
            try
            {
                double price = Double.Parse(result[3]);
                motorbike.price = (double)misc.adjust(price);
            }
            catch (Exception nfe)
            {
                MessageBox.Show(nfe.Message);
                textBox2.Text = "";
                return;
            }

            try
            {
                int quantity = int.Parse(result[4]);
                motorbike.stock = (int)misc.noNegative(quantity);
                motorbikes.motorbikes.Add(motorbike);
                string jsonData = JsonConvert.SerializeObject(motorbikes);
                File.WriteAllText("data/Motorbikes.json", jsonData);
                listBox1.Items.Add(motorbike.name);
                textBox2.Text = "";
            }
            catch (Exception nfe)
            {
                MessageBox.Show(nfe.Message);
                textBox2.Text = "";
                return;
            }
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Enter the following data" + Environment.NewLine + Environment.NewLine +
                "name" + Environment.NewLine +
                "manufacturer" + Environment.NewLine +
                "price" + Environment.NewLine +
                "description" + Environment.NewLine +
                "quantity on stock" + Environment.NewLine
                );
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int pos = listBox1.SelectedIndex;
            Motorbike mb = motorbikes.motorbikes[pos];
            textBox1.Text = "";
            textBox1.Text += "Name: " + mb.name + Environment.NewLine;
            textBox1.Text += "Manufacturer: " + mb.manufacturer + Environment.NewLine;
            textBox1.Text += "Comment: " + mb.description + Environment.NewLine;
            textBox1.Text += "Price: " + mb.price.ToString() + "$" + Environment.NewLine;
            textBox1.Text += "Price: " + mb.stock.ToString() + Environment.NewLine;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if(motorbikes.premium == false)
            {
                foreach(Motorbike motorbike in motorbikes.motorbikes)
                {
                    double price = motorbike.price * 0.75;
                    motorbike.price = (double)misc.adjust(price);
                }
                motorbikes.premium = true;
                try
                {
                    int pos = listBox1.SelectedIndex;
                    Motorbike mb = motorbikes.motorbikes[pos];
                    textBox1.Text = "";
                    textBox1.Text += "Name: " + mb.name + Environment.NewLine;
                    textBox1.Text += "Manufacturer: " + mb.manufacturer + Environment.NewLine;
                    textBox1.Text += "Comment: " + mb.description + Environment.NewLine;
                    textBox1.Text += "Price: " + mb.price.ToString() + "$" + Environment.NewLine;
                    textBox1.Text += "Price: " + mb.stock.ToString() + Environment.NewLine;
                    button5.Enabled = false;
                    button5.Text = "You are a premium client";
                }
                catch (Exception nfe){
                    button5.Enabled = false;
                    button5.Text = "You are a premium client";
                }
                
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                motorbikes.motorbikes.RemoveAt(listBox1.SelectedIndex);
                for (int i = 0; i < motorbikes.motorbikes.Count; i++)
                {
                    motorbikes.motorbikes[i].id = i;
                }
                string jsonData = JsonConvert.SerializeObject(motorbikes);
                File.WriteAllText("data/Motorbikes.json", jsonData);
                textBox1.Text = "";
                listBox1.Items.Clear();
                foreach (Motorbike bike in motorbikes.motorbikes)
                {
                    listBox1.Items.Add(bike.name);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
