/* ----------------------------------------------------------------------------------- */
/* Copyright (C) Simplovation LLC (http://Simplovation.com) 2016. All rights reserved. */
/* Licensing information available at http://webmapsve.codeplex.com                    */
/* ----------------------------------------------------------------------------------- */
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Simplovation.Web.Maps.VE
{
    /// <summary>
    /// The results returned from a Map.FindLocations operation.
    /// </summary>
    [DataContract]
    public class FindLocationsEventArgs : EventArgs
    {
        /// <summary>
        /// The <see cref="LatLong">LatLong</see> object returned from the Map.FindLocations operation.
        /// </summary>
        [DataMember]
        public LatLong Location { get; set; }

        /// <summary>
        /// A List of <see cref="Place">Place</see> objects returned from the Map.FindLocations operation.
        /// </summary>
        [DataMember]
        public List<Place> Places { get; set; }
    }
}
