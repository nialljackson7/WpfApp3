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

namespace WpfApp3
{
    public partial class DeleteForm : Form
    {
        public DeleteForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)// when clicking Delete button 
        {
            // set a variable for sqlite connection
            SQLiteConnection connected = new SQLiteConnection(@"data source = C:\Users\niall\appform.db");
            // delete a record from record table where the user input the id 
            SQLiteCommand delete = new SQLiteCommand("DELETE FROM records WHERE id = @id", connected);
            int ID = Convert.ToInt32(textBox1.Text); // convert text from string to integer
            delete.Parameters.AddWithValue("@id", ID);// linking ID to the query
            connected.Open();//open connection
            delete.ExecuteNonQuery();// excute query 
            connected.Close();//close connection 
            this.Close();//close this form 
        }

        private void button2_Click(object sender, EventArgs e)// when clicking close button
        {
            this.Close();//the form will close 
        }
        // only can enter number not letters in ID texbox
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
    }
}
