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
            String passwordTextView = textBox1.Text;
            if (passwordTextView != "marseloPeruano") {
                this.numberOfIntents--;
                textBox1.Text = "";
                if (this.numberOfIntents != 0)
                {
                    MessageBox.Show("Insert a valid password" + Environment.NewLine + "You have only " + this.numberOfIntents + " more intents");

                }
                else
                {
                    MessageBox.Show("No more attempts, you’ve been disconnected");
                    Application.Exit();
                }
            }
            else if (passwordTextView == "marseloPeruano")
            {
                Form1 secondaryWindow = new Form1();
                secondaryWindow.Show();
                this.Hide();

            }
        }

       
    }
}
