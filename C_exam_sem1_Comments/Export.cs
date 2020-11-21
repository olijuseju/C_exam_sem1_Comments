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
            if (radioButton1.Checked.Equals(true))
            {
                using (StreamWriter sw = new StreamWriter("data/data.txt", true, Encoding.GetEncoding("iso-8859-1")))
                {
                    ;
                }
            }else if (radioButton2.Checked == true)
            {
                XmlDocument doc = new XmlDocument();
                XmlNodeList nodes = doc.DocumentElement.SelectNodes("/geonames/geoname");
                doc.LoadXml("<item><name>wrench</name></item>");

                XmlElement newElem = doc.CreateElement("price");
                newElem.InnerText = "hola";
                doc.DocumentElement.AppendChild(newElem);

                doc.Save("data/data.xml");

            }
            
        }
    }
}
