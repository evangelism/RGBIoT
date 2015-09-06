using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Gpio;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Документацию по шаблону элемента "Пустая страница" см. по адресу http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace RGBIoT
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        public GpioPin red, green, blue;
        DispatcherTimer dt = new DispatcherTimer() { Interval = TimeSpan.FromSeconds(3) };

        public MainPage()
        {
            this.InitializeComponent();
            var gpio = GpioController.GetDefault();
            red = gpio.OpenPin(5); InitPin(red);
            green = gpio.OpenPin(13); InitPin(green);
            blue = gpio.OpenPin(6); InitPin(blue);
            dt.Tick += Dt_Tick;
            dt.Start();
        }

        private async void Dt_Tick(object sender, object e)
        {
            var Cli = new HttpClient();
            var res = await Cli.GetStringAsync("http://RgbController.azurewebsites.net/api/Rgb");
            var cols = (from x in res.Trim('"').Split(',') select int.Parse(x)).ToArray<int>();
            if (cols[0]>0 || cols[1]>0 || cols[2]>0)
            {
                if (cols[0] > cols[1] && cols[0] > cols[2]) SetLED(1);
                else if (cols[1] > cols[0] && cols[1] > cols[2]) SetLED(2);
                else SetLED(4);
            }
        }

        private void InitPin(GpioPin x)
        {
            x.Write(GpioPinValue.High);
            x.SetDriveMode(GpioPinDriveMode.Output);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var x = int.Parse(((Button)sender).Tag.ToString());
            SetLED(x);
        }

        private void SetLED(int x)
        {
            WritePin(red, x % 2);
            if (x % 2 > 0) ColorMon.Fill = new SolidColorBrush(Colors.Red);
            WritePin(green, (x / 2) % 2);
            if ((x/2) % 2 > 0) ColorMon.Fill = new SolidColorBrush(Colors.Green);
            WritePin(blue, (x / 4) % 2);
            if ((x/4) % 2 > 0) ColorMon.Fill = new SolidColorBrush(Colors.Blue);
        }

        private void WritePin(GpioPin p, int v)
        {
            p.Write(v == 0 ? GpioPinValue.Low : GpioPinValue.High);
        }
    }
}
