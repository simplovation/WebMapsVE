/* ----------------------------------------------------------------------------------- */
/* Copyright (C) Simplovation LLC (http://Simplovation.com) 2016. All rights reserved. */
/* Licensing information available at http://webmapsve.codeplex.com                    */
/* ----------------------------------------------------------------------------------- */
using System;
using System.Runtime.Serialization;

namespace Simplovation.Web.Maps.VE
{
    /// <summary>
    /// A found result returned from a location search.
    /// </summary>
    [DataContract]
    public class Place
    {
        /// <summary>
        /// Gets a LatLong object that represents the best location of the found result.
        /// </summary>
        [DataMember]
        public LatLong LatLong { get; set; }

        [DataMember]
        public LatLongRectangle LatLongRect { get; set; }
        //public GeocodeLocation Locations { get; set; }

        /// <summary>
        /// Gets the String object that represents the Virtual Earth unambiguous name for the location.
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// A MarchCode Enumeration specifying the match code from the Virtual Earth geocoder. This value is only valid for where-only searchs.
        /// </summary>
        [DataMember]
        public MatchCode? MatchCode { get; set; }
        //public MatchConfidence MatchConfidence { get; set; }
        //public LocationPrecision Precision { get; set; }

        /// <summary>
        /// A Double value specifying the match confidence from the geocoder. This value is only valid from where-only searches.
        /// </summary>
        [DataMember]
        public double MatchConfidence { get; set; }

        [DataMember]
        public double Score { get; set; }
    }
}