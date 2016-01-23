﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.IO.Ports;              //端口操作
using System.Threading;             //多线程
using System.Collections;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using Desktop_Reader;
using Ini;
using DIP_RFID.DAL;

namespace RFID
{
    public partial class Form1 : Form
    {
        List<TagInfo> TagList = new List<TagInfo>();
        Dictionary<string, TagInfo> m_Tags = new Dictionary<string, TagInfo>();
        public delegate void MyInvoke(TagInfo tag);
        DateTime StartTime;
        private Thread RevDataFrom232;
        UInt16 threadFlag = 0;
        //ListViewColumnSorter lvwColumnSorter = new ListViewColumnSorter();
        int RemovedTagNums = 0;
        Byte u8HeadCnt;
        Byte u8DataPointer;
        Byte checkbyte;
        Byte[] g_Revbuf = new Byte[1024];				//接收缓存
        UInt16 g_RevDataLen;							//接收帧数据长度
        bool bCheckRet;
        bool bGetDataComplete;
        string strMethod;
        SerialPort comID;
        string strMethodReader;
        DataTable dtResult = new DataTable();
        string strResult;
        string INIFlieName = @"C:\Windows\DIP.ini";
        string strPort;
        string strBaudrate;
        string strReadtime;

        public Form1()
        {
            InitializeComponent();
        }

        public void Initiate()
        {

            //string[] ports = SerialPort.GetPortNames();
            //Array.Sort(ports);
            //cbB_COMID.Items.AddRange(ports);
            //cbB_COMID.SelectedIndex = cbB_COMID.Items.Count > 0 ? 0 : -1;
            //cbBPortId.SelectedIndex = comboBaudrate.Items.IndexOf("9600");

            //初始化SerialPort对象
            ReadWriteIO.comm.NewLine = "\r\n";
            ReadWriteIO.comm.RtsEnable = true;//根据实际情况吧。

            //listView初始化
            //listView_Disp.Columns.Add("标签", 100, HorizontalAlignment.Left);
            //listView_Disp.Columns.Add("EPC", 350, HorizontalAlignment.Left);
            //listView_Disp.Columns.Add("读取次数", 100, HorizontalAlignment.Left);
            //listView_Disp.Columns.Add("RSSI(dBm)", 100, HorizontalAlignment.Left);
            //listView_Disp.Columns.Add("天线号", 100, HorizontalAlignment.Left);
            //listView_Disp.Columns.Add("Last Time", 100, HorizontalAlignment.Left);
            //listView_Disp.GridLines = true;
            //listView_Disp.FullRowSelect = true;
            //listView_Disp.MultiSelect = false;


            ReaderParams param = new ReaderParams();
            ReadWriteIO readwriteio = new ReadWriteIO();

            TagList.Clear();
            m_Tags.Clear();
            dtResult = new DataTable();
            dtResult.Columns.Add(new DataColumn("TagID"));
            dtResult.Columns.Add(new DataColumn("AntID"));
            dtResult.Columns.Add(new DataColumn("RSSI"));
            dtResult.Columns.Add(new DataColumn("Time")); ;
            //timer2.Enabled = true;
            threadFlag = 0;

            /*  */
            //DisableOPT();

            //cB_Language.SelectedIndex = 0;
            //cbB_Baud.SelectedIndex = 0;
        }

        private void Connect(string strCom, string strBaud, string method)
        {
            string str = strCom.Substring(0, 3);

            //根据当前串口对象，来判断操作   
            if (("Close".ToLower() == method.ToLower()))
            {
                if (1 == threadFlag)
                {
                    if (RevDataFrom232.IsAlive)
                    {
                        RevDataFrom232.Abort();
                    }
                }

                //打开时点击，则关闭端口   


            }
            else
            {
                // 网口操作
                if ("COM".ToLower() == str.ToLower())
                {
                    ReaderParams.CommIntSelectFlag = 1;
                    //关闭时点击，则设置好端口，波特率后打开   
                    ReadWriteIO.comm.PortName = strCom;
                    ReadWriteIO.baud = int.Parse(strBaud);
                    ReadWriteIO.comm.BaudRate = ReadWriteIO.baud;
                    try
                    {
                        ReadWriteIO.comm.Open();
                    }
                    catch (Exception ex)
                    {
                        //捕获到异常信息，创建一个新的ReadWriteIO.comm对象，之前的不能用了。   
                        //ReadWriteIO.comm = new SerialPort();
                        str = ex.Message;
                        if (0 == ReaderParams.LanguageFlag)
                        {
                            str += "\r\n当前串口可能被占用";
                        }
                        else
                        {
                            str += "\r\nThe port is used";
                        }
                        //显示异常信息给客户。   
                        //MessageBox.Show(str, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }

                    /* 获取模块ID号 */
                    UInt32[] ID = new UInt32[2];
                    int result = ReaderParams.GetModuleID(ID);
                    if (result != 0)
                    {
                        ReadWriteIO.comm.Close();
                        if (0 == ReaderParams.LanguageFlag)
                        {
                            //MessageBox.Show("模块异常", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }
                        else
                        {
                            //MessageBox.Show("Module Error", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }
                        return;
                    }
                }
                else
                {
                    if (0 == ReaderParams.LanguageFlag)
                    {
                        //MessageBox.Show("端口输入错误", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    else
                    {
                        //MessageBox.Show("The Port ID Error", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }

                    return;
                }


            }

        }

        private void MultiRead(string strMet)
        {
            Byte[] revbuf = new Byte[500];           //接收缓冲
            RevDataFrom232 = new Thread(new ThreadStart(ReceiveDataFromUART));
            threadFlag = 1;

            if ((strMet.ToLower() == "Multiple".ToLower()))
            {

                UInt16 len = 2;
                byte[] buf = new byte[2];

                /* 获取当前时间，计算标签识别速率用的 */
                StartTime = DateTime.Now;
                m_Tags.Clear();
                dtResult.Clear();

                buf[0] = (byte)(0x00);
                buf[1] = (byte)(0x00);

                ReadWriteIO.sendFrameBuild(buf, CMD.FRAME_CMD_INVENTORY_MUL, len);

                if (1 == ReaderParams.CommIntSelectFlag)
                {
                    if (ReadWriteIO.comm.IsOpen)
                    {
                        ReadWriteIO.comm.DiscardInBuffer();
                        ReadWriteIO.comm.DiscardOutBuffer();
                        ReadWriteIO.comm.Write(ReadWriteIO.SendBuf, 0, (len + CMD.FRAME_HEADEND_LEN));
                    }
                    else
                    {
                        if (0 == ReaderParams.LanguageFlag)
                        {
                            //MessageBox.Show("端口未打开，操作失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }
                        else
                        {
                            //MessageBox.Show("Do not open the port", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }

                        return;
                    }
                }
                else
                {
                    if (true == ReaderParams.nsStream.CanRead)
                    {
                        //ReaderParams.nsStream.Read(revbuf, 0, revbuf.Length);
                        ReaderParams.nsStream.Write(ReadWriteIO.SendBuf, 0, (len + CMD.FRAME_HEADEND_LEN));//发送测试信息
                    }
                    else
                    {
                        if (0 == ReaderParams.LanguageFlag)
                        {
                            //MessageBox.Show("网口未连接，操作失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }
                        else
                        {
                            //MessageBox.Show("Network port is not connected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }

                        return;
                    }
                }

                //timer1.Enabled = true;

                RevDataFrom232.Start();
                //                ReceiveDataFromUART();
            }
            else if (((strMet.ToLower() == "Stop".ToLower())))
            {
                System.Threading.Thread.Sleep(100);
                StopInvMul();

            }
        }

        private void StopInvMul()
        {
            UInt16 len = 0;
            byte[] buf = new byte[2];
            int recount = 50000;     //重试次数
            int revlen = 0;         //接收数据长度
            Byte[] revbuf = new Byte[500];           //接收缓冲

            ReadWriteIO.sendFrameBuild(buf, CMD.FRAME_CMD_STOP_INVENTORY, len);

            if (1 == ReaderParams.CommIntSelectFlag)
            {
                if (ReadWriteIO.comm.IsOpen)
                {
                    ReadWriteIO.comm.DiscardInBuffer();
                    ReadWriteIO.comm.DiscardOutBuffer();
                    revlen = 0;
                    ReadWriteIO.comm.Write(ReadWriteIO.SendBuf, 0, (len + CMD.FRAME_HEADEND_LEN));
                }
                else
                {
                    if (0 == ReaderParams.LanguageFlag)
                    {
                        //MessageBox.Show("端口未打开，操作失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    else
                    {
                        //MessageBox.Show("Do not open the port", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }

                    return;
                }

                while ((revlen == 0) && (recount != 0))
                {
                    recount--;
                    revlen = ReadWriteIO.comm.BytesToRead;
                }

                if (recount == 0)       //未收到数据
                {
                    return;
                }
                else
                {
                    System.Threading.Thread.Sleep(10);
                    revlen = ReadWriteIO.comm.BytesToRead;
                    ReadWriteIO.comm.Read(revbuf, 0, revlen);
                }
            }
            else
            {
                if (true == ReaderParams.nsStream.CanRead)
                {
                    //ReaderParams.nsStream.Read(revbuf, 0, revbuf.Length);
                    revlen = 0;
                    ReaderParams.nsStream.Write(ReadWriteIO.SendBuf, 0, (len + CMD.FRAME_HEADEND_LEN));//发送测试信息
                }
                else
                {
                    if (0 == ReaderParams.LanguageFlag)
                    {
                        //MessageBox.Show("网口未连接，操作失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    else
                    {
                        //MessageBox.Show("Network port is not connected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }

                    return;
                }


                while ((recount != 0) && (false == ReaderParams.nsStream.DataAvailable))
                {
                    recount--;
                }

                if (recount == 0)       //未收到数据
                {
                    return;
                }
                else
                {
                    System.Threading.Thread.Sleep(100);
                    revlen = ReaderParams.nsStream.Read(revbuf, 0, revbuf.Length);
                }
            }

            //判断是否设置成功
            if (!((revbuf[0] == CMD.FRAME_HEAD_FIRST)
                && (revbuf[1] == CMD.FRAME_HEAD_SECOND)
                && (revbuf[2] == 0x00) && (revbuf[3] == 0x09)
                && (revbuf[4] == CMD.FRAME_CMD_STOP_INVENTORY_RSP)
                && (revbuf[5] == 0x01)))
            {
                return;
            }
        }

        public int checkRevData(byte[] buf, int len)
        {
            //检验帧头是否正确
            if ((buf[0] != CMD.FRAME_HEAD_FIRST) || (buf[1] != CMD.FRAME_HEAD_SECOND))
            {
                return 0;
            }
            //检验帧尾是否正确
            if ((buf[len - 2] != CMD.FRAME_END_MRK_FIRST) || (buf[len - 1] != CMD.FRAME_END_MRK_SECOND))
            {
                return 0;
            }
            //检验校验位是否正确
            if (CheckCRC(buf, (UInt16)len) == false)
            {
                return 0;
            }
            //检验长度是否正确
            if (len != ((buf[2] << 8) + buf[3]))
            {
                return 0;
            }
            //检验cmd位
            switch (buf[4])
            {
                case CMD.FRAME_CMD_FAILD_RSP:

                    return 1;

                case CMD.FRAME_CMD_INVENTORY_SINGLE_RSP:

                    return CMD.FRAME_CMD_INVENTORY_SINGLE_RSP;

                case CMD.FRAME_CMD_INVENTORY_MUL_RSP:

                    return CMD.FRAME_CMD_INVENTORY_MUL_RSP;

                default:
                    break;
            }
            return 3;
        }

        byte ProductCRC(byte[] p, UInt16 len)
        {
            UInt16 i;
            byte crc = 0;

            for (i = 2; i < len; i++)         //计算校验时，帧头和帧尾不计算
            {
                crc ^= p[i];
            }

            return crc;
        }

        bool CheckCRC(byte[] p, UInt16 len)
        {
            UInt16 i;
            byte crc = 0;

            for (i = 2; i < (len - 3); i++)         //计算校验时，帧头和帧尾不计算
            {
                crc ^= p[i];
            }

            if (crc != p[len - 3])
            {
                return false;
            }

            return true;
        }

        void AddTagToBuf(TagInfo tag)
        {
            string keystr = tag.epcid;

            if (m_Tags.ContainsKey(keystr))
            {
                m_Tags[keystr].readcnt += 1;
                //m_Tags[keystr].epcid = tag.;
                m_Tags[keystr].rxrssi = tag.rxrssi;
                m_Tags[keystr].antID = tag.antID;
                m_Tags[keystr].times = tag.times;
                m_Tags[keystr].tid = tag.tid;
            }
            else
            {
                m_Tags.Add(keystr, tag);
            }
        }

        public void UpdataListViewDisp(TagInfo tag)
        {
            //strResult += tag.epcid + " | " + tag.rxrssi + '\n';
            int flag = 0;
            if (strResult != null)
            {
                if (strResult.Contains(tag.epcid.Replace("-", "")) == true)
                {

                    flag = 1;
                }
            }

            if (flag == 0)
            {

                strResult += tag.epcid.Replace("-", "") + '\n';
                
                DIP_RFID.DAL.Common.Utilities.Func.InsertModuleTemp("1", tag.epcid.Replace("-", "").Substring(0,10));
            }
            //foreach (DataRow Dr in dtResult.Rows)
            //{
            //    try
            //    {
            //        if (Dr["TagID"].ToString().ToLower() == Convert.ToString(tag.epcid).ToLower())
            //        {
            //            Dr["RSSI"] = tag.rxrssi.ToString();
            //            Dr["AntID"] = tag.antID.ToString();
            //            Dr["Time"] = tag.times.ToString();
            //            Dr.AcceptChanges();
            //            flag = 1;
            //        }

            //    }
            //    catch (Exception e) { }


            //    if (flag == 0)
            //    {
            //        DataRow newCustomersRow = dtResult.NewRow();
            //        //ListViewItem item = new ListViewItem((listView_Disp.Items.Count + 1).ToString());
            //        newCustomersRow["TagID"] = tag.epcid;
            //        newCustomersRow["AntID"] = tag.antID;
            //        newCustomersRow["RSSI"] = tag.rxrssi;
            //        newCustomersRow["Time"] = tag.times;
            //        dtResult.Rows.Add(newCustomersRow);
            //    }
            //}

        }

        private bool IsReceiveData()
        {
            int recount = 50000;     //重试次数
            int revlen = 0;         //接收数据长度
            bool retval = false;

            if (RevDataFrom232.IsAlive == false)
            {
                return false;
            }

            if (1 == ReaderParams.CommIntSelectFlag)
            {
                while ((revlen == 0) && (recount != 0))
                {
                    recount--;
                    if (RevDataFrom232.IsAlive == false)
                    {
                        return retval;
                    }
                    revlen = ReadWriteIO.comm.BytesToRead;
                }

                if ((recount != 0) || (revlen != 0))       //未收到数据
                {
                    retval = true;
                }
            }
            else
            {
                while ((recount != 0) && (false == ReaderParams.nsStream.DataAvailable))
                {
                    recount--;
                }

                if (recount != 0)       //未收到数据
                {
                    retval = true;
                }
            }

            return retval;
        }

        private bool GetOneByteRxData(Byte[] ch)
        {
            byte[] tmpBuf = new byte[10];
            int tmpSize = 0;

            if (1 == ReaderParams.CommIntSelectFlag)
            {
                tmpSize = ReadWriteIO.comm.Read(tmpBuf, 0, 1);
            }
            else
            {
                tmpSize = ReaderParams.nsStream.Read(tmpBuf, 0, 1);
            }

            if (1 == tmpSize)
            {
                ch[0] = tmpBuf[0];
                return true;
            }
            else
            {
                return false;
            }
        }

        void PraseMFrameData(Byte ch)
        {
            if (u8HeadCnt < 5)
            {
                switch (u8HeadCnt)
                {
                    case 0:															// 帧头
                        if (CMD.FRAME_HEAD_FIRST == ch)
                        {
                            g_Revbuf[0] = ch;
                            u8HeadCnt++;
                        }
                        break;

                    case 1:
                        if (CMD.FRAME_HEAD_SECOND == ch)								// 帧头
                        {
                            g_Revbuf[1] = ch;
                            u8HeadCnt++;
                        }
                        else
                        {
                            u8HeadCnt = 0;
                        }
                        checkbyte = 0;
                        break;

                    case 2:															// 帧长度，高字节
                        if (ch >= 0x01)
                        {
                            u8HeadCnt = 0;
                        }
                        else
                        {
                            g_Revbuf[2] = ch;
                            checkbyte ^= ch;
                            g_RevDataLen = (UInt16)(ch << 8);
                            u8HeadCnt++;
                        }
                        break;

                    case 3:															// 帧长度，低字节
                        g_Revbuf[3] = ch;
                        checkbyte ^= ch;
                        g_RevDataLen += ch;
                        u8HeadCnt++;

                        break;

                    case 4:															// 帧类型
                        g_Revbuf[4] = ch;
                        u8HeadCnt++;
                        checkbyte ^= ch;
                        u8DataPointer = 0;

                        break;

                    default:
                        break;
                }
            }
            else if (u8DataPointer < (g_RevDataLen - CMD.FRAME_HEADEND_LEN))            // 帧数据
            {
                g_Revbuf[CMD.FRAME_HEAD_LEN + u8DataPointer] = ch;
                checkbyte ^= ch;
                u8DataPointer++;
            }
            else if (u8DataPointer == (g_RevDataLen - CMD.FRAME_HEADEND_LEN))           // 校验位
            {
                if (checkbyte == ch)
                {
                    g_Revbuf[CMD.FRAME_HEAD_LEN + u8DataPointer] = ch;
                    u8DataPointer++;
                }
                else																// 校验位错误
                {
                    u8HeadCnt = 0;
                    u8DataPointer = 0;
                }
            }
            else if (u8DataPointer == (g_RevDataLen - CMD.FRAME_HEADEND_LEN + 1))       // 帧尾
            {
                if (CMD.FRAME_END_MRK_FIRST == ch)
                {
                    g_Revbuf[CMD.FRAME_HEAD_LEN + u8DataPointer] = ch;
                    u8DataPointer++;
                }
                else
                {
                    u8HeadCnt = 0;
                    u8DataPointer = 0;
                }
            }
            else if (u8DataPointer == (g_RevDataLen - CMD.FRAME_HEADEND_LEN + 2))       // 帧尾
            {
                if (CMD.FRAME_END_MRK_SECOND == ch)
                {
                    g_Revbuf[CMD.FRAME_HEAD_LEN + u8DataPointer] = ch;
                    bCheckRet = true;
                    bGetDataComplete = true;
                }

                u8HeadCnt = 0;
                u8DataPointer = 0;
            }
            else
            {
                u8HeadCnt = 0;
                u8DataPointer = 0;
            }
        }

        bool ParseMulReadFrameDataProcess()
        {
            string epc_tmp = "";
            string tid_tmp = "";
            byte[] byte_epc = new byte[64];
            byte[] byte_tid = new byte[64];
            byte[] byte_rssi = new byte[2];
            Int16 rssi;
            int antid;
            DateTime nowTime = DateTime.Now;
            TagInfo tmp = new TagInfo("", 0, 0, 1, nowTime);
            int length = 0;
            int rlength = 0;
            int i;

            length = (g_Revbuf[5] >> 3) * 2;
            rlength = (g_Revbuf[2] << 8) + g_Revbuf[3];

            System.Array.Copy(g_Revbuf, 7, byte_epc, 0, length);
            for (i = 0; i < length; i++)
            {
                epc_tmp += byte_epc[i].ToString("X2");
                if (i < length - 1)
                {
                    epc_tmp += "-";
                }
            }

            if (rlength > (length + 8 + 5))
            {
                System.Array.Copy(g_Revbuf, (7 + length), byte_tid, 0, length);
                for (i = 0; i < (rlength - length - 8 - 5); i++)
                {
                    tid_tmp += byte_tid[i].ToString("X2");
                    if (i < length - 1)
                    {
                        tid_tmp += "-";
                    }
                }
            }

            rssi = (Int16)(g_Revbuf[rlength - 6] << 8);
            rssi += (Int16)(g_Revbuf[rlength - 5]);
            antid = g_Revbuf[rlength - 4];
            tmp.epcid = epc_tmp;
            tmp.tid = tid_tmp;
            tmp.rxrssi = (Int16)(rssi / 10);
            tmp.readcnt = 1;
            tmp.antID = antid;

            AddTagToBuf(tmp);
            //MyInvoke mi = new MyInvoke(UpdataListViewDisp);
            //this.BeginInvoke(mi, new Object[] { m_Tags[tmp.epcid] });

            Thread thread = new Thread(() => UpdataListViewDisp(m_Tags[tmp.epcid]));
            thread.Start();

            return true;
        }

        Byte Handle_Uart_Command()
        {
            Byte retval = 0;

            if ((true == bGetDataComplete) && (true == bCheckRet))
            {
                switch (g_Revbuf[4])
                {
                    case CMD.FRAME_CMD_INVENTORY_MUL_RSP:
                        {
                            if (true == ParseMulReadFrameDataProcess())
                            {

                                retval = 1;
                            }
                            break;
                        }

                    default:                            // default reply error
                        {
                            break;
                        }
                }

                bCheckRet = false;
                bGetDataComplete = false;
            }

            return retval;
        }

        private void ReceiveDataFromUART()
        {
            byte[] buf = new byte[2];

            if (RevDataFrom232.IsAlive == false)
            {
                return;
            }

            while (true)
            {
                if (RevDataFrom232.IsAlive == false)
                {
                    return;
                }

                if (IsReceiveData())
                {
                    if (GetOneByteRxData(buf))					// 从接收数据中取出一个字节
                    {
                        PraseMFrameData(buf[0]);
                    }
                }

                if (1 == Handle_Uart_Command())		            // 成功接收一帧数据
                {

                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Initiate();
            Connect(strPort, strBaudrate, "open");
            MultiRead("Multiple");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MultiRead("Stop");
            Connect(strPort, strBaudrate, "close");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            IniFile iniFile = new IniFile(INIFlieName);
            strPort = iniFile.IniReadValue("SETTING", "RF_ComPort");
            strBaudrate = iniFile.IniReadValue("SETTING", "RF_BaudRate");
            strReadtime = iniFile.IniReadValue("SETTING", "RF_ReadTime");
            strMethod = iniFile.IniReadValue("SETTING", "RF_Method");

            button1_Click(null, null);
            System.Threading.Thread.Sleep(Convert.ToInt16(strReadtime) * 1000);
            button2_Click(null, null);
            System.Environment.Exit(0);
        }

       


    }
}
