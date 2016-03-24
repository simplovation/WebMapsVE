/* ----------------------------------------------------------------------------------- */
/* Copyright (C) Simplovation LLC (http://Simplovation.com) 2016. All rights reserved. */
/* Licensing information available at http://webmapsve.codeplex.com                    */
/* ----------------------------------------------------------------------------------- */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Simplovation.Web.Maps.VE
{
    /// <summary>
    /// A single "what" result returned from a Map.Find method search
    /// </summary>
    [DataContract]
    public class FindResult
    {
        /// <summary>
        /// A reference to the Shape class object corresponding to this FindResult object. The Shape object represents the result's pushpin displayed on the map
        /// </summary>
        [DataMember]
        public Shape Shape { get; set; }

        /// <summary>
        /// The name of the found result
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// The description of the found result
        /// </summary>
        [DataMember]
        public string Description { get; set; }

        /// <summary>
        /// The FindType enumeration representing the type of Find that was performed. This matches the FindType parameter specified in the Map.Find method call from which the result was generated
        /// </summary>
        [DataMember]
        public FindType FindType { get; set; }

        /// <summary>
        /// A boolean value indicating whether the found result is a paid advertisement
        /// </summary>
        [DataMember]
        public bool IsSponsored { get; set; }

        /// <summary>
        /// A LatLong class object that represents the location of the found result
        /// </summary>
        [DataMember]
        public LatLong LatLong { get; set; }

        /// <summary>
        /// The telephone number of the found result
        /// </summary>
        [DataMember]
        public string Phone { get; set; }
    }
}
