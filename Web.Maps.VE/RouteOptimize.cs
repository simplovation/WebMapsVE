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
    /// An enumeration specifying how a route is optimized.
    /// </summary>
    public enum RouteOptimize : int
    {
        /// <summary>
        /// No optimization is done. The route is calculated in order of how the locations are specified.
        /// </summary>
        Default = 0,
        /// <summary>
        /// The route is optimized for time.
        /// </summary>
        MinimizeTime = 1,
        /// <summary>
        /// The route is optimized for distance.
        /// </summary>
        MinimizeDistance = 2
    }
}
