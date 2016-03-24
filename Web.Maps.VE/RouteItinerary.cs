/* ----------------------------------------------------------------------------------- */
/* Copyright (C) Simplovation LLC (http://Simplovation.com) 2014. All rights reserved. */
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
    /// Contains a collection of RouteItineraryItems that specify the step-by-step directions for a Route object.
    /// </summary>
    [DataContract]
    public class RouteItinerary
    {
        /// <summary>
        /// A List of <see cref="RouteItineraryItem">RouteItineraryItem</see> objects specifying the step-by-step directions for the route.
        /// </summary>
        [DataMember]
        public List<RouteItineraryItem> Items { get; set; }
    }
}
