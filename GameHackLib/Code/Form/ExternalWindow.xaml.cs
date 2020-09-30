using System;
using System.Numerics;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Interop;
using GameHackLib.Code.Win;
using Size = System.Drawing.Size;

namespace GameHackLib.Code.Form
{
    /// <summary>
    /// Логика взаимодействия для RenderSurface.xaml
    /// </summary>
    public partial class ExternalWindow: Window
    {
        public static CanvasDraw Render { get; private set; }
        public static Size ScreenSize { get; private set; }
        public static Vector2 WindowCenter => new Vector2(ScreenSize.Width / 2F, ScreenSize.Height / 2F);

        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);
            var hwnd = new WindowInteropHelper(this).Handle;
            var extendedStyle = WinAPI.GetWindowLong(hwnd, (int) WinAPI.WindowLongFlags.GWL_EXSTYLE);
            WinAPI.SetWindowLong(hwnd, (int)WinAPI.WindowLongFlags.GWL_EXSTYLE, extendedStyle | (int)WinAPI.WindowLongFlags.WS_EX_TRANSPARENT);
        }

        public ExternalWindow()
        {
            InitializeComponent();

            Render = new CanvasDraw(CanvasControl);

            ScreenSize = Screen.PrimaryScreen.Bounds.Size;
        }
    }
}
