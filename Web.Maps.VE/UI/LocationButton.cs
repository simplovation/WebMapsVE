/* ----------------------------------------------------------------------------------- */
/* Copyright (C) Simplovation LLC (http://Simplovation.com) 2016. All rights reserved. */
/* Licensing information available at http://webmapsve.codeplex.com                    */
/* ----------------------------------------------------------------------------------- */
using System;
using Simplovation.Web.Maps.VE.Util;
using System.Web.UI.HtmlControls;

namespace Simplovation.Web.Maps.VE
{
    /// <summary>
    /// A HtmlButton control with Location specific propertyies (Latitude, Longitude, ZoomLevel, Shape) that specify where the Target Map control is repositioned to when clicked.
    /// </summary>
    public class LocationButton : HtmlButton
    {
        public LocationButton() { }

        /// <summary>
        /// The ID of the Map this link targets.
        /// </summary>
        public string TargetMapID { get; set; }

        /// <summary>
        /// The ID of the MasterPage ContentPlaceHolder the Target Map control is located within.
        /// </summary>
        public string TargetContentPlaceHolderID { get; set; }

        /// <summary>
        /// Sets the Latitude to set the map's location to.
        /// </summary>
        public double Latitude { get; set; }

        /// <summary>
        /// Sets the Longitude to set the map's location to.
        /// </summary>
        public double Longitude { get; set; }

        private int _ZoomLevel = -1;
        /// <summary>
        /// Sets the zoom level this link will change the map to. Default is -1, which doesn't change the map's zoom level.
        /// </summary>
        public int ZoomLevel
        {
            get
            {
                return this._ZoomLevel;
            }
            set
            {
                this._ZoomLevel = value;
            }
        }

        /// <summary>
        /// The ClientID of the VEShape object to center the Map to. This property is used instead of the Latitude and Longitude properties when set.
        /// </summary>
        public string ShapeClientID { get; set; }

        /// <summary>
        /// The Tag of the Shape object to center the Map to. This property is used instead of the Latitude and Longitude properties when set.
        /// </summary>
        public string ShapeTag { get; set; }

        public new string OnClientClick
        {
            get
            {
                Map map = ControlHelper.FindTargetMap(this, this.TargetMapID, this.TargetContentPlaceHolderID);
                if (map == null)
                {
                    throw new InvalidOperationException(String.Format("Map Control with the ID '{0}' not found.", this.TargetMapID));
                }

                if (!string.IsNullOrEmpty(this.ShapeTag))
                {
                    if (this.ZoomLevel > -1)
                    {
                        return String.Format("$find('{0}').SetCenterOnShapeByTag('{1}',{2});",
                            map.ClientID, this.ShapeTag, this.ZoomLevel.ToString());
                    }
                    else
                    {
                        return String.Format("$find('{0}').SetCenterOnShapeByTag('{1}');",
                            map.ClientID, this.ShapeTag);
                    }
                }
                else if (this.ShapeClientID != null)
                {
                    if (this.ZoomLevel > -1)
                    {
                        return String.Format("$find('{0}').SetCenterOnShapeByID('{1}',{2});",
                            map.ClientID, this.ShapeClientID, this.ZoomLevel.ToString());
                    }
                    else
                    {
                        return String.Format("$find('{0}').SetCenterOnShapeByID('{1}');",
                            map.ClientID, this.ShapeClientID);
                    }
                }
                else
                {
                    if (this.ZoomLevel > -1)
                    {
                        return String.Format("$find('{0}').SetCenterAndZoom(new VELatLong({1},{2}),{3});",
                            map.ClientID, this.Latitude.ToString(), this.Longitude.ToString(), this.ZoomLevel.ToString());
                    }
                    else
                    {
                        return String.Format("$find('{0}').SetCenter(new VELatLong({1},{2}));",
                            map.ClientID, this.Latitude.ToString(), this.Longitude.ToString());
                    }
                }
            }
            set
            {
                throw new Exception("OnClientClick property can not be set.");
            }
        }

        protected override void OnPreRender(EventArgs e)
        {
            //base.OnClientClick = this.OnClientClick;
            base.Attributes["onclick"] = this.OnClientClick + "return void(0);";

            base.Attributes["type"] = "button";

            base.OnPreRender(e);
        }
    }
}
