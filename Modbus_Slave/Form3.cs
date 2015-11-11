using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Modbus_Slave
{
    public partial class Form3 : Form
    {
        public delegate void AsyncEditAddress(string slaveid, string address, string quantity);
        public static event AsyncEditAddress toform1;

        string slaveid;
        string address;

        public Form3(string slaveid, string address)
        {
            InitializeComponent();
            this.slaveid = slaveid;
            this.address = address;

            textBoxSlaveID.Text = slaveid;
            textBoxAddress.Text = address;
            textBoxQuantity.Text = "10";
        }

        private void buttonSetting_Click(object sender, EventArgs e)
        {
            if (textBoxSlaveID.Text != "" && textBoxAddress.Text != "" && textBoxQuantity.Text != "")
            {
                toform1(textBoxSlaveID.Text, textBoxAddress.Text, textBoxQuantity.Text);
                this.Close();
            }
            else
                MessageBox.Show("빈칸 없이 모두 입력해주세요.");
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            toform1("","","");
            this.Close();
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

        private void textBoxAddress_TextChanged(object sender, EventArgs e)
        {
            Regex regex = new Regex(@"[^\d]+");

            if (!regex.IsMatch(textBoxAddress.Text))
            {
                // 숫자 일 때 이곳으로 들어옴
            }

            else
            {
                textBoxAddress.Text = textBoxAddress.Text.Substring(0, textBoxAddress.Text.Length - 1);
                textBoxAddress.Select(textBoxAddress.Text.Length, 0);
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
    }
}
