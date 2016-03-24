/* ----------------------------------------------------------------------------------- */
/* Copyright (C) Simplovation LLC (http://Simplovation.com) 2014. All rights reserved. */
/* Licensing information available at http://webmapsve.codeplex.com                    */
/* ----------------------------------------------------------------------------------- */
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Web.UI;
using System.Runtime.Serialization;

namespace Simplovation.Web.Maps.VE
{
    /// <summary>
    /// Contains the LatLong objects that define the boundaries of the current map view.
    /// </summary>
    //[TypeConverter(typeof(GenericConverter)),
    [DataContract,
    ParseChildren(true)]
    public class LatLongRectangle
    {
        #region Properties

        private LatLong _TopLeftLatLong;
        /// <summary>
        /// The LatLong object that represnets the upper-left corner of the map view.
        /// </summary>
        [PersistenceMode(PersistenceMode.InnerProperty),
        DataMember]
        public LatLong TopLeftLatLong
        {
            get { return _TopLeftLatLong; }
            set { _TopLeftLatLong = value; }
        }

        private LatLong _BottomRightLatLong;
        /// <summary>
        /// The LatLong object that represents the lower-right corner of the map view.
        /// </summary>
        [PersistenceMode(PersistenceMode.InnerProperty),
        DataMember]
        public LatLong BottomRightLatLong
        {
            get { return _BottomRightLatLong; }
            set { _BottomRightLatLong = value; }
        }

        private LatLong _TopRightLatLong;
        /// <summary>
        /// The LatLong object that represents the upper-right corner of the map view. Only available in 3D Mode.
        /// </summary>
        [PersistenceMode(PersistenceMode.InnerProperty),
        DataMember]
        public LatLong TopRightLatLong
        {
            get { return _TopRightLatLong; }
            set { _TopRightLatLong = value; }
        }

        private LatLong _BottomLeftLatLong;
        /// <summary>
        /// The LatLong object that represents the lower-left corner of the map view. Only available in 3D Mode.
        /// </summary>
        [PersistenceMode(PersistenceMode.InnerProperty),
        DataMember]
        public LatLong BottomLeftLatLong
        {
            get { return _BottomLeftLatLong; }
            set { _BottomLeftLatLong = value; }
        }

        #endregion

        #region Helper Properties

        /// <summary>
        /// Gets the Minimum Latitude value based on comparing the BottomRightLatLong and TopLeftLatLong properties
        /// </summary>
        public double MinLatitude
        {
            get
            {
                //return GetLowest(BottomRightLatLong.Latitude, TopLeftLatLong.Latitude);
                double? retVal = new double?();

                double? val1 = new double?();
                if (this.BottomRightLatLong != null)
                    val1 = this.BottomRightLatLong.Latitude;

                double? val2 = new double?();
                if (this.TopLeftLatLong != null)
                    val2 = this.TopLeftLatLong.Latitude;

                double? val3 = new double?();
                if (this.BottomLeftLatLong != null)
                    val3 = this.BottomLeftLatLong.Latitude;

                double? val4 = new double?();
                if (this.TopRightLatLong != null)
                    val4 = this.TopRightLatLong.Latitude;


                if (val1.HasValue)
                    retVal = val1;

                if (val2.HasValue)
                    if (retVal.HasValue)
                        retVal = this.GetLowest(retVal.Value, val2.Value);
                    else
                        retVal = val2;

                if (val3.HasValue)
                    if (retVal.HasValue)
                        retVal = this.GetLowest(retVal.Value, val3.Value);
                    else
                        retVal = val3;

                if (val4.HasValue)
                    if (retVal.HasValue)
                        retVal = this.GetLowest(retVal.Value, val4.Value);
                    else
                        retVal = val4;


                if (retVal.HasValue)
                    return retVal.Value;
                else
                    return 0;
            }
        }

        /// <summary>
        /// Gets the Maximum Latitude value based on comparing the BottomRightLatLong and TopLeftLatLong properties
        /// </summary>
        public double MaxLatitude
        {
            get
            {
                //return GetHighest(BottomRightLatLong.Latitude, TopLeftLatLong.Latitude);
                double? retVal = new double?();

                double? val1 = new double?();
                if (this.BottomRightLatLong != null)
                    val1 = this.BottomRightLatLong.Latitude;

                double? val2 = new double?();
                if (this.TopLeftLatLong != null)
                    val2 = this.TopLeftLatLong.Latitude;

                double? val3 = new double?();
                if (this.BottomLeftLatLong != null)
                    val3 = this.BottomLeftLatLong.Latitude;

                double? val4 = new double?();
                if (this.TopRightLatLong != null)
                    val4 = this.TopRightLatLong.Latitude;


                if (val1.HasValue)
                    retVal = val1;

                if (val2.HasValue)
                    if (retVal.HasValue)
                        retVal = this.GetHighest(retVal.Value, val2.Value);
                    else
                        retVal = val2;

                if (val3.HasValue)
                    if (retVal.HasValue)
                        retVal = this.GetHighest(retVal.Value, val3.Value);
                    else
                        retVal = val3;

                if (val4.HasValue)
                    if (retVal.HasValue)
                        retVal = this.GetHighest(retVal.Value, val4.Value);
                    else
                        retVal = val4;


                if (retVal.HasValue)
                    return retVal.Value;
                else
                    return 0;
            }
        }

        /// <summary>
        /// Gets the Minimum Longitude value based on comparing the BottomRightLatLong and TopLeftLatLong properties
        /// </summary>
        public double MinLongitude
        {
            get
            {
                //return GetLowest(BottomRightLatLong.Longitude, TopLeftLatLong.Longitude);
                double? retVal = new double?();

                double? val1 = new double?();
                if (this.BottomRightLatLong != null)
                    val1 = this.BottomRightLatLong.Longitude;

                double? val2 = new double?();
                if (this.TopLeftLatLong != null)
                    val2 = this.TopLeftLatLong.Longitude;

                double? val3 = new double?();
                if (this.BottomLeftLatLong != null)
                    val3 = this.BottomLeftLatLong.Longitude;

                double? val4 = new double?();
                if (this.TopRightLatLong != null)
                    val4 = this.TopRightLatLong.Longitude;


                if (val1.HasValue)
                    retVal = val1;

                if (val2.HasValue)
                    if (retVal.HasValue)
                        retVal = this.GetLowest(retVal.Value, val2.Value);
                    else
                        retVal = val2;

                if (val3.HasValue)
                    if (retVal.HasValue)
                        retVal = this.GetLowest(retVal.Value, val3.Value);
                    else
                        retVal = val3;

                if (val4.HasValue)
                    if (retVal.HasValue)
                        retVal = this.GetLowest(retVal.Value, val4.Value);
                    else
                        retVal = val4;


                if (retVal.HasValue)
                    return retVal.Value;
                else
                    return 0;
            }
        }

        /// <summary>
        /// Gets the Maximum Longitude value based on comparing the BottomRightLatLong and TopLeftLatLong properties
        /// </summary>
        public double MaxLongitude
        {
            get
            {
                //return GetHighest(BottomRightLatLong.Longitude, TopLeftLatLong.Longitude);

                double? retVal = new double?();

                double? val1 = new double?();
                if (this.BottomRightLatLong != null)
                    val1 = this.BottomRightLatLong.Longitude;

                double? val2 = new double?();
                if (this.TopLeftLatLong != null)
                    val2 = this.TopLeftLatLong.Longitude;

                double? val3 = new double?();
                if (this.BottomLeftLatLong != null)
                    val3 = this.BottomLeftLatLong.Longitude;

                double? val4 = new double?();
                if (this.TopRightLatLong != null)
                    val4 = this.TopRightLatLong.Longitude;


                if (val1.HasValue)
                    retVal = val1;

                if (val2.HasValue)
                    if (retVal.HasValue)
                        retVal = this.GetHighest(retVal.Value, val2.Value);
                    else
                        retVal = val2;

                if (val3.HasValue)
                    if (retVal.HasValue)
                        retVal = this.GetHighest(retVal.Value, val3.Value);
                    else
                        retVal = val3;

                if (val4.HasValue)
                    if (retVal.HasValue)
                        retVal = this.GetHighest(retVal.Value, val4.Value);
                    else
                        retVal = val4;


                if (retVal.HasValue)
                    return retVal.Value;
                else
                    return 0;
            }
        }

        #endregion

        #region Helper Methods

        private double GetLowest(double one, double two)
        {
            return (one < two ? one : two);
        }

        private double GetHighest(double one, double two)
        {
            return (one > two ? one : two);
        }

        #endregion
    }
}