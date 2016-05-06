/* ----------------------------------------------------------------------------------- */
/* Copyright (C) Simplovation LLC (http://Simplovation.com) 2014. All rights reserved. */
/* Licensing information available at http://webmapsve.codeplex.com                    */
/* ----------------------------------------------------------------------------------- */
namespace Simplovation.Web.Maps.VE
{
    /// <summary>
    /// An Enumeration of Map Actions that are used by the <see cref="Extenders.MapActionExtender">MapActionExtender</see> control.
    /// </summary>
    public enum MapAction : int
    {
        /// <summary>
        /// The action of Zooming In on the Map.
        /// </summary>
        ZoomIn = 0,
        /// <summary>
        /// The action of Zooming Out on the Map.
        /// </summary>
        ZoomOut = 1,
        /// <summary>
        /// The action of making the Map Dashboard visible to the user.
        /// </summary>
        ShowDashboard = 2,
        /// <summary>
        /// The action of hiding the Map Dashboard from being visible to the user.
        /// </summary>
        HideDashboard = 3,
        /// <summary>
        /// The action of setting the <see cref="MapType">MapType</see> to Road.
        /// </summary>
        SetMapTypeRoad = 4,
        /// <summary>
        /// The action of setting the <see cref="MapType">MapType</see> to Aerial.
        /// </summary>
        SetMapTypeAerial = 5,
        /// <summary>
        /// The action of setting the <see cref="MapType">MapType</see> to Hybrid.
        /// </summary>
        SetMapTypeHybrid = 6,
        /// <summary>
        /// The action of setting the <see cref="MapType">MapType</see> to Birdseye.
        /// </summary>
        SetMapTypeBirdseye = 7,
        /// <summary>
        /// The action of setting the <see cref="MapType">MapType</see> to Shaded.
        /// </summary>
        SetMapTypeShaded = 16,
        /// <summary>
        /// The action of Clearing All Shapes currently being plotted on the Map.
        /// </summary>
        ClearAllShapes = 11,
        /// <summary>
        /// The action of Panning Up on the Map.
        /// </summary>
        PanUp = 17,
        /// <summary>
        /// The action of Panning Down on the Map.
        /// </summary>
        PanDown = 18,
        /// <summary>
        /// The action of Panning Left on the Map.
        /// </summary>
        PanLeft = 19,
        /// <summary>
        /// The action of Panning Right on the Map.
        /// </summary>
        PanRight = 20
    }
}