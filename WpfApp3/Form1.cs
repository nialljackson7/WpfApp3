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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        // information.db
        private void button1_Click(object sender, EventArgs e)// when clicking add a record button
        {
            Add adding = new Add();//assigning add form to a variable 
            adding.ShowDialog(); // show add form 
        }

        private void button4_Click(object sender, EventArgs e)// when clicking show records 
        {
            SQLiteConnection con = new SQLiteConnection(@"data source = C:\Users\niall\appform.db");//connect to sqlite3 database 
            con.Open();//open database
            string query = "SELECT * from records";// select everything in the table 
            SQLiteCommand cmd = new SQLiteCommand(query,con);// excute the query to the sql database 
            DataTable dt = new DataTable();// store data from the database 
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd);// going to and retriving it from database
            adapter.Fill(dt);// fill means reading the database and filling it from database
            dataGridView1.DataSource = dt;// display the database to data grid view 
        }


        private void dataGridView1_DoubleClick_1(object sender, EventArgs e) //when doubleclicking on a selected row in the datagrid
        {
            Form3 f3 = new Form3(); //assigning update form to a variable 
            // change the modifier to public so can access form3 Textbox 
            f3.updateID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();//get value from  id column and put into update textbox
            f3.textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();// get value from name column and put into update textbox
            f3.textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();// get value from address column and put into update textbox
            f3.textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();//get value from phone column and put into update textbox
            f3.ShowDialog(); // show update form 
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DeleteForm f4 = new DeleteForm(); // assign delete form to a variable 
            f4.ShowDialog(); // show delete form
        }
    }
}
