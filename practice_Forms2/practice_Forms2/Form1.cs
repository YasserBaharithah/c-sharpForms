using System;
using System.IO;
using System.Windows.Forms;

namespace practice_Forms2
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, System.EventArgs e)
        {

        }

        private void label1_Click(object sender, System.EventArgs e)
        {
            foreach (Control control in this.Controls)
            {
                if (control is TextBox)
                {

                    control.Text = "";

                }

            }
        }

        private void closeBtn_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void addBtn_Click(object sender, System.EventArgs e)
        {
            foreach (Control item in this.Controls)
            {

                if (item is TextBox)
                {

                    if (item.Text == "")
                    {
                        MessageBox.Show("Fille Empty Field Please !", "Something Wronge !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                }
            }
            StreamReader read = new StreamReader("Data.txt");
            String data = read.ReadToEnd();
            read.Close();

            if (data.Contains(textBox1.Text + "-"))
            {

                MessageBox.Show("Ext. phone is already added");
                textBox1.Focus();
                textBox1.SelectAll();
                return;
            }
            else
            {
                StreamWriter write = new StreamWriter("Data.txt", true);
                String value = textBox1.Text + "-" + textBox2.Text + "-" + textBox3.Text;
                write.WriteLine(value);
                write.Close();
                MessageBox.Show("Ext. phone is Added Successfuly !", "Good Jop !");
            }
            foreach (Control item in this.Controls)
            {

                if (item is TextBox)
                {
                    item.Text = "";
                }
            }

        }

        private void showBtn_Click(object sender, EventArgs e)
        {
            Form showForm = new Form();
            TextBox showText = new TextBox();
            showForm.BackColor = this.BackColor;
            showForm.Size = this.Size;
            showForm.Location = this.Location;
            showForm.Font = this.Font;
            showForm.Text = "Show Data Form";
            showText.Dock = DockStyle.Fill;
            showText.Font = this.Font;
            showText.BackColor = System.Drawing.Color.White;
            showText.Multiline = true;
            showText.Location = this.Location;
            showText.Size = this.Size;
            showForm.Controls.Add(showText);
            showForm.Show();

            StreamReader read = new StreamReader("Data.txt");
            String data = read.ReadToEnd();
            read.Close();
            showText.Text = data;
        }

        private void findBtn_Click(object sender, EventArgs e)
        {

            try
            {
                StreamReader read = new StreamReader("Data.txt");
                String line = "";
                bool found = false;

                if (textBox1.Text != "")
                {
                    do
                    {
                        line = read.ReadLine();
                        if (line != null)
                        {

                            String[] dat = line.Split('-');

                            if (textBox1.Text == dat[0])
                            {
                                textBox2.Text = dat[1];
                                textBox3.Text = dat[2];
                                found = true;
                                break;
                            }
                        }

                    } while (line != null);

                    if (!found)
                    {
                        MessageBox.Show("User Not Found !");
                        textBox1.Focus();
                        textBox1.SelectAll();
                    }
                }
                else
                {
                    MessageBox.Show("Please Enter Ext. To find", "Something Wrong !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox1.Focus();

                }
            }
            catch (Exception)
            {

                throw;
            }

        }


    }
}



