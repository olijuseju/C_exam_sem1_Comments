using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C_exam_sem1_Comments
{
    public partial class PasswordForm : Form
    {
        private int numberOfIntents=3;
        public PasswordForm()
        {
            InitializeComponent();
        }

        private void PasswordForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String passwordTextView = textBox1.Text;//THE PASSWORD FROM THE TEXTBOX IS STORED HERE
            if (passwordTextView != "marseloPeruano") {//CHECK THE PASSWORD
                this.numberOfIntents--;
                textBox1.Text = "";
                if (this.numberOfIntents != 0)// ALERT MESSAGE IF THE NUMBER OF ATTENPS IS LOWER THAN 3
                {
                    MessageBox.Show("Insert a valid password" + Environment.NewLine + "You have only " + this.numberOfIntents + " more intents");

                }
                else
                {
                    //EXIT THE PROGRAM
                    MessageBox.Show("No more attempts, you’ve been disconnected");
                    Application.Exit();
                }
            }
            else if (passwordTextView == "marseloPeruano")
            {
                //GO TO FORM1 AND CLOSE THIS WINDOW
                Form1 secondaryWindow = new Form1();
                secondaryWindow.Show();
                this.Close();

            }
        }

       
    }
}
