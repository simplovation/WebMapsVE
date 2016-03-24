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
    /// Specifies the intermediate legs of a Route.
    /// </summary>
    [DataContract]
    public class RouteLeg
    {
        /// <summary>
        /// Initializes a new instance of the RouteLeg object.
        /// </summary>
        public RouteLeg() { }

        /// <summary>
        /// Specifies the length of the RouteLeg
        /// </summary>
        [DataMember]
        public double Distance { get; set; }

        /// <summary>
        /// Specifies the itinerary of the RouteLeg
        /// </summary>
        [DataMember]
        public RouteItinerary Itinerary { get; set; }
    }
}
