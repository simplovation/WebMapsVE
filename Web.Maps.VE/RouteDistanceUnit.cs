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
    /// An enumeration specifying the units used for the route.
    /// </summary>
    public enum RouteDistanceUnit : int
    {
        /// <summary>
        /// The route is shown in units of Miles.
        /// </summary>
        Miles = 0,
        /// <summary>
        /// The route is shown in units of Kilometers.
        /// </summary>
        Kilometers = 1
    }
}
