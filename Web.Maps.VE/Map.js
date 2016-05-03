/* ----------------------------------------------------------------------------------- */
/* Copyright (C) Simplovation LLC (http://Simplovation.com) 2016. All rights reserved. */
/* Licensing information available at http://webmapsve.codeplex.com                    */
/* ----------------------------------------------------------------------------------- */
/*Map.js - Simplovation.Web.Maps.VE*/
Type.registerNamespace("Simplovation.Web.Maps.VE");
Simplovation.Web.Maps.VE.Map = function(element) {
    Simplovation.Web.Maps.VE.Map.initializeBase(this, [element]);

    this._Map = null; this._MainMapDiv = null;
    this._LatLong = null;
    this._Zoom = "4";
    this._MapStyle = "r";
    this._Fixed = false;
    this._ShowPoweredBy = true;
    this._ShowSwitch = true;
    this._NavigationBarMode = null; // Microsoft.Maps.NavigationBarMode.compact; // <-- use Microsoft.Maps.NavigationBarMode.compact here
    this._TileBuffer = 0; this._Layers = null;
    this._ShowTraffic = false;
    this._ShowTrafficLegend = false;
    this._TrafficLegendText = null;
    this._AsyncPostbackPassShapes = true;
    this._AppPathRoot = null;
    this._AppPathDomain = null;
    this._CustomInfoBoxStylesEnabled = false;
    this._OnClientMapLoaded = null;
    this._FindArgs = null;
    this._ClientToken = null;
    this._BingKey = null;
    this._EnableBirdseye = true;
    this._EnableDashboardLabels = true;
    this._LoadBaseTiles = true;
    this._BirdseyeOrientation = null;

    this._ImportShapeLayerData_shapeSource = null;
    this._ImportShapeLayerData_setBestView = null;

    function fcd(e, h) {
        return Function.createDelegate(e, h);
    }
    //MapEvents
    this._OnMapLoaded_Handled = false;
    this._changeMapStyleHandler = fcd(this, this._onChangeMapStyle);
    this._OnChangeMapStyle_Handled = null;
    this._changeViewHandler = fcd(this, this._onChangeView);
    this._OnChangeView_Handled = null;
    this._endPanHandler = fcd(this, this._onEndPan);
    this._OnEndPan_Handled = null;
    this._endZoomHandler = fcd(this, this._onEndZoom);
    this._OnEndZoom_Handled = null;
    this._errorHandler = fcd(this, this._onError);
    this._OnError_Handled = null;
    this._obliqueChangeHandler = fcd(this, this._onObliqueChange);
    this._obliqueEnterHandler = fcd(this, this._onObliqueEnter);
    this._OnObliqueEnter_Handled = null;
    this._obliqueLeaveHandler = fcd(this, this._onObliqueLeave);
    this._OnObliqueLeave_Handled = null;
    this._resizeHandler = fcd(this, this._onResize);
    this._startPanHandler = fcd(this, this._onStartPan);
    this._startZoomHandler = fcd(this, this._onStartZoom);
    //CustomerIdentificationEvents
    this._onTokenExpireHandler = fcd(this, this._onTokenExpire);
    this._onTokenErrorHandler = fcd(this, this._onTokenError);
    //MouseEvents
    this._clickHandler = fcd(this, this._onClick);
    this._OnClick_Handled = null;
    this._onDoubleClickHandler = fcd(this, this._onDoubleClick);
    this._onMouseDownHandler = fcd(this, this._onMouseDown);
    this._onMouseMoveHandler = fcd(this, this._onMouseMove);
    this._onMouseOutHandler = fcd(this, this._onMouseOut);
    this._onMouseOverHandler = fcd(this, this._onMouseOver);
    this._onMouseUpHandler = fcd(this, this._onMouseUp);
    this._onMouseWheelHandler = fcd(this, this._onMouseWheel);
    //KeyboardEvents
    this._onKeyPressHandler = fcd(this, this._onKeyPress);
    this._onKeyDownHandler = fcd(this, this._onKeyDown);
    this._onKeyUpHandler = fcd(this, this._onKeyUp);
    //OtherEvents
    this._map_OnLoad$delegate = fcd(this, this._map_OnLoad);
};
Simplovation.Web.Maps.VE.Map.prototype = {
    initialize: function() {
        Simplovation.Web.Maps.VE.Map.callBaseMethod(this, "initialize");

        var that = this;

        //All VEMap Stuff
        if (!isNaN(this._MapStyle)) {
            if (this._MapStyle == 2) {
                this._MapStyle = "a";
            } else if (this._MapStyle == 3) {
                this._MapStyle = "h";
            } else if (this._MapStyle == 4) {
                this._MapStyle = "o";
            } else if (this._MapStyle == 5) {
                this._MapStyle = "s";
            } else {
                this._MapStyle = "r";
            }
        }

        if (!isNaN(this._NavigationBarMode)) {
            if (this._NavigationBarMode == 2) {
                this._NavigationBarMode = Microsoft.Maps.NavigationBarMode.compact;
            } else {
                this._NavigationBarMode = Microsoft.Maps.NavigationBarMode.compact; //.normal;
            }
        }
        this._MainMapDiv = $get(this.get_id() + "_Map");


        var mapOptions = {
            credentials: this._BingKey || 'not set',
            zoom: this._Zoom
        };


        if (this._NavigationBarMode) {
            mapOptions.navigationBarMode = this._NavigationBarMode;
        }

        this._Map = new Microsoft.Maps.Map(document.getElementById(this.get_id() + '_Map'), mapOptions);

        ///* Set Customer Identification */
        //if (this._ClientToken != null) {
        //    if (this._Map.SetClientToken) {
        //        this._Map.AttachEvent("ontokenexpire", this._onTokenExpireHandler);
        //        this._Map.AttachEvent("ontokenerror", this._onTokenErrorHandler);
        //        this._Map.SetClientToken(this._ClientToken);
        //    }
        //}

        //if (this._TileBuffer != 0) {
        //    this._Map.SetTileBuffer(this._TileBuffer);
        //}

        //var mapOptions = new VEMapOptions();
        //mapOptions.EnableBirdseye = this._EnableBirdseye;
        //mapOptions.EnableDashboardLabels = this._EnableDashboardLabels;
        //mapOptions.LoadBaseTiles = this._LoadBaseTiles;

        //if (this._BirdseyeOrientation != null) {
        //    this._BirdseyeOrientation = this._getVEOrientation(this._BirdseyeOrientation);
        //    mapOptions.BirdseyeOrientation = this._BirdseyeOrientation;
        //}

        //this._Map.onLoadMap = this._map_OnLoad$delegate;

        //this._Map.LoadMap(
        //    (this._LatLong.Latitude != 0 ? new VELatLong(this._LatLong.Latitude, this._LatLong.Longitude) : null),
        //    this._Zoom,
        //    this._MapStyle,
        //    this._Fixed,
        //    this._MapMode,
        //    this._ShowSwitch,
        //    (this._TileBuffer != 0 ? this._TileBuffer : null),
        //    mapOptions
        //);

        //function av(n, h) {
        //    that._Map.AttachEvent(n, h);
        //}
        ////Map
        //av("onchangemapstyle", this._changeMapStyleHandler);
        //av("onchangeview", this._changeViewHandler);
        //av("onendpan", this._endPanHandler);
        //av("onendzoom", this._endZoomHandler);
        //av("onerror", this._errorHandler);
        //av("onobliquechange", this._obliqueChangeHandler);
        //av("onobliqueenter", this._obliqueEnterHandler);
        //av("onobliqueleave", this._obliqueLeaveHandler);
        //av("onresize", this._resizeHandler);
        //av("onstartpan", this._startPanHandler);
        //av("onstartzoom", this._startZoomHandler);
        ////Mouse
        //av("onclick", this._clickHandler);
        //av("ondoubleclick", this._onDoubleClickHandler);
        //av("onmousedown", this._onMouseDownHandler);
        //av("onmousemove", this._onMouseMoveHandler);
        //av("onmouseout", this._onMouseOutHandler);
        //av("onmouseover", this._onMouseOverHandler);
        //av("onmouseup", this._onMouseUpHandler);
        //av("onmousewheel", this._onMouseWheelHandler);
        ////Keyboard
        //av("onkeypress", this._onKeyPressHandler);
        //av("onkeydown", this._onKeyDownHandler);
        //av("onkeyup", this._onKeyUpHandler);
    },
    dispose: function() {
        if (this._Map && this._Map.Dispose) {
            this._Map.Dispose();
        }
        Simplovation.Web.Maps.VE.Map.callBaseMethod(this, "dispose");
    },
    _map_OnLoad: function(e) {
        var that = this;
        if (this._DistanceUnit != null) {
            if (this._DistanceUnit == 1) { this._DistanceUnit = VEDistanceUnit.Kilometers; } else { this._DistanceUnit = VEDistanceUnit.Miles; } this._Map.SetScaleBarDistanceUnit(this._DistanceUnit);
        }
        if (this._CustomInfoBoxStylesEnabled) { this._Map.ClearInfoBoxStyles(); }
        if (this._ShowTraffic) { this._Map.LoadTraffic(true); }
        if (this._ShowTrafficLegend) {
            this._Map.ShowTrafficLegend();
            if (this._TrafficLegendText) {
                this._Map.SetTrafficLegendText(this._TrafficLegendText);
            }
        }

        if (this._Layers) {
            if (this._Layers.length > 0) {
                this._loadShapeLayersFromCollection(this._Layers);
            }
        }
        if (this.get_OnMapLoaded_Handled()) { this._triggerAsyncPostback("maploaded"); }
        if (this._OnClientMapLoaded) {
            var maploaded$delegate = Function.createDelegate(this, eval(this._OnClientMapLoaded));
            maploaded$delegate(this, e);
        }
        //if (this._FindArgs != null) {
        if (this._FindArgs) {
            this._doFindFromFindArgs(this._FindArgs);
        }
        //if (this._ImportShapeLayerData_shapeSource != null) {
        if (this._ImportShapeLayerData_shapeSource) {
            this._doImportShapeLayerData(this._ImportShapeLayerData_shapeSource, this._ImportShapeLayerData_setBestView);
        }
        if (this._ShowPoweredBy) {
            var logo = this.logo = document.createElement("span");
            logo.id = this.get_id() + "_Logo";
            logo.style.border = "solid 1px #555";
            logo.style.background = "#fff";
            logo.style.padding = "2px";
            logo.style.top = "100px";
            logo.innerHTML = "<span style='font-size:8px;white-space:nowrap;'>powered by<br/></span><span style='font-size:15px;'><a href='http://webmapsve.codeplex.com' target='_blank' style='text-decoration:none;cursor:pointer'>Web.Maps.VE</a></span>";
            window.setTimeout(function() {
                that.get_Map().AddControl(logo);
                that._realignLogo();
            }, 100);
        }
    },
    _realignLogo: function() {
        if (this._ShowPoweredBy) {
            var logo = this.logo;
            if (logo) {
                logo.style.top = this.get_element().offsetHeight - logo.offsetHeight - 50 + "px";
                logo.style.left = "10px";
                this.get_Map().AddControl(logo);
            }
        }
    },
    _loadShapeLayersFromCollection: function(col) {
        var sl = null;
        var isNewLayer = false;
        var collen = col.length;
        for (var layerIndex = 0; layerIndex < collen; layerIndex++) {
            sl = this.get_Map().GetShapeLayerByIndex(layerIndex);
            isNewLayer = (sl == null);
            if (isNewLayer) {
                sl = new VEShapeLayer();
            }
            sl.SetTitle(col[layerIndex].Title);
            sl.SetDescription(col[layerIndex].Description);

            if (col[layerIndex].Visible) {
                sl.Show();
            } else {
                sl.Hide();
            }
            sl.SimplovationTag = col[layerIndex].Tag;

            var shapelen = col[layerIndex].Shapes.length;
            for (var shapeIndex = 0; shapeIndex < shapelen; shapeIndex++) {
                var s = col[layerIndex].Shapes[shapeIndex];
                if (s.ClientID == null) { //NewShape
                    s = this._getVEShape(s);
                    sl.AddShape(s);
                } else { //ExistingShape
                    this._updateVEShape(s);
                }
            }
            if (isNewLayer) {
                this.get_Map().AddShapeLayer(sl);
            }
        }
    },
    _getVEShape: function(s) {
        if (s.Type == 1) {
            s.Type = VEShapeType.Polyline;
        } else if (s.Type == 2) {
            s.Type = VEShapeType.Polygon;
        } else {
            s.Type = VEShapeType.Pushpin;
        }
        var points = [];
        var pl = s.Points.length;
        for (var p = 0; p < pl; p++) {
            points.push(this._getVELatLong(s.Points[p]));
        }
        var shape = new VEShape(s.Type, points);
        this._setVEShapeProperties(s, shape);
        return shape;
    },
    _getVELatLong: function(l) {
        return new VELatLong(l.Latitude, l.Longitude, l.Altitude, this._getVEAltitudeModeFromInt(l.AltitudeMode));
    },
    _getVEAltitudeModeFromInt: function(v) {
        if (v == 0) { return VEAltitudeMode.Default; } else if (v == 1) { return VEAltitudeMode.Absolute; } else if (v == 2) { return VEAltitudeMode.RelativeToGround; } else { return v; }
    },
    _getIntFromVEAltitudeMode: function(v) {
        if (v == VEAltitudeMode.Default) { return 0; } else if (v == VEAltitudeMode.Absolute) { return 1; } else if (v == VEAltitudeMode.RelativeToGround) { return 2; } else { return v; }
    },
    _getVEShapeSourceSpecification: function(v) {
        return new VEShapeSourceSpecification(this._getVEDataType(v.Type), v.LayerSource, null);
    },
    _getVEDataType: function(v) {
        if (v == 0) {
            return VEDataType.GeoRSS;
        } else if (v == 1) {
            return VEDataType.VECollection;
        } else if (v == 2) {
            return VEDataType.ImportXML;
        } else {
            return v;
        }
    },
    _getIntFromVEDataType: function(v) {
        if (v == VEDataType.GeoRSS) {
            return 0;
        } else if (v == VEDataType.VECollection) {
            return 1;
        } else if (v == VEDataType.ImportXML) {
            return 2;
        } else {
            return v;
        }
    },
    _updateVEShape: function(s) {
        var shape = this.get_Map().GetShapeByID(s.ClientID);
        if (shape == null) {
            //Shape Not Found
        } else {
            if (s.Type == 1) {
                s.Type = VEShapeType.Polyline;
            } else if (s.Type == 2) {
                s.Type = VEShapeType.Polygon;
            } else {
                s.Type = VEShapeType.Pushpin;
            }
            this._setVEShapeProperties(s, shape);
        }
    },
    _getVEOrientation: function(o) {
        if (o == 0) {
            return VEOrientation.North;
        } else if (o == 1) {
            return VEOrientation.South;
        } else if (o == 2) {
            return VEOrientation.East;
        } else if (o == 3) {
            return VEOrientation.West;
        } else {
            return o;
        }
    },
    _getIntFromVEOrientation: function(o) {
        if (o == VEOrientation.North) {
            return 0;
        } else if (o == VEOrientation.South) {
            return 1;
        } else if (o == VEOrientation.East) {
            return 2;
        } else if (o == VEOrientation.West) {
            return 3;
        } else {
            return o;
        }
    },
    _getVEColor: function(c) {
        return new VEColor(c.R, c.G, c.B, c.A);
    },
    _getVEPixel: function(p) {
        return new VEPixel(p.X, p.Y);
    },
    _getVECustomIconSpecification: function(v) {
        var s = new VECustomIconSpecification();
        //if (v.BackColor != null) {
        if (v.BackColor) {
            s.BackColor = this._getVEColor(v.BackColor);
        }
        //if (v.CustomHTML != null) {
        if (v.CustomHTML) {
            s.CustomHTML = v.CustomHTML;
        }
        //if (v.ForeColor != null) {
        if (v.ForeColor) {
            s.ForeColor = this._getVEColor(v.ForeColor);
        }
        //if (v.Image != null) {
        if (v.Image) {
            s.Image = v.Image;
        }
        //if (v.ImageOffset != null) {
        if (v.ImageOffset) {
            s.ImageOffset = this._getVEPixel(v.ImageOffset);
        }
        //if (v.TextBold != null) {
        if (v.TextBold) {
            s.TextBold = v.TextBold;
        }
        //if (v.TextContent != null) {
        if (v.TextContent) {
            s.TextContent = v.TextContent;
        }
        //if (v.TextFont != null) {
        if (v.TextFont) {
            s.TextFont = v.TextFont;
        }
        //if (v.TextItalics != null) {
        if (v.TextItalics) {
            s.TextItalics = v.TextItalics;
        }
        //if (v.TextOffset != null) {
        if (v.TextOffset) {
            s.TextOffset = this._getVEPixel(v.TextOffset);
        }
        //if (v.TextSize != null) {
        if (v.TextSize) {
            s.TextSize = v.TextSize;
        }
        //if (v.TextUnderline != null) {
        if (v.TextUnderline) {
            s.TextUnderline = v.TextUnderline;
        }
        return s;
    },
    _setVEShapeProperties: function(s, shape) {
        //if (s.Altitude != null) {
        if (s.Altitude) {
            shape.SetAltitude(s.Altitude, this._getVEAltitudeModeFromInt(s.AltitudeMode));
        }
        //if (s.Description != null) {
        if (s.Description) {
            shape.SetDescription(s.Description);
        }
        if (s.Draggable != undefined){
            shape.Draggable = s.Draggable;
        }
        //if (s.CustomIcon != null) {
        if (s.CustomIcon) {
            //shape.SetCustomIcon(s.CustomIcon);
            shape.SetCustomIcon(this._getVECustomIconSpecification(s.CustomIcon));
        }
        //if (s.FillColor != null) {
        if (s.FillColor) {
            //shape.SetFillColor(new VEColor(s.FillColor.R,s.FillColor.G,s.FillColor.B,s.FillColor.A));
            shape.SetFillColor(this._getVEColor(s.FillColor));
        }
        //if (s.IconAnchor != null) {
        if (s.IconAnchor) {
            shape.SetIconAnchor(new VELatLong(s.IconAnchor.Latitude, s.IconAnchor.Longitude));
        }
        //if (s.LineColor != null) {
        if (s.LineColor) {
            //shape.SetLineColor(new VEColor(s.LineColor.R,s.LineColor.G,s.LineColor.B,s.LineColor.A));
            shape.SetLineColor(this._getVEColor(s.LineColor));
        }
        if (s.Type != VEShapeType.Pushpin) {
            if (s.LineWidth > 0) {
                shape.SetLineWidth(s.LineWidth);
            }
        }
        //if (s.MoreInfoURL != null) {
        if (s.MoreInfoURL) {
            shape.SetMoreInfoURL(Simplovation.Web.Maps.VE.Utils.UrlHelper.ToAbsolute(s.MoreInfoURL, this._AppPathRoot));
        }
        //if (s.PhotoURL != null) {
        if (s.PhotoURL) {
            shape.SetPhotoURL(Simplovation.Web.Maps.VE.Utils.UrlHelper.ToAbsolute(s.PhotoURL, this._AppPathRoot));
        }
        //if (s.ZIndex != null) {
        if (s.ZIndex) {
            shape.SetZIndex(s.ZIndex);
        }
        shape.SetTitle(s.Title);
        shape.SimplovationTag = s.Tag;
        if (s.ShowIcon) {
            shape.ShowIcon();
        } else {
            shape.HideIcon();
        }
    },
    AddShape: function(s) {
        this.get_Map().AddShape(s);
    },
    DeleteShapeById: function(id) {
        var s = this.GetShapeByID(id);
        this.DeleteShape(s);
    },
    SetCenterOnShapeByID: function(shapeid, zoom, showInfoBox) {
        var shape = this.GetShapeByID(shapeid);
        if (shape == null) {
            throw "Unable to find Shape (" + shapeid + ")";
        } else {
            this.SetCenterOnShape(shape, zoom, showInfoBox);
        }
    },
    SetCenterOnShape: function(shape, zoom, showInfoBox) {
        //if (zoom != null) {
        if (zoom) {
            this.SetCenterAndZoom(shape.GetIconAnchor(), zoom);
        } else {
            this.SetCenter(shape.GetIconAnchor());
        }
    },
    SetCenterOnShapeByTag: function(tag, zoom) {
        var s = this.GetShapeByTag(tag);
        if (s == null) {
            throw "Unable to find Shape by Tag (" + tag + ")";
        } else {
            this.SetCenterOnShape(s, zoom);
        }
    },
    GetShapeByTag: function(tag) {
        var m = this.get_Map();
        var lc = m.GetShapeLayerCount();
        for (var l = 0; l < lc; l++) {
            var shapeLayer = m.GetShapeLayerByIndex(l);
            var ls = shapeLayer.GetShapeCount();
            for (var s = 0; s < ls; s++) {
                var shape = shapeLayer.GetShapeByIndex(s);
                if (shape.SimplovationTag == tag) {
                    return shape;
                }
            }
        }
        return null;
    },


    AddControl: function(e, z) {
        this.get_Map().AddControl(e, z);
    },
    AddCustomLayer: function(a) {
        this.get_Map().AddCustomLayer(a);
    },
    AddShapeLayer: function(l, b) {
        this.get_Map().AddShapeLayer(l, b);
    },
    AddTileLayer: function(l, v) {
        this.get_Map().AddTileLayer(l, v);
    },
    Clear: function() {
        this.get_Map().Clear();
    },
    ClearInfoBoxStyles: function() {
        this.get_Map().ClearInfoBoxStyles();
    },
    ClearTraffic: function() {
        this.set_ShowTraffic(false); this.get_Map().ClearTraffic();
    },
    DeleteAllShapeLayers: function() {
        this.get_Map().DeleteAllShapeLayers();
    },
    DeleteAllShapes: function() {
        this.get_Map().DeleteAllShapes();
    },
    DeleteControl: function(e) {
        this.get_Map().DeleteControl(e);
    },
    DeleteRoute: function() {
        this.get_Map().DeleteRoute();
    },
    DeleteShape: function(s) {
        if (s) {
            this.get_Map().DeleteShape(s);
            s = null;
        }
    },
    DeleteShapeLayer: function(l) {
        this.get_Map().DeleteShapeLayer(l);
    },
    DeleteTileLayer: function(id) {
        this.get_Map().DeleteTileLayer(id)
    },
    EnableShapeDisplayThreshold: function(v) {
        this.get_Map().EnableShapeDisplayThreshold(v);
    },
    EndContinuousPan: function() {
        this.get_Map().EndContinuousPan();
    },
    Find: function(what, where, findType, shapeLayer, startIndex, numberOfResults, showResults, createResults, useDefaultDisambiguation, setBestMapView, callback) {
        this.get_Map().Find(what, where, findType, shapeLayer, startIndex, numberOfResults, showResults, createResults, useDefaultDisambiguation, setBestMapView, callback);
    },
    FindLocations: function(l, c) {
        this.get_Map().FindLocations(l, c);
    },
    Geocode: function(query, callback, opts) {
        this.get_Map().Geocode(query, callback, opts);
    },
    GetBirdseyeScene: function() {
        return this.get_Map().GetBirdseyeScene();
    },
    GetCenter: function() {
        return this.get_Map().GetCenter();
    },
    GetDirections: function(l, o) {
        this.get_Map().GetDirections(l, o);
    },
    GetHeight: function() {
        return this.get_Height();
    },
    GetLeft: function() {
        return this.get_Map().GetLeft();
    },
    GetMapStyle: function() {
        return this.get_Map().GetMapStyle();
    },
    GetMapView: function() {
        return this.get_Map().GetMapView();
    },
    GetShapeByID: function(id) {
        return this.get_Map().GetShapeByID(id);
    },
    GetShapeLayerByIndex: function(i) {
        return this.get_Map().GetShapeLayerByIndex(i);
    },
    GetShapeLayerCount: function(i) {
        return this.get_Map().GetShapeLayerCount(i);
    },
    GetTileLayerByID: function(id) {
        return this.get_Map().GetTileLayerByID(id);
    },
    GetTileLayerByIndex: function(i) {
        return this.get_Map().GetTileLayerByIndex(i);
    },
    GetTileLayerCount: function() {
        return this.get_Map().GetTileLayerCount();
    },
    GetTop: function() {
        return this.get_Map().GetTop();
    },
    GetVersion: function() {
        return VEMap.GetVersion();
    },
    GetWidth: function() {
        return this.get_Width();
    },
    GetZoomLevel: function() {
        return this.get_Map().GetZoomLevel();
    },
    Hide3DNavigationControl: function() {
        this.get_Map().Hide3DNavigationControl();
    },
    HideAllShapeLayers: function() {
        this.get_Map().HideAllShapeLayers();
    },
    HideControl: function(e) {
        this.get_Map().HideControl(e);
    },
    HideFindControl: function() {
        this.get_Map().HideFindControl();
    },
    HideInfoBox: function() {
        this.get_Map().HideInfoBox();
    },
    HideMiniMap: function() {
        this.get_Map().HideMiniMap();
    },
    HideTileLayer: function(l) {
        this.get_Map().HideTileLayer(l);
    },
    HideTrafficLegend: function() {
        this._ShowTrafficLegend = false;
        this.get_Map().HideTrafficLegend();
    },
    ImportShapeLayerData: function(s, c, v) {
        this.get_Map().ImportShapeLayerData(s, c, v);
    },
    IncludePointInView: function(l) {
        this.get_Map().IncludePointInView(l);
    },
    IsBirdseyeAvailable: function() {
        return this.get_Map().IsBirdseyeAvailable();
    },
    LatLongToPixel: function(l) {
        return this.get_Map().LatLongToPixel(l);
    },
    LoadTraffic: function(v) {
        this.set_ShowTraffic(true);
        this.get_Map().LoadTraffic(v);
    },
    Pan: function(x, y) {
        this.get_Map().Pan(x, y);
    },
    PanToLatLong: function(l) {
        this.get_Map().PanToLatLong(l);
    },
    PixelToLatLong: function(p) {
        return this.get_Map().PixelToLatLong(p);
    },
    RemoveCustomLayer: function(a) {
        this.get_Map().RemoveCustomLayer(a);
    },
    Resize: function(w, h) {
        this.get_Map().Resize(w, h);
    },
    Search: function(query, callback, opts){
        this.get_Map().Search(query, callback, opts);
    },
    SetBirdseyeOrientation: function(o) {
        this.get_Map().SetBirdseyeOrientation(o);
    },
    SetBirdseyeScene: function(a, b, c, d) {
        this.get_Map().SetBirdseyeScene(a, b, c, d);
    },
    SetCenter: function(l) {
        this.get_Map().SetCenter(l);
    },
    SetCenterAndZoom: function(l, z) {
        this.get_Map().SetCenterAndZoom(l, z);
    },
    SetNavigationBarMode: function (d) {
        this.get_Map().SetNavigationBarMode(d);
    },
    SetDefaultInfoBoxStyles: function() {
        this.get_Map().SetDefaultInfoBoxStyles();
    },
    SetFailedShapeRequest: function(p) {
        this.get_Map().SetFailedShapeRequest(p);
    },
    SetMapStyle: function(v) {
        if (!isNaN(v)) {
            if (v == 2) {
                v = "a";
            } else if (v == 3) {
                v = "h";
            } else if (v == 4) {
                v = "o";
            } else if (v == 5) {
                v = "s";
            } else {
                v = "r";
            }
        }
        this.get_Map().SetMapStyle(v);
    },
    SetMapView: function(v) {
        this.get_Map().SetMapView(v);
    },
    SetMouseWheelZoomToCenter: function(v) {
        this.get_Map().SetMouseWheelZoomToCenter(v);
    },
    SetShapesAccuracy: function(p) {
        this.get_Map().SetShapesAccuracy(p);
    },
    SetShapesAccuracyRequestLimit: function(v) {
        this.get_Map().SetShapesAccuracyRequestLimit(v);
    },
    SetTileBuffer: function(v) {
        this.get_Map().SetTileBuffer(v);
    },
    SetTrafficLegendText: function(v) {
        this._TrafficLegendText = v;
        this.get_Map().SetTrafficLegendText(v);
    },
    SetZoomLevel: function(v) {
        this.get_Map().SetZoomLevel(v);
    },
    Show3DNavigationControl: function() {
        this.get_Map().Show3DNavigationControl();
    },
    ShowAllShapeLayers: function() {
        this.get_Map().ShowAllShapeLayers();
    },
    ShowControl: function(e) {
        this.get_Map().ShowControl();
    },
    ShowDisambiguationDialog: function(v) {
        this.get_Map().ShowDisambiguationDialog(v);
    },
    ShowFindControl: function() {
        this.get_Map().ShowFindControl();
    },
    ShowInfoBox: function(s, a, o) {
        this.get_Map().ShowInfoBox(s, a, o);
    },
    ShowMessage: function(m) {
        this.get_Map().ShowMessage(m);
    },
    ShowMiniMap: function(x, y, s) {
        this.get_Map().ShowMiniMap(x, y, s);
    },
    ShowTileLayer: function(id) {
        this.get_Map().ShowTileLayer(id);
    },
    ShowTrafficLegend: function(x, y) {
        this._ShowTrafficLegend = true;
        this.get_Map().ShowTrafficLegend(x, y);
    },
    StartContinuousPan: function(x, y) {
        this.get_Map().StartContinuousPan(x, y);
    },
    ZoomIn: function() {
        this.get_Map().ZoomIn();
    },
    ZoomOut: function() {
        this.get_Map().ZoomOut();
    },
    //Property Accessors
    get_Map: function() {
        return this._Map;
    },
    get_MainMapDiv: function() {
        return this._MainMapDiv;
    },
    get_ShowPoweredBy: function () { return this._ShowPoweredBy; }, set_ShowPoweredBy: function (v) { this._ShowPoweredBy = v; },
    get_Width: function() { return this.get_MainMapDiv().offsetWidth; }, set_Width: function(v) { var mapdiv = this.get_MainMapDiv(); if (mapdiv) { var cv = mapdiv.offsetWidth; if (cv != v) { this.Resize(v, mapdiv.offsetHeight); } } },
    get_Height: function() { return this.get_MainMapDiv().offsetHeight; }, set_Height: function(v) { var mapdiv = this.get_MainMapDiv(); if (mapdiv) { var cv = mapdiv.offsetHeight; if (cv != v) { this.Resize(mapdiv.offsetWidth, v); } } },
    get_LatLong: function() { return this._LatLong; }, set_LatLong: function(v) { this._LatLong = v; },
    get_Zoom: function() { return this._Zoom; }, set_Zoom: function(v) { this._Zoom = v; },
    get_MapStyle: function() { return this._MapStyle; }, set_MapStyle: function(v) { this._MapStyle = v; },
    get_AsyncPostbackPassShapes: function() { return this._AsyncPostbackPassShapes; }, set_AsyncPostbackPassShapes: function(v) { this._AsyncPostbackPassShapes = v; },
    get_Fixed: function() { return this._Fixed; }, set_Fixed: function(v) { this._Fixed = v; },
    get_CustomInfoBoxStylesEnabled: function() { return this._CustomInfoBoxStylesEnabled; }, set_CustomInfoBoxStylesEnabled: function(v) { this._CustomInfoBoxStylesEnabled = v; },
    get_DistanceUnit: function() { return this._DistanceUnit; }, set_DistanceUnit: function(v) { this._DistanceUnit = v; },
    get_ShowSwitch: function() { return this._ShowSwitch; }, set_ShowSwitch: function(v) { this._ShowSwitch = v; },
    get_NavigationBarMode: function () { return this._NavigationBarMode; }, set_NavigationBarMode: function (v) { this._NavigationBarMode = v; },
    get_TileBuffer: function() { return this._TileBuffer; }, set_TileBuffer: function(v) { this._TileBuffer = v; },
    get_EnableBirdseye: function() { return this._EnableBirdseye; }, set_EnableBirdseye: function(v) { this._EnableBirdseye = v; },
    get_EnableDashboardLabels: function() { return this._EnableDashboardLabels; }, set_EnableDashboardLabels: function(v) { this._EnableDashboardLabels = v; },
    get_LoadBaseTiles: function() { return this._LoadBaseTiles; }, set_LoadBaseTiles: function(v) { this._LoadBaseTiles = v; },
    get_BirdseyeOrientation: function() { return this._BirdseyeOrientation; }, set_BirdseyeOrientation: function(v) { this._BirdseyeOrientation = v; },
    get_Layers: function() { return this_Layers; }, set_Layers: function(v) { this._Layers = v; },
    get_ShowTraffic: function() { return this._ShowTraffic; }, set_ShowTraffic: function(v) { this._ShowTraffic = v; },
    get_ShowTrafficLegend: function() { return this._ShowTrafficLegend; }, set_ShowTrafficLegend: function(v) { this._ShowTrafficLegend = v; },
    get_TrafficLegendText: function() { return this._TrafficLegendText; }, set_TrafficLegendText: function(v) { this._TrafficLegendText = v; },
    get_AppPathRoot: function() { return this._AppPathRoot; }, set_AppPathRoot: function(v) { this._AppPathRoot = v; },
    get_ClientToken: function() { return this._ClientToken; }, set_ClientToken: function(v) { this._ClientToken = v; },
    get_BingKey: function() { return this._BingKey; }, set_BingKey: function(v) { this._BingKey = v; },
    get_ImportShapeLayerData_shapeSource: function() { return this._ImportShapeLayerData_shapeSource; }, set_ImportShapeLayerData_shapeSource: function(v) { this._ImportShapeLayerData_shapeSource = v; },
    get_ImportShapeLayerData_setBestView: function() { return this._ImportShapeLayerData_setBestView; }, set_ImportShapeLayerData_setBestView: function(v) { this._ImportShapeLayerData_setBestView = v; },
    //Map Events Handled
    get_OnMapLoaded_Handled: function() { return this._OnMapLoaded_Handled; }, set_OnMapLoaded_Handled: function(v) { this._OnMapLoaded_Handled = v; },
    get_OnClientMapLoaded: function() { return this._OnClientMapLoaded; }, set_OnClientMapLoaded: function(v) { this._OnClientMapLoaded = v; },
    get_OnChangeMapStyle_Handled: function() { return this._OnChangeMapStyle_Handled; }, set_OnChangeMapStyle_Handled: function(v) { this._OnChangeMapStyle_Handled = v; },
    get_OnChangeView_Handled: function() { return this._OnChangeView_Handled; }, set_OnChangeView_Handled: function(v) { this._OnChangeView_Handled = v; }, get_OnEndPan_Handled: function() { return this._OnEndPan_Handled; }, set_OnEndPan_Handled: function(v) { this._OnEndPan_Handled = v; }, get_OnEndZoom_Handled: function() { return this._OnEndZoom_Handled; }, set_OnEndZoom_Handled: function(v) { this._OnEndZoom_Handled = v; }, get_OnObliqueEnter_Handled: function() { return this._OnObliqueEnter_Handled; }, set_OnObliqueEnter_Handled: function(v) { this._OnObliqueEnter_Handled = v; }, get_OnObliqueLeave_Handled: function() { return this._OnObliqueLeave_Handled; }, set_OnObliqueLeave_Handled: function(v) { this._OnObliqueLeave_Handled = v; }, /* Mouse Events Handled */get_OnClick_Handled: function() { return this._OnClick_Handled; }, set_OnClick_Handled: function(v) { this._OnClick_Handled = v; },
    //Other Events
    get_FindArgs: function() {
        return this._FindArgs;
    },
    set_FindArgs: function(v) {
        this._FindArgs = v;
    },
    GetAsyncEventData: function(args) {
        var mapData = new Simplovation.Web.Maps.VE.AsyncMapData();
        var map = this._Map;
        mapData.EventName = args[0];
        mapData.EventArgs = args[1];

        mapData.Width = this.get_Width();
        mapData.Height = this.get_Height();

        //if (mapData.EventArgs != undefined && mapData.EventArgs != null) {
        if (mapData.EventArgs) {
            var pInt = function(v) {
                //if (v != undefined && v != null) {
                if (v) {
                    return parseInt(v);
                } else {
                    return v;
                }
            };
            mapData.EventArgs.mapX = pInt(mapData.EventArgs.mapX);
            mapData.EventArgs.mapY = pInt(mapData.EventArgs.mapY);
            mapData.EventArgs.clientX = pInt(mapData.EventArgs.clientX);
            mapData.EventArgs.clientY = pInt(mapData.EventArgs.clientY);
        }
        mapData.BirdseyeOrientation = this._getIntFromVEOrientation(this._BirdseyeOrientation);
        mapData.ZoomLevel = map.GetZoomLevel();
        var mapStyle = map.GetMapStyle();
        if (mapStyle == "a") { mapData.MapStyle = 2; } else if (mapStyle == "h") { mapData.MapStyle = 3; } else if (mapStyle == "o") { mapData.MapStyle = 4; } else if (mapStyle == "s") { mapData.MapStyle = 5; } else { /*r*/mapData.MapStyle = 1; }
        if (mapData.MapStyle != 4) { mapData.MapView = this._Map.GetMapView(); }
        mapData.Latitude = map.GetCenter().Latitude; mapData.Longitude = map.GetCenter().Longitude;
        mapData.CustomInfoBoxStyles = this._CustomInfoBoxStyles;
        mapData.ShowTraffic = this._ShowTraffic;
        mapData.ShowTrafficLegend = this._ShowTrafficLegend;
        if (mapData.EventName == "maploaded") {
            mapData.MapLoadedEventArgs = {};
            mapData.MapLoadedEventArgs.MapView = map.GetMapView();
        }
        if (this._DistanceUnit == VEDistanceUnit.Miles) { mapData.DistanceUnit = 0; } else if (this._DistanceUnit == VEDistanceUnit.Kilometers) { mapData.DistanceUnit = 1; } else { mapData.DistanceUnit = this._DistanceUnit; }
        if (mapData.EventName == "onclick") {
            //2D Mode
            var clickedLatLong = map.PixelToLatLong(new VEPixel(mapData.EventArgs.mapX, mapData.EventArgs.mapY));
            if (clickedLatLong.Latitude != null) {
                mapData.ClickedLatitude = clickedLatLong.Latitude;
                mapData.ClickedLongitude = clickedLatLong.Longitude;
            } else {
                //this occurs in Birdseye/Oblique map style
                mapData.MapView = null;
            }
        }
        //Get ShapeLayers and Shapes to postback
        var myShapeLayers = [];
        var sl = null;
        if (this._AsyncPostbackPassShapes) {
            //Get all Shapes to postback
            var l = map.GetShapeLayerCount();
            for (var layerIndex = 0; layerIndex < l; layerIndex++) {
                var layer = map.GetShapeLayerByIndex(layerIndex);
                myShapeLayers.push(this._convertShapeLayerToPostback(layer));
            }
        }
        else {
            //if (mapData.EventArgs != null) {
            if (mapData.EventArgs) {
                //if (mapData.EventArgs.elementID != null) {
                if (mapData.EventArgs.elementID) {
                    var shape = map.GetShapeByID(mapData.EventArgs.elementID);
                    var layer = shape.GetShapeLayer();
                    sl = new Simplovation.Web.Maps.VE.ShapeLayer();
                    sl.Title = layer.GetTitle();
                    sl.Description = layer.GetDescription();
                    sl.Visible = layer.IsVisible();
                    sl.Tag = layer.SimplovationTag;
                    sl.Shapes = [];
                    sl.Shapes.push(this._convertShapeToPostback(mapData.EventArgs.elementID));
                    myShapeLayers.push(sl);
                }
            }
        }
        mapData.Layers = myShapeLayers;
        return Sys.Serialization.JavaScriptSerializer.serialize(mapData);
    },
    _triggerDirectionsLoadedAsyncPostback: function(route) {
        //serialize route
        var sbRoute = new Sys.StringBuilder();
        var itinerary;

        sbRoute.append("{\"Distance\":");
        sbRoute.append(route.Distance);
        sbRoute.append(",\"Time\":");
        sbRoute.append(route.Time);
        sbRoute.append(",\"RouteLegs\":[");

        var routelegslen = route.RouteLegs.length;
        for (var rl = 0; rl < routelegslen; rl++) {
            var routeLeg = route.RouteLegs[rl];
            if (rl > 0) {
                sbRoute.append(",");
            }
            sbRoute.append("{\"Distance\":");
            sbRoute.append(route.RouteLegs[rl].Distance);
            sbRoute.append(",\"Itinerary\":{\"Items\":[");

            var itinitemlen = routeLeg.Itinerary.Items.length
            for (var i = 0; i < itinitemlen; i++) {
                itinerary = routeLeg.Itinerary.Items[i];
                if (i > 0) {
                    sbRoute.append(",");
                }
                sbRoute.append("{");
                sbRoute.append("\"Distance\":");
                sbRoute.append(itinerary.Distance);
                sbRoute.append(",\"LatLong\":{\"Latitude\":");
                sbRoute.append(itinerary.LatLong.Latitude);
                sbRoute.append(",\"Longitude\":");
                sbRoute.append(itinerary.LatLong.Longitude);
                sbRoute.append("}");
                sbRoute.append(",\"Text\":");
                sbRoute.append(Sys.Serialization.JavaScriptSerializer.serialize(itinerary.Text));
                sbRoute.append(",\"Time\":");
                sbRoute.append(itinerary.Time);
                sbRoute.append("}");
            }
            sbRoute.append("]}}");
        }
        sbRoute.append("]}");

        var hf = document.getElementById(this.get_id() + "_UP_HiddenDirectionsField");
        hf.value = sbRoute.toString();

        this._triggerAsyncPostback("directionsloaded");
    },
    LoadAsyncEventData: function(data) {
        var m = this;
        var map = this.get_Map();
        var mapData = Sys.Serialization.JavaScriptSerializer.deserialize(data);

        if (mapData.Width != this.get_Width() || mapData.Height != this.get_Height()) {
            this.Resize(mapData.Width, mapData.Height);
        }

        if (mapData.MapStyle != null) {
            this.SetMapStyle(mapData.MapStyle);
        }
        if (mapData.ShowTraffic != null) {
            if (mapData.ShowTraffic) {
                this.LoadTraffic(true);
            } else {
                this.ClearTraffic();
            }
        }
        if (mapData.ShowTrafficLegend != null) {
            if (mapData.ShowTrafficLegend) {
                this.ShowTrafficLegend();
            } else {
                this.HideTrafficLegend();
            }
        }

        if (mapData.TrafficLegendText) {
            this.SetTrafficLegendText(mapData.TrafficLegendText);
        }
        if (mapData.DeleteLayersFirst != null) {
            if (mapData.DeleteLayersFirst) {
                this.DeleteAllShapeLayers();
            }
        }

        if (mapData.ShapeLayersToRemove) {
            var ids = mapData.ShapeLayersToRemove.split("|");
            for (var i = (ids.length - 1); i >= 0; i--) {
                this.DeleteShapeLayer(this.GetShapeLayerByIndex(parseInt(ids[i])));
            }
        }

        if (mapData.ShapesToRemove) {
            var ids = mapData.ShapesToRemove.split("|");
            var idsl = ids.length;
            for (var i = 0; i < idsl; i++) {
                this.DeleteShape(map.GetShapeByID(ids[i]));
            }
        }
        //if (mapData.Layers != null) {
        if (mapData.Layers) {
            this._loadShapeLayersFromCollection(mapData.Layers);
        }
        if (mapData.CustomInfoBoxStylesEnabled != null) {
            this._CustomInfoBoxStylesEnabled = mapData.CustomInfoBoxStylesEnabled;
            if (this._CustomInfoBoxStylesEnabled) {
                map.ClearInfoBoxStyles();
            } else {
                map.SetDefaultInfoBoxStyles();
            }
        }
        if (mapData.BirdseyeOrientation != null) {
            this._BirdseyeOrientation = this._getVEOrientation(mapData.BirdseyeOrientation);
            map.SetBirdseyeOrientation(this._BirdseyeOrientation);
        }
        //if (mapData.ZoomLevel != null && mapData.Latitude != null && mapData.Longitude != null) {
        if (mapData.ZoomLevel && mapData.Latitude && mapData.Longitude) {
            map.SetCenterAndZoom(new VELatLong(mapData.Latitude, mapData.Longitude), mapData.ZoomLevel);
        } else {
            //if (mapData.ZoomLevel != null) {
            if (mapData.ZoomLevel) {
                map.SetZoomLevel(mapData.ZoomLevel);
            }
            //if (mapData.Latitude != null && mapData.Longitude != null) {
            if (mapData.Latitude && mapData.Longitude) {
                map.SetCenter(new VELatLong(mapData.Latitude, mapData.Longitude));
            }
        }
        if (mapData.Directions_Clear != null) {
            map.DeleteRoute();
        }
        //if (mapData.Direction_Locations != null) {
        if (mapData.Direction_Locations) {
            var locations = [];
            var dirloclen = mapData.Direction_Locations.length;
            for (var i = 0; i < dirloclen; i++) {
                var loc = mapData.Direction_Locations[i];
                if (typeof (loc) == "string") {
                    locations[i] = loc;
                } else {
                    locations[i] = new VELatLong(loc.Latitude, loc.Longitude);
                }
            }
            var routeOptions = new VERouteOptions();
            routeOptions.RouteCallback = function(route) {
                if (route) {
                    m._triggerDirectionsLoadedAsyncPostback(route);
                }
            };
            var ro = mapData.Direction_RouteOptions;
            if (ro) {
                if (ro.DistanceUnit != null) {
                    routeOptions.DistanceUnit = ((ro.DistanceUnit == 1) ? VERouteDistanceUnit.Kilometer : VERouteDistanceUnit.Mile);
                }
                if (ro.DrawRoute != null) {
                    routeOptions.DrawRoute = ro.DrawRoute;
                }
                if (ro.RouteColor != null) {
                    routeOptions.RouteColor = this._getVEColor(ro.RouteColor);
                }
                if (ro.RouteMode != null) {
                    routeOptions.RouteMode = (ro.RouteMode == 1 ? VERouteMode.Walking : VERouteMode.Driving);
                }
                if (ro.RouteOptimize != null) {
                    routeOptions.RouteOptimize = ((ro.RouteOptimize == 1) ? VERouteOptimize.MinimizeTime : ((ro.RouteOptimize == 2) ? VERouteOptimize.MinimizeDistance : VERouteOptimize.Default));
                }
                if (ro.RouteWeight != null) {
                    routeOptions.RouteWeight = ro.RouteWeight;
                }
                if (ro.RouteZIndex != null) {
                    routeOptions.RouteZIndex = ro.RouteZIndex;
                }
                if (ro.SetBestMapView != null) {
                    routeOptions.SetBestMapView = ro.SetBestMapView;
                }
                if (ro.ShowDisambiguation != null) {
                    routeOptions.ShowDisambiguation = ro.ShowDisambiguation;
                }
                if (ro.ShowErrorMessages != null) {
                    routeOptions.ShowErrorMessages = ro.ShowErrorMessages;
                }
            }
            map.GetDirections(locations, routeOptions);
        }
        //if (mapData.FindArgs != null) {
        if (mapData.FindArgs) {
            this._doFindFromFindArgs(mapData.FindArgs);
        }
        //if (mapData.FindLocations != null) {
        if (mapData.FindLocations) {
            var loc = this._getVELatLong(mapData.FindLocations);
            map.FindLocations(loc, function(places) {
                m._findLocationsCallback(loc, places);
            });
        }
        //if (mapData.ImportShapeLayerData_shapeSource != null) {
        if (mapData.ImportShapeLayerData_shapeSource) {
            this._doImportShapeLayerData(mapData.ImportShapeLayerData_shapeSource, mapData.ImportShapeLayerData_setBestView);
        }
        return null;
    },
    _doImportShapeLayerData: function(shapeSource, setBestView) {
        var m = this;
        this.ImportShapeLayerData(this._getVEShapeSourceSpecification(shapeSource),
            function(sl) {
                m._importShapeLayerDataCallback(sl);
            }, setBestView);
    },
    _importShapeLayerDataCallback: function(shapeLayer) {
        var r = new Simplovation.Web.Maps.VE.ImportShapeLayerDataEventArgs();
        r.ShapeLayer = this._convertShapeLayerToPostback(shapeLayer);
        r.ShapeSource = new Simplovation.Web.Maps.VE.ShapeSourceSpecification();
        r.ShapeSource.LayerSource = shapeLayer.Spec.LayerSource;
        r.ShapeSource.Type = this._getIntFromVEDataType(shapeLayer.Spec.Type);
        var hf = document.getElementById(this.get_id() + "_UP_ISLDHF");
        hf.value = Sys.Serialization.JavaScriptSerializer.serialize(r);
        this._triggerAsyncPostback("importshapelayerdataloaded");
    },
    _findLocationsCallback: function(loc, places) {
        var args = new Simplovation.Web.Maps.VE.FindLocationsCallbackArgs();
        args.Location = loc;
        args.Places = places;
        var hf = document.getElementById(this.get_id() + "_UP_HiddenFLField");
        hf.value = Sys.Serialization.JavaScriptSerializer.serialize(args);
        this._triggerAsyncPostback("findlocationsloaded");
    },
    _doFindFromFindArgs: function(findArgs) {
        var m = this;
        this.Find(findArgs.What, findArgs.Where, VEFindType.Businesses,
            null, //shapeLayer
            findArgs.StartIndex, findArgs.NumberOfResults, findArgs.ShowResults,
            findArgs.CreateResults, findArgs.UseDefaultDisambiguation, findArgs.SetBestMapView,
            function(layer, resultsArray, places, hasMore, veErrorMessage) {
                m._findCallback(layer, resultsArray, places, hasMore, veErrorMessage);
            });
    },
    _findCallback: function(layer, resultsArray, places, hasMore, veErrorMessage) {
        var args = new Simplovation.Web.Maps.VE.FindCallbackArgs();
        args.Places = places;
        //Array of VEFindResult
        var results = [];
        if (resultsArray) {
            var ral = resultsArray.length;
            for (var i = 0; i < ral; i++) {
                var item = resultsArray[i];
                var r = {};
                r.Name = item.Name;
                if (item.Shape == null) {
                    r.Shape == null;
                } else {
                    r.Shape = this._convertShapeToPostback(item.Shape);
                }
                r.Description = item.Description;
                r.FindType = this._getIntFromFindType(item.FindType);
                r.IsSponsored = item.IsSponsored;
                r.LatLong = item.LatLong;
                r.Phone = item.Phone;
                results.push(r);
            }
        }
        args.Results = results;

        var hff = document.getElementById(this.get_id() + "_UP_HiddenFindField");
        hff.value = Sys.Serialization.JavaScriptSerializer.serialize(args);

        this._triggerAsyncPostback("findloaded");
    },
    _getIntFromFindType: function(f) {
        if (f == VEFindType.Businesses) {
            return 0;
        }
        return f;
    },
    _raiseClientSideEvent: function(evtName, e) {
        var h = this.get_events().getHandler(evtName);
        if (h) {
            h(this, e);
        }
    },
    addHandler: function(eventName, method) {
        this.get_events().addHandler(eventName, method);
    },
    removeHandler: function(eventName, method) {
        this.get_events().removeHandler(eventName, method);
    },
    AddHandler: function(e, m) {
        this.addHandler(e, m);
    },
    RemoveHandler: function(e, m) {
        this.removeHandler(e, m);
    },
    AttachEvent: function(e, m) {
        this.addHandler(e, m);
    },
    DetachEvent: function(e, m) {
        this.removeHandler(e, m);
    },
    _convertShapeLayerToPostback: function(layer) {
        sl = new Simplovation.Web.Maps.VE.ShapeLayer();
        sl.Title = layer.GetTitle();
        sl.Description = layer.GetDescription();
        sl.Visible = layer.IsVisible();
        sl.Tag = layer.SimplovationTag;
        sl.Shapes = [];

        var l = layer.GetShapeCount();
        for (var shapeIndex = 0; shapeIndex < l; shapeIndex++) {
            sl.Shapes.push(this._convertShapeToPostback(layer.GetShapeByIndex(shapeIndex)));
        }

        return sl;
    },
    _convertShapeToPostback: function(shape) {
        var appPathDomain = Simplovation.Web.Maps.VE.Utils.AppPathDomain;

        var mapShape;
        var myShape = new Simplovation.Web.Maps.VE.Shape();
        if (typeof (shape) != "string") {
            mapShape = shape;
            myShape.ClientID = mapShape.GetID();
        } else {
            myShape.ClientID = shape;
            mapShape = this._Map.GetShapeByID(myShape.ClientID);
        }
        myShape.Title = Simplovation$Web$Maps$JSONEncodeString(mapShape.GetTitle());
        myShape.Description = Simplovation$Web$Maps$JSONEncodeString(mapShape.GetDescription());
        
        myShape.Draggable = mapShape.Draggable;

        if (mapShape.GetCustomIcon()) {
            myShape.CustomIcon = mapShape.GetCustomIcon();
            myShape.CustomIcon.CustomHTML = Simplovation$Web$Maps$JSONEncodeString(myShape.CustomIcon.CustomHTML);
            myShape.CustomIcon.Image = Simplovation$Web$Maps$JSONEncodeString(myShape.CustomIcon.Image);
            myShape.CustomIcon.ImageOffset = new Simplovation.Web.Maps.VE.Pixel(myShape.CustomIcon.ImageOffset.x, myShape.CustomIcon.ImageOffset.y);
            myShape.CustomIcon.TextOffset = new Simplovation.Web.Maps.VE.Pixel(myShape.CustomIcon.TextOffset.x, myShape.CustomIcon.TextOffset.y);
        }

        myShape.FillColor = mapShape.GetFillColor();
        myShape.IconAnchor = mapShape.GetIconAnchor();
        myShape.LineColor = mapShape.GetLineColor();

        var lineWidth = mapShape.GetLineWidth();
        if (lineWidth) {
            myShape.LineWidth = lineWidth;
        }

        var strMoreInfoUrl = mapShape.GetMoreInfoURL();
        if (strMoreInfoUrl.substring(0, appPathDomain.length) == appPathDomain) {
            strMoreInfoUrl = strMoreInfoUrl.substring(appPathDomain.length);
        }
        if (strMoreInfoUrl.substring(0, this._AppPathRoot.length) == this._AppPathRoot) {
            strMoreInfoUrl = "~/" + strMoreInfoUrl.substring(this._AppPathRoot.length);
        }
        myShape.MoreInfoURL = strMoreInfoUrl;

        var strPhotoUrl = mapShape.GetPhotoURL();
        if (strPhotoUrl.substring(0, appPathDomain.length) == appPathDomain) {
            strPhotoUrl = strPhotoUrl.substring(appPathDomain.length);
        }
        if (strPhotoUrl.substring(0, this._AppPathRoot.length) == this._AppPathRoot) {
            strPhotoUrl = "~/" + strPhotoUrl.substring(this._AppPathRoot.length);
        }

        myShape.PhotoURL = strPhotoUrl;
        myShape.Points = mapShape.GetPoints();
        if (myShape.Points.length != 0) {
            var mspl = myShape.Points.length;
            for (var i = 0; i < mspl; i++) {
                myShape.Points[i].AltitudeMode = this._getIntFromVEAltitudeMode(myShape.Points[i].AltitudeMode);
            }
        }

        var altitude = mapShape.GetAltitude();
        if (altitude) {
            myShape.Altitude = altitude[0];
        }
        myShape.AltitudeMode = this._getIntFromVEAltitudeMode(mapShape.GetAltitudeMode);

        var shapeType = mapShape.GetType();
        if (shapeType == VEShapeType.Pushpin) {
            myShape.Type = 0;
        } else if (shapeType == VEShapeType.Polygon) {
            myShape.Type = 2;
        } else { //if(shapeType==VEShapeType.Polyline)
            myShape.Type = 1;
        }
        myShape.ZIndex = mapShape.GetZIndex();
        myShape.Tag = mapShape.SimplovationTag;
        return myShape;
    },
    //MapEvents
    _onChangeMapStyle: function(e) {
        if (this.get_OnChangeMapStyle_Handled()) {
            this._triggerAsyncPostback("onchangemapstyle", e);
        }
        this._raiseClientSideEvent("onchangemapstyle", e);
    },
    _onChangeView: function(e) {
        if (this.get_OnChangeView_Handled()) {
            this._triggerAsyncPostback("onchangeview", e);
        }
        this._raiseClientSideEvent("onchangeview", e);
    },
    _onEndPan: function(e) {
        if (this.get_OnEndPan_Handled()) {
            this._triggerAsyncPostback("onendpan", e);
        }
        this._raiseClientSideEvent("onendpan", e);
    },
    _onEndZoom: function(e) {
        if (this.get_OnEndZoom_Handled()) {
            this._triggerAsyncPostback("onendzoom", e);
        }
        this._raiseClientSideEvent("onendzoom", e);
    },
    _onError: function(e) {
        this._triggerAsyncPostback("onerror", e);
        this._raiseClientSideEvent("onerror", e);
    },
    _onObliqueEnter: function(e) {
        if (this.get_OnObliqueEnter_Handled()) {
            this._triggerAsyncPostback("onobliqueenter", e);
        }
        this._raiseClientSideEvent("onobliqueenter", e);
    },
    _onObliqueLeave: function(e) {
        if (this.get_OnObliqueLeave_Handled()) {
            this._triggerAsyncPostback("onobliqueleave", e);
        }
        this._raiseClientSideEvent("onobliqueleave", e);
    },
    _onObliqueChange: function(e) {
        this._raiseClientSideEvent("onobliquechange", e);
    },
    _onResize: function(e) {
        var mapdiv = this.get_MainMapDiv();
        if (mapdiv) {
            // Adjust the Main Control DIV to be same size as the VEMap
            var oldWidth = mapdiv.offsetWidth;
            var oldHeight = mapdiv.offsetHeight;

            if (oldHeight && oldWidth) {
                var newHeight = oldHeight;
                var newWidth = oldWidth;
                var elem = this.get_element();
                if (elem) {
                    elem.style.height = newHeight + "px";
                    elem.style.width = newWidth + "px";
                }
            }
            this._realignLogo();
        }

        this._raiseClientSideEvent("onresize", e);
    },
    _onStartPan: function(e) {
        this._raiseClientSideEvent("onstartpan", e);
    },
    _onStartZoom: function(e) {
        this._raiseClientSideEvent("onstartzoom", e);
    },
    //CustomerIdentificationEvents
    _onTokenExpire: function(e) {
        this._raiseClientSideEvent("ontokenexpire", e);
    },
    _onTokenError: function(e) {
        this._raiseClientSideEvent("ontokenerror", e);
    },
    //MouseEvents
    _onClick: function(e) {
        if (this.get_OnClick_Handled()) {
            this._triggerAsyncPostback("onclick", e);
        }
        this._raiseClientSideEvent("onclick", e);
    },
    _onDoubleClick: function(e) {
        this._raiseClientSideEvent("ondoubleclick", e);
    },
    _onMouseDown: function(e) {
        this._raiseClientSideEvent("onmousedown", e);
    },
    _onMouseMove: function(e) {
        this._raiseClientSideEvent("onmousemove", e);
    },
    _onMouseOut: function(e) {
        this._raiseClientSideEvent("onmouseout", e);
    },
    _onMouseOver: function(e) {
        this._raiseClientSideEvent("onmouseover", e);
    },
    _onMouseUp: function(e) {
        this._raiseClientSideEvent("onmouseup", e);
    },
    _onMouseWheel: function(e) {
        this._raiseClientSideEvent("onmousewheel", e);
    },
    //KeyboardEvents
    _onKeyPress: function(e) {
        this._raiseClientSideEvent("onkeypress", e);
    },
    _onKeyDown: function(e) {
        this._raiseClientSideEvent("onkeydown", e);
    },
    _onKeyUp: function(e) {
        this._raiseClientSideEvent("onkeyup", e);
    }
};
Simplovation.Web.Maps.VE.Map.registerClass("Simplovation.Web.Maps.VE.Map", Simplovation.Web.Maps.VE.AsyncScriptControl);

Simplovation.Web.Maps.VE.AsyncMapData = function() {
    this.EventName = null; this.EventArgs = null; this.Width = null; this.Height = null;
    this.ZoomLevel = null; this.Latitude = null; this.Longitude = null; this.MapStyle = null;
    this.Direction_Locations = null; this.Direction_RouteOptions = null; this.MapLoadedEventArgs = null;
    this.CustomInfoBoxStylesEnabled = null; this.ShowTraffic = null; this.ShowTrafficLegend = null;
    this.TrafficLegendText = null;
    this.ImportShapeLayerData_shapeSource = null; this.ImportShapeLayerData_setBestView = false; 
    this.BirdseyeOrientation = null;
};
Simplovation.Web.Maps.VE.FindCallbackArgs = function() {
    this.Places = null;
    this.Results = null;
};
Simplovation.Web.Maps.VE.FindLocationsCallbackArgs = function() {
    this.Location = null;
    this.Places = null;
};
Simplovation.Web.Maps.VE.Shape=function(){
    this.ClientID = null; 
    this.CustomIcon = null; 
    this.Description = null;
    this.FillColor = null; 
    this.IconAnchor = null;
    this.LineColor=null;
    this.LineWidth = 2; 
    this.MoreInfoURL = null; 
    this.PhotoURL = null; 
    this.Points = null; 
    this.Title = null; 
    this.Type = 0; 
    this.Altitude = 0;
    this.AltitudeMode=0;
};
Simplovation.Web.Maps.VE.Pixel = function(x, y) {
    if (isNaN(x)) {
        this.X = 0;
    } else {
        this.X = x;
    }
    if (isNaN(y)) {
        this.Y = 0; 
    } else {
        this.Y = y; 
    }
};
Simplovation.Web.Maps.VE.ShapeLayer = function() {
    this.Title = null;
    this.Description = null;
    this.Shapes = null;
    this.Visible = true;
};
Simplovation.Web.Maps.VE.ImportShapeLayerDataEventArgs = function() {
    this.ShapeLayer = null;
    this.BestMapView = null;
    this.ShapeSource = null;
};
Simplovation.Web.Maps.VE.ShapeSourceSpecification = function() {
    this.LayerSource = null;
    this.Type = null;
};

Type.registerNamespace("Simplovation.Web.Maps.VE.Utils");
Simplovation.Web.Maps.VE.Utils.AppPathDomain = location.protocol + "//" + location.host;
Type.registerNamespace("Simplovation.Web.Maps.VE.Utils.UrlHelper");
Simplovation.Web.Maps.VE.Utils.UrlHelper.ToAbsolute = function(s, appRoot) {
    var n = s;
    if (n.substring(0, 2) == "~/") {
        n = appRoot + n.substring(2);
    }
    if (n.substring(0, 1) == "/") {
        n = Simplovation.Web.Maps.VE.Utils.AppPathDomain + n;
    }
    return n;
};

function Simplovation$Web$Maps$JSONEncodeString(str) {
    var newstr = str;
    
    var r = function(s, o, n) {
        var ns = s;
        while (ns.indexOf(o) != -1) {
            ns = ns.replace(o, n);
        }
        return ns;
    }

    newstr = r(newstr, "<", "\\u003c");
    newstr = r(newstr, ">", "\\u003e");
    newstr = r(newstr, "&", "\\u0026");
    return newstr;
}
Sys.Application.notifyScriptLoaded();