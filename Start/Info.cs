using System.Diagnostics;
using System.Windows.Forms;

namespace AppleMusicProject.Start {
    public partial class Info : Form {
        public Info() {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            Process.Start(new ProcessStartInfo {
                FileName = "https://music.apple.com/",
                UseShellExecute = true
            });
        }
    }
}
