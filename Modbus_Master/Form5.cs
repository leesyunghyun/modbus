using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Modbus_Master
{
    public partial class EditDialog : Form
    {

        public delegate void AsyncEditValue(int index, string value);
        public static event AsyncEditValue toform4;

        int index;
        int value;

        public EditDialog(int index, int value)
        {
            InitializeComponent();
            this.index = index;
            this.value = value;
            textBoxValue.Text = Convert.ToString(this.value);
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (textBoxValue.Text != "")
            {
                toform4(index, textBoxValue.Text);
                this.Close();
            }
            else
                MessageBox.Show("빈칸 없이 모두 입력해주세요");
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

        private void buttonClose_Click(object sender, EventArgs e)
        {
            toform4(0, "");
            this.Close();
        }
    }
}
