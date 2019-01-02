using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using SharpPcap;
using SharpPcap.LibPcap;

namespace pop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
        }
        string userName = string.Empty;
        CaptureDeviceList devices = CaptureDeviceList.Instance;
        private ICaptureDevice device;
        private void getAdapter()//获取网卡 
        {
            var devices = LibPcapLiveDeviceList.Instance;
            //var devices = WinPcapDeviceList.Instance;
            //var devices = CaptureDeviceList.Instance;
            if (devices.Count < 1)
                MessageBox.Show("此设备上没有网卡");
            else
                foreach (var dev in devices)
                {
                    combDevice.Items.Add(dev.Interface.FriendlyName);
                    combDevice.SelectedIndex = 0;
                }
        }
        private string HexArrToAscii(byte[] s)
        {
            StringBuilder sb = new StringBuilder();
            foreach (byte b in s)
            {
                char c = (char) b;
                if (!char.IsControl(c))
                {
                    sb.Append(c);
                }
                else
                {
                    sb.Append('.');
                }
            }
            return sb.ToString();
        }
        private  void device_OnPacketArrival(object sender, CaptureEventArgs e)
        {
            var pData = e.Packet.Data;
            if (pData.Length >= 37)
            {
                if (pData[37] != 110)   //如果不是110 端口,则不记录
                {
                     return;
                }
            }
            string hexStr = HexArrToAscii(pData);
            char[] packetArr = hexStr.ToCharArray();
            if (packetArr.Length >= 54)
            {
                for (int i = 0; i < packetArr.Length - 2; i++)
                {
                    if (packetArr[i] == 'U' && packetArr[i + 1] == 'S' && packetArr[i + 2] == 'E' && packetArr[i + 3] == 'R')
                    {
                        int passLength = packetArr.Length - i - 3 - 2; //i + 3长度是数据包头，2长度是控制符
                        char[] userArr = new char[passLength];

                        for (int j = 0; j < passLength - 2; j++)
                        {
                            userArr[j] = packetArr[i + 3 + j + 2];
                        }
                        string resultPass = new string(userArr);
                        userName = resultPass;
                    }
                }
            }
            if (!string.IsNullOrEmpty(userName) && packetArr.Length >= 57) 
            {
                for (int i = 0; i < packetArr.Length - 2; i++)
                {
                    if (packetArr[i] == 'P' && packetArr[i + 1] == 'A' && packetArr[i + 2] == 'S' && packetArr[i + 3] == 'S')
                    {
                        int passLength = packetArr.Length - i - 3 - 2;//i + 3长度是数据包头，2长度是控制符
                        char[] passArr = new char[passLength];

                        for (int j = 0; j < passLength - 2; j++)
                        {
                            passArr[j] = packetArr[i+3 + j+2];
                        }
                        string resultPass = new string(passArr);
                        InsertGridView( userName, resultPass);
                        userName = string.Empty;
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "停止监听")
            {
                if (device !=null)
                {
                    if (device.Started)
                    {
                        device.StopCapture();
                        device.Close();
                    }
                }
               
                button1.Text = "开始监听";
                radio110.Enabled = true;
                radiolocalhost.Enabled = true;
                combDevice.Enabled = true;
                return;
            }
            dataGridView1.Rows.Clear();
            radio110.Enabled = false;
            radiolocalhost.Enabled = false;
            combDevice.Enabled = false;
            if (radio110.Checked == true)
            {
                int devId = this.combDevice.SelectedIndex;
                if (devId > -1)
                {
                    devices = CaptureDeviceList.Instance;
                    device = devices[devId];
                    device.OnPacketArrival += new SharpPcap.PacketArrivalEventHandler(device_OnPacketArrival);
                    int readTimeoutMilliseconds = 1000;
                    device.Open(DeviceMode.Promiscuous, readTimeoutMilliseconds);
                    device.StartCapture();
                    button1.Text = "停止监听";
                }
                else
                {
                    MessageBox.Show(this, "请选择一个设备", "提示", MessageBoxButtons.OK);
                }
            }
            if (radiolocalhost.Checked == true)
            {
                button1.Text = "停止监听";
                Thread t = new Thread(LocalhostMode);
                t.IsBackground = true;
                t.Start();
            }
        }

        private IPEndPoint ipEndPoint;
        private TcpListener tcpServer;
        private void LocalhostMode()
        {
            try
            {
                if (ipEndPoint ==null)
                {
                    ipEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 110);
                }
                if (tcpServer ==null)
                {
                    tcpServer = new TcpListener(ipEndPoint);
                }
                tcpServer.Start();
                TcpClient tcpClient = tcpServer.AcceptTcpClient();
                NetworkStream ns = tcpClient.GetStream();
                byte[] outbytes = Encoding.ASCII.GetBytes("+OK Welcome" + Environment.NewLine);
                ns.Write(outbytes, 0, outbytes.Length);
                byte[] userBytes = new byte[255];//密码
                ns.Read(userBytes, 0, userBytes.Length);
                string capa = Encoding.ASCII.GetString(userBytes);
                if (capa.IndexOf("CAPA") >= 0)
                {
                    byte[] capaByteArr = Encoding.ASCII.GetBytes("0" + Environment.NewLine);
                    ns.Write(capaByteArr, 0, capaByteArr.Length);
                    ns.Read(userBytes, 0, userBytes.Length);
                }
                outbytes = Encoding.ASCII.GetBytes("+OK" + Environment.NewLine);
                ns.Write(outbytes, 0, outbytes.Length);
                byte[] pwdBytes = new byte[255];
                ns.Read(pwdBytes, 0, pwdBytes.Length);
                string user = Encoding.ASCII.GetString(userBytes).Replace("USER", "").Replace("\r\n", "").Replace("\0", "");
                string pass = Encoding.ASCII.GetString(pwdBytes).Replace("PASS", "").Replace("\r\n", "").Replace("\0", "");
                tcpClient.Close();
                InsertGridView(user, pass);
                button1.Text = "开始监听";
                radio110.Enabled = true;
                radiolocalhost.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            radio110.Checked = true;    //默认监听110端口
            ChageListenMode();
            getAdapter();
            dataGridView1.Columns[0].HeaderText = "时间";
            dataGridView1.Columns[1].HeaderText = "用户名";
            dataGridView1.Columns[2].HeaderText = "密码";

        }

        private delegate void InvokeHandler();  //事件委托，防止修改ui假死
        private void InsertGridView(string user,string pass)
        {
            string time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            this.Invoke(new InvokeHandler(delegate()
            {
                dataGridView1.Rows.Add(time, user, pass);
            }));
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            //释放资源
            try
            {
                device.StopCapture();
                device.Close();
            }
            catch 
            {
                
            }
            finally
            {
                this.Dispose();
                this.Close();
            }
        }

        private void ChageListenMode()
        {
            if (radio110.Checked == true)
            {
                combDevice.Enabled = true;
            }
            else
            {
                combDevice.Enabled = false;
            }
        }
        private void radiolocalhost_CheckedChanged(object sender, EventArgs e)
        {
            ChageListenMode();
        }

        private void Mac_Lab_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void combDevice_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
