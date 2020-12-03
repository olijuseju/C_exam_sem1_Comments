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

namespace C_exam_sem1_Comments
{
    public partial class modifyMotorbike : Form
    {
        public Motorbikes motorbikes;
        public int id;//THIS STORES THE ID FROM FORM1
        public modifyMotorbike()
        {
            InitializeComponent();
            using (StreamReader sr = File.OpenText("data/Motorbikes.json"))
            {
                string json = sr.ReadToEnd();
                motorbikes = JsonConvert.DeserializeObject<Motorbikes>(json);//READ THE DATA FROM THE JSON AND SAVE IT IN THE motorbikes OBJECT
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            try
            {
                Motorbike motorbike = motorbikes.motorbikes[id];//SEARCH THE MOTORBIKE BY THE ID
                motorbike.name = (string)misc.normalize(textBox2.Text);
                motorbike.manufacturer = (string)misc.normalize(textBox4.Text);
                motorbike.description = textBox5.Text;
                double price = Convert.ToDouble(textBox3.Text);// WE REWRITE THIS MOTORBIKE WITH THE DATA FROM THE TEXTBOXES
                motorbike.price = (double)misc.adjust(price);
                int stock = Convert.ToInt32(textBox6.Text);
                motorbike.stock = (int)misc.noNegative(stock);
                string jsonData = JsonConvert.SerializeObject(motorbikes);
                File.WriteAllText("data/Motorbikes.json", jsonData);//REWRITE THE JSON
                form.update();//WE CALL THE UPDATE FUNCTION
                form.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The product could not be modified" + Environment.NewLine + ex.Message);// E R R O R
                form.Show();
                this.Close();
            }
            
        }
    }
}
