using GlazerCalculation.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace GlazerCalculation
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void SubmitBtn_Click(object sender, RoutedEventArgs e)
        {
            Display();
        }

        public void Display()
        {
            double width = double.Parse(widthTxt.Text);
            double height = double.Parse(heightTxt.Text);
           

            double woodLength = 2 * (width + height) * 3.25;

            double glassArea = 2 * (width + height);

            Glazer glazer = new Glazer(width, height, glassArea, woodLength);

            woodLengthOutput.Text = glassArea.ToString();

            //woodLengthOutput.Text = "The Length of the wood is " + woodLength.ToString() + " feet";

          

        } 

    }
}
