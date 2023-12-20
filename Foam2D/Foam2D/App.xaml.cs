
//using Android.App;
using Foam2D.Interfaces;

namespace Foam2D
{
    public partial class App : Application, ICenterArea
    {
        private double centerX, centerY;

        public App()
        {
            InitializeComponent();

        }

        public void CenterArea(int width, int height)
        {
            Window win = new Window();

            var displayInfo = DeviceDisplay.Current.MainDisplayInfo;

            this.centerX = ((displayInfo.Width - width) / 2);
            this.centerY = ((displayInfo.Height - height) / 2);

        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            int width = 920;
            int height = 643;

            CenterArea(width, height);

            Window window = new Window(new AppShell())
            {

                Width = width,
                Height = height,
                X = this.centerX,
                Y = this.centerY
            };

            return window;
        }


    }
}
