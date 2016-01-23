using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Runtime.InteropServices;
using NRfidApi;

namespace SI_C
{
    public partial class frmCheckIn : Form
    {
        ArrayList Tags;
        RfidApi rfid;
        Point PanelLocationShow;
        Point PanelLocationHide;
        Timer timerStop = null;
        ArrayList alKeys = null;

        #region  ########## Play_Sound ##########
        [DllImport("coredll.dll")]
        private static extern int PlaySound(string szSound, IntPtr hModule, int flags);

        private enum PlaySoundFlags : int
        {
            SND_SYNC = 0x0,         // play synchronously (default)
            SND_ASYNC = 0x1,        // play asynchronously
            SND_NODEFAULT = 0x2,    // silence (!default) if sound not found
            SND_MEMORY = 0x4,       // pszSound points to a memory file
            SND_LOOP = 0x8,         // loop the sound until next sndPlaySound
            SND_NOSTOP = 0x10,      // don't stop any currently playing sound
            SND_NOWAIT = 0x2000,    // don't wait if the driver is busy
            SND_ALIAS = 0x10000,    // name is a registry alias
            SND_ALIAS_ID = 0x110000,// alias is a predefined ID
            SND_FILENAME = 0x20000, // name is file name
            SND_RESOURCE = 0x40004, // name is resource name or atom
        };
        public void Play_Sound(string fileName)
        {
            PlaySound(fileName, IntPtr.Zero, (int)(PlaySoundFlags.SND_FILENAME | PlaySoundFlags.SND_ASYNC));
        }
        public void Play_Sound_NOSTOP(string fileName)
        {
            PlaySound(fileName, IntPtr.Zero, (int)(PlaySoundFlags.SND_FILENAME | PlaySoundFlags.SND_ASYNC | PlaySoundFlags.SND_NOSTOP));
        }
        #endregion

        public frmCheckIn()
        {
            InitializeComponent();
        }

        private void btnMainmenu_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //private void frmCheckIn_Load(object sender, EventArgs e)
        //{
        //    this.KeyPreview = true;
        //    this.WindowState = FormWindowState.Maximized;

        //    alKeys = new ArrayList();

        //    // Windows CE Fn Keys
        //    alKeys.Add(Convert.ToInt32(Keys.F7));   // "F7" key
        //    alKeys.Add(Convert.ToInt32(Keys.F8));   // "F8" key
        //    alKeys.Add(Convert.ToInt32(Keys.F9));   // "SCAN" key
        //    alKeys.Add(Convert.ToInt32(Keys.F19));  // Gun trigger

        //    // Windows Mobile Fn Keys
        //    alKeys.Add(Convert.ToInt32(0xEF));      // "F7" key
        //    alKeys.Add(Convert.ToInt32(0xF0));      // "F8" key
        //    alKeys.Add(Convert.ToInt32(0xD3));      // "SCAN" key
        //    alKeys.Add(Convert.ToInt32(0xD2));      // Gun trigger

        //    // windows ce
        //    if (Environment.OSVersion.Version.Minor != 2)
        //    {
        //        this.MaximizeBox = false;
        //        this.Menu = null;

        //        tabControl1.Location = new Point(0, 0);
        //    }

        //    PanelLocationShow = panel1.Location;
        //    PanelLocationHide = panel2.Location;

        //    comboBox1.SelectedIndex = 0;
        //    Tags = new ArrayList();

        //    rfid = new RfidApi();

        //    rfid.PowerOn();

        //    if (rfid.Open() == RFID_RESULT.RFID_RESULT_SUCCESS)
        //    {
        //        //===============================================================================
        //        //  RFID reader tag data read by the application at the end to register 
        //        // callback fuction is called.
        //        rfid.SetCallback(new RfidCallbackProc(CallbackProc));
        //    }
        //    else
        //    {
        //        //  RFID reader module to an authorized power is removed.
        //        rfid.PowerOff();
        //        MessageBox.Show("RFID Open Failed");

        //        this.Close();
        //    }

        //    timerStop = new Timer();
        //    timerStop.Interval = 10;
        //    timerStop.Tick += new EventHandler(timerStop_Tick);
        //}

        //void timerStop_Tick(object sender, EventArgs e)
        //{
        //    timerStop.Enabled = false;
        //    button1_Click(null, null);
        //}

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    // Tag reading on the type of tag(ISO-1800-6B or ISO-18000-6C[GEN2]) can be read by specifying a UID.
        //    RFID_READ_TYPE ReadType;

        //    if (button1.Text.Equals("Start"))
        //    {
        //        button1.Text = "Stop";

        //        ReadType = RFID_READ_TYPE.EPC_GEN2_MULTI_TAG;

        //        // RFID tag reads from the EPC data.
        //        rfid.ReadEpc(false, ReadType, String.Empty);

        //    }
        //    else
        //    {
        //        rfid.Stop();
        //    }
        //}

        //private void frmCheckIn_Closing(object sender, CancelEventArgs e)
        //{
        //    // RFID reader module, open a port for communication with the close.
        //    rfid.Close();
        //    rfid.PowerOff();
        //}

        //public void CallbackProc(RFIDCALLBACKDATA CallbackData)
        //{
        //    string Msg = new string(new char[512]);

        //    // Data GetResult function and read the values separated by a CallbackType Reply to the reporting process.
        //    rfid.GetResult(Msg, CallbackData.CallbackType, CallbackData.wParam, CallbackData.lParam);
        //    Msg = Msg.Substring(0, Msg.IndexOf("\0"));

        //    switch (tabControl1.SelectedIndex)
        //    {
        //        case 0: // Inventory
        //            InventoryProc(Msg, CallbackData.CallbackType);
        //            break;
        //        case 1: // Read/Write
        //            ReadWriteProc(Msg, CallbackData.CallbackType);
        //            break;
        //        case 2: // Lock/Kill
        //            LockKillProc(Msg, CallbackData.CallbackType);
        //            break;
        //        case 3: // Configuration
        //            break;
        //        default:
        //            break;
        //    }

        //}

        //public void InventoryProc(string Msg, RFID_CALLBACK_TYPE Type)
        //{
        //    // Memory modules of the Data from the tags and read through it runs so Callback delegate.
        //    if (Type == RFID_CALLBACK_TYPE.RFIDCALLBACKTYPE_DATA)
        //    {
        //        //if (Tags.Contains(Msg))
        //        //{
        //        //    foreach (ListViewItem item in listView1.Items)
        //        //    {
        //        //        if (item.SubItems[0].Text.Equals(Msg))
        //        //        {
        //        //            item.SubItems[1].Text = Convert.ToString(Convert.ToInt32(item.SubItems[1].Text) + 1);
        //        //            break;
        //        //        }
        //        //    }
        //        //}
        //        //else
        //        //{
        //        //    ListViewItem item = new ListViewItem(Msg);
        //        //    item.SubItems.Add("1");
        //        //    int count = listView1.Items.Count;
        //        //    if (count == 0 || count % 2 == 0)
        //        //        item.BackColor = Color.LightCyan;
        //        //    else
        //        //        item.BackColor = Color.AntiqueWhite;
        //        //    listView1.Items.Add(item);
        //        //    Tags.Add(Msg);
        //        //    label1.Text = Tags.Count.ToString();
        //        //}

        //        //Play_Sound_NOSTOP(@"\Windows\Success.wav");
        //        //}
        //        string strMsg = Msg.Split(',')[0].ToLower();
        //        string intRSSI = Msg.Split(',')[1].Split('=')[1];
        //        string strTag = txtTag.Text.ToLower();
        //        if (strTag == strMsg)
        //        {
        //            //lblStatus.Text = "Found";
        //            lblStatus.Text = Convert.ToString(Convert.ToInt32((((Convert.ToDouble(intRSSI) + (100)) * 100) / (60))));
        //            if (Convert.ToInt16(lblStatus.text) <= 80)
        //            {
        //                Play_Sound_NOSTOP(@"\Windows\Success.wav");
        //            }
        //            else
        //            {
        //                Play_Sound_NOSTOP(@"\Windows\Success.wav");
        //            }
        //        }
        //        else
        //        {
        //            //lblStatus.Text = "0";
        //            //lblStatus.Text = "Not Found";
        //        }
        //    }
        //    // Run from the command module to receive the results of running Callback delegate.
        //    else if (Type == RFID_CALLBACK_TYPE.RFIDCALLBACKTYPE_REPLY)
        //    {
        //        if (Msg.Equals("OK") || Msg.Equals("Multi Read Stop") || Msg.Equals(""))
        //        {
        //            button1.Text = "Start";
        //        }
        //        else
        //        {
        //            MessageBox.Show(Msg);
        //            button1.Text = "Start";
        //        }
        //    }
        //}
    }
}