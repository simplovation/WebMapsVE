/* ----------------------------------------------------------------------------------- */
/* Copyright (C) Simplovation LLC (http://Simplovation.com) 2014. All rights reserved. */
/* Licensing information available at http://webmapsve.codeplex.com                    */
/* ----------------------------------------------------------------------------------- */
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace Simplovation.Web.Maps.VE
{
    /// <summary>
    /// Specifies the color and transparency to use when drawing <see cref="Shape">Shape</see> objects on the <see cref="Map">Map</see>.
    /// </summary>
    [DataContract]
    public class Color
    {
        #region Constructors

        /// <summary>
        /// Instantiates a new Color object that is semi-transparent blue.
        /// </summary>
        /// <overloads>There are two overloads for the constructor</overloads>
        public Color()
        {
            this.R = 0;
            this.G = 0;
            this.B = 255;
            this.A = 0.5;
        }

        ///// <summary>
        ///// Instantiates a new Color object derived from a System.Drawing.Color object
        ///// </summary>
        ///// <param name="color">A System.Drawing.Color object</param>
        //public Color(System.Drawing.Color color)
        //{
        //    this.R = BitConverter.ToInt32(new byte[] { color.R }, 0);
        //    this.G = BitConverter.ToInt32(new byte[] { color.G }, 0);
        //    this.B = BitConverter.ToInt32(new byte[] { color.B }, 0);
        //    this.A = BitConverter.ToInt32(new byte[] { color.A }, 0);
        //}

        /// <summary>
        /// Instantiates a new Color object
        /// </summary>
        /// <param name="r">The Red component value. Valid values range from 0 to 255.</param>
        /// <param name="g">The Green component value. Valid values range from 0 to 255.</param>
        /// <param name="b">The Blue component value. Valid values range from 0 to 255.</param>
        /// <param name="a">The Alpha (transparency) component value. Valid values range from 0.0 to 1.0.</param>
        public Color(int r, int g, int b, double a)
        {
            this.R = r;
            this.G = g;
            this.B = b;
            this.A = a;
        }

        #endregion

        #region Properties

        private int _R;
        /// <summary>
        /// The Red component value, valid values are 0 to 255
        /// </summary>
        [DataMember]
        public int R
        {
            get { return _R; }
            set
            {
                int v = value;
                if (v < 0) v = 0;
                if (v > 255) v = 255;
                _R = v;
            }
        }

        private int _G;
        /// <summary>
        /// The Green component value, valid values are 0 to 255
        /// </summary>
        [DataMember]
        public int G
        {
            get { return _G; }
            set
            {
                int v = value;
                if (v < 0) v = 0;
                if (v > 255) v = 255; 
                _G = v; 
            }
        }

        private int _B;
        /// <summary>
        /// The Blue component value, valid values are 0 to 255
        /// </summary>
        [DataMember]
        public int B
        {
            get { return _B; }
            set
            {
                int v = value;
                if (v < 0) v = 0;
                if (v > 255) v = 255; 
                _B = v;
            }
        }

        private double _A;
        /// <summary>
        /// The Transparency (Alpha) component value, valid values are 0.0 to 1.0
        /// </summary>
        [DataMember]
        public double A
        {
            get { return _A; }
            set
            {
                double v = value;
                if (v < 0.0) v = 0.0;
                if (v > 1.0) v = 1.0;
                _A = v;
            }
        }

        #endregion

        #region Static Properties

        /// <summary>
        /// The color Red.
        /// </summary>
        public static Simplovation.Web.Maps.VE.Color Red
        {
            get
            {
                //return new Color(System.Drawing.Color.Red);
                return new Color(255, 0, 0, 1.0);
            }
        }

        /// <summary>
        /// The color Green.
        /// </summary>
        public static Simplovation.Web.Maps.VE.Color Green
        {
            get
            {
                //return new Color(System.Drawing.Color.Green);
                return new Color(0, 255, 0, 1.0);
            }
        }

        /// <summary>
        /// The color Blue.
        /// </summary>
        public static Simplovation.Web.Maps.VE.Color Blue
        {
            get
            {
                //return new Color(System.Drawing.Color.Blue);
                return new Color(0, 0, 255, 1.0);
            }
        }

        #endregion

        #region "Static Methods"

        /// <summary>
        /// Translates an HTML color representation to a System.Web.Maps.VE.Color object.
        /// </summary>
        /// <param name="htmlColor">The string representation of the HTML color to translate.</param>
        /// <returns>A Simplovation.Web.Maps.VE.Color object that represents the specified HTML color.</returns>
        public static Color FromHtml(string htmlColor)
        {
            var c = System.Drawing.ColorTranslator.FromHtml(htmlColor);
            return new Simplovation.Web.Maps.VE.Color(c.R, c.G, c.B, c.A);
        }

        #endregion
    }
}
