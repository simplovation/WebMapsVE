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
    /// An enumeration of route modes
    /// </summary>
    public enum RouteMode : int
    {
        /// <summary>
        /// The returned route contains driving directions
        /// </summary>
        Driving = 0,
        /// <summary>
        /// The returned route contains walking directions
        /// </summary>
        Walking = 1
    }
}