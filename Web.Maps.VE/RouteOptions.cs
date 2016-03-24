/* ----------------------------------------------------------------------------------- */
/* Copyright (C) Simplovation LLC (http://Simplovation.com) 2016. All rights reserved. */
/* Licensing information available at http://webmapsve.codeplex.com                    */
/* ----------------------------------------------------------------------------------- */
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace Simplovation.Web.Maps.VE
{
    /// <summary>
    /// Attributes for a multi-point route.
    /// </summary>
    [DataContract]
    public class RouteOptions
    {
        /// <summary>
        /// Initializes a new instance of the RouteOptions object.
        /// </summary>
        public RouteOptions()
        {
            this.RouteColor = new Color(0, 169, 235, 0.7);
        }

        private RouteDistanceUnit _DistanceUnit = RouteDistanceUnit.Miles;
        /// <summary>
        /// Specifies the RouteDistanceUnit used for the Route. Default is Miles.
        /// </summary>
        [DataMember]
        public RouteDistanceUnit DistanceUnit
        {
            get { return _DistanceUnit; }
            set { _DistanceUnit = value; }
        }

        private bool _DrawRoute = true;
        /// <summary>
        /// Specifies whether the route is drawn on the map. Default is True.
        /// </summary>
        [DataMember]
        public bool DrawRoute
        {
            get { return _DrawRoute; }
            set { _DrawRoute = value; }
        }

        private Simplovation.Web.Maps.VE.Color _RouteColor;
        /// <summary>
        /// Specifies the color of the Route line to be drawn on the map. Default is ? or Color(0, 169, 235, 0.7)
        /// </summary>
        [DataMember]
        public Simplovation.Web.Maps.VE.Color RouteColor
        {
            get { return _RouteColor; }
            set { _RouteColor = value; }
        }

        private RouteMode _RouteMode = RouteMode.Driving;
        /// <summary>
        /// A RouteMode enumeration value specifying the mode of route to return.
        /// </summary>
        [DataMember]
        public RouteMode RouteMode
        {
            get { return _RouteMode; }
            set { _RouteMode = value; }
        }

        private RouteOptimize _RouteOptimize = RouteOptimize.Default;
        /// <summary>
        /// Specifies how the route is optimized. Default is RouteOptimize.Default, which specifies the route is calculated in order of how the locations are specified.
        /// </summary>
        [DataMember]
        public RouteOptimize RouteOptimize
        {
            get { return _RouteOptimize; }
            set { _RouteOptimize = value; }
        }

        private int _RouteWeight = 6;
        /// <summary>
        /// The thickness, in pixels, of the route line. Default is 6 pixels.
        /// </summary>
        [DataMember]
        public int RouteWeight
        {
            get { return _RouteWeight; }
            set { _RouteWeight = value; }
        }

        private int _RouteZIndex = 4;
        /// <summary>
        /// The z-index of the route line. Default is 4.
        /// </summary>
        [DataMember]
        public int RouteZIndex
        {
            get { return _RouteZIndex; }
            set { _RouteZIndex = value; }
        }

        private bool _SetBestMapView = true;
        /// <summary>
        /// Specifies whether the map view is set to the best view of the route after it is drawn. Default is True.
        /// </summary>
        [DataMember]
        public bool SetBestMapView
        {
            get { return _SetBestMapView; }
            set { _SetBestMapView = value; }
        }

        private bool _ShowDisambiguation = true;
        /// <summary>
        /// Specifies whether a disambiguation dialog box is shown. Default is True, which means the disambiguation dialog box is shown. If False, no disambiguation dialogs are displayed and the route uses the first geocoded response for each location.
        /// </summary>
        [DataMember]
        public bool ShowDisambiguation
        {
            get { return _ShowDisambiguation; }
            set { _ShowDisambiguation = value; }
        }

        private bool _ShowErrorMessages = true;
        /// <summary>
        /// Specifies whether to show any error messages. Default is True.
        /// </summary>
        [DataMember]
        public bool ShowErrorMessages
        {
            get { return _ShowErrorMessages; }
            set { _ShowErrorMessages = value; }
        }


    }
}
