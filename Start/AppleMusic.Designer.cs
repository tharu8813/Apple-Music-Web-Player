namespace AppleMusicWebPlayer.Start {
    partial class AppleMusic {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AppleMusic));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.appleMusicToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.실행ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.정보ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.설정ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.항상위에표시ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.상탄컨트롤바상시표시ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.항상표시ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.숨기기ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.종료ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.종료시프로그램종료ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.최소화ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.물어보기ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.최소화설정ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.최소화ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.백그라운드실행ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.ㅈToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.webView21 = new Microsoft.Web.WebView2.WinForms.WebView2();
            this.contextMenuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.webView21)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.appleMusicToolStripMenuItem,
            this.toolStripSeparator1,
            this.실행ToolStripMenuItem,
            this.정보ToolStripMenuItem,
            this.설정ToolStripMenuItem,
            this.toolStripSeparator2,
            this.ㅈToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.contextMenuStrip1.Size = new System.Drawing.Size(142, 126);
            // 
            // appleMusicToolStripMenuItem
            // 
            this.appleMusicToolStripMenuItem.Image = global::AppleMusicWebPlayer.Properties.Resources.icon;
            this.appleMusicToolStripMenuItem.Name = "appleMusicToolStripMenuItem";
            this.appleMusicToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.appleMusicToolStripMenuItem.Text = "Apple Music";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(138, 6);
            // 
            // 실행ToolStripMenuItem
            // 
            this.실행ToolStripMenuItem.Name = "실행ToolStripMenuItem";
            this.실행ToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.실행ToolStripMenuItem.Text = "실행";
            this.실행ToolStripMenuItem.Click += new System.EventHandler(this.OnShowMenuItemClick);
            // 
            // 정보ToolStripMenuItem
            // 
            this.정보ToolStripMenuItem.Name = "정보ToolStripMenuItem";
            this.정보ToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.정보ToolStripMenuItem.Text = "정보";
            this.정보ToolStripMenuItem.Click += new System.EventHandler(this.OnInfoMenuItemClick);
            // 
            // 설정ToolStripMenuItem
            // 
            this.설정ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.항상위에표시ToolStripMenuItem,
            this.상탄컨트롤바상시표시ToolStripMenuItem,
            this.종료ToolStripMenuItem,
            this.최소화설정ToolStripMenuItem});
            this.설정ToolStripMenuItem.Name = "설정ToolStripMenuItem";
            this.설정ToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.설정ToolStripMenuItem.Text = "설정";
            // 
            // 항상위에표시ToolStripMenuItem
            // 
            this.항상위에표시ToolStripMenuItem.CheckOnClick = true;
            this.항상위에표시ToolStripMenuItem.Name = "항상위에표시ToolStripMenuItem";
            this.항상위에표시ToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.항상위에표시ToolStripMenuItem.Text = "항상 위에 표시";
            this.항상위에표시ToolStripMenuItem.Click += new System.EventHandler(this.OnAlwaysOnTopMenuItemClick);
            // 
            // 상탄컨트롤바상시표시ToolStripMenuItem
            // 
            this.상탄컨트롤바상시표시ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.항상표시ToolStripMenuItem,
            this.숨기기ToolStripMenuItem});
            this.상탄컨트롤바상시표시ToolStripMenuItem.Name = "상탄컨트롤바상시표시ToolStripMenuItem";
            this.상탄컨트롤바상시표시ToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.상탄컨트롤바상시표시ToolStripMenuItem.Text = "상단 컨트롤바";
            // 
            // 항상표시ToolStripMenuItem
            // 
            this.항상표시ToolStripMenuItem.Name = "항상표시ToolStripMenuItem";
            this.항상표시ToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.항상표시ToolStripMenuItem.Text = "항상 표시";
            // 
            // 숨기기ToolStripMenuItem
            // 
            this.숨기기ToolStripMenuItem.Name = "숨기기ToolStripMenuItem";
            this.숨기기ToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.숨기기ToolStripMenuItem.Text = "숨기기";
            // 
            // 종료ToolStripMenuItem
            // 
            this.종료ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.종료시프로그램종료ToolStripMenuItem,
            this.최소화ToolStripMenuItem,
            this.물어보기ToolStripMenuItem});
            this.종료ToolStripMenuItem.Name = "종료ToolStripMenuItem";
            this.종료ToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.종료ToolStripMenuItem.Text = "종료 설정";
            // 
            // 종료시프로그램종료ToolStripMenuItem
            // 
            this.종료시프로그램종료ToolStripMenuItem.Name = "종료시프로그램종료ToolStripMenuItem";
            this.종료시프로그램종료ToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.종료시프로그램종료ToolStripMenuItem.Text = "종료";
            // 
            // 최소화ToolStripMenuItem
            // 
            this.최소화ToolStripMenuItem.Name = "최소화ToolStripMenuItem";
            this.최소화ToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.최소화ToolStripMenuItem.Text = "최소화";
            // 
            // 물어보기ToolStripMenuItem
            // 
            this.물어보기ToolStripMenuItem.Name = "물어보기ToolStripMenuItem";
            this.물어보기ToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.물어보기ToolStripMenuItem.Text = "물어보기";
            // 
            // 최소화설정ToolStripMenuItem
            // 
            this.최소화설정ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.최소화ToolStripMenuItem1,
            this.백그라운드실행ToolStripMenuItem});
            this.최소화설정ToolStripMenuItem.Name = "최소화설정ToolStripMenuItem";
            this.최소화설정ToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.최소화설정ToolStripMenuItem.Text = "최소화 설정";
            // 
            // 최소화ToolStripMenuItem1
            // 
            this.최소화ToolStripMenuItem1.Name = "최소화ToolStripMenuItem1";
            this.최소화ToolStripMenuItem1.Size = new System.Drawing.Size(162, 22);
            this.최소화ToolStripMenuItem1.Text = "최소화";
            // 
            // 백그라운드실행ToolStripMenuItem
            // 
            this.백그라운드실행ToolStripMenuItem.Name = "백그라운드실행ToolStripMenuItem";
            this.백그라운드실행ToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.백그라운드실행ToolStripMenuItem.Text = "백그라운드 실행";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(138, 6);
            // 
            // ㅈToolStripMenuItem
            // 
            this.ㅈToolStripMenuItem.Name = "ㅈToolStripMenuItem";
            this.ㅈToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.ㅈToolStripMenuItem.Text = "종료";
            this.ㅈToolStripMenuItem.Click += new System.EventHandler(this.OnExitMenuItemClick);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Apple Music";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.DoubleClick += new System.EventHandler(this.NotifyIcon_DoubleClick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DimGray;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.ForeColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(5, 5);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(3);
            this.panel1.Size = new System.Drawing.Size(841, 32);
            this.panel1.TabIndex = 1;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.White;
            this.button3.Dock = System.Windows.Forms.DockStyle.Right;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("한컴 말랑말랑 Bold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button3.ForeColor = System.Drawing.Color.Black;
            this.button3.Location = new System.Drawing.Point(738, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(26, 24);
            this.button3.TabIndex = 4;
            this.button3.Text = "_";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // panel4
            // 
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(764, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(10, 24);
            this.panel4.TabIndex = 6;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.White;
            this.button2.Dock = System.Windows.Forms.DockStyle.Right;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("한컴 말랑말랑 Bold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button2.ForeColor = System.Drawing.Color.Black;
            this.button2.Location = new System.Drawing.Point(774, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(26, 24);
            this.button2.TabIndex = 3;
            this.button2.Text = "□";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Location = new System.Drawing.Point(23, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Apple Music";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Image = global::AppleMusicWebPlayer.Properties.Resources.download_removebg_preview;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(20, 24);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(800, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(10, 24);
            this.panel3.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Red;
            this.button1.Dock = System.Windows.Forms.DockStyle.Right;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("한컴 말랑말랑 Bold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button1.Location = new System.Drawing.Point(810, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(26, 24);
            this.button1.TabIndex = 2;
            this.button1.Text = "X";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.webView21);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(5, 37);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(841, 512);
            this.panel2.TabIndex = 2;
            // 
            // webView21
            // 
            this.webView21.AllowExternalDrop = true;
            this.webView21.BackColor = System.Drawing.Color.White;
            this.webView21.CreationProperties = null;
            this.webView21.DefaultBackgroundColor = System.Drawing.Color.White;
            this.webView21.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webView21.Location = new System.Drawing.Point(0, 0);
            this.webView21.Name = "webView21";
            this.webView21.Size = new System.Drawing.Size(839, 510);
            this.webView21.Source = new System.Uri("https://music.apple.com/kr/", System.UriKind.Absolute);
            this.webView21.TabIndex = 3;
            this.webView21.ZoomFactor = 1D;
            this.webView21.KeyDown += new System.Windows.Forms.KeyEventHandler(this.webView21_KeyDown);
            // 
            // AppleMusic
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(851, 554);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(290, 480);
            this.Name = "AppleMusic";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Apple Music";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.webView21_KeyDown);
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.webView21)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem appleMusicToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem 실행ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 정보ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 설정ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem ㅈToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 항상위에표시ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 상탄컨트롤바상시표시ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 항상표시ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 숨기기ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 종료ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 종료시프로그램종료ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 최소화ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 물어보기ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 최소화설정ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 최소화ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 백그라운드실행ToolStripMenuItem;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private Microsoft.Web.WebView2.WinForms.WebView2 webView21;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
    }
}