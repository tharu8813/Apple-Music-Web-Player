using AppleMusicProject.Tools;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace AppleMusicProject.Start {
    public partial class AppleMusic : Form {
        int[] formSize = { 0, 0 };
        int[] formLocation = { 0, 0 };

        private bool isFullScreen = false;
        private FormBorderStyle originalFormBorderStyle;
        private FormWindowState originalWindowState;

        // 설정 저장 변수들
        private Tool.ExitReason exitBehavior = Tool.ExitReason.확인;  // ✅ 기본값을 '확인'으로 수정
        private Tool.HideForm hideBehavior = Tool.HideForm.백그라운드실행;
        private Tool.TopControl topControlBehavior = Tool.TopControl.항상표시;

        // 마우스 오버 타이머
        private Timer hideTimer;

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HTCAPTION = 0x2;

        private void panel1_MouseDown(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }

        public AppleMusic() {
            InitializeComponent();
            InitializeToolClass();
            InitializeTimer();
            LoadSettings();
            InitializeMenus();
            ApplyTopControlBehavior();

            notifyIcon1.ContextMenuStrip = contextMenuStrip1;
        }

        private void InitializeTimer() {
            hideTimer = new Timer();
            hideTimer.Interval = 800;
            hideTimer.Tick += HideTimer_Tick;
        }

        private void HideTimer_Tick(object sender, EventArgs e) {
            Point mousePos = this.PointToClient(Cursor.Position);
            Rectangle panel1Rect = new Rectangle(panel1.Location, panel1.Size);

            if (!panel1Rect.Contains(mousePos)) {
                panel1.Visible = false;
                hideTimer.Stop();
            }
        }

        private void LoadSettings() {
            // ✅ ExitOption 설정 로드 (수정됨)
            string exitOption = Properties.Settings.Default.ExitOption;
            if (string.IsNullOrEmpty(exitOption)) {
                exitBehavior = Tool.ExitReason.확인;  // 기본값
            } else if (exitOption == "Exit") {
                exitBehavior = Tool.ExitReason.닫기;
            } else if (exitOption == "Background") {
                exitBehavior = Tool.ExitReason.백그라운드실행;
            } else if (exitOption == "Ask") {
                exitBehavior = Tool.ExitReason.확인;
            } else {
                exitBehavior = Tool.ExitReason.확인;  // 알 수 없는 값일 경우 기본값
            }

            // ✅ TapShow 설정 로드 (간소화)
            string tapShow = Properties.Settings.Default.TapShow;
            if (string.IsNullOrEmpty(tapShow) || tapShow == "AlwaysShow") {
                topControlBehavior = Tool.TopControl.항상표시;
            } else if (tapShow == "Hide") {
                topControlBehavior = Tool.TopControl.표시하지않음;
            } else {
                topControlBehavior = Tool.TopControl.항상표시;  // 기본값
            }

            // ✅ MinimizeOption 설정 로드 (안전성 개선)
            string minimizeOption = Properties.Settings.Default.MinimizeOption;
            if (string.IsNullOrEmpty(minimizeOption) || minimizeOption == "Background") {
                hideBehavior = Tool.HideForm.백그라운드실행;
            } else if (minimizeOption == "Minimize") {
                hideBehavior = Tool.HideForm.최소화;
            } else {
                hideBehavior = Tool.HideForm.백그라운드실행;  // 기본값
            }
        }

        private void SaveSettings() {
            // ✅ ExitOption 설정 저장 (수정됨)
            if (exitBehavior == Tool.ExitReason.닫기) {
                Properties.Settings.Default.ExitOption = "Exit";
            } else if (exitBehavior == Tool.ExitReason.백그라운드실행) {
                Properties.Settings.Default.ExitOption = "Background";
            } else if (exitBehavior == Tool.ExitReason.확인) {
                Properties.Settings.Default.ExitOption = "Ask";
            } else {
                Properties.Settings.Default.ExitOption = "Ask";  // 기본값
            }

            // TapShow 설정 저장
            if (topControlBehavior == Tool.TopControl.항상표시) {
                Properties.Settings.Default.TapShow = "AlwaysShow";
            } else if (topControlBehavior == Tool.TopControl.표시하지않음) {
                Properties.Settings.Default.TapShow = "Hide";
            }

            // MinimizeOption 설정 저장
            if (hideBehavior == Tool.HideForm.최소화) {
                Properties.Settings.Default.MinimizeOption = "Minimize";
            } else if (hideBehavior == Tool.HideForm.백그라운드실행) {
                Properties.Settings.Default.MinimizeOption = "Background";
            }

            Properties.Settings.Default.Save();
        }

        private void InitializeToolClass() {
            Tool.notifyIcon = this.notifyIcon1;
            Tool.contextMenu = this.contextMenuStrip1;
            Tool.alwaysOnTopMenuItem = this.항상위에표시ToolStripMenuItem;
        }

        private void InitializeMenus() {
            // 종료 설정 메뉴 초기화
            종료시프로그램종료ToolStripMenuItem.Click += (s, e) => SetExitBehavior(Tool.ExitReason.닫기);
            최소화ToolStripMenuItem.Click += (s, e) => SetExitBehavior(Tool.ExitReason.백그라운드실행);
            물어보기ToolStripMenuItem.Click += (s, e) => SetExitBehavior(Tool.ExitReason.확인);  // ✅ 수정됨

            // 최소화 설정 메뉴 초기화
            최소화ToolStripMenuItem1.Click += (s, e) => SetHideBehavior(Tool.HideForm.최소화);
            백그라운드실행ToolStripMenuItem.Click += (s, e) => SetHideBehavior(Tool.HideForm.백그라운드실행);

            // 상단 컨트롤바 메뉴 초기화
            항상표시ToolStripMenuItem.Click += (s, e) => SetTopControlBehavior(Tool.TopControl.항상표시);
            숨기기ToolStripMenuItem.Click += (s, e) => SetTopControlBehavior(Tool.TopControl.표시하지않음);

            // 초기 체크 상태 설정
            UpdateExitMenuChecks();
            UpdateHideMenuChecks();
            UpdateTopControlMenuChecks();
        }

        private void SetExitBehavior(Tool.ExitReason behavior) {
            exitBehavior = behavior;
            UpdateExitMenuChecks();
            SaveSettings();
        }

        private void UpdateExitMenuChecks() {
            종료시프로그램종료ToolStripMenuItem.Checked = (exitBehavior == Tool.ExitReason.닫기);
            최소화ToolStripMenuItem.Checked = (exitBehavior == Tool.ExitReason.백그라운드실행);
            물어보기ToolStripMenuItem.Checked = (exitBehavior == Tool.ExitReason.확인);  // ✅ 수정됨
        }

        private void SetHideBehavior(Tool.HideForm behavior) {
            hideBehavior = behavior;
            UpdateHideMenuChecks();
            SaveSettings();
        }

        private void UpdateHideMenuChecks() {
            최소화ToolStripMenuItem1.Checked = (hideBehavior == Tool.HideForm.최소화);
            백그라운드실행ToolStripMenuItem.Checked = (hideBehavior == Tool.HideForm.백그라운드실행);
        }

        private void SetTopControlBehavior(Tool.TopControl behavior) {
            topControlBehavior = behavior;
            UpdateTopControlMenuChecks();
            ApplyTopControlBehavior();
            SaveSettings();
        }

        private void UpdateTopControlMenuChecks() {
            항상표시ToolStripMenuItem.Checked = (topControlBehavior == Tool.TopControl.항상표시);
            숨기기ToolStripMenuItem.Checked = (topControlBehavior == Tool.TopControl.표시하지않음);
        }

        private void ApplyTopControlBehavior() {
            if (topControlBehavior == Tool.TopControl.항상표시) {
                panel1.Visible = true;
            } else {
                panel1.Visible = false;
            }
        }

        private void ToggleFullScreen() {
            if (isFullScreen) {
                // 전체화면 해제
                FormBorderStyle = originalFormBorderStyle;
                WindowState = originalWindowState;
                TopMost = false;
                Location = new Point(formLocation[0], formLocation[1]);
                Size = new Size(formSize[0], formSize[1]);
                isFullScreen = false;

                // 상단 바와 테두리 다시 표시
                panel1.Visible = true;
                this.Padding = new Padding(5);
                panel2.BorderStyle = BorderStyle.FixedSingle;

                ApplyTopControlBehavior();
            } else {
                // 전체화면 진입
                originalFormBorderStyle = FormBorderStyle;
                originalWindowState = WindowState;
                formSize[0] = Size.Width;
                formSize[1] = Size.Height;
                formLocation[0] = Location.X;
                formLocation[1] = Location.Y;

                // 상단 바와 테두리 완전히 숨김
                panel1.Visible = false;
                this.Padding = new Padding(0);
                panel2.BorderStyle = BorderStyle.None;

                // 전체화면 설정
                FormBorderStyle = FormBorderStyle.None;
                WindowState = FormWindowState.Normal;
                Bounds = Screen.FromControl(this).Bounds;
                TopMost = true;

                isFullScreen = true;
            }
        }

        private void OnAlwaysOnTopMenuItemClick(object sender, EventArgs e) {
            ToolStripMenuItem menuItem = sender as ToolStripMenuItem;
            if (menuItem != null) {
                this.TopMost = menuItem.Checked;
            }
        }

        private void NotifyIcon_DoubleClick(object sender, EventArgs e) {
            ShowForm();
        }

        private void HideForm() {
            this.Hide();
            Tool.notifyIcon.Visible = true;
            Tool.ShowNotification("Apple Music", "Apple Music가 시스템 트레이로 이동되었습니다.\n종료를 원하면 우클릭후 종료해주세요.");
        }

        private void ShowForm() {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.BringToFront();
        }

        private void OnShowMenuItemClick(object sender, EventArgs e) {
            ShowForm();
        }

        private void OnInfoMenuItemClick(object sender, EventArgs e) {
            ShowInformationForm();
        }

        private void OnExitMenuItemClick(object sender, EventArgs e) {
            if (Tool.alwaysOnTopMenuItem.Checked) {
                TopMost = false;
            }
            DialogResult rs = MessageBox.Show("종료하시겠습니까?", "종료", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes) {
                Tool.notifyIcon.Visible = false;
                Environment.Exit(0);
            } else {
                if (Tool.alwaysOnTopMenuItem.Checked) {
                    TopMost = true;
                }
            }
        }

        private void ShowInformationForm() {
            if (Tool.alwaysOnTopMenuItem.Checked) {
                TopMost = false;
            }
            new Info().ShowDialog();
            if (Tool.alwaysOnTopMenuItem.Checked) {
                TopMost = true;
            }
        }

        protected override void OnResize(EventArgs e) {
            base.OnResize(e);
            if (this.WindowState == FormWindowState.Minimized) {
                if (hideBehavior == Tool.HideForm.백그라운드실행) {
                    HideForm();
                }
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e) {
            switch (exitBehavior) {
                case Tool.ExitReason.닫기:
                    Tool.notifyIcon.Visible = false;
                    Environment.Exit(0);
                    break;

                case Tool.ExitReason.백그라운드실행:
                    e.Cancel = true;
                    HideForm();
                    break;

                case Tool.ExitReason.확인:  // ✅ 수정됨
                    DialogResult rs = MessageBox.Show("최소화(백그라운드)로 실행하시겠습니까?", "종료", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    if (rs == DialogResult.Yes) {
                        e.Cancel = true;
                        HideForm();
                    } else if (rs == DialogResult.No) {
                        Tool.notifyIcon.Visible = false;
                        Environment.Exit(0);
                    } else {
                        e.Cancel = true;
                    }
                    break;
            }
        }

        private void webView21_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.F11) {
                ToggleFullScreen();
            }
        }

        protected override void WndProc(ref Message m) {
            const int WM_NCHITTEST = 0x84;
            const int HTCLIENT = 0x1;
            const int HTLEFT = 0xA;
            const int HTRIGHT = 0xB;
            const int HTTOP = 0xC;
            const int HTTOPLEFT = 0xD;
            const int HTTOPRIGHT = 0xE;
            const int HTBOTTOM = 0xF;
            const int HTBOTTOMLEFT = 0x10;
            const int HTBOTTOMRIGHT = 0x11;

            int resizeArea = 5;

            if (m.Msg == WM_NCHITTEST) {
                base.WndProc(ref m);

                if ((int)m.Result == HTCLIENT) {
                    Point cursor = PointToClient(Cursor.Position);

                    if (cursor.X <= resizeArea) {
                        if (cursor.Y <= resizeArea)
                            m.Result = (IntPtr)HTTOPLEFT;
                        else if (cursor.Y >= ClientSize.Height - resizeArea)
                            m.Result = (IntPtr)HTBOTTOMLEFT;
                        else
                            m.Result = (IntPtr)HTLEFT;
                        return;
                    } else if (cursor.X >= ClientSize.Width - resizeArea) {
                        if (cursor.Y <= resizeArea)
                            m.Result = (IntPtr)HTTOPRIGHT;
                        else if (cursor.Y >= ClientSize.Height - resizeArea)
                            m.Result = (IntPtr)HTBOTTOMRIGHT;
                        else
                            m.Result = (IntPtr)HTRIGHT;
                        return;
                    } else if (cursor.Y <= resizeArea) {
                        m.Result = (IntPtr)HTTOP;
                        return;
                    } else if (cursor.Y >= ClientSize.Height - resizeArea) {
                        m.Result = (IntPtr)HTBOTTOM;
                        return;
                    }
                }
                return;
            }

            base.WndProc(ref m);
        }

        private void button1_Click(object sender, EventArgs e) => Close();

        private void button3_Click(object sender, EventArgs e) => WindowState = FormWindowState.Minimized;

        private void button2_Click(object sender, EventArgs e) {
            if (WindowState == FormWindowState.Maximized) {
                WindowState = FormWindowState.Normal;
            } else {
                WindowState = FormWindowState.Maximized;
            }
        }

        // ✅ 폼 종료 시 리소스 정리
        protected override void OnFormClosed(FormClosedEventArgs e) {
            // 타이머 정리
            if (hideTimer != null) {
                hideTimer.Stop();
                hideTimer.Tick -= HideTimer_Tick;
                hideTimer.Dispose();
                hideTimer = null;
            }

            base.OnFormClosed(e);
        }
    }
}