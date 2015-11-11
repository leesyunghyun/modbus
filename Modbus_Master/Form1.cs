using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace Modbus_Master
{
    public partial class Main : Form
    {
        public delegate void AsyncEditForm(string message);
        public static event AsyncEditForm toform2;
        public static event AsyncEditForm toform4;
        Thread threadRequestData;
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

        Socket modbusMaster = null;

        AsyncCallback asyncCbConnect = null;
        AsyncCallback asyncCbRespond = null;
        AsyncCallback asyncCbRequest = null;

        Write_0x06 SingleRegister;
        ChangeAddress ChangeAddress;
        Write_0x10 MultiRegister;

        public Main()
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

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                if (modbusMaster != null)
                {
                    if (modbusMaster.Connected)
                    {
                        SingleRegister = new Write_0x06(modbusMaster, Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value), Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()));
                        SingleRegister.StartPosition = FormStartPosition.CenterParent;
                        Write_0x06.toform1 += new Write_0x06.AsyncEditValue(AsyncEditValue);
                        SingleRegister.ShowDialog();
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

        private void buttonTCP_Click(object sender, EventArgs e)
        {
            if (buttonTCP.Text == "Disconnect")
            {
                modbusMaster.Shutdown(SocketShutdown.Both);
                threadRequestData.Abort();

                modbusMaster.BeginDisconnect(true, DisconnectCallback, modbusMaster);

                labelState.Text = "No Connect";
                buttonTCP.Text = "Connect";
                textBoxip.Enabled = true;
                textBoxport.Enabled = true;
                textBoxCntTO.Enabled = true;
                textBoxDelayPoll.Enabled = true;
                textBoxRsnTO.Enabled = true;
            }
            else
            {
                modbusMaster = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                modbusMaster.SendTimeout = Convert.ToInt32(textBoxCntTO.Text);
                modbusMaster.ReceiveTimeout = Convert.ToInt32(textBoxRsnTO.Text);
                modbusMaster.Poll(Convert.ToInt32(textBoxDelayPoll.Text), SelectMode.SelectWrite);
                IPAddress ipAddr = IPAddress.Parse(textBoxip.Text);
                IPEndPoint ipep = new IPEndPoint(ipAddr, Convert.ToInt32(textBoxport.Text));
                asyncCbConnect = new AsyncCallback(AsyncHandleMasterConnect);
                asyncCbRespond = new AsyncCallback(AsyncHandleMasterRespond);

                textBoxip.Enabled = false;
                textBoxport.Enabled = false;
                textBoxCntTO.Enabled = false;
                textBoxDelayPoll.Enabled = false;
                textBoxRsnTO.Enabled = false;

                buttonTCP.Text = "Disconnect";

                modbusMaster.BeginConnect(ipep, asyncCbConnect, modbusMaster);
            }
        }

        private void AsyncHandleMasterConnect(IAsyncResult ar)
        {
            Socket master = (Socket)ar.AsyncState;

            master.EndConnect(ar);

            if (master.Connected)
            {
                AsyncMasterFrame ao = new AsyncMasterFrame(1024);
                ao.workSocket = master;

                threadRequestData = new Thread(thRequestData);
                threadRequestData.Start();

                master.BeginReceive(ao.buffer, 0, ao.buffer.Length, SocketFlags.None, asyncCbRespond, ao);

                labelState.Text = "Connect";
            }
        }
        private static void DisconnectCallback(IAsyncResult ar)
        {
            // Complete the disconnect request.
            Socket client = (Socket)ar.AsyncState;
            client.EndDisconnect(ar);
            client.Close();

            // Signal that the disconnect is complete.
            //Modbus_Master.Set();
        }


        private void AsyncHandleMasterRespond(IAsyncResult ar)
        {
            AsyncMasterFrame ao = (AsyncMasterFrame)ar.AsyncState;
            Int32 recvBytes = ao.workSocket.EndReceive(ar);
            if (recvBytes > 0)
            {
                //header 분석
                byte[] ti = new byte[2];
                ti[0] = ao.buffer[0];
                ti[1] = ao.buffer[1];

                byte[] pi = new byte[2];
                pi[0] = ao.buffer[2];
                pi[1] = ao.buffer[3];

                byte[] framelength = new byte[2];
                framelength[0] = ao.buffer[4];
                framelength[1] = ao.buffer[5];

                ////////////////////////////////

                //frame분석

                if (pi[1] == 0x00) //tcp
                {
                    byte slaveid = ao.buffer[6];
                    byte functioncode = ao.buffer[7];


                    if (functioncode == 0x03)
                    {
                        byte bytecount = ao.buffer[8];

                        byte[] registervalue = new byte[bytecount];

                        for (int i = 0; i < bytecount; i++)
                        {
                            registervalue[i] = ao.buffer[i + 9];
                        }

                        int[] value = new int[bytecount / 2];

                        for (int i = 0; i < bytecount / 2; i++)
                        {
                            int j = i * 2;
                            value[i] = registervalue[j] * 256 + registervalue[j + 1];
                            dataGridView1.Rows[i].Cells[2].Value = value[i];
                        }
                        labelState.Text = "Connected";
                    }
                    else if (functioncode == 0x06)
                    {
                        byte[] startaddr = new byte[2];
                        startaddr[0] = ao.buffer[8];
                        startaddr[1] = ao.buffer[9];

                        int nstartaddr = 256 * startaddr[0] + startaddr[1];

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

                        toform2("Result : Response ok!");
                        labelState.Text = "Connected";
                    }
                    else if(functioncode == 0x10)
                    {
                        toform4("Response ok");
                        labelState.Text = "Connected";
                    }
                    else if(functioncode == 0x83)
                    {
                        byte errorcode = ao.buffer[8];
                        switch(errorcode)
                        {
                            case 0x00:
                                break;
                            case 0x01:
                                break;
                            case 0x02:
                                labelState.Text = "illegal Data Address";
                                break;
                        }
                    }
                    else if(functioncode == 0x86)
                    {
                        byte errorcode = ao.buffer[8];
                        switch (errorcode)
                        {
                            case 0x00:
                                break;
                            case 0x01:
                                break;
                            case 0x02:
                                toform2("Result : illegal Data Address");
                                break;
                        }
                    }
                    else if(functioncode == 0x90)
                    {
                        byte errorcode = ao.buffer[8];
                        switch (errorcode)
                        {
                            case 0x00:
                                break;
                            case 0x01:
                                break;
                            case 0x02:
                                labelState.Text = "illegal Data Address";
                                toform4("illegal Data Address");
                                break;
                        }
                    }
                }
                else if (pi[1] == 0x01) //rtu
                {

                }
                else if (pi[2] == 0x02) //ascii
                {


                }
            }

            Thread.Sleep(10);
            ao.inibuffer();
            ao.workSocket.BeginReceive(ao.buffer, 0, ao.buffer.Length, SocketFlags.None, asyncCbRespond, ao);
        }

        private void AsyncHandleMasterRequest(IAsyncResult ar)
        {
            AsyncMasterFrame ao = (AsyncMasterFrame)ar.AsyncState;

            Int32 sentbyte = ao.workSocket.EndSend(ar);
        }

        private void thRequestData()
        {
            while (true)
            {
                AsyncMasterFrame ao = new AsyncMasterFrame(12);

                //헤더구성
                ao.buffer[0] = 0x00;
                ao.buffer[1] = 0x01;
                ao.buffer[2] = 0x00;
                ao.buffer[3] = 0x00; //여기서 TCP RTU ASCII 구분
                ao.buffer[4] = 0x00;
                ao.buffer[5] = 0x06; //프레임길이


                //프레임구성

                ao.buffer[6] = 0x01; //slaveid
                ao.buffer[7] = 0x03; //functioncode
                
                int startaddr = Convert.ToInt32(dataGridView1.Rows[0].Cells[0].Value);
                ao.buffer[8] = Convert.ToByte(startaddr / 256);
                ao.buffer[9] = Convert.ToByte(startaddr % 256);

                int datacount = dataGridView1.Rows.Count;

                ao.buffer[10] = Convert.ToByte(datacount / 256);
                ao.buffer[11] = Convert.ToByte(datacount % 256);

                ao.workSocket = modbusMaster;
                modbusMaster.BeginSend(ao.buffer, 0, ao.buffer.Length, SocketFlags.None, asyncCbRequest, ao);
                Thread.Sleep(1000);
            }
        }

        public void AsyncEditValue(string slaveid, string address, string value)
        {
            if(labelState.Text == "Connected")
            {
                AsyncMasterFrame ao = new AsyncMasterFrame(12);

                //헤더구성
                ao.buffer[0] = 0x00;
                ao.buffer[1] = 0x01;
                ao.buffer[2] = 0x00;
                ao.buffer[3] = 0x00; //여기서 TCP RTU ASCII 구분
                ao.buffer[4] = 0x00;
                ao.buffer[5] = 0x06; //프레임길이


                //프레임구성
                if (slaveid == "" && address == "" && value == "")
                {
                    Write_0x06.toform1 -= new Write_0x06.AsyncEditValue(AsyncEditValue);
                    return;
                }

                ao.buffer[6] = Convert.ToByte(slaveid); //slaveid
                ao.buffer[7] = 0x06; //functioncode

                int startaddr = Convert.ToInt32(address);
                ao.buffer[8] = Convert.ToByte(startaddr / 256);
                ao.buffer[9] = Convert.ToByte(startaddr % 256);

                int data = Convert.ToInt32(value);

                ao.buffer[10] = Convert.ToByte(data / 256);
                ao.buffer[11] = Convert.ToByte(data % 256);

                ao.workSocket = modbusMaster;
                modbusMaster.BeginSend(ao.buffer, 0, ao.buffer.Length, SocketFlags.None, asyncCbRequest, ao);
            }
            else
            {
                return;
            }
        }

        private void addressChangeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeAddress = new ChangeAddress("1", Convert.ToString(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value));
            ChangeAddress.StartPosition = FormStartPosition.CenterParent;
            ChangeAddress.toform1 += new ChangeAddress.AsyncEditAddress(AsyncEditAddress);
            ChangeAddress.ShowDialog();
        }

        public void AsyncEditAddress(string slaveid, string address, string quantity)
        {
            if(slaveid == "" && address == "" && quantity == "")
            {
                ChangeAddress.toform1 -= new ChangeAddress.AsyncEditAddress(AsyncEditAddress);
                return;
            }

            dataGridView1.Rows.Clear();

            int startaddr = Convert.ToInt32(address);
            int nquantity = startaddr + Convert.ToInt32(quantity);
            for (int i = startaddr; i < nquantity ; i++)
            {
                string[] a = new string[3];
                a[0] = Convert.ToString(i);
                a[2] = Convert.ToString(0);
                dataGridView1.Rows.Add(a);
            }
            ChangeAddress.toform1 -= new ChangeAddress.AsyncEditAddress(AsyncEditAddress);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.DefaultExt = "txt";
            saveFileDialog1.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.InitialDirectory = @"C:\Users\cbfhr\바탕화면\";
            saveFileDialog1.RestoreDirectory = true;

            if(saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sw = new StreamWriter(saveFileDialog1.FileName);
                sw.WriteLine("Slave ID = 1");
                sw.WriteLine();
                sw.WriteLine("\tAddress\t Alias\t Value");
                int count = Convert.ToInt32(dataGridView1.Rows.Count);
                for(int i=0;i<count;i++)
                {
                    sw.Write("\t   ");
                    for(int j=0;j<3;j++)
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

        private void multiRegisterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int[] value = new int[dataGridView1.Rows.Count];

            for (int i = 0; i < value.Length; i++)
            {
                value[i] = Convert.ToInt32(dataGridView1.Rows[i].Cells[2].Value);
            }
            MultiRegister = new Write_0x10("1", Convert.ToString(dataGridView1.Rows[0].Cells[0].Value), Convert.ToString(dataGridView1.Rows.Count), value);
            MultiRegister.StartPosition = FormStartPosition.CenterParent;
            Write_0x10.toform1 += new Write_0x10.AsyncMultiRegister(AsyncMultiRegister);
            MultiRegister.ShowDialog();
        }

        public void AsyncMultiRegister(string slaveid, string addr, string quantity, int[] data)
        {
            if(slaveid == "" && addr == "" && quantity == "")
            {
                Write_0x10.toform1 -= new Write_0x10.AsyncMultiRegister(AsyncMultiRegister);
                return;
            }

            int hdframelength = 13 + data.Length*2;
            AsyncMasterFrame ao = new AsyncMasterFrame(hdframelength);

            //헤더구성
            ao.buffer[0] = 0x00;
            ao.buffer[1] = 0x01;
            ao.buffer[2] = 0x00;
            ao.buffer[3] = 0x00; //여기서 TCP RTU ASCII 구분
            ao.buffer[4] = 0x00;
            ao.buffer[5] = Convert.ToByte(7 + data.Length*2); //프레임길이


            //프레임구성

            ao.buffer[6] = 0x01; //slaveid
            ao.buffer[7] = 0x10; //functioncode

            int startaddr = Convert.ToInt32(addr);
            ao.buffer[8] = Convert.ToByte(startaddr / 256);
            ao.buffer[9] = Convert.ToByte(startaddr % 256);

            int datacount = Convert.ToInt32(quantity);

            ao.buffer[10] = Convert.ToByte(datacount / 256);
            ao.buffer[11] = Convert.ToByte(datacount % 256);

            ao.buffer[12] = Convert.ToByte(data.Length * 2); //데이터 바이트 수

            for (int i = 0; i < data.Length;i++)
            {
                int j = i * 2;
                ao.buffer[13 + j] = Convert.ToByte(data[i] / 256);
                ao.buffer[14 + j] = Convert.ToByte(data[i] % 256);
            }

            ao.workSocket = modbusMaster;
            modbusMaster.BeginSend(ao.buffer, 0, ao.buffer.Length, SocketFlags.None, asyncCbRequest, ao);
        }
    }
}
