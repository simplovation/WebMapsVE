/* ----------------------------------------------------------------------------------- */
/* Copyright (C) Simplovation LLC (http://Simplovation.com) 2014. All rights reserved. */
/* Licensing information available at http://webmapsve.codeplex.com                    */
/* ----------------------------------------------------------------------------------- */
using System;
using System.Collections.Generic;
using System.Text;

namespace Simplovation.Web.Maps.VE
{
    /// <summary>
    /// An enumeration of Map Modes.
    /// </summary>
    public enum MapMode : int
    {
        /// <summary>
        /// Displays the Map in the traditional two dimensions.
        /// </summary>
        Mode2D = 1,
        /// <summary>
        /// Loads the Virtual Earth 3D control, displays the map in three dimensions, and displays the 3D navigation control.
        /// </summary>
        Mode3D = 2
    }
}
