/* ----------------------------------------------------------------------------------- */
/* Copyright (C) Simplovation LLC (http://Simplovation.com) 2016. All rights reserved. */
/* Licensing information available at http://webmapsve.codeplex.com                    */
/* ----------------------------------------------------------------------------------- */
namespace Simplovation.Web.Maps.VE
{
    /// <summary>
    /// This enumeration represents the Shape Type for a <see cref="Shape"/> object.
    /// </summary>
    /// <example language="C#">ShapeType st = ShapeType.Pushpin;</example>
    public enum ShapeType
    {
        /// <summary>
        /// This represents a <see cref="Shape"/> object that is a pushpin.
        /// </summary>
        Pushpin = 0,
        /// <summary>
        /// This represents a <see cref="Shape"/> object that is a polyline.
        /// </summary>
        Polyline = 1,
        /// <summary>
        /// This represents a <see cref="Shape"/> object that is a polygon.
        /// </summary>
        Polygon = 2
    }
}
