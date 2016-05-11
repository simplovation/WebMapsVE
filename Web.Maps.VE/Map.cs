/* ----------------------------------------------------------------------------------- */
/* Copyright (C) Simplovation LLC (http://Simplovation.com) 2016. All rights reserved. */
/* Licensing information available at http://webmapsve.codeplex.com                    */
/* ----------------------------------------------------------------------------------- */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Security;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Simplovation.Web.Maps.VE.Base;
using Simplovation.Web.Maps.VE.Collections;

[assembly: System.Web.UI.WebResource("Simplovation.Web.Maps.VE.Map.js", "text/javascript")]
[assembly: System.Web.UI.WebResource("Simplovation.Web.Maps.VE.Map.min.js", "text/javascript")]
[assembly: TagPrefix("Simplovation.Web.Maps.VE", "Simplovation")]

// http://blogs.msdn.com/shawnfa/archive/2005/02/04/367390.aspx
[assembly: AllowPartiallyTrustedCallers()]

namespace Simplovation.Web.Maps.VE
{
    /// <summary>
    /// An ASP.NET AJAX Bing Maps Mapping Server Control
    /// </summary>
    //[ClientScriptResource("Simplovation.Web.Maps.VE.Map.js", "Simplovation.Web.Maps.VE")]
    [ToolboxData("<{0}:Map runat=server></{0}:Map>"),
    Designer(typeof(Design.MapDesigner)),
    Description("ASP.NET AJAX Bing Map Server Control")]
    public class Map : Simplovation.Web.Maps.VE.Base.AsyncScriptControl
    {
        internal object _licenseLock = new object();

        private DirectionsLoadedEventArgs _directionsLoadedEventArgs;
        private FindEventArgs _findLoadedEventArgs;
        private FindLocationsEventArgs _findLocationsEventArgs;
        private ImportShapeLayerDataEventArgs _importShapeLayerDataEventArgs;

        /// <summary>
        /// Instantiates a new Map object.
        /// </summary>
        public Map() : base()
        {
            this.Width = new System.Web.UI.WebControls.Unit("400px");
            this.Height = new System.Web.UI.WebControls.Unit("400px");
            this.LatLong = new LatLong(40.5137991550441, -97.734375);
        }

        /// <summary>
        /// The Dispose method.
        /// </summary>
        public override void Dispose()
        {
            base.Dispose();
        }

        /// <summary>
        /// OnLoad
        /// </summary>
        /// <param name="e">EventArgs</param>
        protected override void OnLoad(EventArgs e)
        {
            ScriptManager sm = ScriptManager.GetCurrent(this.Page);

            if (sm == null)
            {
                throw new InvalidOperationException("The control with ID '" + this.ID + "' requires a ScriptManager on the page. The ScriptManager must appear before any controls that need it.");
            }

            if (sm.IsInAsyncPostBack)
            {
                HttpRequest r = HttpContext.Current.Request;

                for (int i = 0; i < r.Form.Keys.Count; i++)
                {
                    if (r.Form.Keys[i] != null)
                    {
                        if (r.Form.Keys[i].EndsWith(this.ID + "$UP_HiddenDirectionsField"))
                        {
                            string directions = r.Form[r.Form.Keys[i]];
                            this._directionsLoadedEventArgs = new DirectionsLoadedEventArgs();
                            if (directions.Length != 0)
                            {
                                this._directionsLoadedEventArgs.Route = Simplovation.Web.Maps.VE.Util.JSONHelper.Deserialize<Route>(directions);
                            }
                        }
                        else if (r.Form.Keys[i].EndsWith(this.ID + "$UP_HiddenFindField"))
                        {
                            string findResults = r.Form[r.Form.Keys[i]];
                            this._findLoadedEventArgs = new FindEventArgs();
                            if (findResults.Length != 0)
                            {
                                this._findLoadedEventArgs = Simplovation.Web.Maps.VE.Util.JSONHelper.Deserialize<FindEventArgs>(findResults);
                            }
                        }
                        else if (r.Form.Keys[i].EndsWith(this.ID + "$UP_HiddenFLField"))
                        {
                            string findLocationsResults = r.Form[r.Form.Keys[i]];
                            this._findLocationsEventArgs = new FindLocationsEventArgs();
                            if (findLocationsResults.Length != 0)
                            {
                                this._findLocationsEventArgs = Simplovation.Web.Maps.VE.Util.JSONHelper.Deserialize<FindLocationsEventArgs>(findLocationsResults);
                            }
                        }
                        else if (r.Form.Keys[i].EndsWith(this.ID + "$UP_ISLDHF"))
                        {
                            string importShapeLayerDataResults = r.Form[r.Form.Keys[i]];
                            this._importShapeLayerDataEventArgs = new ImportShapeLayerDataEventArgs();
                            if (!string.IsNullOrEmpty(importShapeLayerDataResults))
                            {
                                this._importShapeLayerDataEventArgs = Simplovation.Web.Maps.VE.Util.JSONHelper.Deserialize<ImportShapeLayerDataEventArgs>(importShapeLayerDataResults);
                            }
                        }
                    }
                }
            }

            base.OnLoad(e);
        }

        protected override void LoadAsyncData(string asyncData)
        {
            if (asyncData.Length != 0)
            {
                AsyncMapData mapData = Simplovation.Web.Maps.VE.Util.JSONHelper.Deserialize<AsyncMapData>(asyncData);

                this.Height = new Unit(mapData.Height.Value);
                this.Width = new Unit(mapData.Width.Value);

                if (mapData.Layers == null) mapData.Layers = new DirtyStateList<ShapeLayer>();


                foreach (ShapeLayer sl in mapData.Layers)
                {
                    //Remove JSONEncoding from the string properties of the Shape objects
                    //This encoding on client-side and decoding on server-side fixes an issue with putting HTML inside the text of these properties that caused an Exception.
                    foreach (Shape s in sl.Shapes)
                    {
                        if (!string.IsNullOrEmpty(s.Title)) s.Title = Util.JSONHelper.DecodeString(s.Title);
                        if (!string.IsNullOrEmpty(s.Description)) s.Description = Util.JSONHelper.DecodeString(s.Description);
                        if (s.CustomIcon != null)
                        {
                            if(!string.IsNullOrEmpty(s.CustomIcon.CustomHTML))
                                s.CustomIcon.CustomHTML = Util.JSONHelper.DecodeString(s.CustomIcon.CustomHTML);
                            if (!string.IsNullOrEmpty(s.CustomIcon.Image))
                                s.CustomIcon.Image = Util.JSONHelper.DecodeString(s.CustomIcon.Image);

                        }
                    }
                }

                // Set Map properties to match AsyncMapData
                
                if (mapData.ZoomLevel != null) this.Zoom = int.Parse(mapData.ZoomLevel.ToString());
                if (mapData.Latitude != null && mapData.Longitude != null)
                {
                    this.LatLong = new LatLong(double.Parse(mapData.Latitude.ToString()), double.Parse(mapData.Longitude.ToString()));
                }
                this._LatLongDirty = false;

                if (mapData.MapView != null) this._MapView = mapData.MapView;

                if (mapData.MapType.HasValue) this.MapType = (MapType)((int)mapData.MapType);
                this._MapTypeDirty = false;

                if (mapData.DistanceUnit.HasValue) this._DistanceUnit = (DistanceUnit)((int)mapData.DistanceUnit);

                if (mapData.EventArgs != null)
                {
                    // Make sure the EventArgs.latlong property always has a value.
                    if (mapData.EventName == "onclick" && !(mapData.ClickedLatitude == null || mapData.ClickedLongitude == null))
                    {
                        //when the OnClick event occurs, make sure it contains the point that was clickee by the user.
                        mapData.EventArgs.latlong = new LatLong((double)mapData.ClickedLatitude, (double)mapData.ClickedLongitude);
                    }
                    else if (mapData.EventArgs.latlong == null && !(mapData.Latitude == null || mapData.Longitude == null))
                    {
                        //if it doesn't have a value and the user didn't click, then make sure it contains the center point of the map.
                        mapData.EventArgs.latlong = new LatLong((double)mapData.Latitude, (double)mapData.Longitude);
                    }


                    // if an ElementID is passed, then get a reference to the Shape with that ID, if there is one.
                    mapData.EventArgs.Shape = null;
                    if (mapData.EventArgs.elementID != null)
                    {
                        foreach (ShapeLayer sl in mapData.Layers)
                        {
                            foreach (Shape s in sl.Shapes)
                            {
                                if (mapData.EventArgs.elementID.Length >= s.ClientID.Length)
                                {
                                    if (mapData.EventArgs.elementID.Substring(0, s.ClientID.Length) == s.ClientID)
                                    {
                                        mapData.EventArgs.Shape = s;
                                        break;
                                    }
                                }
                            }
                            if (mapData.EventArgs.Shape != null) { break; }
                        }
                    }

                }
                



                if (mapData.Layers.Count != 0)
                {
                    this.Layers = mapData.Layers;
                    this.Layers.MarkClean();
                    foreach (ShapeLayer sl in this.Layers)
                    {
                        sl.Shapes.MarkClean();
                    }
                }



                if (mapData != null)
                {
                    // Load Map Properties from props variable
                    switch (mapData.EventName)
                    {
                        case "directionsloaded":
                            if (this.DirectionsLoaded != null)
                            {
                                this.DirectionsLoaded(this, this._directionsLoadedEventArgs);
                            }
                            break;
                        case "findloaded":
                            if (this.FindLoaded != null)
                            {
                                this.FindLoaded(this, this._findLoadedEventArgs);
                            }
                            break;
                        case "findlocationsloaded":
                            if (this.FindLocationsLoaded != null)
                            {
                                this.FindLocationsLoaded(this, this._findLocationsEventArgs);
                            }
                            break;
                        case "importshapelayerdataloaded":
                            if (this.ImportShapeLayerDataLoaded != null)
                            {
                                this.ImportShapeLayerDataLoaded(this, this._importShapeLayerDataEventArgs);
                            }
                            break;
                        case "maploaded":
                            if (this.MapLoaded != null)
                            {
                                mapData.MapLoadedEventArgs.zoomLevel = this.Zoom;
                                mapData.MapLoadedEventArgs.mapType = this.MapType;
                                mapData.MapLoadedEventArgs.latlong = this.LatLong;
                                this.MapLoaded(this, mapData.MapLoadedEventArgs);
                            }
                            break;

                        // Map Events
                        case "maptypechanged":
                            if (this.ChangeMapType != null) this.ChangeMapType(this, mapData.EventArgs);
                            break;
                        case "onchangeview":
                            if (this.ChangeView != null && this.MapType != MapType.Birdseye) this.ChangeView(this, mapData.EventArgs);
                            break;
                        case "onendzoom":
                            if (this.EndZoom != null) this.EndZoom(this, mapData.EventArgs);
                            break;
                        /*
                        case "onerror":
                            if (this.Error != null) this.Error(this, mapData.EventArgs);
                            break;
                        */
                        /*
                        case "onobliquechange":
                            if (this.ObliqueChange != null) this.ObliqueChange(this, mapData.EventArgs);
                            break;
                        */
                        case "onobliqueenter":
                            if (this.ObliqueEnter != null) this.ObliqueEnter(this, mapData.EventArgs);
                            break;
                        case "onobliqueleave":
                            if (this.ObliqueLeave != null) this.ObliqueLeave(this, mapData.EventArgs);
                            break;
                        /*
                        case "onstartzoom":
                            if (this.StartZoom != null) this.StartZoom(this, mapData.EventArgs);
                            break;
                        */

                        // Mouse Events
                        case "click":
                            if (this.Click != null && this.MapType != MapType.Birdseye) this.Click(this, mapData.EventArgs);
                            break;
                        /*
                        case "dblclick":
                            if (this.DoubleClick != null) this.DoubleClick(this, mapData.EventArgs);
                            break;
                        case "mousemove":
                            if (this.MouseMove != null) this.MouseMove(this, mapData.EventArgs);
                            break;
                        case "mousedown":
                            if (this.MouseDown != null) this.MouseDown(this, mapData.EventArgs);
                            break;
                        case "mouseup":
                            if (this.MouseUp != null) this.MouseUp(this, mapData.EventArgs);
                            break;
                        case "mouseout":
                            if (this.MouseOut != null) this.MouseOut(this, mapData.EventArgs);
                            break;
                        case "onmousewheel":
                            if (this.MouseWheel != null) this.MouseWheel(this, mapData.EventArgs);
                            break;

                        // Keyboard Events
                        case "onkeypress":
                            if (this.KeyPress != null) this.KeyPress(this, mapData.EventArgs);
                            break;
                        case "onkeydown":
                            if (this.KeyDown != null) this.KeyDown(this, mapData.EventArgs);
                            break;
                        case "onkeyup":
                            if (this.KeyUp != null) this.KeyUp(this, mapData.EventArgs);
                            break;
                        */
                    }
                }
            }
        }

        /// <summary>
        /// TagKey
        /// </summary>
        protected override HtmlTextWriterTag TagKey
        {
            get
            {
                return HtmlTextWriterTag.Div;
            }
        }

        private string GetVEMapScript()
        {
            string strPath;

            if (this.Page.Request.IsSecureConnection)
            {
                // "Standard" URL using SSL
                strPath = "https://www.bing.com/api/maps/mapcontrol";
            }
            else
            {
                // "Standard URL"
                strPath = "https://www.bing.com/api/maps/mapcontrol";
            }

            switch (this.Market)
            {
                case Market.English:
                    break;
                case Market.Japanese:
                    strPath += "&mkt=ja-jp";
                    break;
                case Market.ja_jp:
                    strPath += "&mkt=ja-jp";
                    break;
                case Market.cs_cz:
                    strPath += "&mkt=cs-cz";
                    break;
                case Market.da_dk:
                    strPath += "&mkt=da-dk";
                    break;
                case Market.de_de:
                    strPath += "&mkt=de-de";
                    break;
                case Market.en_ca:
                    strPath += "&mkt=en-ca";
                    break;
                case Market.en_gb:
                    strPath += "&mkt=en-gb";
                    break;
                case Market.es_es:
                    strPath += "&mkt=es-es";
                    break;
                case Market.fi_fi:
                    strPath += "&mkt=fi-fi";
                    break;
                case Market.fr_fr:
                    strPath += "&mkt=fr-fr";
                    break;
                case Market.it_it:
                    strPath += "&mkt=it-it";
                    break;
                case Market.nb_no:
                    strPath += "&mkt=nb-no";
                    break;
                case Market.nl_nl:
                    strPath += "&mkt=nl-nl";
                    break;
                case Market.pt_pt:
                    strPath += "&mkt=pt-pt";
                    break;
                case Market.sv_se:
                    strPath += "&mkt=sv-se";
                    break;
            }

            return strPath;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected override IEnumerable<ScriptDescriptor> GetScriptDescriptors()
        {
            List<ScriptDescriptor> descriptors = new List<ScriptDescriptor>();
            foreach (ScriptDescriptor sd in base.GetScriptDescriptors())
            {
                ScriptControlDescriptor d = sd as ScriptControlDescriptor;

                if (d != null)
                {
                    if (d.ClientID == this.ClientID)
                    {
                        d.AddProperty("AppPathRoot", VirtualPathUtility.ToAbsolute("~/"));

                        d.AddProperty("ShowPoweredBy", this.ShowPoweredBy);

                        d.AddProperty("OnMapLoaded_Handled", this.MapLoaded != null);
                        d.AddProperty("OnChangeMapType_Handled", this.ChangeMapType != null);
                        d.AddProperty("OnChangeView_Handled", this.ChangeView != null);
                        d.AddProperty("OnEndZoom_Handled", this.EndZoom != null);
                        d.AddProperty("OnObliqueEnter_Handled", this.ObliqueEnter != null);
                        d.AddProperty("OnObliqueLeave_Handled", this.ObliqueLeave != null);
                        d.AddProperty("Click_Handled", this.Click != null);

                        d.AddProperty("FindArgs", this._FindArguments);

                        if (this._importShapeLayerData_shapeSource != null)
                        {
                            d.AddProperty("ImportShapeLayerData_shapeSource", this._importShapeLayerData_shapeSource);
                            d.AddProperty("ImportShapeLayerData_setBestView", this._importShapeLayerData_setBestView);
                        }
                    }
                }

                descriptors.Add(sd);
            }
            return descriptors;
        }

        protected override IEnumerable<ScriptReference> GetScriptReferences()
        {
            List<ScriptReference> scripts = (List<ScriptReference>)base.GetScriptReferences();
            if (HttpContext.Current.IsDebuggingEnabled)
            {
                scripts.Add(new ScriptReference("Simplovation.Web.Maps.VE.Map.js", "Simplovation.Web.Maps.VE"));
            }
            else
            {
                scripts.Add(new ScriptReference("Simplovation.Web.Maps.VE.Map.min.js", "Simplovation.Web.Maps.VE"));
            }
            return scripts;
        }

        /// <summary>
        /// The CreateChileControls method.
        /// </summary>
        protected override void CreateChildControls()
        {
            System.Web.UI.HtmlControls.HtmlGenericControl m = new System.Web.UI.HtmlControls.HtmlGenericControl("div");
            m.ID = "Map";
            m.Style.Add("position", "relative");
            m.Style.Add("width", "100%");
            m.Style.Add("height", "100%");
            this.Controls.Add(m);

            HiddenField directionsHiddenField = new HiddenField();
            directionsHiddenField.ID = this.InternalUpdatePanel.ID + "_HiddenDirectionsField";
            directionsHiddenField.Value = string.Empty;
            this.InternalUpdatePanel.ContentTemplateContainer.Controls.Add(directionsHiddenField);

            HiddenField findHiddenField = new HiddenField();
            findHiddenField.ID = this.InternalUpdatePanel.ID + "_HiddenFindField";
            findHiddenField.Value = string.Empty;
            this.InternalUpdatePanel.ContentTemplateContainer.Controls.Add(findHiddenField);

            HiddenField findLocationsHiddenField = new HiddenField();
            findLocationsHiddenField.ID = this.InternalUpdatePanel.ID + "_HiddenFLField";
            findLocationsHiddenField.Value = string.Empty;
            this.InternalUpdatePanel.ContentTemplateContainer.Controls.Add(findLocationsHiddenField);

            HiddenField importShapeLayerDataHiddenField = new HiddenField();
            importShapeLayerDataHiddenField.ID = this.InternalUpdatePanel.ID + "_ISLDHF";
            importShapeLayerDataHiddenField.Value = string.Empty;
            this.InternalUpdatePanel.ContentTemplateContainer.Controls.Add(importShapeLayerDataHiddenField);

            base.CreateChildControls();
        }

        /// <summary>
        /// OnPreRender
        /// </summary>
        /// <param name="e">EventArgs</param>
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            ScriptManager sm = ScriptManager.GetCurrent(Page);
            if (!sm.IsInAsyncPostBack)
            {
                string strUrl = string.Empty;
                if (!string.IsNullOrEmpty(this.CustomMapScript)){
                    // Use Custom Script file instead of Bing Maps API
                    strUrl = this.CustomMapScript;
                    if (strUrl.StartsWith("~")){
                        strUrl = VirtualPathUtility.ToAbsolute(strUrl);
                    }
                }
                else
                {
                    // Use Bing Maps API Script file
                    strUrl = this.GetVEMapScript();
                }
                
                //this.Page.ClientScript.RegisterClientScriptInclude("VEMapControl", strUrl);
                /*
                HtmlGenericControl ve = new HtmlGenericControl("script");
                ve.Attributes.Add("type", "text/javascript");
                ve.Attributes.Add("src", strUrl);
                this.Page.Header.Controls.Add(ve);
                */

                if (this.Page.Header == null)
                {
                    throw new InvalidOperationException("Web.Maps.VE: The MS Bing Maps JavaScript API could not be loaded. A header control on the page is required. (e.g. <head runat=\"server\" />).");
                }
                
                LiteralControl ve = new LiteralControl("<script type='text/javascript' src='" + strUrl + "'></script>");
                this.Page.Header.Controls.Add(ve);

                //if (this.License.IsTrial) //if (_license.IsTrial)
                //{
                //    LiteralControl trialmessage = new LiteralControl("<script type='text/javascript'>alert('Your Simplovation.Web.Maps.VE v2.0 Trial License Expires " + _license.ExpirationDate.ToShortDateString() + "\\nTo purchase a Full Development License go to http://simplovation.com');</script>");
                //    this.Page.Header.Controls.Add(trialmessage);
                //}
            }
        }

        protected override string GetAsyncData()
        {
            AsyncMapData mapData = new AsyncMapData();

            mapData.Width = this.Width.Value;
            mapData.Height = this.Height.Value;
            
            if (this._ZoomDirty) mapData.ZoomLevel = this.Zoom;
            if (this._LatLongDirty) mapData.Latitude = this.Latitude;
            if (this._LatLongDirty) mapData.Longitude = this.Longitude;
            if (this._MapTypeDirty) mapData.MapType = this.MapType;

            if (this._direction_locations != null) mapData.Direction_Locations = this._direction_locations;
            if (this._direction_routeoptions != null) mapData.Direction_RouteOptions = this._direction_routeoptions;
            if (this._directions_clear == true) mapData.Directions_Clear = true;


            if (this._importShapeLayerData_shapeSource != null)
            {
                mapData.ImportShapeLayerData_shapeSource = this._importShapeLayerData_shapeSource;
                mapData.ImportShapeLayerData_setBestView = this._importShapeLayerData_setBestView;
            }


            /* Allow removal of Layers and Shapes */
            if (this.Layers.WasCleared)
            {
                mapData.DeleteLayersFirst = true;
            }
            else
            {
                if (!string.IsNullOrEmpty(this.Layers.ItemIndexesToRemove))
                {
                    mapData.ShapeLayersToRemove = this.Layers.ItemIndexesToRemove;
                }

                mapData.ShapesToRemove = "";
                foreach (ShapeLayer sl in this.Layers)
                {
                    if (sl.Shapes.IDListToRemove.Length != 0)
                    {
                        if (mapData.ShapesToRemove.Length != 0) mapData.ShapesToRemove += "|";
                        mapData.ShapesToRemove += sl.Shapes.IDListToRemove;
                    }
                }
            }
            if (this.Layers.IsDirty) mapData.Layers = this.Layers;


            if (this._FindArguments != null)
                mapData.FindArgs = this._FindArguments;

            if (this._FindLocations != null)
                mapData.FindLocations = this._FindLocations;

            return Simplovation.Web.Maps.VE.Util.JSONHelper.Serialize<AsyncMapData>(mapData);
        }

        #region Properties

        private bool _ShowPoweredBy = true;
        /// <summary>
        /// A boolean that determines whether to show the "Powered by Web.Maps.VE" badge.
        /// </summary>
        public bool ShowPoweredBy
        {
            get { return _ShowPoweredBy; }
            set { _ShowPoweredBy = value; }
        }

        private LatLongRectangle _MapView = null;
        /// <summary>
        /// The current MapView being shown to the user during an Async Postback.
        /// </summary>
        public LatLongRectangle MapView
        {
            get { return _MapView; }
        }

        private DistanceUnit _DistanceUnit = DistanceUnit.Miles;
        /// <summary>
        /// The distance unit for the map scale. Miles or Kilometers. Default is Miles.
        /// </summary>
        [ScriptControlProperty, DefaultValue(DistanceUnit.Miles)]
        public DistanceUnit DistanceUnit
        {
            get { return _DistanceUnit; }
            set
            {
                if (this.Page != null)
                {
                    ScriptManager sm = ScriptManager.GetCurrent(this.Page);
                    if (sm.IsInAsyncPostBack)
                    {
                        if (this._DistanceUnit != value) throw new Exception("The DistanceUnit cannot be changed during an Asynchronous Postback.");
                    }
                }
                _DistanceUnit = value;
            }
        }

        private DirtyStateList<ShapeLayer> _Layers = new DirtyStateList<ShapeLayer>();
        /// <summary>
        /// The Maps Shape Layers.
        /// </summary>
        [ScriptControlProperty,
        PersistenceMode(PersistenceMode.InnerProperty)]
        public DirtyStateList<ShapeLayer> Layers
        {
            get { return this._Layers; }
            set { this._Layers = value; }
        }

        private bool _AsyncPostbackPassShapes = true;
        /// <summary>
        /// This defines whether the Shapes plotted on the map will be posted back to the server during an Asynchronous Postback. This is to help improve the performance of "Dynamic Search" style maps. The Default is True.
        /// </summary>
        [ScriptControlProperty, DefaultValue(true)]
        public bool AsyncPostbackPassShapes
        {
            get { return _AsyncPostbackPassShapes; }
            set
            {
                if (!this.DesignMode)
                {
                    if (this.Page != null)
                    {
                        ScriptManager sm = ScriptManager.GetCurrent(this.Page);
                        if (sm.IsInAsyncPostBack)
                        {
                            if (this._AsyncPostbackPassShapes != value) throw new Exception("The AsyncPostbackPassShapes property cannot be changed during an Asynchronous Postback.");
                        }
                    }
                }
                _AsyncPostbackPassShapes = value;
            }
        }

        private Market _Market = Market.English;
        /// <summary>
        /// The Bing Maps API supported international market to use. Default is English.
        /// </summary>
        public Market Market
        {
            get { return this._Market; }
            set
            {
                if (this.Page != null)
                {
                    ScriptManager sm = ScriptManager.GetCurrent(this.Page);
                    if (sm.IsInAsyncPostBack)
                    {
                        if (this._Market != value) throw new Exception("The Map Market cannot be changed during an Asynchronous Postback.");
                    }
                }
                this._Market = value;
            }
        }

        private LatLong _LatLong = new LatLong(0,0);
        private bool _LatLongDirty = false;
        /// <summary>
        /// A LatLong object that represents the center of the map.
        /// </summary>
        [ScriptControlProperty]
        public LatLong LatLong
        {
            get { return _LatLong; }
            set { _LatLong = value; _LatLongDirty = true; }
        }

        /// <summary>
        /// The Latitude of the Map.LatLong property.
        /// </summary>
        public double Latitude
        {
            get { return this._LatLong.Latitude.Value; }
            set
            {
                if (this._LatLong == null) this._LatLong = new LatLong(0, 0);
                this._LatLong.Latitude = value;
                _LatLongDirty = true;
            }
        }

        /// <summary>
        /// The Longitude of the Map.LatLong property.
        /// </summary>
        public double Longitude
        {
            get { return this._LatLong.Longitude.Value; }
            set
            {
                if (this._LatLong == null) this._LatLong = new LatLong(0, 0);
                this._LatLong.Longitude = value;
                _LatLongDirty = true;
            }
        }

        private int _Zoom = 4;
        private bool _ZoomDirty = false;
        /// <summary>
        /// The zoom level to display. Valid values range from 1 through 19. Default is 4.
        /// </summary>
        [ScriptControlProperty, DefaultValue(4)]
        public int Zoom
        {
            get { return _Zoom; }
            set
            {
                int v = value;
                if (v < 1) v = 1;
                if (v > 19) v = 19;

                if (_Zoom != v) _ZoomDirty = true;

                _Zoom = v;
            }
        }

        //private bool _UseSSL = true;
        ///// <summary>
        ///// Determines whether the Bing Maps JavaScript file is included within the page using SSL or not. The Default is True.
        ///// </summary>
        //public bool UseSSL
        //{
        //    get { return this._UseSSL; }
        //    set { this._UseSSL = value; }
        //}

        private MapType _MapType = MapType.Road;
        private bool _MapTypeDirty = false;
        /// <summary>
        /// The style of the map; Road, Aerial, Hybrid or Oblique (Bird's eye).
        /// </summary>
        [ScriptControlProperty, DefaultValue(MapType.Road)]
        public MapType MapType
        {
            get { return _MapType; }
            set { _MapType = value; _MapTypeDirty = true; }
        }

        private bool _Fixed;
        /// <summary>
        /// A Boolean value that specifies whether the map view is displayed as a fixed map that the user cannot change. Default is false.
        /// </summary>
        [ScriptControlProperty, DefaultValue(false)]
        public bool Fixed
        {
            get { return _Fixed; }
            set
            {
                if (!this.DesignMode)
                {
                    if (this.Page != null)
                    {
                        ScriptManager sm = ScriptManager.GetCurrent(this.Page);
                        if (sm.IsInAsyncPostBack)
                        {
                            if (this._Fixed != value) throw new Exception("The Fixed cannot be changed during an Asynchronous Postback.");
                        }
                    }
                }
                _Fixed = value;
            }
        }

        private bool _ShowSwitch = true;
        /// <summary>
        /// Specifies whether to show the map mode switch on the dashboard control. Default is true.
        /// This property cannot be changed during an Asynchronous Postback.
        /// </summary>
        [ScriptControlProperty, DefaultValue(true)]
        public bool ShowSwitch
        {
            get { return _ShowSwitch; }
            set
            {
                if (!this.DesignMode)
                {
                    if (this.Page != null)
                    {
                        ScriptManager sm = ScriptManager.GetCurrent(this.Page);
                        if (sm.IsInAsyncPostBack)
                        {
                            if (this._ShowSwitch != value) throw new Exception("The ShowSwitch cannot be changed during an Asynchronous Postback.");
                        }
                    }
                }
                _ShowSwitch = value;
            }
        }

        private NavigationBarMode _NavigationBarMode = NavigationBarMode.Normal;
        /// <summary>
        /// The maps dashboard size and type.
        /// This property cannot be changed during an Asynchronous Postback.
        /// </summary>
        [ScriptControlProperty, DefaultValue(NavigationBarMode.Normal)]
        public NavigationBarMode NavigationBarMode
        {
            get { return _NavigationBarMode; }
            set
            {
                if (!this.DesignMode)
                {
                    if (this.Page != null)
                    {
                        ScriptManager sm = ScriptManager.GetCurrent(this.Page);
                        if (sm.IsInAsyncPostBack)
                        {
                            if (this._NavigationBarMode != value) throw new Exception("The NavigationBarMode cannot be changed during an Asynchronous Postback.");
                        }
                    }
                }
                _NavigationBarMode = value;
            }
        }

        private int _TileBuffer = 0;
        /// <summary>
        /// An integer value greater than or equal to 0 that indicates the number of rings of additional tiles that should be loaded. The default is 0, and the maximum is 3.
        /// This property is used for enabling Tile Overfetching.
        /// </summary>
        [ScriptControlProperty, DefaultValue(0)]
        public int TileBuffer
        {
            get { return _TileBuffer; }
            set
            {
                int v = value;
                if (v < 0) { v = 0; }
                if (v > 3) { v = 3; }
                _TileBuffer = v;
            }
        }

        private bool _EnableBirdseye = true;
        /// <summary>
        /// A Boolean value that specifies whether or not to enable the Birdseye map style in the map control. The default value is True.
        /// </summary>
        [ScriptControlProperty(), DefaultValue(true)]
        public bool EnableBirdseye
        {
            get { return this._EnableBirdseye; }
            set
            {
                if (!this.DesignMode)
                {
                    if (this.Page != null)
                    {
                        ScriptManager sm = ScriptManager.GetCurrent(this.Page);
                        if (sm.IsInAsyncPostBack)
                        {
                            if (this._EnableBirdseye != value) throw new Exception("The EnableBirdseye cannot be changed during an Asynchronous Postback.");
                        }
                    }
                }
                this._EnableBirdseye = value;
            }
        }

        private bool _EnableDashboardLabels = true;
        /// <summary>
        /// A Boolean value that specifies whether or not labels appear on the map when a user clicks the Aerial or Birdseye map style buttons on the map control dashboard. The default value is true.
        /// </summary>
        [ScriptControlProperty(), DefaultValue(true)]
        public bool EnableDashboardLabels
        {
            get { return this._EnableDashboardLabels; }
            set
            {
                if (!this.DesignMode)
                {
                    if (this.Page != null)
                    {
                        ScriptManager sm = ScriptManager.GetCurrent(this.Page);
                        if (sm.IsInAsyncPostBack)
                        {
                            if (this._EnableDashboardLabels != value) throw new Exception("The EnableDashboardLabels cannot be changed during an Asynchronous Postback.");
                        }
                    }
                }
                this._EnableDashboardLabels = value;
            }
        }

        private bool _LoadBaseTiles = true;
        /// <summary>
        /// A Boolean value indicating whether or not to load the base map tiles. The default value is true.
        /// </summary>
        [ScriptControlProperty(), DefaultValue(true)]
        public bool LoadBaseTiles
        {
            get { return this._LoadBaseTiles; }
            set
            {
                if (!this.DesignMode)
                {
                    if (this.Page != null)
                    {
                        ScriptManager sm = ScriptManager.GetCurrent(this.Page);
                        if (sm.IsInAsyncPostBack)
                        {
                            if (this._LoadBaseTiles != value) throw new Exception("The LoadBaseTiles cannot be changed during an Asynchronous Postback.");
                        }
                    }
                }
                this._LoadBaseTiles = value;
            }
        }

        private string _OnClientMapLoaded = null;
        /// <summary>
        /// The JavaScript Method that is called on the client-side when the Map has finished loading.
        /// </summary>
        [ScriptControlProperty]
        public string OnClientMapLoaded
        {
            get { return _OnClientMapLoaded; }
            set { _OnClientMapLoaded = value; }
        }

        private string _BingKey = null;
        /// <summary>
        /// The Bing Maps Key used to authenticate map service requests.
        /// </summary>
        [ScriptControlProperty]
        public string BingKey
        {
            get { return _BingKey; }
            set { _BingKey = value; }
        }

        /// <summary>
        /// Sets the JavaScript file to include instead of the Microsoft Bing Maps JavaScript API. Only use if you have your own custom/hosted version of the script file.
        /// </summary>
        public string CustomMapScript
        {
            get;
            set;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Adds a <see cref="Shape">Shape</see> object to the default "base" Shape Layer.
        /// </summary>
        /// <param name="shape">The Shape to add to the Map's Defaut Shape Layer.</param>
        public void AddShape(Shape shape)
        {
            if (this.Layers == null) { this.Layers = new DirtyStateList<ShapeLayer>(); }
            if (this.Layers.Count == 0) { this.Layers.Add(new ShapeLayer()); }
            this.Layers[0].Shapes.Add(shape);
        }

        /// <summary>
        /// Deletes a <see cref="Shape">Shape</see> object from any Shape Layer on the Map.
        /// </summary>
        /// <param name="shape">The Shape to Deleve from the Map.</param>
        public void DeleteShape(Shape s)
        {
            if (this.Layers != null)
            {
                foreach(ShapeLayer sl in this.Layers)
                {
                    if (sl.Shapes.Contains(s))
                    {
                        sl.Shapes.Remove(s);
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Search all ShapeLayers and Return the first Shape that has its Tag property set to the passed in value.
        /// </summary>
        /// <param name="tag">The Shape.Tag value to search for.</param>
        /// <returns>The Shape with the Tag property that matches the "tag" passed in.</returns>
        public Shape GetShapeByTag(string tag)
        {
            Shape s = null;
            foreach (var l in this.Layers)
            {
                s = l.GetShapeByTag(tag);
                if (s != null)
                {
                    return s;
                }
            }
            return null;
        }

        private ShapeSourceSpecification _importShapeLayerData_shapeSource = null;
        private bool _importShapeLayerData_setBestView = false;
        /// <summary>
        /// Imports data from a GeoRSS feed, Live Search Maps Collection or KML URL
        /// </summary>
        /// <param name="shapeSource">A ShapeSourceSpecification object specifying the source of the Shape Layer data to import</param>
        /// /// <param name="setBestView">A boolean value specifying whether the map view is changed to the best view for the layer</param>
        public void ImportShapeLayerData(ShapeSourceSpecification shapeSource, bool setBestView)
        {
            this._importShapeLayerData_shapeSource = shapeSource;
            this._importShapeLayerData_setBestView = setBestView;
        }


        private List<object> _direction_locations = null;
        private RouteOptions _direction_routeoptions = null;
        private bool _directions_clear = false;

        /// <summary>
        /// Draws a multi-point route on the map.
        /// </summary>
        /// <overloads>Draws a multi-point route on the Map.</overloads>
        /// <param name="locations">The Array of Locations (can be either String or LatLong objects) to get the multi-point route for.</param>
        public void GetDirections(List<object> locations)
        {
            this.GetDirections(locations, new RouteOptions());
        }

        /// <summary>
        /// Draws a multi-point route on the map.
        /// </summary>
        /// <param name="locations">The Array of Locations (can be either String or LatLong objects) to get the multi-point route for.</param>
        /// <param name="routeOptions">The RouteOptions attributes for getting a multi-point route.</param>
        public void GetDirections(List<object> locations, RouteOptions routeOptions)
        {
            foreach (Object obj in locations)
            {
                if (obj.GetType() != typeof(string) && obj.GetType() != typeof(LatLong))
                {
                    throw new Exception("Location of unexpected type (" + obj.GetType().ToString() + ") found. Locations must be of type String or LatLong.");
                }
            }

            this._direction_locations = locations;
            this._direction_routeoptions = routeOptions;
            this._directions_clear = false;
        }

        /// <summary>
        /// Clears the currently plotted Route from the map.
        /// </summary>
        public void ClearDirections()
        {
            this._directions_clear = true;
        }


        private FindArguments _FindArguments = null;

        /// <summary>
        /// Performs a what (business) search or a where (location) search
        /// </summary>
        /// <param name="findArguments">The FindArguments used to perform the Find operation.</param>
        public void Find(FindArguments findArguments)
        {
            this._FindArguments = findArguments;
        }

        private LatLong _FindLocations = null;

        /// <summary>
        /// Performs a search for locations that match a LatLong coordinate input
        /// </summary>
        /// <param name="latlong">A LatLong class that specifies what map location to match</param>
        public void FindLocations(LatLong latlong)
        {
            this._FindLocations = latlong;
        }

        #endregion

        #region Delegates and Events

        /// <summary>
        /// Delegate for Asynchronous Postback based Map Events
        /// </summary>
        /// <param name="sender">The Object that fired the event.</param>
        /// <param name="e">A <see cref="AsyncMapEventArgs">AsyncMapEventArgs</see> object containing the event arguments for the event that was fired.</param>
        public delegate void AsyncMapEventHandler(object sender, AsyncMapEventArgs e);


        /// <summary>
        /// The Delegate for the Map.DirectionsLoaded event.
        /// </summary>
        /// <param name="sender">The Object that fired the event.</param>
        /// <param name="e">The Event Arguments for the Map.DirectionsLoaded event.</param>
        public delegate void DirectionsLoadedEventHandler(object sender, DirectionsLoadedEventArgs e);

        /// <summary>
        /// The Delegate for the Map.FindLoaded event.
        /// </summary>
        /// <param name="sender">The Object that fired the event.</param>
        /// <param name="e">The results returned from the Map.Find operation.</param>
        public delegate void FindLoadedEventHandler(object sender, FindEventArgs e);

        /// <summary>
        /// The Delegate for the Map.FindLocationsLoaded event.
        /// </summary>
        /// <param name="sender">The Object that fired the event.</param>
        /// <param name="e">The results returned from the Map.FindLocations operation.</param>
        public delegate void FindLocationsLoadedEventHandler(object sender, FindLocationsEventArgs e);

        /// <summary>
        /// The Delegate for the Map.MapLoaded event.
        /// </summary>
        /// <param name="sender">The Object that fired the event.</param>
        /// <param name="e">The Event Arguments for the Map.MapLoaded event.</param>
        public delegate void MapLoadedEventHandler(object sender, MapLoadedEventArgs e);

        /// <summary>
        /// The Delegate for the Map.ImportShapeLayerDataLoaded event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void ImportShapeLayerDataLoadedEventHandler(object sender, ImportShapeLayerDataEventArgs e);

        #region Web.Maps.VE Events

        /// <summary>
        /// Occurs when Directions are loaded on the Map after calling the Map.GetDirections method.
        /// </summary>
        public event DirectionsLoadedEventHandler DirectionsLoaded;

        /// <summary>
        /// Occurs when a Find operation is completed after calling the Map.Find method.
        /// </summary>
        public event FindLoadedEventHandler FindLoaded;

        /// <summary>
        /// Occurs when a FindLocations operation is completed after calling the Map.FindLocations method.
        /// </summary>
        public event FindLocationsLoadedEventHandler FindLocationsLoaded;

        /// <summary>
        /// Occurs when ShapeLayer Data has been loaded on the Map after calling the Map.ImportShapeLayerData method.
        /// </summary>
        public event ImportShapeLayerDataLoadedEventHandler ImportShapeLayerDataLoaded;

        /// <summary>
        /// This event is fired when the Map is first loaded on the client.
        /// </summary>
        public event MapLoadedEventHandler MapLoaded;

        #endregion

        #region VirtualEarth Events

        /// <summary>
        /// Occurs when the map style chanages
        /// </summary>
        public event AsyncMapEventHandler ChangeMapType;

        /// <summary>
        /// Occurs whenever the map view changes
        /// </summary>
        public event AsyncMapEventHandler ChangeView; 

        /// <summary>
        /// Occurs when the map zoom ends
        /// </summary>
        public event AsyncMapEventHandler EndZoom;

        /*
        public event AsyncMapEventHandler Error;
        [ScriptControlProperty]
        public bool OnError_Handled
        {
            get { return (this.Error != null); }
        }
        
        public event AsyncMapEventHandler ObliqueChange;
        [ScriptControlProperty]
        public bool OnObliqueChange_Handled
        {
            get { return (this.ObliqueChange != null); }
        }
        */

        /// <summary>
        /// Occurs when birdseye images are available at the center of the current map
        /// </summary>
        public event AsyncMapEventHandler ObliqueEnter;

        /// <summary>
        /// Occurs when birdseye images are no longer available at the center of the current map
        /// </summary>
        public event AsyncMapEventHandler ObliqueLeave;

        /*

        public event AsyncMapEventHandler StartZoom;
        [ScriptControlProperty]
        public bool OnStartZoom_Handled
        {
            get { return (this.StartZoom != null); }
        }
        */

        #endregion

        #region Mouse Events

        /// <summary>
        /// The Click event is fired when the user clicks on the Map within the Web Browser (on the client-side) and is raised on the Server-Side via an Asynchronous Postback to the server.
        /// </summary>
        public event AsyncMapEventHandler Click;

        /*
        public event AsyncMapEventHandler DoubleClick;
        [ScriptControlProperty]
        public bool OnDoubleClick_Handled
        {
            get { return (this.DoubleClick != null); }
        }

        public event AsyncMapEventHandler MouseMove;
        [ScriptControlProperty]
        public bool OnMouseMove_Handled
        {
            get { return (this.MouseMove != null); }
        }

        public event AsyncMapEventHandler MouseDown;
        [ScriptControlProperty]
        public bool OnMouseDown_Handled
        {
            get { return (this.MouseDown != null); }
        }

        public event AsyncMapEventHandler MouseUp;
        [ScriptControlProperty]
        public bool OnMouseUp_Handled
        {
            get { return (this.MouseUp != null); }
        }

        public event AsyncMapEventHandler MouseOut;
        [ScriptControlProperty]
        public bool OnMouseOut_Handled
        {
            get { return (this.MouseOut != null); }
        }

        public event AsyncMapEventHandler MouseWheel;
        [ScriptControlProperty]
        public bool OnMouseWheel_Handled
        {
            get { return (this.MouseWheel != null); }
        }

        */

        #endregion

        #region Keyboard Events

        /*
        public event AsyncMapEventHandler KeyPress;
        [ScriptControlProperty]
        public bool OnKeyPress_Handled
        {
            get { return (this.KeyPress != null); }
        }

        public event AsyncMapEventHandler KeyDown;
        [ScriptControlProperty]
        public bool OnKeyDown_Handled
        {
            get { return (this.KeyDown != null); }
        }

        public event AsyncMapEventHandler KeyUp;
        [ScriptControlProperty]
        public bool OnKeyUp_Handled
        {
            get { return (this.KeyUp != null); }
        }
        */
        #endregion

        #endregion

    }
}
