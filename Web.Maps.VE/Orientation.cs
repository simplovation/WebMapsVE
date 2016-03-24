/* ----------------------------------------------------------------------------------- */
/* Copyright (C) Simplovation LLC (http://Simplovation.com) 2016. All rights reserved. */
/* Licensing information available at http://webmapsve.codeplex.com                    */
/* ----------------------------------------------------------------------------------- */

namespace Simplovation.Web.Maps.VE
{
    /// <summary>
    /// An enumeration of available directional views for a bird's eye image.
    /// </summary>
    public enum Orientation : int
    {
        /// <summary>
        /// The image was taken looking toward the north.
        /// </summary>
        North = 0,
        /// <summary>
        /// The image was taken looking toward the south.
        /// </summary>
        South = 1,
        /// <summary>
        /// The image was taken looking toward the east.
        /// </summary>
        East = 2,
        /// <summary>
        /// The image was taken looking toward the west.
        /// </summary>
        West = 3
    }
}
