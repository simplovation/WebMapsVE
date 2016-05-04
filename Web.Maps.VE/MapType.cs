/* ----------------------------------------------------------------------------------- */
/* Copyright (C) Simplovation LLC (http://Simplovation.com) 2016. All rights reserved. */
/* Licensing information available at http://webmapsve.codeplex.com                    */
/* ----------------------------------------------------------------------------------- */
using System.ComponentModel;

namespace Simplovation.Web.Maps.VE
{
    /// <summary>
    /// An enumeration of map styles.
    /// </summary>
    public enum MapType : int
    {
        /// <summary>
        /// The road map style
        /// </summary>
        [Description("road")]
        Road = 1,
        /// <summary>
        /// The aerial map style
        /// </summary>
        [Description("aerial")]
        Aerial = 2,
        /// <summary>
        /// The hybrid map style, which is an aerial map with a label overlay
        /// </summary>
        [Description("hybrid")]
        Hybrid = 3,
        /// <summary>
        /// The bird's eye (oblique-angle) imagery map style
        /// </summary>
        [Description("oblique")]
        Birdseye = 4,
        /// <summary>
        /// The shaded map style; a road map with shaded contours.
        /// </summary>
        [Description("shaded")]
        Shaded = 5
    }
}
