/* ----------------------------------------------------------------------------------- */
/* Copyright (C) Simplovation LLC (http://Simplovation.com) 2016. All rights reserved. */
/* Licensing information available at http://webmapsve.codeplex.com                    */
/* ----------------------------------------------------------------------------------- */
namespace Simplovation.Web.Maps.VE
{
    /// <summary>
    /// A match code value as received from the geocoder.
    /// </summary>
    /// <seealso cref="Place.MatchCode"/>
    public enum MatchCode : int
    {
        /// <summary>
        /// No match was found
        /// </summary>
        None = 0,
        /// <summary>
        /// The match was good
        /// </summary>
        Good = 1,
        /// <summary>
        /// The match was ambiguous
        /// </summary>
        Ambiguous = 2,
        /// <summary>
        /// The match was found by a broader search
        /// </summary>
        UpHierarchy = 3,
        /// <summary>
        /// The match was found, but to a modified place
        /// </summary>
        Modified = 4
    }
}