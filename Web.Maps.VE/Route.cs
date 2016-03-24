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
    /// Contains the route and itinerary information for a generated route.
    /// </summary>
    [DataContract]
    public class Route
    {
        /// <summary>
        /// Initializes a new instance of the Route object.
        /// </summary>
        public Route() { }

        /// <summary>
        /// Specifies the total length of the route.
        /// </summary>
        [DataMember]
        public double Distance { get; set; }

        /// <summary>
        /// A collection of RouteLeg objects that specify the intermediate legs of the route.
        /// </summary>
        [DataMember]
        public List<RouteLeg> RouteLegs { get; set; }

        /// <summary>
        /// An integer specifying the total elapsed time, in seconds, to traverse the route.
        /// </summary>
        [DataMember]
        public int Time { get; set; }
    }
}
