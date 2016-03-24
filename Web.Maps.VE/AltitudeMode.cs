/* ----------------------------------------------------------------------------------- */
/* Copyright (C) Simplovation LLC (http://Simplovation.com) 2014. All rights reserved. */
/* Licensing information available at http://webmapsve.codeplex.com                    */
/* ----------------------------------------------------------------------------------- */

namespace Simplovation.Web.Maps.VE
{
    /// <summary>
    /// Defines the altitude of a point on the globe
    /// </summary>
    public enum AltitudeMode : int
    {
        /// <summary>
        /// The altitude is meters above ground level
        /// </summary>
        Default = 0,
        /// <summary>
        /// The altitude is meters above the WGS 84 ellipsoid
        /// </summary>
        Absolute = 1,
        /// <summary>
        /// The altitude is meters above ground level
        /// </summary>
        RelativeToGround = 2
    }
}
