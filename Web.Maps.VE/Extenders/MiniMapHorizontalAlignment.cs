/* ----------------------------------------------------------------------------------- */
/* Copyright (C) Simplovation LLC (http://Simplovation.com) 2016. All rights reserved. */
/* Licensing information available at http://webmapsve.codeplex.com                    */
/* ----------------------------------------------------------------------------------- */
namespace Simplovation.Web.Maps.VE
{
    /// <summary>
    /// The Horizontal Alignment to assign the Mini Map when displayed using the <see cref="Extenders.MiniMapExtender">MiniMapExtender</see>.
    /// </summary>
    /// <seealso cref="Extenders.MiniMapExtender"/>
    public enum MiniMapHorizontalAlignment : int
    {
        /// <summary>
        /// Align the Mini Map to the Left side of the <see cref="Map">Map</see>.
        /// </summary>
        Left = 0,
        /// <summary>
        /// Align the Mini Map to the Center of the <see cref="Map">Map</see>.
        /// </summary>
        Center = 1,
        /// <summary>
        /// Align the Mini Map to the Right side of the <see cref="Map">Map</see>.
        /// </summary>
        Right = 2
    }
}