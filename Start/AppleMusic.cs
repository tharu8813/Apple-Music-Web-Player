using AppleMusicProject.Tools;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace AppleMusicProject.Start {
    public partial class AppleMusic : Form {
        int[] formSize = { 0, 0 }; // 폼의 크기를 저장하는 변수
        int[] formLocation = { 0, 0 }; // 폼의 위치를 저장하는 변수

        private bool isFullScreen = false; // 전체 화면 모드 상태를 저장하는 변수
        private FormBorderStyle originalFormBorderStyle;
        private FormWindowState originalWindowState;

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HTCAPTION = 0x2;

        private void panel1_MouseDown(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) // 왼쪽 클릭일 때만
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }


        public AppleMusic() {
            InitializeComponent();
        }

        private void ToggleFullScreen() {
            if (isFullScreen) {
                FormBorderStyle = originalFormBorderStyle;
                WindowState = originalWindowState;
                TopMost = false;
                Location = new Point(formLocation[0], formLocation[1]);
                Size = new Size(formSize[0], formSize[1]);
                isFullScreen = false;
            } else {
                originalFormBorderStyle = FormBorderStyle;
                originalWindowState = WindowState;
                formSize[0] = Size.Width;
                formSize[1] = Size.Height;
                formLocation[0] = Location.X;
                formLocation[1] = Location.Y;

                WindowState = FormWindowState.Normal;
                FormBorderStyle = FormBorderStyle.None;
                WindowState = FormWindowState.Maximized;
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
                TopMost = false; // 메시지 박스가 보이도록 최상위 속성 해제
            }
            DialogResult rs = MessageBox.Show("종료하시겠습니까?", "종료", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes) {
                Tool.notifyIcon.Visible = false;
                Environment.Exit(0);
            } else {
                if (Tool.alwaysOnTopMenuItem.Checked) {
                    TopMost = true; // 다시 최상위 속성 설정
                }
            }
        }

        private void ShowInformationForm() {
            if (Tool.alwaysOnTopMenuItem.Checked) {
                TopMost = false; // 메시지 박스가 보이도록 최상위 속성 해제
            }
            new Info().ShowDialog();
            if (Tool.alwaysOnTopMenuItem.Checked) {
                TopMost = true; // 다시 최상위 속성 설정
            }
        }

        protected override void OnResize(EventArgs e) {
            base.OnResize(e);
            if (this.WindowState == FormWindowState.Minimized) {
                HideForm();
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e) {
            DialogResult rs = MessageBox.Show("최소화(백그라운드)로 실행하시겠습니까?", "종료", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes) {
                e.Cancel = true;
                HideForm();
            } else if (rs == DialogResult.No) {
                Environment.Exit(0);
            } else {
                e.Cancel = true;
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

            int resizeArea = 5; // 크기 조절 가능한 테두리 영역 두께(px)

            if (m.Msg == WM_NCHITTEST) {
                base.WndProc(ref m);

                if ((int)m.Result == HTCLIENT) {
                    Point cursor = PointToClient(Cursor.Position);

                    // 왼쪽
                    if (cursor.X <= resizeArea) {
                        if (cursor.Y <= resizeArea)
                            m.Result = (IntPtr)HTTOPLEFT;
                        else if (cursor.Y >= ClientSize.Height - resizeArea)
                            m.Result = (IntPtr)HTBOTTOMLEFT;
                        else
                            m.Result = (IntPtr)HTLEFT;
                        return;
                    }
                    // 오른쪽
                    else if (cursor.X >= ClientSize.Width - resizeArea) {
                        if (cursor.Y <= resizeArea)
                            m.Result = (IntPtr)HTTOPRIGHT;
                        else if (cursor.Y >= ClientSize.Height - resizeArea)
                            m.Result = (IntPtr)HTBOTTOMRIGHT;
                        else
                            m.Result = (IntPtr)HTRIGHT;
                        return;
                    }
                    // 위쪽
                    else if (cursor.Y <= resizeArea) {
                        m.Result = (IntPtr)HTTOP;
                        return;
                    }
                    // 아래쪽
                    else if (cursor.Y >= ClientSize.Height - resizeArea) {
                        m.Result = (IntPtr)HTBOTTOM;
                        return;
                    }
                }
                return;
            }

            base.WndProc(ref m);
        }

        private void webView21_Click(object sender, EventArgs e) {

        }

        private void button1_Click(object sender, EventArgs e) => Close();

        private void button3_Click(object sender, EventArgs e) => WindowState = FormWindowState.Minimized;

        private void button2_Click(object sender, EventArgs e) => WindowState = FormWindowState.Maximized;

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Right) {
                contextMenuStrip1.Show(Cursor.Position);
            }
        }
    }
}