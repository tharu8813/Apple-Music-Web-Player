using System.Windows.Forms;

namespace AppleMusicProject.Tools {
    /// <summary>
    /// 여러가지 도구를 제공하는 클래스입니다.
    /// </summary>
    internal class Tool {

        public static NotifyIcon notifyIcon;
        public static ContextMenuStrip contextMenu;
        public static ToolStripMenuItem alwaysOnTopMenuItem;

        public static void ShowNotification(string title, string message) {
            notifyIcon.BalloonTipTitle = title;
            notifyIcon.BalloonTipText = message;
            notifyIcon.BalloonTipIcon = ToolTipIcon.None;
            notifyIcon.ShowBalloonTip(3000);
        }

        public enum ExitReason {
            닫기,
            확인,
            백그라운드실행,
            물어보기
        }

        public enum TopControl {
            항상표시,
            표시하지않음
        }

        public enum HideForm {
            최소화,
            백그라운드실행
        }
    }
}
