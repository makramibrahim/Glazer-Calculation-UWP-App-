using GlazerCalculation.Properties;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        /***************************
         * Declare some variables
         * *************************/
        double width = 0;
        double height = 0;
        double woodLength = 0;
        double glassArea = 0;

        public const double MAX_WIDTH = 5.0;
        public const double MIN_WIDTH = 0.5;
        public const double MAX_HEIGHT = 3.0;
        public const double MIN_HEIGHT = 0.75;

        // Store colors input in a list.
        List<string> tintColor = new List<string>();

        public MainPage()
        {
            this.InitializeComponent();

            tintColor.Add("Black");
            tintColor.Add("Brown");
            tintColor.Add("Blue");

            TintColor.ItemsSource = tintColor;

            TintColor.SelectedIndex = 0;
        }

        /***********************************************************************
         *  Build a voice reader to repeat the out put to the user.
         * *********************************************************************/
        private async void VoiceMessage(string voice)
        {
            MediaElement mediaElement = new MediaElement();
            var synth = new Windows.Media.SpeechSynthesis.SpeechSynthesizer();
            Windows.Media.SpeechSynthesis.SpeechSynthesisStream stream = await synth.SynthesizeTextToStreamAsync(voice);
            mediaElement.SetSource(stream, stream.ContentType);
            mediaElement.Play();
        }

        /***********************************************************************
        * Display(): Method will call the class glazer and pass all the value
        * Through the constructor.
        * *********************************************************************/
        public void Display()
        {

            width = double.Parse(widthTxt.Text);
            height = double.Parse(heightTxt.Text);

      
            Glazer glazer = new Glazer(width, height, glassArea, woodLength);

            woodLength = glazer.WoodLengthCalc() * Qunatity.Value;
            glassArea = glazer.GlassAreaCalc() * Qunatity.Value;

            var colors = TintColor.SelectedValue;

            var date = DateTime.Now.ToString("MM/dd/yyyy");

            woodLengthOutput.Text = "Date " + date + Environment.NewLine + "The length of the wood is " + woodLength + " feet."
                                               + Environment.NewLine + "The area of the glass is " + glassArea + " square metres"
                                               + Environment.NewLine + "Selected color is " + colors + Environment.NewLine +
                                               "Qouantity: " + Qunatity.Value;

            VoiceMessage("The length of the wood is " + woodLength + " feet and The area of the glass is " + glassArea + " square metres");


        }

        /***********************************************************************
        * Submit Button event will check if the input is there to get the result.
        * *********************************************************************/
        private void SubmitBtn_Click(object sender, RoutedEventArgs e)
        { 
            if (widthTxt.Text == "" || heightTxt.Text == "")
            {
                VoiceMessage("Fields can't be empty.");
            }
            else
            {
                Display();
            }
          
        }
        /*********************************
         *  Validated the width input
         * ******************************/

        private void widthTxt_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                width = double.Parse(widthTxt.Text);

                if (widthTxt.Text == "")
                {
                    WidthValidation.Text = "Wdith field can't be empty";
                }
                else if (width > MAX_WIDTH)
                {
                    WidthValidation.Text = "Width is too larage(Max is 5.0)";
                   
                }
                else if (width < MIN_WIDTH)
                {
                    WidthValidation.Text = "Width is too small(Min is 0.5)";
                }
                else
                {
                    WidthValidation.Text = "";
                }
            } 
           catch
            {
                WidthValidation.Text = "";
            }

        }

        /***********************************
        * Validate the height input.
        * **************************************/
        private void heightTxt_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                height = double.Parse(heightTxt.Text);
                if (heightTxt.Text == "")
                {
                    HeightValidation.Text = "Height field can't be empty.";
                }
                else if (height > MAX_HEIGHT)
                {
                    HeightValidation.Text = "Height is too larage(Max is 3.0)";
                }
                else if (height < MIN_HEIGHT)
                {
                    HeightValidation.Text = "Height is too small(Min is 0.75)";
                }
                else
                {
                    HeightValidation.Text = "";
                }
            }
            catch
            {
                HeightValidation.Text = "";
            }
        }
    }
}
