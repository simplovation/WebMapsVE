/* ----------------------------------------------------------------------------------- */
/* Copyright (C) Simplovation LLC (http://Simplovation.com) 2014. All rights reserved. */
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
    /// The Event Arguments that contain the results of a Map.ImportShapeLayerData operation.
    /// </summary>
    [DataContract]
    public class ImportShapeLayerDataEventArgs : EventArgs
    {
        /// <summary>
        /// The <see cref="ShapeLayer">ShapeLayer</see> object that was added to the Map containing the imported data.
        /// </summary>
        [DataMember]
        public ShapeLayer ShapeLayer { get; set; }

        /// <summary>
        /// The <see cref="ShapeSourceSpecification">ShapeSourceSpecification</see> object that was used to import the data.
        /// </summary>
        [DataMember]
        public ShapeSourceSpecification ShapeSource { get; set; }
    }
}
