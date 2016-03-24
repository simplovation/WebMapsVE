/* ----------------------------------------------------------------------------------- */
/* Copyright (C) Simplovation LLC (http://Simplovation.com) 2014. All rights reserved. */
/* Licensing information available at http://webmapsve.codeplex.com                    */
/* ----------------------------------------------------------------------------------- */
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace Simplovation.Web.Maps.VE
{
    /// <summary>
    /// An enumeration of map styles.
    /// </summary>
    public enum MapStyle : int
    {
        /// <summary>
        /// The road map style
        /// </summary>
        [Description("r")]
        Road = 1,
        /// <summary>
        /// The aerial map style
        /// </summary>
        [Description("a")]
        Aerial = 2,
        /// <summary>
        /// The hybrid map style, which is an aerial map with a label overlay
        /// </summary>
        [Description("h")]
        Hybrid = 3,
        /// <summary>
        /// The bird's eye (oblique-angle) imagery map style
        /// </summary>
        [Description("o")]
        Birdseye = 4,
        /// <summary>
        /// The shaded map style; a road map with shaded contours.
        /// </summary>
        [Description("s")]
        Shaded = 5
    }
}
