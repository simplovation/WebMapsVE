/* ----------------------------------------------------------------------------------- */
/* Copyright (C) Simplovation LLC (http://Simplovation.com) 2016. All rights reserved. */
/* Licensing information available at http://webmapsve.codeplex.com                    */
/* ----------------------------------------------------------------------------------- */
using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace Simplovation.Web.Maps.VE
{
    /// <summary>
    /// A Server-Side representation of the Client-Side VEMap Event Object
    /// </summary>
    [DataContract]
    public class AsyncMapEventArgs : EventArgs
    {
        /// <summary>
        /// A String object containing the error message, if any.
        /// </summary>
        [DataMember]
        public string error { get; set; }

        /// <summary>
        /// The current map zoom level.
        /// </summary>
        [DataMember]
        public int zoomLevel { get; set; }

        /// <summary>
        /// The current map style as a String. Valid String results are a, r, h and o.
        /// </summary>
        [DataMember]
        public string mapType { get; set; }

        /// <summary>
        /// If the map style is set to bird's eye (oblique), the unique identifier of the current bird's eye scene.
        /// </summary>
        [DataMember]
        public string birdseyeSceneID { get; set; }

        /// <summary>
        /// If the map style is set to bird's eye (oblique), the orientation of the current bird's eye scene.
        /// </summary>
        [DataMember]
        public string birdseyeSceneOrientation { get; set; }

        /// <summary>
        /// A boolean representing whether the left mouse button has been clicked.
        /// </summary>
        [DataMember]
        public bool leftMouseButton { get; set; }

        /// <summary>
        /// A boolean representing whether the right mouse button has been clicked.
        /// </summary>
        [DataMember]
        public bool rightMouseButton { get; set; }

        /// <summary>
        /// A boolean representing whether the middle mouse button (or mouse wheel) has been clicked.
        /// </summary>
        [DataMember]
        public bool middleMouseButton { get; set; }

        /// <summary>
        /// The number of units that the mouse wheel has changed.
        /// NOTE: This is not supported in 3D mode, and the value returned in Firefox 1.5 and 2.0 is incorrect.
        /// </summary>
        [DataMember]
        public int mouseWheelChange { get; set; }

        /// <summary>
        /// The x coordinate of the mouse cursor relative to the browser window.
        /// </summary>
        [DataMember]
        public int clientX { get; set; }

        /// <summary>
        /// The y coordinate of the mouse cursor relative to the browser window.
        /// </summary>
        [DataMember]
        public int clientY { get; set; }

        /// <summary>
        /// The x coordinate of the mouse cursor relative to the screen.
        /// NOTE: This is not supported in 3D mode
        /// </summary>
        [DataMember]
        public int screenX { get; set; }

        /// <summary>
        /// The y coordinate of the mouse cursor relative to the screen.
        /// NOTE: This is not supported in 3D mode
        /// </summary>
        [DataMember]
        public int screenY { get; set; }

        /// <summary>
        /// The x coordinate of the map relative to the screen.
        /// NOTE: This is not supported in 3D mode
        /// </summary>
        [DataMember]
        public int mapX { get; set; }

        /// <summary>
        /// The y coordinate of the map relative to the screen.
        /// NOTE: This is not supported in 3D mode
        /// </summary>
        [DataMember]
        public int mapY { get; set; }

        /// <summary>
        /// The latlong coordinates of the center of the map. During the OnClick event, this contains the coordinates of the clicked location.
        /// </summary>
        [DataMember]
        public LatLong latlong { get; set; }

        /// <summary>
        /// The key code of the key that has been pressed.
        /// NOTE: This is not supported in 3D mode.
        /// </summary>
        [DataMember]
        public string keyCode { get; set; }

        /// <summary>
        /// A boolean representing whether the ALT key was held when the key was pressed.
        /// NOTE: This is not supported in 3D mode.
        /// </summary>
        [DataMember]
        public bool altKey { get; set; }

        /// <summary>
        /// A boolean representing whether the CTRL key was held when the key was pressed.
        /// NOTE: This is not supported in 3D mode.
        /// </summary>
        [DataMember]
        public bool ctrlKey { get; set; }

        /// <summary>
        /// A boolean representing whether the Shift key was held when the key was pressed.
        /// NOTE: This is not supported in 3D mode.
        /// </summary>
        [DataMember]
        public bool shiftKey { get; set; }

        /// <summary>
        /// A string representing the type of event that occurred.
        /// </summary>
        [DataMember]
        public string eventName { get; set; }

        /// <summary>
        /// The client-side ID of the object associated with the event, usually a VEShape Class object or the base map.
        /// </summary>
        [DataMember]
        public string elementID { get; set; }

        /// <summary>
        /// The Shape object associated with the event.
        /// </summary>
        [DataMember]
        public Shape Shape { get; set; }

        /// <summary>
        /// The current map view.
        /// </summary>
        [DataMember]
        public LatLongRectangle MapView { get; set; }
    }
}
