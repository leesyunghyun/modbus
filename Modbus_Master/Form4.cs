using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System.Collections;
using System.Text.RegularExpressions;
namespace Modbus_Master
{
    public partial class Write_0x10 : Form
    {
        string slaveid;
        string startaddr;
        string quantity;
        Hashtable hash;
        int[] value;

        EditDialog EditForm;
        public delegate void AsyncMultiRegister(string slaveid, string address, string quantity,int[] data);
        public static event AsyncMultiRegister toform1;

        public Write_0x10(string slaveid, string startaddr, string quantity, int[] value)
        {
            InitializeComponent();
            hash = new Hashtable();
            this.slaveid = slaveid;
            this.startaddr = startaddr;
            this.quantity = quantity;
            this.value = value;
            for(int i=0;i<value.Length;i++)
            {
                int j = i + Convert.ToInt32(startaddr);
                listBoxAddress.Items.Add("[" + j + "] = " + this.value[i]);
                hash.Add(j, this.value[i]);
            }

            Main.toform4 += new Main.AsyncEditForm(AsyncEditForm);

            textBoxSlaveID.Text = this.slaveid;
            textBoxAddr.Text = this.startaddr;
            textBoxQuantity.Text = this.quantity;
        }

        private void listBoxAddress_Enter(object sender, EventArgs e)
        {
            if(textBoxSlaveID.Text == "" || textBoxAddr.Text == "" || textBoxQuantity.Text == "")
            {
                MessageBox.Show("빈칸 없이 모두 입력해주세요.");
                return;
            }

            listBoxAddress.Items.Clear();

            for (int i = 0; i < Convert.ToInt32(textBoxQuantity.Text); i++)
            {
                int j = i + Convert.ToInt32(textBoxAddr.Text);
                if(hash.ContainsKey(j))
                {
                    listBoxAddress.Items.Add("[" + j + "] = " + hash[j]);    
                }
                else
                {
                    hash.Add(j, 0);
                    listBoxAddress.Items.Add("[" + j + "] = " + hash[j]);
                }
            }
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            int[] data = new int[Convert.ToInt32(textBoxQuantity.Text)];
            for(int i=0;i<Convert.ToInt32(textBoxQuantity.Text); i++)
            {
                int j = i+Convert.ToInt32(textBoxAddr.Text);
                data[i] = Convert.ToInt32(hash[j]);
            }

            toform1(textBoxSlaveID.Text,textBoxAddr.Text,textBoxQuantity.Text,data);
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            toform1("","","",null);
            Main.toform4 -= new Main.AsyncEditForm(AsyncEditForm);
            this.Close();
        }
        
        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if(listBoxAddress.SelectedIndex != -1)
            {
                EditForm = new EditDialog(listBoxAddress.SelectedIndex, value[listBoxAddress.SelectedIndex]);
                EditForm.StartPosition = FormStartPosition.CenterParent;
                EditDialog.toform4 += new EditDialog.AsyncEditValue(AsyncEditValue);
                EditForm.ShowDialog();
            }
        }

        private void listBoxAddress_DoubleClick(object sender, EventArgs e)
        {
            if (listBoxAddress.SelectedIndex != -1)
            {
                EditForm = new EditDialog(listBoxAddress.SelectedIndex, value[listBoxAddress.SelectedIndex]);
                EditForm.StartPosition = FormStartPosition.CenterParent;
                EditDialog.toform4 += new EditDialog.AsyncEditValue(AsyncEditValue);
                EditForm.ShowDialog();
            }
        }

        public void AsyncEditValue(int index, string value)
        {
            if(index == 0 && value=="")
            {
                EditDialog.toform4 -= new EditDialog.AsyncEditValue(AsyncEditValue);
                return;
            }
            listBoxAddress.Items.RemoveAt(index);
            int address = Convert.ToInt32(textBoxAddr.Text) + index;

            string data = "[" + address + "] = " + value; 

            listBoxAddress.Items.Insert(index, data);
            hash[address] = Convert.ToInt32(value);
            EditDialog.toform4 -= new EditDialog.AsyncEditValue(AsyncEditValue);
        }

        private void textBoxSlaveID_TextChanged(object sender, EventArgs e)
        {
            Regex regex = new Regex(@"[^\d]+");

            if (!regex.IsMatch(textBoxSlaveID.Text))
            {
                // 숫자 일 때 이곳으로 들어옴
            }

            else
            {
                textBoxSlaveID.Text = textBoxSlaveID.Text.Substring(0, textBoxSlaveID.Text.Length - 1);
                textBoxSlaveID.Select(textBoxSlaveID.Text.Length, 0);
                // 숫자가 아닐 때 이곳으로 들어옴
            }
        }

        private void textBoxAddr_TextChanged(object sender, EventArgs e)
        {
            Regex regex = new Regex(@"[^\d]+");

            if (!regex.IsMatch(textBoxAddr.Text))
            {
                // 숫자 일 때 이곳으로 들어옴
            }

            else
            {
                textBoxAddr.Text = textBoxAddr.Text.Substring(0, textBoxAddr.Text.Length - 1);
                textBoxAddr.Select(textBoxAddr.Text.Length, 0);
                // 숫자가 아닐 때 이곳으로 들어옴
            }
        }

        private void textBoxQuantity_TextChanged(object sender, EventArgs e)
        {
            Regex regex = new Regex(@"[^\d]+");

            if (!regex.IsMatch(textBoxQuantity.Text))
            {
                // 숫자 일 때 이곳으로 들어옴
            }

            else
            {
                textBoxQuantity.Text = textBoxQuantity.Text.Substring(0, textBoxQuantity.Text.Length - 1);
                textBoxQuantity.Select(textBoxQuantity.Text.Length, 0);
                // 숫자가 아닐 때 이곳으로 들어옴
            }
        }

        public void AsyncEditForm(string message)
        {
            MessageBox.Show(message);
        }
    }
}
