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
    public partial class Form2 : Form
    {
        public delegate void AsyncEditValue(string value, int Row);
        int selectedRows;
        public static event AsyncEditValue toform1;
        public Form2(String value,int selectedRows)
        {
            InitializeComponent();
            
            textBoxValue.Text = value;
            this.selectedRows = selectedRows;
        }

        
        private void buttonEdit_Click(object sender, EventArgs e)
        {
            //form2 에서 form1로 값전송
            if (textBoxValue.Text != "")
            {
                toform1(textBoxValue.Text, selectedRows);
                this.Close();
            }
            else
                MessageBox.Show("값을 입력해주세요", ":경고");  
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
            toform1("", 0);
            this.Close();
        }
    }
}
