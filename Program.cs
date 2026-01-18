using AppleMusicWebPlayer.Start;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace AppleMusicWebPlayer {
    internal static class Program {
        private static Mutex mutex = null;

        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("user32.dll")]
        private static extern bool IsIconic(IntPtr hWnd);

        private const int SW_RESTORE = 9;

        private static void BringExistingInstanceToFront() {
            Process current = Process.GetCurrentProcess();
            foreach (Process process in Process.GetProcessesByName(current.ProcessName)) {
                if (process.Id != current.Id) {
                    IntPtr handle = process.MainWindowHandle;
                    if (IsIconic(handle)) {
                        ShowWindow(handle, SW_RESTORE);
                    }
                    SetForegroundWindow(handle);
                    break;
                }
            }
        }

        [STAThread]
        static void Main() {
            bool isNewInstance;
            string mutexName = "AppleMusicWebPlayerMutex"; // 고유한 프로그램 이름
            mutex = new Mutex(true, mutexName, out isNewInstance);

            if (!isNewInstance) {
                // 이미 실행 중인 프로그램에 포커스를 맞추기
                BringExistingInstanceToFront();
                return; // 새로운 인스턴스 종료
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new AppleMusic()); // AppleMusic 폼 실행
        }
    }
}
