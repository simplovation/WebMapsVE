/* ----------------------------------------------------------------------------------- */
/* Copyright (C) Simplovation LLC (http://Simplovation.com) 2016. All rights reserved. */
/* Licensing information available at http://webmapsve.codeplex.com                    */
/* ----------------------------------------------------------------------------------- */
using System.Runtime.Serialization;

namespace Simplovation.Web.Maps.VE
{
    /// <summary>
    /// Contains the information about a Map pixel.
    /// </summary>
    [DataContract]
    public class Pixel
    {
        /// <summary>
        /// Initializes a new instance of the Pixel object.
        /// </summary>
        public Pixel() { }

        /// <summary>
        /// Initializes a new instance of the Pixel object.
        /// </summary>
        /// <param name="XCoordinate">The Pixel's X coordinate</param>
        /// <param name="YCoordinate">The Pixel's Y coordinate</param>
        /// <seealso cref="Pixel.x"/>
        /// <seealso cref="Pixel.y"/>
        public Pixel(int XCoordinate, int YCoordinate)
        {
            this.x = XCoordinate;
            this.y = YCoordinate;
        }

        /// <summary>
        /// Gets or sets the Pixel's X coordinate
        /// </summary>
        [DataMember]
        public int x { get; set; }

        /// <summary>
        /// Gets or sets the Pixel's Y coordinate
        /// </summary>
        [DataMember]
        public int y { get; set; }
    }
}
