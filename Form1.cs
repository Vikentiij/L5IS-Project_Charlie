using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Charlie_1
{

    public partial class Form1 : Form
    {
        bool buttonwasclicked = false;
        bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
          
        }
        private void button1_Click(object sender, EventArgs e)
        {

            int num = 0;
            textBox1.BackColor = Color.White;
            textBox2.BackColor = Color.White;
            textBox3.BackColor = Color.White;
            textBox4.BackColor = Color.White;
            
            numericUpDown1.BackColor = Color.White;
            numericUpDown2.BackColor = Color.White;
            comboBox1.BackColor = Color.White;
            if (textBox1.Text == "") //Empty Validation
            {
                textBox1.BackColor = Color.Pink;
                MessageBox.Show("Firstname can't be empty");
                textBox1.Focus();// it will bring cursor back to the textbox 1
            }
            else if (textBox2.Text == "") //Empty Validation
            {
                textBox2.BackColor = Color.Pink;
                MessageBox.Show("Surname can't be empty");
                textBox2.Focus();// it will bring cursor back to the textbox 2
            }
            else if (textBox3.Text == "")
            {
                textBox3.BackColor = Color.Pink;
                MessageBox.Show("Mobile number can't be empty");
                textBox3.Focus();
            }
            else if (int.TryParse(textBox3.Text, out num) == false) //number validation
            {
                textBox3.BackColor = Color.Pink;
                MessageBox.Show("Enter Digits only:");
                textBox3.Focus();
            }

            else if (textBox4.Text == "") //Empty Validation
            {
                textBox4.BackColor = Color.Pink;
                MessageBox.Show("Email can't be empty");
                textBox4.Focus();// it will bring cursor back to the textbox 4
            }

            else if (IsValidEmail(textBox4.Text) == false)
            {
                textBox4.BackColor = Color.Pink;
                MessageBox.Show("Invalid email");
                textBox4.Focus();
            }

            else if (dateTimePicker1.Value.Date < DateTime.Now.Date)
            {

                MessageBox.Show("Please enter the correct date:");
                dateTimePicker1.Focus();
            }

            else if (numericUpDown1.Value == 0) //Numeric UpDown validation
            {
                numericUpDown1.BackColor = Color.Aquamarine;
                MessageBox.Show("Please enter the hour time:");
                numericUpDown1.Focus();
            }
            //else if (numericUpDown2.Value == 0)
            //{
            //    numericUpDown1.BackColor = Color.White;
            //    MessageBox.Show("Please enter the minutes:");
            //    numericUpDown2.BackColor = Color.Aquamarine;
            //    numericUpDown2.Focus();
            //}

            else if (comboBox1.SelectedIndex == -1) //Combo Box validation
            {
                //numericUpDown1.BackColor = Color.White;
                comboBox1.BackColor = Color.Pink;
                MessageBox.Show("Please select any item");

                comboBox1.Focus();
            }

            else if (buttonwasclicked == false) //buttom validation
            {
                //comboBox1.BackColor = Color.White;
                MessageBox.Show("Please click the button");
            }

            else
            {
                listBox1.Items.Add("Meeting off: " + textBox1.Text + " " + textBox2.Text);
                listBox1.Items.Add("Meeting at: " + numericUpDown1.Value + ":" + numericUpDown2.Value);
                listBox1.Items.Add("Meeting with: " + comboBox1.SelectedItem);
                listBox1.Items.Add("Meeting Aim: " + button2.Text);
                listBox1.Items.Add("------------------------------------------------------------------------");
                ResetFields();
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            Form2 km = new Form2();
            //km.ShowDialog();
            if (km.ShowDialog() == DialogResult.OK)
            {
                
                if (km.radioButton1.Checked == true)
                {
                    button2.Text = km.radioButton1.Text;
                   buttonwasclicked = true;
                }
                else if (km.radioButton2.Checked == true)
                {
                    button2.Text = km.radioButton2.Text;
                   buttonwasclicked = true;
                }
                else if (km.radioButton3.Checked == true)
                {
                    button2.Text = km.radioButton3.Text;
                   buttonwasclicked = true;
                }
                else if (km.radioButton4.Checked == true)
                {
                    button2.Text = km.radioButton4.Text;
                    buttonwasclicked = true;
                }
           }
            
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        void ResetFields()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        
            dateTimePicker1.ResetText();
            numericUpDown1.Value = 0;
            numericUpDown2.Value = 0;
           // comboBox1.Text = "Non selected";
            comboBox1.SelectedIndex = -1;
            buttonwasclicked = false;
            button2.Text = "Click to select";
        }

        

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void listBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                listBox1.Items.Remove(listBox1.SelectedItem);
            }
        }
    }
}
