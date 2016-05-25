/* ----------------------------------------------------------------------------------- */
/* Copyright (C) Simplovation LLC (http://Simplovation.com) 2016. All rights reserved. */
/* Licensing information available at http://webmapsve.codeplex.com                    */
/* ----------------------------------------------------------------------------------- */
using System.ComponentModel;

namespace Simplovation.Web.Maps.VE
{
    /// <summary>
    /// An enumeration of map styles.
    /// </summary>
    public enum MapType : int
    {
        /// <summary>
        /// The road map type
        /// </summary>
        [Description("road")]
        Road = 1,
        /// <summary>
        /// The aerial map type
        /// </summary>
        [Description("aerial")]
        Aerial = 2,
        /// <summary>
        /// The ordnanceSurvey map type
        /// </summary>
        [Description("ordnanceSurvey")]        
        OrdnanceSurvey = 3,
        /// <summary>
        /// The streetside map type
        /// </summary>
        [Description("streetside")]
        Streetside = 4
    }
}
