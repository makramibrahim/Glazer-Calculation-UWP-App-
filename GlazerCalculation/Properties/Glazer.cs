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



    }
}
