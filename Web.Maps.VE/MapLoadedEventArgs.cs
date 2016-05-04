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
    /// The Event Arguments for the Map.MapLoaded event.
    /// </summary>
    [DataContract]
    public class MapLoadedEventArgs : EventArgs
    {
        private LatLongRectangle _MapView;
        /// <summary>
        /// The current map view.
        /// </summary>
        [DataMember]
        public LatLongRectangle MapView
        {
            get { return _MapView; }
            set { _MapView = value; }
        }

        private int _zoomLevel;
        /// <summary>
        /// The current map zoom level.
        /// </summary>
        [DataMember]
        public int zoomLevel
        {
            get { return _zoomLevel; }
            set { _zoomLevel = value; }
        }

        private MapType _mapType;
        /// <summary>
        /// The current map type.
        /// </summary>
        [DataMember]
        public MapType mapType
        {
            get { return _mapType; }
            set { _mapType = value; }
        }

        private LatLong _latlong = null;
        /// <summary>
        /// The latlong coordinates of the center of the map. During the OnClick event, this contains the coordinates of the clicked location.
        /// </summary>
        [DataMember]
        public LatLong latlong
        {
            get { return _latlong; }
            set { _latlong = value; }
        }
    }
}
