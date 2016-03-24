/* ----------------------------------------------------------------------------------- */
/* Copyright (C) Simplovation LLC (http://Simplovation.com) 2016. All rights reserved. */
/* Licensing information available at http://webmapsve.codeplex.com                    */
/* ----------------------------------------------------------------------------------- */
using System.ComponentModel;
using System.Web.UI;
using Simplovation.Web.Maps.VE.Base;

[assembly: System.Web.UI.WebResource("Simplovation.Web.Maps.VE.Extenders.MiniMapExtender.js", "text/javascript")]

namespace Simplovation.Web.Maps.VE.Extenders
{
    /// <summary>
    /// Allows a Mini Map to easily be added to the Virtual Earth Map. Allows the Mini Map to easily be aligned to any side/corner of the Virtual Earth Map.
    /// </summary>
    [Designer(typeof(MiniMapExtenderDesigner)),
    ClientScriptResource("Simplovation.Web.Maps.VE.Extenders.MiniMapExtender.js", "Simplovation.Web.Maps.VE"),
    TargetControlType(typeof(Map))]
    public class MiniMapExtender : Simplovation.Web.Maps.VE.Base.ExtenderControl
    {
        private bool _ShowMiniMap = true;
        /// <summary>
        /// A boolean value determining whether the Mini Map is shown. Default is True.
        /// </summary>
        [ExtenderControlProperty,
        DefaultValue(true)]
        public bool ShowMiniMap
        {
            get
            {
                //return GetPropertyValue<bool>("ShowMiniMap", true);
                return this._ShowMiniMap;
            }
            set
            {
                //SetPropertyValue<bool>("ShowMiniMap", value);
                this._ShowMiniMap = value;
            }
        }

        private MiniMapSize _MiniMapSize = MiniMapSize.Small;
        /// <summary>
        /// The Size of the Mini Map to Show. Default is Small.
        /// </summary>
        [ExtenderControlProperty,
        DefaultValue(MiniMapSize.Small)]
        public MiniMapSize MiniMapSize
        {
            get
            {
                //return GetPropertyValue<MiniMapSize>("MiniMapSize", MiniMapSize.Small);
                return this._MiniMapSize;
            }
            set
            {
                //SetPropertyValue<MiniMapSize>("MiniMapSize", value);
                this._MiniMapSize = value;
            }
        }

        private MiniMapVerticalAlignment _VerticalSide = MiniMapVerticalAlignment.Top;
        /// <summary>
        /// Vertical side of the Map to align the Mini Map. Default is Top.
        /// </summary>
        [ExtenderControlProperty,
        DefaultValue(MiniMapVerticalAlignment.Top)]
        public MiniMapVerticalAlignment VerticalSide
        {
            get
            {
                //return GetPropertyValue<MiniMapVerticalAlignment>("VerticalSide", MiniMapVerticalAlignment.Top);
                return this._VerticalSide;
            }
            set
            {
                //SetPropertyValue<MiniMapVerticalAlignment>("VerticalSide", value);
                this._VerticalSide = value;
            }
        }

        private MiniMapHorizontalAlignment _HorizontalSide = MiniMapHorizontalAlignment.Right;
        /// <summary>
        /// Horizontal side of the Map to align the Mini Map. Default is Right.
        /// </summary>
        [ExtenderControlProperty,
        DefaultValue(MiniMapHorizontalAlignment.Right)]
        public MiniMapHorizontalAlignment HorizontalSide
        {
            get
            {
                //return GetPropertyValue<MiniMapHorizontalAlignment>("HorizontalSide", MiniMapHorizontalAlignment.Right);
                return this._HorizontalSide;
            }
            set
            {
                //SetPropertyValue<MiniMapHorizontalAlignment>("HorizontalSide", value);
                this._HorizontalSide = value;
            }
        }

        /// <summary>
        /// Distance to the HorizontalSide edge of the Map in pixels from the same side of the Mini Map. Default is 0.
        /// </summary>
        [ExtenderControlProperty,
        DefaultValue(0)]
        public int HorizontalOffset { get; set; }

        /// <summary>
        /// Distance to the VerticalSide edge of the Map in pixels from the same side of the Mini Map. Default is 0.
        /// </summary>
        [ExtenderControlProperty,
        DefaultValue(0)]
        public int VerticalOffset { get; set; }
    }
}
