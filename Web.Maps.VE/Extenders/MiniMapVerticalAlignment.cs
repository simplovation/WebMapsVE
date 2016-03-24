/* ----------------------------------------------------------------------------------- */
/* Copyright (C) Simplovation LLC (http://Simplovation.com) 2016. All rights reserved. */
/* Licensing information available at http://webmapsve.codeplex.com                    */
/* ----------------------------------------------------------------------------------- */
namespace Simplovation.Web.Maps.VE
{
    /// <summary>
    /// The Vertical Alignment to assign the Mini Map when displayed using the <see cref="Extenders.MiniMapExtender">MiniMapExtender</see>.
    /// </summary>
    /// <seealso cref="Extenders.MiniMapExtender"/>
    public enum MiniMapVerticalAlignment : int
    {
        /// <summary>
        /// Align the Mini Map to the Top of the <see cref="Map">Map</see>.
        /// </summary>
        Top = 0,
        /// <summary>
        /// Align the Mini Map to the Middle of the <see cref="Map">Map</see>.
        /// </summary>
        Middle = 1,
        /// <summary>
        /// Align the Mini Map to the Bottom of the <see cref="Map">Map</see>.
        /// </summary>
        Bottom = 2
    }
}