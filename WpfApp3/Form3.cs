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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void updateID_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e) //when clicking update button
        {
            Regex numbers = new Regex(@"(\+44\s?\d{4}|\(?0\d{4}\)?)\s?\d{3}\s?\d{3}"); //assign a regax to a variable
            string updatenumbervaild = textBox4.Text;// assign phonenumber text to a variable 
            if (!numbers.IsMatch(updatenumbervaild))//if number text in not matched with uk phone number
            {
                MessageBox.Show("Enter valid Number");// a message to show a valid number
            }
            else
            {
                //set a variation for sqlite connection to the database
                SQLiteConnection updatecon = new SQLiteConnection(@"data source = C:\Users\niall\appform.db");
                //update query so changing name, address and phonenumber by using the id. using connection variable for the commmand 
                SQLiteCommand updating = new SQLiteCommand("UPDATE records SET Name =@name, Address =@address, PhoneNumber = @phonenumber WHERE id = @id", updatecon);
                int ids = Convert.ToInt32(updateID.Text); // converting  id text from string to integer and assigning a variable for it 
                updating.Parameters.AddWithValue("@id", ids);// using a variable to link the query 
                updating.Parameters.AddWithValue("@name", textBox2.Text);// using name text to link the query 
                updating.Parameters.AddWithValue("@address", textBox3.Text); //using address text to link the query
                updating.Parameters.AddWithValue("@phonenumber", updatenumbervaild);// using phone number text to link query 
                updatecon.Open();//open connection
                updating.ExecuteNonQuery();//excute the query
                updatecon.Close();//close connection
                this.Close();// close this form 
            }
        }

        private void button2_Click(object sender, EventArgs e)// when clicking close button
        {
            this.Close();// the form will close
        }

        //in phonenumber texbox that only can enter number not letters 
        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
    }
}
