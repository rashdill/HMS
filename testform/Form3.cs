using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace testform
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        ROOM room = new ROOM();
        private void Form3_Load(object sender, EventArgs e)
        {
            comboBoxRoomType.DataSource = room.roomTypeList();
            comboBoxRoomType.DisplayMember = "label";//display the combo box cateogray
            comboBoxRoomType.ValueMember = "category_id";

            dataGridView1.DataSource = room.getRooms();

        }

        private void label6_Click(object sender, EventArgs e)
        {
           
        }

        private void buttonAddRoom_Click(object sender, EventArgs e)
        {
            
            int type = Convert.ToInt32(comboBoxRoomType.SelectedValue.ToString());
            String phone = textBoxPhone.Text;
            String free="";
            try
            {
                int number = Convert.ToInt32(textBoxNumber.Text);
                if (radioButtonYES.Checked)
                {
                    free = "Yes";
                }
                else if (radioButtonNO.Checked)
                {
                    free = "No";
                }


                if (room.addRoom(number, type, phone, free))
                {
                    dataGridView1.DataSource = room.getRooms();
                    MessageBox.Show("Room Added Successfully", "Add Room", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Room not Added", "Add Room", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error about Room", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


        }

        private void buttonEditRoom_Click(object sender, EventArgs e)
        {
            
            int type = Convert.ToInt32(comboBoxRoomType.SelectedValue.ToString());
            String phone = textBoxPhone.Text;
            String free="";
            try
            {
                int number = Convert.ToInt32(textBoxNumber.Text);
                if (radioButtonYES.Checked)
                {
                    free = "YES";
                }
                else if (radioButtonNO.Checked)
                {
                    free = "NO";
                }

                if (room.editRoom(number, type, phone, free))
                {
                    dataGridView1.DataSource = room.getRooms();
                    MessageBox.Show("Data Updated", "Edit Room", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Data Could'nt Updated", "Edit Room", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error about Room", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            
        }

        private void buttonRemoveRoom_Click(object sender, EventArgs e)
        {
            try
            {
                int number = Convert.ToInt32(textBoxNumber.Text);

                if (room.removeRoom(number))
                {
                    dataGridView1.DataSource = room.getRooms();
                    MessageBox.Show("Data Deleted", "Delete Room", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Data Could'nt Deleted", "Delete Room", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error about Room", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxNumber.Text = "";
            comboBoxRoomType.SelectedIndex = 0;
            textBoxPhone.Text = "";
            radioButtonYES.Checked = true;
        }
        //display selected row data from datagridview to textboxes
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBoxNumber.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            comboBoxRoomType.SelectedValue = dataGridView1.CurrentRow.Cells[1].Value;
            textBoxPhone.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
             //when user select some row yes or nor select

            String free = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            if (free.Equals("Yes"))
            {
                radioButtonYES.Checked = true;
            }
            else if (free.Equals("No"))
            {
                radioButtonNO.Checked = true;
            }
        }
    }
}
