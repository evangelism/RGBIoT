using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Gpio;
using Windows.Foundation;
using Windows.Foundation.Collections;
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

        public MainPage()
        {
            this.InitializeComponent();
            var gpio = GpioController.GetDefault();
            red = gpio.OpenPin(5); InitPin(red);
            green = gpio.OpenPin(13); InitPin(green);
            blue = gpio.OpenPin(6); InitPin(blue);
        }

        private void InitPin(GpioPin x)
        {
            x.Write(GpioPinValue.High);
            x.SetDriveMode(GpioPinDriveMode.Output);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var x = int.Parse(((Button)sender).Tag.ToString());
            WritePin(red, x % 2);
            WritePin(green, (x / 2) % 2);
            WritePin(blue, (x / 4) % 2);
        }

        private void WritePin(GpioPin p, int v)
        {
            p.Write(v == 0 ? GpioPinValue.Low : GpioPinValue.High);
        }
    }
}
