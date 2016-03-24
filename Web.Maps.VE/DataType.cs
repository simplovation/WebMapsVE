/* ----------------------------------------------------------------------------------- */
/* Copyright (C) Simplovation LLC (http://Simplovation.com) 2014. All rights reserved. */
/* Licensing information available at http://webmapsve.codeplex.com                    */
/* ----------------------------------------------------------------------------------- */
namespace Simplovation.Web.Maps.VE
{
    /// <summary>
    /// An enumeration of Shape Layer Data Types
    /// </summary>
    public enum DataType : int
    {
        /// <summary>
        /// This represents a GeoRSS data import
        /// </summary>
        GeoRSS = 0,
        /// <summary>
        /// This represents a Live Search maps Collection import
        /// </summary>
        VECollection = 1,
        /// <summary>
        /// This represents an XML data import
        /// </summary>
        ImportXML = 2
    }
}