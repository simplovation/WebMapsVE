/* ----------------------------------------------------------------------------------- */
/* Copyright (C) Simplovation LLC (http://Simplovation.com) 2016. All rights reserved. */
/* Licensing information available at http://webmapsve.codeplex.com                    */
/* ----------------------------------------------------------------------------------- */
using Simplovation.Web.Maps.VE.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Simplovation.Web.Maps.VE
{
    /// <summary>
    /// The AyncMapData object is used for passing Map data down to the client when an Asynchronous Postback occurrs.
    /// </summary>
    [DataContract]
    public class AsyncMapData
    {
        [DataMember]
        public string EventName { get; set; }

        private AsyncMapEventArgs _EventArgs = null;
        /// <summary>
        /// When an Asyncronous postback occurs this will contain all the Client-Side VEMap Event Object Properties so the event can be handled accordingly from Server-Side code.
        /// </summary>
        [DataMember]
        public AsyncMapEventArgs EventArgs
        {
            get
            {
                if (_EventArgs != null) { _EventArgs.MapView = this.MapView; }
                return _EventArgs;
            }
            set { _EventArgs = value; }
        }

        private MapLoadedEventArgs _MapLoadedEventArgs;
        [DataMember]
        public MapLoadedEventArgs MapLoadedEventArgs
        {
            get { return _MapLoadedEventArgs; }
            set { _MapLoadedEventArgs = value; }
        }

        [DataMember]
        public double? Width { get; set; }

        [DataMember]
        public double? Height { get; set; }

        [DataMember]
        public int? ZoomLevel { get; set; }

        [DataMember]
        public double? Latitude { get; set; }
        
        [DataMember]
        public double? Longitude { get; set; }

        [DataMember]
        public double? Pitch { get; set; }

        [DataMember]
        public double? Altitude { get; set; }
        
        [DataMember]
        public double? Heading { get; set; }
        
        [DataMember]
        public MapType? MapType { get; set; }

        [DataMember]
        public MapMode? MapMode { get; set; }

        [DataMember]
        public bool? ShowDashboard { get; set; }

        [DataMember]
        public LatLongRectangle MapView { get; set; }

        [DataMember]
        public bool? ShowMiniMap { get; set; }

        [DataMember]
        public double? ClickedLatitude { get; set; }

        [DataMember]
        public double? ClickedLongitude { get; set; }

        [DataMember]
        public DirtyStateList<ShapeLayer> Layers { get; set; }

        [DataMember]
        public bool? DeleteLayersFirst { get; set; }

        [DataMember]
        public string ShapeLayersToRemove { get; set; }

        [DataMember]
        public string ShapesToRemove { get; set; }

        [DataMember]
        public DistanceUnit? DistanceUnit { get; set; }

        [DataMember]
        public List<object> Direction_Locations { get; set; }

        [DataMember]
        public RouteOptions Direction_RouteOptions { get; set; }

        [DataMember]
        public bool? Directions_Clear { get; set; }

        private bool? _CustomInfoBoxStylesEnabled = false;
        [DataMember]
        public bool? CustomInfoBoxStylesEnabled
        {
            get { return _CustomInfoBoxStylesEnabled; }
            set { _CustomInfoBoxStylesEnabled = value; }
        }

        [DataMember]
        public FindArguments FindArgs { get; set; }

        [DataMember]
        public LatLong FindLocations { get; set; }

        [DataMember]
        public ShapeSourceSpecification ImportShapeLayerData_shapeSource { get; set; }

        [DataMember]
        public bool ImportShapeLayerData_setBestView { get; set; }
    }
}
