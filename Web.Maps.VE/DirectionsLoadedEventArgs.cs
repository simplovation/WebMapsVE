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
    /// The Event Arguments for the Map.DirectionLoaded Event.
    /// </summary>
    public class DirectionsLoadedEventArgs : EventArgs
    {
        private Route _Route = null;
        /// <summary>
        /// Contains the route and itinerary information for the generated route.
        /// </summary>
        public Route Route
        {
            get { return _Route; }
            set { _Route = value; }
        }
    }
}
