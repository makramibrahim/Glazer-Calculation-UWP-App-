using GlazerCalculation.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
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
        
        double width = 0;
        double height = 0;
        double woodLength = 0;
        double glassArea = 0;

        public const double MAX_WIDTH = 5.0;
        public const double MIN_WIDTH = 0.5;
        public const double MAX_HEIGHT = 3.0;
        public const double MIN_HEIGHT = 0.75;



        public MainPage()
        {
            this.InitializeComponent();
        }

        private void SubmitBtn_Click(object sender, RoutedEventArgs e)
        {
            Display();
        }

        //private void widthTxt_KeyUp(object sender, KeyRoutedEventArgs e)
        //{
           

        //}


        public void Display()
        {
            try
            {
                width = double.Parse(widthTxt.Text);
                height = double.Parse(heightTxt.Text);

                woodLength = 2 * (width + height) * 3.25;
                glassArea = 2 * (width + height);

                if (width > MAX_WIDTH)
                {
                    WidthValidation.Text = "Width is too larage(Max is 5.0)";
                    woodLengthOutput.Text = "0.00";
                    glassAreaOutput.Text =  "0.00";
                }
                else if (width < MIN_WIDTH)
                {
                    WidthValidation.Text = "Width is too small(Min is 0.5)";
                    woodLengthOutput.Text = "0.00";
                    glassAreaOutput.Text = "0.00";
                }
            
                else if (height > MAX_HEIGHT)
                {
                    heightValidation.Text = "Height is too larage(Max is 3.0)";
                    woodLengthOutput.Text = "0.00";
                    glassAreaOutput.Text = "0.00";
                }
                else if (height < MIN_HEIGHT)
                {
                    heightValidation.Text = "Height is too small(Min is 0.75)";
                    woodLengthOutput.Text = "0.00";
                    glassAreaOutput.Text =  "0.00";
                    
                }
                else
                {
                    WidthValidation.Text = "";
                    heightValidation.Text = "";

                    Glazer glazer = new Glazer(width, height, glassArea, woodLength);

                    woodLengthOutput.Text = "The length of the wood is " + woodLength + " feet";
                    glassAreaOutput.Text =  "The area of the glass is " + glassArea + " square metres";
                }

            }
            catch 
            {
               //
            }

        }

    }
}
