using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SI_C
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLocate_Click(object sender, EventArgs e)
        {
            frmTest frm = new frmTest();
            //frm.Location = new Point(10,0);
            frm.Show();
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            frmCheckOut frm = new frmCheckOut();
            frm.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

            frmCheckIn frm = new frmCheckIn();
            frm.Show();
        }
    }
}