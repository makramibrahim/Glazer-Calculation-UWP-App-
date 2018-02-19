/*****************************************************************
 * Author: Makram Ibrahim
 * Instructor: Brother Blazzard
 * CIT 365 - .NET Software Development
 * Date: Feb 17, 2018
 * Summary:
 *  The purpose of this hands-on programming assignment is to 
 *  introduce the basics of the UWP application development process
 *  and to experience XAML design and development methods. 
 * ***************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlazerCalculation.Properties
{
    class Glazer
    {
        private double Width      { get; set; }
        private double Height     { get; set; }
        private double GlassArea  { get; set; }
        private double WoodLength { get; set; }

    
        public Glazer(double width, double height, double glassArea, double woodLength)
        {
            this.Width = width;
            this.Height = height;
            this.GlassArea = glassArea;
            this.WoodLength = woodLength;
        }

       // public Glazer() { }


        public double WoodLengthCalc()
        {
           return 2 * (Width + Height) * 3.25;
        }

        public double GlassAreaCalc()
        {
            return 2 * (Width + Height);
        }


    }
}
