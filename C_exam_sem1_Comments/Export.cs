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
using System.Xml;
using Newtonsoft.Json;


namespace C_exam_sem1_Comments
{
    public partial class Export : Form
    {
        public Motorbikes motorbikes;
        public Export()
        {
            InitializeComponent();
            using (StreamReader sr = File.OpenText("data/Motorbikes.json"))
            {
                string json = sr.ReadToEnd();
                motorbikes = JsonConvert.DeserializeObject<Motorbikes>(json);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ( radioButton1.Checked.Equals("false") && radioButton2.Checked.Equals("false") ) {
                MessageBox.Show("Select a valid export method");
            }else
            if (radioButton1.Checked.Equals(true))
            {
                using (StreamWriter sw = new StreamWriter("data/data.txt", false, Encoding.GetEncoding("iso-8859-1")))
                {
                    sw.WriteLine("ID,name,manufacturer,description,price,stock");
                    foreach (Motorbike m in motorbikes.motorbikes)
                    {
                        sw.WriteLine(m.id.ToString() + "," + m.name + "," + m.manufacturer + "," + m.description + "," + m.price.ToString() + "," + m.stock.ToString());
                    }
                    
                }
                MessageBox.Show("File exported correctly to CSV");
                textBox1.Text = System.IO.File.ReadAllText("data/data.txt");
            }
            else if (radioButton2.Checked == true)
            {
               
                XmlDocument doc = new XmlDocument();
                XmlDeclaration xmlDeclaration = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
                XmlElement root = doc.DocumentElement;
                doc.InsertBefore(xmlDeclaration, root);
                XmlElement mainLabel = doc.CreateElement(string.Empty, "motorbikes", string.Empty);
                doc.AppendChild(mainLabel);
                foreach (Motorbike p in motorbikes.motorbikes)
                {
                    XmlElement motorbikeLabel = doc.CreateElement(string.Empty, "motorbike", string.Empty);
                    mainLabel.AppendChild(motorbikeLabel);
                    XmlElement idLabel = doc.CreateElement(string.Empty, "id", string.Empty);
                    XmlText valueId = doc.CreateTextNode(p.id.ToString());
                    motorbikeLabel.AppendChild(idLabel);
                    idLabel.AppendChild(valueId);
                    XmlElement nameLabel = doc.CreateElement(string.Empty, "name", string.Empty);
                    XmlText valueName = doc.CreateTextNode(p.name);
                    motorbikeLabel.AppendChild(nameLabel);
                    nameLabel.AppendChild(valueName);
                    XmlElement manufacturerLabel = doc.CreateElement(string.Empty, "manufacturer", string.Empty);
                    XmlText valueManufacturer = doc.CreateTextNode(p.manufacturer);
                    motorbikeLabel.AppendChild(manufacturerLabel);
                    manufacturerLabel.AppendChild(valueManufacturer);
                    XmlElement descLabel = doc.CreateElement(string.Empty, "description", string.Empty);
                    XmlText valueDesc = doc.CreateTextNode(p.description);
                    motorbikeLabel.AppendChild(descLabel);
                    descLabel.AppendChild(valueDesc);
                    XmlElement priceLabel = doc.CreateElement(string.Empty, "price", string.Empty);
                    XmlText valuePrice = doc.CreateTextNode(p.price.ToString());
                    motorbikeLabel.AppendChild(priceLabel);
                    priceLabel.AppendChild(valuePrice);
                    XmlElement stockLabel = doc.CreateElement(string.Empty, "quantity", string.Empty);
                    XmlText valueStock = doc.CreateTextNode(p.stock.ToString());
                    motorbikeLabel.AppendChild(stockLabel);
                    stockLabel.AppendChild(valueStock);

                }
                doc.Save("data/data.xml");
                MessageBox.Show("File exported correctly to XML");
                textBox1.Text = "";
                textBox1.Text = doc.OuterXml;
               
            }

        }
    }
}
