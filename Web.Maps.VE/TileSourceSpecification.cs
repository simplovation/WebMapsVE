/* ----------------------------------------------------------------------------------- */
/* Copyright (C) Simplovation LLC (http://Simplovation.com) 2016. All rights reserved. */
/* Licensing information available at http://webmapsve.codeplex.com                    */
/* ----------------------------------------------------------------------------------- */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web.UI;

namespace Simplovation.Web.Maps.VE
{
    /// <summary>
    /// Information about a Custom Map Tile Source
    /// </summary>
    [ParseChildren(true), PersistChildren(false)]
    public class TileSourceSpecification
    {
        /// <summary>
        /// A collection of LatLongRectangle objects that specify the layers approximate coverage area.
        /// </summary>
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public List<LatLongRectangle> Bounds { get; set; }

        /// <summary>
        /// When the map is in 2D mode, this property specifies the client-side JavaScript function that determines the correct file names for your tiles. When a GetTilePath value is specified, the NumServers and TileSource properties are ignored.
        /// </summary>
        public string GetTilePath { get; set; }

        /// <summary>
        /// The unique identifier for the layer. Required.
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// The Maximum Zoom Level to display the custom tile source.
        /// </summary>
        public int? MaxZoom { get; set; }

        /// <summary>
        /// The Minimum Zoom Level to display the custom tile source.
        /// </summary>
        public int? MinZoom { get; set; }

        private int _NumServers = 1;
        /// <summary>
        /// The number of servers on which tiles are hosted. Use this property if your tile source uses more than one server. Default is 1.
        /// </summary>
        public int NumServers
        {
            get
            {
                return this._NumServers;
            }
            set
            {
                this._NumServers = value;
            }
        }

        private double _Opacity = 1.0;
        /// <summary>
        /// The Opacity level of the tiles when displayed over the map. Default is 1.0 (100%)
        /// </summary>
        public double Opacity
        {
            get
            {
                return this._Opacity;
            }
            set
            {
                this._Opacity = value;
            }
        }

        /// <summary>
        /// The location of the tiles. Required.
        /// </summary>
        public string TileSource { get; set; }

        /// <summary>
        /// The Z-Index value for the tiles. Optional.
        /// </summary>
        public int? ZIndex { get; set; }

        private bool _VisibleOnLoad = true;
        /// <summary>
        /// Determines whether the Layer is shown when added to the Map. Default is True.
        /// </summary>
        public bool VisibleOnLoad
        {
            get
            {
                return this._VisibleOnLoad;
            }
            set
            {
                this._VisibleOnLoad = value;
            }
        }
    }
}