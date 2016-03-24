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
    /// The Event Arguments that contain the results of a Map.Find operation.
    /// </summary>
    [DataContract]
    public class FindEventArgs
    {
        /// <summary>
        /// A List of <see cref="Place">Place</see> objects returned from the Map.Find operation.
        /// </summary>
        [DataMember]
        public List<Place> Places { get; set; }

        /// <summary>
        /// A List of <see cref="FindResult">FindResult</see> objects returned from the Map.Find operation.
        /// </summary>
        [DataMember]
        public List<FindResult> Results { get; set; }
    }
}
