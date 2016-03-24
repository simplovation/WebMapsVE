/* ----------------------------------------------------------------------------------- */
/* Copyright (C) Simplovation LLC (http://Simplovation.com) 2016. All rights reserved. */
/* Licensing information available at http://webmapsve.codeplex.com                    */
/* ----------------------------------------------------------------------------------- */
using System.Runtime.Serialization;
using System.Web.UI;

namespace Simplovation.Web.Maps.VE
{
    /// <summary>
    /// Contains the Latitude and Longitude of a single point on the globe.
    /// </summary>
    [DataContract,
    ParseChildren(true),
    KnownType(typeof(LatLong))]
    public class LatLong
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LatLong">LatLong</see> object.
        /// </summary>
        /// <overloads>Initializes a new instance of the <see cref="LatLong">LatLong</see> object.</overloads>
        public LatLong() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="LatLong">LatLong</see> object.
        /// </summary>
        /// <param name="latitude">Specifies the latitude of a single point on the globe.</param>
        /// <param name="longitude">Specifies the longitude of a single point on the globe.</param>
        public LatLong(double latitude, double longitude)
        {
            this.Latitude = latitude;
            this.Longitude = longitude;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LatLong">LatLong</see> object.
        /// </summary>
        /// <param name="latitude">Specifies the latitude of a single point on the globe.</param>
        /// <param name="longitude">Specifies the longitude of a single point on the globe.</param>
        /// <param name="altitude">Specifies the altitude of a single point on the globe.</param>
        public LatLong(double latitude, double longitude, double altitude)
        {
            this.Latitude = latitude;
            this.Longitude = longitude;
            this.Altitude = altitude;
            this.AltitudeMode = Simplovation.Web.Maps.VE.AltitudeMode.Default;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LatLong">LatLong</see> object.
        /// </summary>
        /// <param name="latitude">Specifies the latitude of a single point on the globe.</param>
        /// <param name="longitude">Specifies the longitude of a single point on the globe.</param>
        /// <param name="altitude">Specifies the altitude of a single point on the globe.</param>
        /// <param name="altitudeMode">Specifies the mode in which an altitude is represented.</param>
        public LatLong(double latitude, double longitude, double altitude, AltitudeMode altitudeMode)
        {
            this.Latitude = latitude;
            this.Longitude = longitude;
            this.Altitude = altitude;
            this.AltitudeMode = altitudeMode;
        }

        /// <summary>
        /// Returns a String representation of the <see cref="LatLong">LatLong</see> object.
        /// </summary>
        /// <returns>A string containing only the Latitude and Longitude of the LatLong object seperated by a comma and space (Example: "75.55, -75.55")</returns>
        public new string ToString()
        {
            return this.Latitude.ToString() + ", " + this.Longitude.ToString();
        }

        /// <summary>
        /// Specifies the latitude of a single point on the globe.
        /// </summary>
        [DataMember]
        public double? Latitude { get; set; }

        /// <summary>
        /// Specifies the longitude of a single point on the globe.
        /// </summary>
        [DataMember]
        public double? Longitude { get; set; }

        /// <summary>
        /// Specifies the altitude of a single point on the globe.
        /// </summary>
        [DataMember]
        public double? Altitude { get; set; }

        /// <summary>
        /// Specifies the mode in which an altitude is represented.
        /// </summary>
        [DataMember]
        public AltitudeMode? AltitudeMode { get; set; }
    }
}
