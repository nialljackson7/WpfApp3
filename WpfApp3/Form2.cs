using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Text.RegularExpressions;

namespace WpfApp3
{
    public partial class Add : Form
    {
        public Add()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)//when clicking apply
        {
            //used "using system.text.RegularExpression" to able use regex for phonenumber validation 
            Regex number = new Regex(@"(\+44\s?\d{4}|\(?0\d{4}\)?)\s?\d{3}\s?\d{3}"); // assign regex to uk phone number 
            string vaildnumber = textBox3.Text; //set a variable for phone number text
            if (string.IsNullOrEmpty(textBox1.Text)) // if name textbox is empty 
            {
                MessageBox.Show("Please enter Your name");//it will show a message to enter their name
            }
            else if (string.IsNullOrEmpty(textBox2.Text))//if address text is empty 
            {
                MessageBox.Show("Please enter Your address");//a meesage pops to enter address
            }
            else if (!number.IsMatch(vaildnumber))// if phonenumber textbox is not equal to uk phone number
            {
                MessageBox.Show("Invaild number"); //it will show invaild message
            }
            else
            {
                SQLiteConnection connect = new SQLiteConnection(@"data source = C:\Users\niall\appform.db");// to get location of the database and assign to a variable 
                //adding the details to the database and use sqlite connection 
                SQLiteCommand insert = new SQLiteCommand("INSERT INTO records(Name, Address, PhoneNumber) values (@Name, @Address, @PhoneNumber)", connect); 
                insert.Parameters.AddWithValue("@Name", textBox1.Text); //linking @name to nametextbox
                insert.Parameters.AddWithValue("@Address", textBox2.Text);//linking @address to address textbox
                insert.Parameters.AddWithValue("@PhoneNumber", vaildnumber);//linking @phonenumber to phonenumber textbox
                connect.Open(); //open the connection 
                insert.ExecuteNonQuery();//excute the query
                connect.Close();//close connection 
                this.Close();//the form will close
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            //in phonenumber texbox that only can enter number not letters 
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
    }
}
