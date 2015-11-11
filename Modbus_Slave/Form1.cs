using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;

namespace Modbus_Slave
{
    public partial class Form1 : Form
    {        

        public class AsyncMasterFrame //서버에서 전송하는 데이터 형식
        {
            public Socket workSocket;
            public byte[] buffer;
            public Int32 size;
            public AsyncMasterFrame(Int32 bufferSize)
            {
                this.size = bufferSize;
                this.buffer = new byte[size];
            }
            public void inibuffer()
            {
                this.buffer = null;
                this.buffer = new byte[size];
            }
        }
        
        Socket ModbusSlave = null;
        Form2 EditForm;
        Form3 ChangeAddr;
        AsyncCallback asyncCbOpen = null;
        AsyncCallback asyncCbRespond = null;
        AsyncCallback asyncCbRequest = null;

        public Form1()
        {
            InitializeComponent();

            for (int i = 0; i < 10; i++)
            {
                string[] a = new string[3];
                a[0] = Convert.ToString(i);
                a[2] = Convert.ToString(0);
                dataGridView1.Rows.Add(a);
            }


            //선택 리스트 항목
            comboBoxSelect.Items.Add("TCP/IP");
            comboBoxSelect.Items.Add("UDP");
            comboBoxSelect.Items.Add("Serial");
            comboBoxSelect.Items.Add("RTU over TCP");
            comboBoxSelect.Items.Add("RTU over UDP");

            comboBoxSelect.SelectedIndex = 0;

            //Serial 연결대상
            comboBoxCom.Items.Add("COM1");
            comboBoxCom.Items.Add("COM2");
            comboBoxCom.Items.Add("COM3");
            comboBoxCom.Items.Add("COM4");

            comboBoxCom.SelectedIndex = 0;

            //Serial Baud
            comboBoxBaud.Items.Add("1200 Baud");
            comboBoxBaud.Items.Add("2400 Baud");
            comboBoxBaud.Items.Add("4800 Baud");
            comboBoxBaud.Items.Add("9600 Baud");
            comboBoxBaud.Items.Add("19200 Baud");
            comboBoxBaud.Items.Add("38400 Baud");
            comboBoxBaud.Items.Add("57600 Baud");

            comboBoxBaud.SelectedIndex = 3;

            //Serial Data bits
            comboBoxBit.Items.Add("7 Data bits");
            comboBoxBit.Items.Add("8 Data bits");

            comboBoxBit.SelectedIndex = 1;

            //Serial Parity
            comboBoxParity.Items.Add("None Parity");
            comboBoxParity.Items.Add("Odd Parity");
            comboBoxParity.Items.Add("Even Parity");

            comboBoxParity.SelectedIndex = 2;

            //Serial Stop Bit
            comboBoxStopBit.Items.Add("1 Stop Bit");
            comboBoxStopBit.Items.Add("2 Stop Bits");

            comboBoxStopBit.SelectedIndex = 0;
        }

        private void buttonTCP_Click(object sender, EventArgs e)
        {
            if (buttonTCP.Text == "Close")
            {
                textBoxip.Enabled = true;
                textBoxport.Enabled = true;
                textBoxCntTO.Enabled = true;
                textBoxDelayPoll.Enabled = true;
                textBoxRsnTO.Enabled = true;
                //ModbusSlave.Close();
                //ModbusSlave.Dispose();
                buttonTCP.Text = "Open";
            }
            else if (buttonTCP.Text == "Open")
            {
                asyncCbOpen = new AsyncCallback(AsyncHandleAccept);
                asyncCbRespond = new AsyncCallback(AsyncHandleRespond);
                asyncCbRequest = new AsyncCallback(AsyncHandleRequest);

                ModbusSlave = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                ModbusSlave.Bind(new IPEndPoint(IPAddress.Parse(textBoxip.Text), Convert.ToInt32(textBoxport.Text)));
                ModbusSlave.Listen(5);

                ModbusSlave.BeginAccept(asyncCbOpen, null);

                buttonTCP.Text = "Close";
                textBoxip.Enabled = false;
                textBoxport.Enabled = false;
                textBoxCntTO.Enabled = false;
                textBoxDelayPoll.Enabled = false;
                textBoxRsnTO.Enabled = false;
            }
            else if (buttonTCP.Text == "Disconnect")
            {
               // ModbusSlave.Shutdown(SocketShutdown.Both);
              //  ModbusSlave.Close();
              //  ModbusSlave.Dispose();

                textBoxip.Enabled = true;
                textBoxport.Enabled = true;
                textBoxCntTO.Enabled = true;
                textBoxDelayPoll.Enabled = true;
                textBoxRsnTO.Enabled = true;
                buttonTCP.Text = "Open";
            }
        }

        private void AsyncHandleAccept(IAsyncResult ar)
        {
            ModbusSlave = ModbusSlave.EndAccept(ar);

            AsyncMasterFrame ao = new AsyncMasterFrame(1024);
            ao.workSocket = ModbusSlave;

            ModbusSlave.BeginReceive(ao.buffer, 0, ao.buffer.Length, SocketFlags.None, asyncCbRespond, ao);

            buttonTCP.Text = "Disconnect";
           
            labelState.Text = "Connected";
        }

        private void AsyncHandleRespond(IAsyncResult ar)
        {
            AsyncMasterFrame ao = (AsyncMasterFrame)ar.AsyncState;
            Int32 recvBytes = ao.workSocket.EndReceive(ar);
            if(recvBytes > 0)
            {
                //프레임분석 후 다시 전송
                //header
                byte[] ti = new byte[2];
                ti[0] = ao.buffer[0];
                ti[1] = ao.buffer[1];
                byte[] pi = new byte[2];
                pi[0] = ao.buffer[2];
                pi[1] = ao.buffer[3];
                byte[] length = new byte[2];
                length[0] = ao.buffer[4];
                length[1] = ao.buffer[5];
                ////////////////////////

                //frame
                int nlength = 256 * ao.buffer[4] + ao.buffer[5];
                byte slaveid = ao.buffer[6];
                byte functioncode = ao.buffer[7];

                if(functioncode == 0x03)
                {
                    byte[] startaddr = new byte[2];
                    startaddr[0] = ao.buffer[8];
                    startaddr[1] = ao.buffer[9];

                    int nstartaddr = 256 * startaddr[0] + startaddr[1];

                    
                    byte[] datacount = new byte[2];
                    datacount[0] = ao.buffer[10];
                    datacount[1] = ao.buffer[11];

                    int ndatacount = 256 * datacount[0] + datacount[1];
                    
                    //조건이 일치할 경우 true값을 보냄
                    if ((nstartaddr == Convert.ToInt32(dataGridView1.Rows[0].Cells[0].Value)) && (ndatacount == Convert.ToInt32(dataGridView1.Rows.Count)))
                    {
                        int headerframelength = 6 + 3 + (ndatacount * 2);
                        int framelength = headerframelength - 6;
                        AsyncMasterFrame ao2 = new AsyncMasterFrame(headerframelength);

                        ao2.buffer[0] = ao.buffer[0];
                        ao2.buffer[1] = ao.buffer[1];
                        ao2.buffer[2] = ao.buffer[2];
                        ao2.buffer[3] = ao.buffer[3];
                        ao2.buffer[4] = Convert.ToByte(framelength / 256);
                        ao2.buffer[5] = Convert.ToByte(framelength % 256);

                        ao2.buffer[6] = ao.buffer[6];
                        ao2.buffer[7] = ao.buffer[7];
                        ao2.buffer[8] = Convert.ToByte(ndatacount * 2);
                        for (int i = 0; i < ndatacount; i++)
                        {
                            int j = i * 2;
                            ao2.buffer[j + 9] = Convert.ToByte(Convert.ToInt32(dataGridView1.Rows[i].Cells[2].Value) / 256);
                            ao2.buffer[j + 10] = Convert.ToByte(Convert.ToInt32(dataGridView1.Rows[i].Cells[2].Value) % 256);
                        }
                        ao2.workSocket = ModbusSlave;
                        ModbusSlave.BeginSend(ao2.buffer, 0, ao2.buffer.Length, SocketFlags.None, asyncCbRequest, ao);
                    }
                    else //조건 불일치일 경우 82 에러코드 전송
                    {
                        AsyncMasterFrame ao2 = new AsyncMasterFrame(9);

                        ao2.buffer[0] = ao.buffer[0];
                        ao2.buffer[1] = ao.buffer[1];
                        ao2.buffer[2] = ao.buffer[2];
                        ao2.buffer[3] = ao.buffer[3];
                        ao2.buffer[4] = 0x00;
                        ao2.buffer[5] = 0x03;

                        ao2.buffer[6] = ao.buffer[6];
                        ao2.buffer[7] = 0x83;
                        ao2.buffer[8] = 0x02;
                       
                        ao2.workSocket = ModbusSlave;
                        ModbusSlave.BeginSend(ao2.buffer, 0, ao2.buffer.Length, SocketFlags.None, asyncCbRequest, ao);
                    }
                }
                else if(functioncode == 0x06)
                {
                    //원래 주소 검사, slave id검사 등을 통해서 일치하는지 검사하고 값을 대입
                    //일치하지 않을 경우 오류코드를 전송, 마스터에서도 오류코드 검사
                    //현재 주소 검사는 시행하는 중.
                    byte[] startaddr = new byte[2];
                    startaddr[0] = ao.buffer[8];
                    startaddr[1] = ao.buffer[9];

                    int nstartaddr = 256 * startaddr[0] + startaddr[1];

                    if((nstartaddr >= Convert.ToInt32(dataGridView1.Rows[0].Cells[0].Value)) && (nstartaddr <= Convert.ToInt32(dataGridView1.Rows[dataGridView1.Rows.Count-1].Cells[0].Value)))
                    {
                        byte[] data = new byte[2];
                        data[0] = ao.buffer[10];
                        data[1] = ao.buffer[11];

                        int ndata = 256 * data[0] + data[1];

                        int nindex = 0;
                        for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        {
                            if (Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value) == nstartaddr)
                            {
                                nindex = i;
                            }
                        }

                        dataGridView1.Rows[nindex].Cells[2].Value = ndata;

                        AsyncMasterFrame ao2 = new AsyncMasterFrame(12);

                        for (int i = 0; i < ao2.buffer.Length; i++)
                        {
                            ao2.buffer[i] = ao.buffer[i];
                        }

                        ao2.workSocket = ModbusSlave;
                        ModbusSlave.BeginSend(ao2.buffer, 0, ao2.buffer.Length, SocketFlags.None, asyncCbRequest, ao);
                    }
                    else
                    {
                        AsyncMasterFrame ao2 = new AsyncMasterFrame(9);

                        for (int i = 0; i < 5; i++)
                        {
                            ao2.buffer[i] = ao.buffer[i];
                        }
                        ao2.buffer[5] = 0x03;
                        ao2.buffer[6] = 0x01;
                        ao2.buffer[7] = 0x86;//에러코드
                        ao2.buffer[8] = 0x02;
                      
                        ao2.workSocket = ModbusSlave;
                        ModbusSlave.BeginSend(ao2.buffer, 0, ao2.buffer.Length, SocketFlags.None, asyncCbRequest, ao);
                    }
                }
                else if(functioncode == 0x10)
                {
                    byte[] startaddr = new byte[2];
                    startaddr[0] = ao.buffer[8];
                    startaddr[1] = ao.buffer[9];

                    int nstartaddr = 256 * startaddr[0] + startaddr[1];


                    byte[] datacount = new byte[2];
                    datacount[0] = ao.buffer[10];
                    datacount[1] = ao.buffer[11];

                    int ndatacount = 256 * datacount[0] + datacount[1];

                    //조건이 일치할 경우 true값을 보냄
                    if ((nstartaddr == Convert.ToInt32(dataGridView1.Rows[0].Cells[0].Value)) && (ndatacount == Convert.ToInt32(dataGridView1.Rows.Count)))
                    {
                       
                        for(int i=0;i<dataGridView1.Rows.Count;i++)
                        {
                            int j = i*2;
                            int value = 256 * ao.buffer[13+j] + ao.buffer[14+j];

                            dataGridView1.Rows[i].Cells[2].Value = value;
                        }
                        
  
                        AsyncMasterFrame ao2 = new AsyncMasterFrame(12);

                        ao2.buffer[0] = ao.buffer[0];
                        ao2.buffer[1] = ao.buffer[1];
                        ao2.buffer[2] = ao.buffer[2];
                        ao2.buffer[3] = ao.buffer[3];
                        ao2.buffer[4] = 0x00;
                        ao2.buffer[5] = 0x06;

                        ao2.buffer[6] = ao.buffer[6];
                        ao2.buffer[7] = ao.buffer[7];
                        ao2.buffer[8] = ao.buffer[8];
                        ao2.buffer[9] = ao.buffer[9];
                        ao2.buffer[10] = ao.buffer[10];
                        ao2.buffer[11] = ao.buffer[11];
                       
                        ao2.workSocket = ModbusSlave;
                        ModbusSlave.BeginSend(ao2.buffer, 0, ao2.buffer.Length, SocketFlags.None, asyncCbRequest, ao);
                    }
                    else //조건 불일치일 경우 90 에러코드 전송
                    {
                        AsyncMasterFrame ao2 = new AsyncMasterFrame(9);

                        ao2.buffer[0] = ao.buffer[0];
                        ao2.buffer[1] = ao.buffer[1];
                        ao2.buffer[2] = ao.buffer[2];
                        ao2.buffer[3] = ao.buffer[3];
                        ao2.buffer[4] = 0x00;
                        ao2.buffer[5] = 0x03;

                        ao2.buffer[6] = ao.buffer[6];
                        ao2.buffer[7] = 0x90;
                        ao2.buffer[8] = 0x02;

                        ao2.workSocket = ModbusSlave;
                        ModbusSlave.BeginSend(ao2.buffer, 0, ao2.buffer.Length, SocketFlags.None, asyncCbRequest, ao);
                    }
                }
            }

            Thread.Sleep(10);
            ao.inibuffer();
            ao.workSocket.BeginReceive(ao.buffer, 0, ao.buffer.Length, SocketFlags.None, asyncCbRespond, ao);
        }

        private void AsyncHandleRequest(IAsyncResult ar)
        {
            AsyncMasterFrame ao = (AsyncMasterFrame)ar.AsyncState;

            Int32 sentbyte = ao.workSocket.EndSend(ar);
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                if (ModbusSlave != null)
                {
                    if (ModbusSlave.Connected)
                    {
                        EditForm = new Form2(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(),e.RowIndex);
                        EditForm.StartPosition = FormStartPosition.CenterParent;
                        Form2.toform1 += new Form2.AsyncEditValue(AsyncEditValue);
                        EditForm.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("No Connected", "Warning");
                    }
                }
                else
                {
                    MessageBox.Show("No Socket", "Warning");
                }
            }
            else
            {
                return;
            }
        }

        private void comboBoxSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = comboBoxSelect.SelectedIndex;

            switch (index)
            {
                case 0:
                    textBoxip.Enabled = true;
                    textBoxport.Enabled = true;
                    textBoxCntTO.Enabled = true;
                    textBoxDelayPoll.Enabled = true;
                    textBoxRsnTO.Enabled = true;
                    buttonTCP.Enabled = true;

                    comboBoxCom.Enabled = false;
                    comboBoxBit.Enabled = false;
                    comboBoxParity.Enabled = false;
                    comboBoxStopBit.Enabled = false;
                    comboBoxBaud.Enabled = false;
                    buttonSerial.Enabled = false;

                    radioButtonRtu.Enabled = false;
                    radioButtonASCII.Enabled = false;
                    break;
                case 1:
                    textBoxip.Enabled = true;
                    textBoxport.Enabled = true;
                    textBoxCntTO.Enabled = false;
                    textBoxDelayPoll.Enabled = true;
                    textBoxRsnTO.Enabled = true;
                    buttonTCP.Enabled = true;

                    comboBoxCom.Enabled = false;
                    comboBoxBit.Enabled = false;
                    comboBoxParity.Enabled = false;
                    comboBoxStopBit.Enabled = false;
                    comboBoxBaud.Enabled = false;
                    buttonSerial.Enabled = false;

                    radioButtonRtu.Enabled = false;
                    radioButtonASCII.Enabled = false;
                    break;
                case 2:
                    textBoxip.Enabled = false;
                    textBoxport.Enabled = false;
                    textBoxCntTO.Enabled = false;
                    textBoxDelayPoll.Enabled = false;
                    textBoxRsnTO.Enabled = false;
                    buttonTCP.Enabled = false;

                    comboBoxCom.Enabled = true;
                    comboBoxBit.Enabled = true;
                    comboBoxParity.Enabled = true;
                    comboBoxStopBit.Enabled = true;
                    comboBoxBaud.Enabled = true;
                    buttonSerial.Enabled = true;

                    radioButtonRtu.Enabled = true;
                    radioButtonASCII.Enabled = true;
                    break;
                case 3:
                    textBoxip.Enabled = true;
                    textBoxport.Enabled = true;
                    textBoxCntTO.Enabled = true;
                    textBoxDelayPoll.Enabled = true;
                    textBoxRsnTO.Enabled = true;
                    buttonTCP.Enabled = true;

                    comboBoxCom.Enabled = false;
                    comboBoxBit.Enabled = false;
                    comboBoxParity.Enabled = false;
                    comboBoxStopBit.Enabled = false;
                    comboBoxBaud.Enabled = false;
                    buttonSerial.Enabled = false;

                    radioButtonRtu.Enabled = true;
                    radioButtonASCII.Enabled = true;
                    break;
                case 4:
                    textBoxip.Enabled = true;
                    textBoxport.Enabled = true;
                    textBoxCntTO.Enabled = false;
                    textBoxDelayPoll.Enabled = true;
                    textBoxRsnTO.Enabled = true;
                    buttonTCP.Enabled = true;

                    comboBoxCom.Enabled = false;
                    comboBoxBit.Enabled = false;
                    comboBoxParity.Enabled = false;
                    comboBoxStopBit.Enabled = false;
                    comboBoxBaud.Enabled = false;
                    buttonSerial.Enabled = false;

                    radioButtonRtu.Enabled = true;
                    radioButtonASCII.Enabled = true;
                    break;
            }
        }

        public void AsyncEditValue(string value, int Rows)
        {
            if(value =="")
            {
                Form2.toform1 -= new Form2.AsyncEditValue(AsyncEditValue);
                return;
            }
             dataGridView1.Rows[Rows].Cells[2].Value = value;
             Form2.toform1 -= new Form2.AsyncEditValue(AsyncEditValue);
        }

        private void changeAddressToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeAddr = new Form3("1", Convert.ToString(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value));
            ChangeAddr.StartPosition = FormStartPosition.CenterParent;
            Form3.toform1 += new Form3.AsyncEditAddress(AsyncEditAddress);
            ChangeAddr.ShowDialog();
        }

        public void AsyncEditAddress(string slaveid, string address, string quantity)
        {
            if(slaveid == "" && address == "" && quantity == "")
            {
                Form3.toform1 -= new Form3.AsyncEditAddress(AsyncEditAddress);
                return;
            }

            dataGridView1.Rows.Clear();

            int startaddr = Convert.ToInt32(address);
            int nquantity = startaddr + Convert.ToInt32(quantity);
            for (int i = startaddr; i < nquantity; i++)
            {
                string[] a = new string[3];
                a[0] = Convert.ToString(i);
                a[2] = Convert.ToString(0);
                dataGridView1.Rows.Add(a);
            }

            Form3.toform1 -= new Form3.AsyncEditAddress(AsyncEditAddress);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.DefaultExt = "txt";
            saveFileDialog1.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.InitialDirectory = @"C:\Users\cbfhr\바탕화면\";
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sw = new StreamWriter(saveFileDialog1.FileName);
                sw.WriteLine("Slave ID = 1");
                sw.WriteLine();
                sw.WriteLine("\tAddress\t Alias\t Value");
                int count = Convert.ToInt32(dataGridView1.Rows.Count);
                for (int i = 0; i < count; i++)
                {
                    sw.Write("\t   ");
                    for (int j = 0; j < 3; j++)
                    {
                        sw.Write(dataGridView1.Rows[i].Cells[j].Value);
                        sw.Write("\t   ");
                    }
                    sw.WriteLine();
                }
                sw.Close();
                sw.Dispose();
            }
        }
    }
}
