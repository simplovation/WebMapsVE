/* ----------------------------------------------------------------------------------- */
/* Copyright (C) Simplovation LLC (http://Simplovation.com) 2016. All rights reserved. */
/* Licensing information available at http://webmapsve.codeplex.com                    */
/* ----------------------------------------------------------------------------------- */
using System.Collections.Generic;
using System.ComponentModel;
using System.Web.UI;
using Simplovation.Web.Maps.VE.Base;

[assembly: System.Web.UI.WebResource("Simplovation.Web.Maps.VE.Extenders.TileLayerExtender.js", "text/javascript")]

namespace Simplovation.Web.Maps.VE.Extenders
{
    /// <summary>
    /// Allows a Custom Tile Layers to be added to the Virtual Earth Map.
    /// </summary>
    [Designer(typeof(TileLayerExtenderDesigner)),
    ClientScriptResource("Simplovation.Web.Maps.VE.Extenders.TileLayerExtender.js", "Simplovation.Web.Maps.VE"),
    TargetControlType(typeof(Map)),
    ParseChildren(true), PersistChildren(false)]
    public class TileLayerExtender : Simplovation.Web.Maps.VE.Base.ExtenderControl
    {
        private List<TileSourceSpecification> _TileSources = new List<TileSourceSpecification>();
        /// <summary>
        /// A List of TileSourceSpecification objects that define the Custom Tile Layers to be added to the Virtual Earth Map.
        /// </summary>
        [ExtenderControlProperty]
        public List<TileSourceSpecification> TileSources
        {
            get
            {
                return this._TileSources;
            }
            set
            {
                this._TileSources = value;
            }
        }
    }
}