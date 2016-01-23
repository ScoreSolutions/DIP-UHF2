namespace SI_C
{
    partial class frmTest
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTest));
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.button1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.txtSegment3 = new System.Windows.Forms.TextBox();
            this.txtDocNo = new System.Windows.Forms.TextBox();
            this.cboDocType = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(114)))), ((int)(((byte)(183)))));
            this.label1.Font = new System.Drawing.Font("Tahoma", 48F, System.Drawing.FontStyle.Regular);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(66, 123);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 77);
            this.label1.Text = "00";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(71, 262);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(100, 21);
            this.pictureBox4.Click += new System.EventHandler(this.pictureBox4_Click_1);
            // 
            // button1
            // 
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(60, 225);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(122, 34);
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(60, 100);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(122, 122);
            // 
            // txtSegment3
            // 
            this.txtSegment3.Location = new System.Drawing.Point(165, 74);
            this.txtSegment3.Name = "txtSegment3";
            this.txtSegment3.Size = new System.Drawing.Size(54, 23);
            this.txtSegment3.TabIndex = 11;
            // 
            // txtDocNo
            // 
            this.txtDocNo.Location = new System.Drawing.Point(57, 74);
            this.txtDocNo.Name = "txtDocNo";
            this.txtDocNo.Size = new System.Drawing.Size(104, 23);
            this.txtDocNo.TabIndex = 8;
            this.txtDocNo.Text = "300000000000000b000903031400";
            // 
            // cboDocType
            // 
            this.cboDocType.Items.Add("PX");
            this.cboDocType.Items.Add("PL");
            this.cboDocType.Items.Add("PH");
            this.cboDocType.Items.Add("PA");
            this.cboDocType.Items.Add("PM");
            this.cboDocType.Items.Add("PYH");
            this.cboDocType.Items.Add("PU");
            this.cboDocType.Items.Add("PMR");
            this.cboDocType.Items.Add("PT");
            this.cboDocType.Items.Add("PS");
            this.cboDocType.Items.Add("PSC");
            this.cboDocType.Items.Add("PDK");
            this.cboDocType.Items.Add("PCH");
            this.cboDocType.Items.Add("PTYK");
            this.cboDocType.Items.Add("PRP");
            this.cboDocType.Items.Add("PHGK");
            this.cboDocType.Location = new System.Drawing.Point(5, 74);
            this.cboDocType.Name = "cboDocType";
            this.cboDocType.Size = new System.Drawing.Size(51, 23);
            this.cboDocType.TabIndex = 6;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(240, 320);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(114)))), ((int)(((byte)(183)))));
            this.label2.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Regular);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(153, 161);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 30);
            this.label2.Text = "%";
            // 
            // frmTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(493, 308);
            this.ControlBox = false;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.txtSegment3);
            this.Controls.Add(this.txtDocNo);
            this.Controls.Add(this.cboDocType);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Menu = this.mainMenu1;
            this.MinimizeBox = false;
            this.Name = "frmTest";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.Form1_Closing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.MainMenu mainMenu1;
        private System.Windows.Forms.PictureBox button1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox txtSegment3;
        private System.Windows.Forms.TextBox txtDocNo;
        private System.Windows.Forms.ComboBox cboDocType;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;

    }
}

