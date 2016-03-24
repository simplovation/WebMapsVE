/* ----------------------------------------------------------------------------------- */
/* Copyright (C) Simplovation LLC (http://Simplovation.com) 2016. All rights reserved. */
/* Licensing information available at http://webmapsve.codeplex.com                    */
/* ----------------------------------------------------------------------------------- */
using System;
using System.Collections.Generic;
using System.Text;

namespace Simplovation.Web.Maps.VE
{
    /// <summary>
    /// An enumeration that represents the size and type of dashboard to be displayed on the map.
    /// </summary>
    public enum DashboardSize : int
    {
        /// <summary>
        /// The default dashboard.
        /// </summary>
        Normal = 1,
        /// <summary>
        /// A smaller dashboard that the default: only containing Zoom In(+) and Out(-) buttons and Road, Aerial and Hybrid buttons for changing the map style.
        /// </summary>
        Small = 2,
        /// <summary>
        /// The smallest dashboard option: only containing Zoom In(+) and Out(-) buttons.
        /// </summary>
        Tiny = 3
    }
}
