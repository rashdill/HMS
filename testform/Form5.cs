using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace testform
{
    public partial class Form5 : Form
    {
        CLIENT client = new CLIENT();
        public Form5()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

       
      

        private void Form5_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = client.getClient();
        }

        private void buttonAddClient_Click(object sender, EventArgs e)
        {
            String fname = textBoxFirstName.Text;
            String lname = textBoxLastName.Text;
            String phone = textBoxPhone.Text;
            String country = textBoxCountry.Text;
            if (fname.Trim().Equals("") || lname.Trim().Equals("") || phone.Trim().Equals("") || country.Trim().Equals(""))
            {
                MessageBox.Show("Required Fields - First & Last Name , Phone Number ", " Empty Fields", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                Boolean insertClient = client.insertClient(fname, lname, phone, country);

                if (insertClient)
                {
                    dataGridView1.DataSource = client.getClient();
                    MessageBox.Show("Successfuly inserted", " Add Client", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error - Could'nt Inserted", " Add Client", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        //Edit
        private void buttonEditClient_Click(object sender, EventArgs e)
        {
            int id;
           
            String fname = textBoxFirstName.Text;
            String lname = textBoxLastName.Text;
            String phone = textBoxPhone.Text;
            String country = textBoxCountry.Text;

            try
            {
                id= Convert.ToInt32(textBoxID.Text);

                if (fname.Trim().Equals("") || lname.Trim().Equals("") || phone.Trim().Equals("") || country.Trim().Equals(""))
                {
                    MessageBox.Show("Required Fields - First & Last Name , Phone Number ", " Empty Fields", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {
                    Boolean insertClient = client.editClient(id, fname, lname, phone, country);

                    if (insertClient)
                    {
                        dataGridView1.DataSource = client.getClient();
                        MessageBox.Show("Successfuly updated", " Edit Client", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error - Could'nt updated", " Edit Client", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error about ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            

        }
        //display the selected data from datagridview to textboes
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBoxID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBoxFirstName.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBoxLastName.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBoxPhone.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBoxCountry.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
        }

        private void buttonRemoveClient_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(textBoxID.Text);
                if(client.removeClient(id))
                {
                    dataGridView1.DataSource = client.getClient();
                    MessageBox.Show("Successfuly Deleted", " Delete Client", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //clear all textboxes after the deleted
                    buttonClear.PerformClick();

                }
                else
                {
                    MessageBox.Show("Error - Could'nt Deleted", " Delete Client", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error about ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxID.Text = "";
            textBoxFirstName.Text = "";
            textBoxLastName.Text = "";
            textBoxPhone.Text = "";
            textBoxCountry.Text = "";
        }
    }
}
