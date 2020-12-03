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
                motorbikes = JsonConvert.DeserializeObject<Motorbikes>(json);// TU SABE KLK
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ( radioButton1.Checked.Equals(false) && radioButton2.Checked.Equals(false) ) {
                MessageBox.Show("Select a valid export method");// ERROR MESSAGE
            }else
            if (radioButton1.Checked.Equals(true))// CSV OPTION
            {
                using (StreamWriter sw = new StreamWriter("data/data.txt", false, Encoding.GetEncoding("iso-8859-1")))// WE READ OR CREATE A data.txt file
                {
                    sw.WriteLine("ID,name,manufacturer,description,price,stock");//The first line of the csv
                    foreach (Motorbike m in motorbikes.motorbikes)//The rest of the lines are the atributes of each motorbike
                    {
                        sw.WriteLine(m.id.ToString() + "," + m.name + "," + m.manufacturer + "," + m.description + "," + m.price.ToString() + "," + m.stock.ToString());
                    }
                    
                }
                MessageBox.Show("File exported correctly to CSV");//verification message
                textBox1.Text = System.IO.File.ReadAllText("data/data.txt");// Mostramos los datos del csv en el textbox
            }
            else if (radioButton2.Checked == true)// XML OPTION
            {
               
                XmlDocument doc = new XmlDocument();// WE CREATE A NEW XML DOCUMENT
                XmlDeclaration xmlDeclaration = doc.CreateXmlDeclaration("1.0", "UTF-8", null);// DECLARE THE VERSION AND THE UTF OF THE XML FILE
                XmlElement root = doc.DocumentElement;//THAT'S THE CENTRAL ELEMENT, IT REPRESENTS ALL THE DATA OF THE FILE 
                doc.InsertBefore(xmlDeclaration, root);//INSERT THE CENTRAL ELEMENT
                XmlElement mainLabel = doc.CreateElement(string.Empty, "motorbikes", string.Empty);
                doc.AppendChild(mainLabel);//INSERT THE ELEMENT MOTORBIKES, IS THE MOTORBIKES OBJECT
                foreach (Motorbike p in motorbikes.motorbikes)
                {
                    XmlElement motorbikeLabel = doc.CreateElement(string.Empty, "motorbike", string.Empty);//THIS IS THE CENTRAL ELEMEMENT OF EACH MOTORBIKE
                    mainLabel.AppendChild(motorbikeLabel);//WE ADD THE MOTORBIKE ELEMENT INTO THE MOTORBIKES ELEMENT
                    XmlElement idLabel = doc.CreateElement(string.Empty, "id", string.Empty);
                    XmlText valueId = doc.CreateTextNode(p.id.ToString());
                    motorbikeLabel.AppendChild(idLabel);
                    idLabel.AppendChild(valueId);
                    XmlElement nameLabel = doc.CreateElement(string.Empty, "name", string.Empty);//THOSE ARE THE ELEMENTS THAT REPRESENTS ALL THE ATRIBUTES OF EACH MOTORBIKE
                    XmlText valueName = doc.CreateTextNode(p.name);//THOSE ARE THE VALUES OF THE ELEMENTS
                    motorbikeLabel.AppendChild(nameLabel);// ADD THE ELEMENTS IN THE MOTORBIKE ELEMENT
                    nameLabel.AppendChild(valueName);//ADD THE VALUES OF EACH ELEMENT
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
                doc.Save("data/data.xml");//WE SAVE THE XML DOCUMENT IN THIS PATH
                MessageBox.Show("File exported correctly to XML");
                textBox1.Text = "";//CLEAN THE TEXTBOX
                textBox1.Text = doc.OuterXml;//WRITE THE DATA OF THE FILE IN THE DOCUMENT DOC
               
            }

        }
    }
}
