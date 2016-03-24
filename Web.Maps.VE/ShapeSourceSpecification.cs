/* ----------------------------------------------------------------------------------- */
/* Copyright (C) Simplovation LLC (http://Simplovation.com) 2016. All rights reserved. */
/* Licensing information available at http://webmapsve.codeplex.com                    */
/* ----------------------------------------------------------------------------------- */
using System.Runtime.Serialization;

namespace Simplovation.Web.Maps.VE
{
    /// <summary>
    /// Defines the specification for importing Shape objects to the Map.
    /// </summary>
    [DataContract]
    public class ShapeSourceSpecification
    {
        /// <summary>
        /// Initializes a new instance of the ShapeSourceSpecification object.
        /// </summary>
        /// <param name="type">A DataType enumeration specifying the type of data to be imported into the Shape Layer</param>
        /// <param name="layerSource">A string specifying the Shape Layer Source</param>
        public ShapeSourceSpecification(DataType type, string layerSource)
        {
            this.Type = type;
            this.LayerSource = layerSource;
        }

        /// <summary>
        /// A string specifying the Shape Layer Source
        /// </summary>
        [DataMember]
        public string LayerSource { get; set; }

        /// <summary>
        /// A DataType enumeration specifying the type of data to be imported into the Shape Layer
        /// </summary>
        [DataMember]
        public DataType Type { get; set; }
    }
}
