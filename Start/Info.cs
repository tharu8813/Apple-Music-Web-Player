using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace AppleMusicWebPlayer.Start {
    public partial class Info : Form {
        public Info() {
            InitializeComponent();

            // 닫기 버튼에 호버 효과
            btnClose.MouseEnter += (s, e) => {
                btnClose.BackColor = System.Drawing.Color.FromArgb(0, 100, 220);
            };
            btnClose.MouseLeave += (s, e) => {
                btnClose.BackColor = System.Drawing.Color.FromArgb(0, 122, 255);
            };

            lblVersion.Text = $"버전: {Application.ProductVersion}";
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            try {
                Process.Start(new ProcessStartInfo {
                    FileName = "https://music.apple.com/",
                    UseShellExecute = true
                });
            } catch (Exception ex) {
                MessageBox.Show($"웹 브라우저를 열 수 없습니다: {ex.Message}",
                    "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void linkGithub_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            try {
                Process.Start(new ProcessStartInfo {
                    FileName = "https://github.com/tharu8813", // 실제 GitHub 주소로 변경하세요
                    UseShellExecute = true
                });
            } catch (Exception ex) {
                MessageBox.Show($"웹 브라우저를 열 수 없습니다: {ex.Message}",
                    "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e) {
            this.Close();
        }
    }
}