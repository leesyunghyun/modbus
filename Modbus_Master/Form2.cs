using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace Modbus_Master
{
    public partial class Write_0x06 : Form
    {
        public delegate void AsyncEditValue(string slaveid, string address, string value);
        public static event AsyncEditValue toform1;

        int Address;
        int value;
        Socket mbMaster;
        public Write_0x06(Socket socket,int Address, int value)
        {
            InitializeComponent();
            this.Address = Address;
            this.value = value;
            mbMaster = socket;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Main.toform2 += new Main.AsyncEditForm(AsyncEditForm);
            textBoxSlaveID.Text = Convert.ToString(1);
            textBoxAddress.Text = Convert.ToString(Address);
            textBoxValue.Text = Convert.ToString(value);
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            if (textBoxSlaveID.Text != "" && textBoxAddress.Text != "" && textBoxValue.Text != "")
            {
                toform1(textBoxSlaveID.Text, textBoxAddress.Text, textBoxValue.Text);
            }
            else
                MessageBox.Show("값을 모두 입력해주세요.", "경고");
            
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            toform1("", "", ""); //이벤트 삭제해달라는 신호

            //이벤트 삭제
            Main.toform2 -= new Main.AsyncEditForm(AsyncEditForm);
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

        private void textBoxValue_TextChanged(object sender, EventArgs e)
        {
            Regex regex = new Regex(@"[^\d]+");

            if (!regex.IsMatch(textBoxValue.Text))
            {
                // 숫자 일 때 이곳으로 들어옴
            }

            else
            {
                textBoxValue.Text = textBoxValue.Text.Substring(0, textBoxValue.Text.Length - 1);
                textBoxValue.Select(textBoxValue.Text.Length, 0);
                // 숫자가 아닐 때 이곳으로 들어옴
            }
        }

        public void AsyncEditForm(string message)
        {
            labelResponse.Text = message;
            if (labelResponse.Text == "Result : Response ok!" && checkBoxResponse.Checked)
            {
                //이벤트 삭제
                toform1("", "", ""); //이벤트 삭제해달라는 신호

                Main.toform2 -= new Main.AsyncEditForm(AsyncEditForm);

                this.Close();
            }
        }
    }
}
