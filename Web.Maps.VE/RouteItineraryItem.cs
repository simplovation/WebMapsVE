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
    /// Specifies a step in the step-by-step directions of a Route.
    /// </summary>
    //[TypeConverter(typeof(GenericConverter))]
    [DataContract]
    public class RouteItineraryItem
    {
        /// <summary>
        /// Specifies the distance of the step.
        /// </summary>
        [DataMember]
        public double Distance { get; set; }

        /// <summary>
        /// Specifies the LatLong position of the step.
        /// </summary>
        [DataMember]
        public LatLong LatLong { get; set; }

        /*
        private Shape _Shape;
        /// <summary>
        /// Specifies the Shape of the step.
        /// </summary>
        public Shape Shape
        {
            get { return _Shape; }
            set { _Shape = value; }
        }
        */

        /// <summary>
        /// The description of the step.
        /// </summary>
        [DataMember]
        public string Text { get; set; }

        /// <summary>
        /// An integer specifying the total elapsed time, in seconds, to traverse the route itinerary step.
        /// </summary>
        [DataMember]
        public int Time { get; set; }
    }
}
