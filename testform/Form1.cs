using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MySqlConnector;
using System.Linq;
using System.Threading.Tasks;
namespace testform
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            try
            {
                CONNECTION conn = new CONNECTION();
                DataTable table = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                MySqlCommand command = new MySqlCommand();
                String query = "SELECT * FROM `users` WHERE `User Name`=@usn AND `Password`=@pass";
                command.CommandText = query;
                command.Connection = conn.getConnection();

                command.Parameters.Add("@usn", MySqlDbType.VarChar).Value = textBoxUserName.Text;
                command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = textBoxPassword.Text;

                adapter.SelectCommand = command;
                adapter.Fill(table);
                if (table.Rows.Count > 0)
                {
                    // show the main form
                    this.Hide();
                    Form2 mform = new Form2();
                    mform.Show();
                }
                else
                {
                    if(textBoxUserName.Text.Trim().Equals(""))
                    {
                        MessageBox.Show("Enter Your UserName to Login", "Empty UserName", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (textBoxPassword.Text.Trim().Equals(""))
                    {
                        MessageBox.Show("Enter Your Password to Login", "Empty Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else 
                    {
                        MessageBox.Show("This User Name or password does'nt exists", "Wrong Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception )
            {

            }







        }
    }
}
