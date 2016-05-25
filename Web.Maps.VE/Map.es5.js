/* ----------------------------------------------------------------------------------- */
/* Copyright (C) Simplovation LLC (http://Simplovation.com) 2016. All rights reserved. */
/* Licensing information available at http://webmapsve.codeplex.com                    */
/* ----------------------------------------------------------------------------------- */
/*Map.js - Simplovation.Web.Maps.VE*/
"use strict";

Type.registerNamespace("Simplovation.Web.Maps.VE");
Simplovation.Web.Maps.VE.Map = function (element) {
    Simplovation.Web.Maps.VE.Map.initializeBase(this, [element]);

    this._Map = null;
    this._MainMapDiv = null;
    this._LatLong = null;
    this._Zoom = "4";
    this._MapType = Microsoft.Maps.MapTypeId.road;
    this._Fixed = false;
    this._ShowPoweredBy = true;
    this._ShowSwitch = true;
    this._NavigationBarMode = null; // Microsoft.Maps.NavigationBarMode.compact; // <-- use Microsoft.Maps.NavigationBarMode.compact here
    this._TileBuffer = 0;this._Layers = null;
    this._AsyncPostbackPassShapes = true;
    this._AppPathRoot = null;
    this._AppPathDomain = null;
    this._OnClientMapLoaded = null;
    this._FindArgs = null;
    this._BingKey = null;
    this._EnableDashboardLabels = true;
    this._LoadBaseTiles = true;

    this._ImportShapeLayerData_shapeSource = null;
    this._ImportShapeLayerData_setBestView = null;

    function fcd(e, h) {
        return Function.createDelegate(e, h);
    }
    //MapEvents
    this._OnMapLoaded_Handled = false;
    this._changeMapTypeHandler = fcd(this, this._onChangeMapType);
    this._OnChangeMapType_Handled = null;
    this._changeViewHandler = fcd(this, this._onChangeView);
    this._OnChangeView_Handled = null;
    this._endZoomHandler = fcd(this, this._onEndZoom);
    this._OnEndZoom_Handled = null;
    this._errorHandler = fcd(this, this._onError);
    this._OnError_Handled = null;
    this._startZoomHandler = fcd(this, this._onStartZoom);
    //MouseEvents
    this._clickHandler = fcd(this, this._click);
    this._click_Handled = null;
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
    initialize: function initialize() {
        Simplovation.Web.Maps.VE.Map.callBaseMethod(this, "initialize");

        var that = this;

        //All VEMap Stuff
        if (!isNaN(this._MapType)) {
            if (this._MapType == 2) {
                this._MapType = Microsoft.Maps.MapTypeId.aerial;
            } else if (this._MapType == 3) {
                this._MapType = Microsoft.Maps.MapTypeId.ordnanceSurvey;
            } else if (this._MapType == 4) {
                this._MapType = Microsoft.Maps.MapTypeId.streetside;
            } else {
                this._MapType = Microsoft.Maps.MapTypeId.road;
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
            zoom: this._Zoom,
            disablePanning: this._Fixed,
            disableZooming: this._Fixed
        };

        if (this._NavigationBarMode !== null) {
            mapOptions.navigationBarMode = this._NavigationBarMode;
        }

        window.setTimeout(function () {

            that._Map = new Microsoft.Maps.Map(that._MainMapDiv, mapOptions);
        }, 100);

        //if (this._TileBuffer != 0) {
        //    this._Map.SetTileBuffer(this._TileBuffer);
        //}

        //var mapOptions = new VEMapOptions();
        //mapOptions.EnableDashboardLabels = this._EnableDashboardLabels;
        //mapOptions.LoadBaseTiles = this._LoadBaseTiles;

        //this._Map.onLoadMap = this._map_OnLoad$delegate;

        //this._Map.LoadMap(
        //    (this._LatLong.Latitude != 0 ? new Microsoft.Maps.Location(this._LatLong.Latitude, this._LatLong.Longitude) : null),
        //    this._Zoom,
        //    this._MapType,
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
        //av("maptypechanged", this._changeMapTypeHandler);
        //av("onchangeview", this._changeViewHandler);
        //av("onendzoom", this._endZoomHandler);
        //av("onerror", this._errorHandler);
        //av("onstartzoom", this._startZoomHandler);
        ////Mouse
        //av("click", this._clickHandler);
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
    dispose: function dispose() {
        if (this._Map && this._Map.Dispose) {
            this._Map.Dispose();
        }
        Simplovation.Web.Maps.VE.Map.callBaseMethod(this, "dispose");
    },
    _map_OnLoad: function _map_OnLoad(e) {
        var that = this;
        if (this._DistanceUnit != null) {
            if (this._DistanceUnit == 1) {
                this._DistanceUnit = VEDistanceUnit.Kilometers;
            } else {
                this._DistanceUnit = VEDistanceUnit.Miles;
            }this._Map.SetScaleBarDistanceUnit(this._DistanceUnit);
        }

        if (this._Layers) {
            if (this._Layers.length > 0) {
                this._loadShapeLayersFromCollection(this._Layers);
            }
        }
        if (this.get_OnMapLoaded_Handled()) {
            this._triggerAsyncPostback("maploaded");
        }
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
            window.setTimeout(function () {
                that.get_Map().AddControl(logo);
                that._realignLogo();
            }, 100);
        }
    },
    _realignLogo: function _realignLogo() {
        if (this._ShowPoweredBy) {
            var logo = this.logo;
            if (logo) {
                logo.style.top = this.get_element().offsetHeight - logo.offsetHeight - 50 + "px";
                logo.style.left = "10px";
                this.get_Map().AddControl(logo);
            }
        }
    },
    _loadShapeLayersFromCollection: function _loadShapeLayersFromCollection(col) {
        var sl = null;
        var isNewLayer = false;
        var collen = col.length;
        for (var layerIndex = 0; layerIndex < collen; layerIndex++) {
            sl = this.get_Map().GetShapeLayerByIndex(layerIndex);
            isNewLayer = sl == null;
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
                if (s.ClientID == null) {
                    //NewShape
                    console.error('adding NewShapes not supported yet');
                    s = this._getVEShape(s);
                    sl.AddShape(s);
                } else {
                    //ExistingShape
                    console.error('update ExistingShape not supported yet');
                    this._updateVEShape(s);
                }
            }
            if (isNewLayer) {
                this.get_Map().AddShapeLayer(sl);
            }
        }
    },
    _getVEShape: function _getVEShape(s) {
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
    _getVELatLong: function _getVELatLong(l) {
        return new Microsoft.Maps.Location(l.Latitude, l.Longitude);
    },
    _getVEShapeSourceSpecification: function _getVEShapeSourceSpecification(v) {
        return new VEShapeSourceSpecification(this._getVEDataType(v.Type), v.LayerSource, null);
    },
    _getVEDataType: function _getVEDataType(v) {
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
    _getIntFromVEDataType: function _getIntFromVEDataType(v) {
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
    _updateVEShape: function _updateVEShape(s) {
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
    _getVEColor: function _getVEColor(c) {
        return new VEColor(c.R, c.G, c.B, c.A);
    },
    _getVEPixel: function _getVEPixel(p) {
        return new VEPixel(p.X, p.Y);
    },
    _getVECustomIconSpecification: function _getVECustomIconSpecification(v) {
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
    _setVEShapeProperties: function _setVEShapeProperties(s, shape) {
        //if (s.Altitude != null) {
        if (s.Altitude) {
            shape.SetAltitude(s.Altitude, this._getVEAltitudeModeFromInt(s.AltitudeMode));
        }
        //if (s.Description != null) {
        if (s.Description) {
            shape.SetDescription(s.Description);
        }
        if (s.Draggable != undefined) {
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
            shape.SetIconAnchor(new Microsoft.Maps.Location(s.IconAnchor.Latitude, s.IconAnchor.Longitude));
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
    AddShape: function AddShape(s) {
        this.get_Map().AddShape(s);
    },
    DeleteShapeById: function DeleteShapeById(id) {
        var s = this.GetShapeByID(id);
        this.DeleteShape(s);
    },
    SetCenterOnShapeByID: function SetCenterOnShapeByID(shapeid, zoom, showInfoBox) {
        var shape = this.GetShapeByID(shapeid);
        if (shape == null) {
            throw "Unable to find Shape (" + shapeid + ")";
        } else {
            this.SetCenterOnShape(shape, zoom, showInfoBox);
        }
    },
    SetCenterOnShape: function SetCenterOnShape(shape, zoom, showInfoBox) {
        //if (zoom != null) {
        if (zoom) {
            this.SetCenterAndZoom(shape.GetIconAnchor(), zoom);
        } else {
            this.SetCenter(shape.GetIconAnchor());
        }
    },
    SetCenterOnShapeByTag: function SetCenterOnShapeByTag(tag, zoom) {
        var s = this.GetShapeByTag(tag);
        if (s == null) {
            throw "Unable to find Shape by Tag (" + tag + ")";
        } else {
            this.SetCenterOnShape(s, zoom);
        }
    },
    GetShapeByTag: function GetShapeByTag(tag) {
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

    AddControl: function AddControl(e, z) {
        this.get_Map().AddControl(e, z);
    },
    AddCustomLayer: function AddCustomLayer(a) {
        this.get_Map().AddCustomLayer(a);
    },
    AddShapeLayer: function AddShapeLayer(l, b) {
        this.get_Map().AddShapeLayer(l, b);
    },
    AddTileLayer: function AddTileLayer(l, v) {
        this.get_Map().AddTileLayer(l, v);
    },
    Clear: function Clear() {
        this.get_Map().Clear();
    },
    DeleteAllShapeLayers: function DeleteAllShapeLayers() {
        this.get_Map().DeleteAllShapeLayers();
    },
    DeleteAllShapes: function DeleteAllShapes() {
        this.get_Map().DeleteAllShapes();
    },
    DeleteControl: function DeleteControl(e) {
        this.get_Map().DeleteControl(e);
    },
    DeleteRoute: function DeleteRoute() {
        this.get_Map().DeleteRoute();
    },
    DeleteShape: function DeleteShape(s) {
        if (s) {
            this.get_Map().DeleteShape(s);
            s = null;
        }
    },
    DeleteShapeLayer: function DeleteShapeLayer(l) {
        this.get_Map().DeleteShapeLayer(l);
    },
    DeleteTileLayer: function DeleteTileLayer(id) {
        this.get_Map().DeleteTileLayer(id);
    },
    EnableShapeDisplayThreshold: function EnableShapeDisplayThreshold(v) {
        this.get_Map().EnableShapeDisplayThreshold(v);
    },
    Find: function Find(what, where, findType, shapeLayer, startIndex, numberOfResults, showResults, createResults, useDefaultDisambiguation, setBestMapView, callback) {
        this.get_Map().Find(what, where, findType, shapeLayer, startIndex, numberOfResults, showResults, createResults, useDefaultDisambiguation, setBestMapView, callback);
    },
    FindLocations: function FindLocations(l, c) {
        this.get_Map().FindLocations(l, c);
    },
    Geocode: function Geocode(query, callback, opts) {
        this.get_Map().Geocode(query, callback, opts);
    },
    GetCenter: function GetCenter() {
        return this.get_Map().GetCenter();
    },
    GetDirections: function GetDirections(l, o) {
        this.get_Map().GetDirections(l, o);
    },
    GetHeight: function GetHeight() {
        return this.get_Height();
    },
    GetLeft: function GetLeft() {
        return this.get_Map().GetLeft();
    },
    GetMapType: function GetMapType() {
        return this.get_Map().getMapTypeId();
    },
    GetMapView: function GetMapView() {
        return null; //return this.get_Map().GetMapView();
    },
    GetShapeByID: function GetShapeByID(id) {
        return this.get_Map().GetShapeByID(id);
    },
    GetShapeLayerByIndex: function GetShapeLayerByIndex(i) {
        return this.get_Map().GetShapeLayerByIndex(i);
    },
    GetShapeLayerCount: function GetShapeLayerCount(i) {
        return this.get_Map().GetShapeLayerCount(i);
    },
    GetTileLayerByID: function GetTileLayerByID(id) {
        return this.get_Map().GetTileLayerByID(id);
    },
    GetTileLayerByIndex: function GetTileLayerByIndex(i) {
        return this.get_Map().GetTileLayerByIndex(i);
    },
    GetTileLayerCount: function GetTileLayerCount() {
        return this.get_Map().GetTileLayerCount();
    },
    GetTop: function GetTop() {
        return this.get_Map().GetTop();
    },
    GetVersion: function GetVersion() {
        return VEMap.GetVersion();
    },
    GetWidth: function GetWidth() {
        return this.get_Width();
    },
    GetZoomLevel: function GetZoomLevel() {
        return this.get_Map().getZoom();
    },
    Hide3DNavigationControl: function Hide3DNavigationControl() {
        this.get_Map().Hide3DNavigationControl();
    },
    HideAllShapeLayers: function HideAllShapeLayers() {
        this.get_Map().HideAllShapeLayers();
    },
    HideControl: function HideControl(e) {
        this.get_Map().HideControl(e);
    },
    HideFindControl: function HideFindControl() {
        this.get_Map().HideFindControl();
    },
    HideInfoBox: function HideInfoBox() {
        this.get_Map().HideInfoBox();
    },
    HideMiniMap: function HideMiniMap() {
        this.get_Map().HideMiniMap();
    },
    HideTileLayer: function HideTileLayer(l) {
        this.get_Map().HideTileLayer(l);
    },
    ImportShapeLayerData: function ImportShapeLayerData(s, c, v) {
        this.get_Map().ImportShapeLayerData(s, c, v);
    },
    IncludePointInView: function IncludePointInView(l) {
        this.get_Map().IncludePointInView(l);
    },
    LatLongToPixel: function LatLongToPixel(l) {
        return this.get_Map().LatLongToPixel(l);
    },
    PixelToLatLong: function PixelToLatLong(p) {
        return this.get_Map().PixelToLatLong(p);
    },
    RemoveCustomLayer: function RemoveCustomLayer(a) {
        this.get_Map().RemoveCustomLayer(a);
    },
    Search: function Search(query, callback, opts) {
        this.get_Map().Search(query, callback, opts);
    },
    SetCenter: function SetCenter(l) {
        this.get_Map().setView({
            center: l
        });
    },
    SetCenterAndZoom: function SetCenterAndZoom(l, z) {
        this.get_Map().setView({
            center: l,
            zoom: z
        });
    },
    SetNavigationBarMode: function SetNavigationBarMode(d) {
        this.get_Map().SetNavigationBarMode(d);
    },
    SetFailedShapeRequest: function SetFailedShapeRequest(p) {
        this.get_Map().SetFailedShapeRequest(p);
    },
    SetMapType: function SetMapType(v) {
        if (!isNaN(v)) {
            if (v == 2) {
                v = Microsoft.Maps.MapTypeId.aerial;
            } else if (v == 3) {
                v = Microsoft.Maps.MapTypeId.ordnanceSurvey;
            } else if (v == 4) {
                v = Microsoft.Maps.MapTypeId.streetside;
            } else {
                v = Microsoft.Maps.MapTypeId.road;
            }
        }
        this.get_Map().setMapType(v);
    },
    SetMapView: function SetMapView(v) {
        this.get_Map().SetMapView(v);
    },
    SetMouseWheelZoomToCenter: function SetMouseWheelZoomToCenter(v) {
        this.get_Map().SetMouseWheelZoomToCenter(v);
    },
    SetShapesAccuracy: function SetShapesAccuracy(p) {
        this.get_Map().SetShapesAccuracy(p);
    },
    SetShapesAccuracyRequestLimit: function SetShapesAccuracyRequestLimit(v) {
        this.get_Map().SetShapesAccuracyRequestLimit(v);
    },
    SetTileBuffer: function SetTileBuffer(v) {
        this.get_Map().SetTileBuffer(v);
    },
    SetZoomLevel: function SetZoomLevel(v) {
        this.get_Map().setView({ zoom: v });
    },
    Show3DNavigationControl: function Show3DNavigationControl() {
        this.get_Map().Show3DNavigationControl();
    },
    ShowAllShapeLayers: function ShowAllShapeLayers() {
        this.get_Map().ShowAllShapeLayers();
    },
    ShowControl: function ShowControl(e) {
        this.get_Map().ShowControl();
    },
    ShowDisambiguationDialog: function ShowDisambiguationDialog(v) {
        this.get_Map().ShowDisambiguationDialog(v);
    },
    ShowFindControl: function ShowFindControl() {
        this.get_Map().ShowFindControl();
    },
    ShowInfoBox: function ShowInfoBox(s, a, o) {
        this.get_Map().ShowInfoBox(s, a, o);
    },
    ShowMessage: function ShowMessage(m) {
        this.get_Map().ShowMessage(m);
    },
    ShowMiniMap: function ShowMiniMap(x, y, s) {
        this.get_Map().ShowMiniMap(x, y, s);
    },
    ShowTileLayer: function ShowTileLayer(id) {
        this.get_Map().ShowTileLayer(id);
    },
    ZoomIn: function ZoomIn() {
        this.SetZoomLevel(this.GetZoomLevel() + 1);
    },
    ZoomOut: function ZoomOut() {
        this.SetZoomLevel(this.GetZoomLevel() - 1);
    },
    //Property Accessors
    get_Map: function get_Map() {
        return this._Map;
    },
    get_MainMapDiv: function get_MainMapDiv() {
        return this._MainMapDiv;
    },
    get_ShowPoweredBy: function get_ShowPoweredBy() {
        return this._ShowPoweredBy;
    }, set_ShowPoweredBy: function set_ShowPoweredBy(v) {
        this._ShowPoweredBy = v;
    },
    get_Width: function get_Width() {
        return this.get_Map().getWidth();
    },
    get_Height: function get_Height() {
        return this.get_Map().getHeight();
    },
    get_LatLong: function get_LatLong() {
        return this._LatLong;
    }, set_LatLong: function set_LatLong(v) {
        this._LatLong = v;
    },
    get_Zoom: function get_Zoom() {
        return this._Zoom;
    }, set_Zoom: function set_Zoom(v) {
        this._Zoom = v;
    },
    get_MapType: function get_MapType() {
        return this._MapType;
    }, set_MapType: function set_MapType(v) {
        this._MapType = v;
    },
    get_AsyncPostbackPassShapes: function get_AsyncPostbackPassShapes() {
        return this._AsyncPostbackPassShapes;
    }, set_AsyncPostbackPassShapes: function set_AsyncPostbackPassShapes(v) {
        this._AsyncPostbackPassShapes = v;
    },
    get_Fixed: function get_Fixed() {
        return this._Fixed;
    }, set_Fixed: function set_Fixed(v) {
        this._Fixed = v;
    },
    get_DistanceUnit: function get_DistanceUnit() {
        return this._DistanceUnit;
    }, set_DistanceUnit: function set_DistanceUnit(v) {
        this._DistanceUnit = v;
    },
    get_ShowSwitch: function get_ShowSwitch() {
        return this._ShowSwitch;
    }, set_ShowSwitch: function set_ShowSwitch(v) {
        this._ShowSwitch = v;
    },
    get_NavigationBarMode: function get_NavigationBarMode() {
        return this._NavigationBarMode;
    }, set_NavigationBarMode: function set_NavigationBarMode(v) {
        this._NavigationBarMode = v;
    },
    get_TileBuffer: function get_TileBuffer() {
        return this._TileBuffer;
    }, set_TileBuffer: function set_TileBuffer(v) {
        this._TileBuffer = v;
    },
    get_EnableDashboardLabels: function get_EnableDashboardLabels() {
        return this._EnableDashboardLabels;
    }, set_EnableDashboardLabels: function set_EnableDashboardLabels(v) {
        this._EnableDashboardLabels = v;
    },
    get_LoadBaseTiles: function get_LoadBaseTiles() {
        return this._LoadBaseTiles;
    }, set_LoadBaseTiles: function set_LoadBaseTiles(v) {
        this._LoadBaseTiles = v;
    },
    get_Layers: function get_Layers() {
        return this_Layers;
    }, set_Layers: function set_Layers(v) {
        this._Layers = v;
    },
    get_AppPathRoot: function get_AppPathRoot() {
        return this._AppPathRoot;
    }, set_AppPathRoot: function set_AppPathRoot(v) {
        this._AppPathRoot = v;
    },
    get_BingKey: function get_BingKey() {
        return this._BingKey;
    }, set_BingKey: function set_BingKey(v) {
        this._BingKey = v;
    },
    get_ImportShapeLayerData_shapeSource: function get_ImportShapeLayerData_shapeSource() {
        return this._ImportShapeLayerData_shapeSource;
    }, set_ImportShapeLayerData_shapeSource: function set_ImportShapeLayerData_shapeSource(v) {
        this._ImportShapeLayerData_shapeSource = v;
    },
    get_ImportShapeLayerData_setBestView: function get_ImportShapeLayerData_setBestView() {
        return this._ImportShapeLayerData_setBestView;
    }, set_ImportShapeLayerData_setBestView: function set_ImportShapeLayerData_setBestView(v) {
        this._ImportShapeLayerData_setBestView = v;
    },
    //Map Events Handled
    get_OnMapLoaded_Handled: function get_OnMapLoaded_Handled() {
        return this._OnMapLoaded_Handled;
    }, set_OnMapLoaded_Handled: function set_OnMapLoaded_Handled(v) {
        this._OnMapLoaded_Handled = v;
    },
    get_OnClientMapLoaded: function get_OnClientMapLoaded() {
        return this._OnClientMapLoaded;
    }, set_OnClientMapLoaded: function set_OnClientMapLoaded(v) {
        this._OnClientMapLoaded = v;
    },
    get_OnChangeMapType_Handled: function get_OnChangeMapType_Handled() {
        return this._OnChangeMapType_Handled;
    }, set_OnChangeMapType_Handled: function set_OnChangeMapType_Handled(v) {
        this._OnChangeMapType_Handled = v;
    },
    get_OnChangeView_Handled: function get_OnChangeView_Handled() {
        return this._OnChangeView_Handled;
    }, set_OnChangeView_Handled: function set_OnChangeView_Handled(v) {
        this._OnChangeView_Handled = v;
    },
    get_OnEndZoom_Handled: function get_OnEndZoom_Handled() {
        return this._OnEndZoom_Handled;
    }, set_OnEndZoom_Handled: function set_OnEndZoom_Handled(v) {
        this._OnEndZoom_Handled = v;
    },
    /* Mouse Events Handled */
    get_Click_Handled: function get_Click_Handled() {
        return this._click_Handled;
    }, set_Click_Handled: function set_Click_Handled(v) {
        this._click_Handled = v;
    },
    //Other Events
    get_FindArgs: function get_FindArgs() {
        return this._FindArgs;
    },
    set_FindArgs: function set_FindArgs(v) {
        this._FindArgs = v;
    },
    GetAsyncEventData: function GetAsyncEventData(args) {
        var mapData = new Simplovation.Web.Maps.VE.AsyncMapData();
        var map = this._Map;
        mapData.EventName = args[0];
        mapData.EventArgs = args[1];

        mapData.Width = this.get_Width();
        mapData.Height = this.get_Height();

        //if (mapData.EventArgs != undefined && mapData.EventArgs != null) {
        if (mapData.EventArgs) {
            var pInt = function pInt(v) {
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
        mapData.ZoomLevel = map.getZoom();
        var mapType = map.getMapTypeId();

        if (mapType == Microsoft.Maps.MapTypeId.aerial) {
            mapData.MapType = 2;
        } else if (mapType == Microsoft.Maps.MapTypeId.ordnanceSurvey) {
            mapData.MapType = 3;
        } else if (mapType == Microsoft.Maps.MapTypeId.streetside) {
            mapData.MapType = 4;
        } else {
            /* road */
            mapData.MapType = 1;
        }

        //if (mapData.MapType != 4) { mapData.MapView = this._Map.GetMapView(); }

        (function () {
            var center = map.getCenter();
            mapData.Latitude = center.latitude;
            mapData.Longitude = center.longitude;
        })();

        if (mapData.EventName == "maploaded") {
            mapData.MapLoadedEventArgs = {};
            //mapData.MapLoadedEventArgs.MapView = map.GetMapView();
        }

        /*
        if (this._DistanceUnit == VEDistanceUnit.Miles) {
            mapData.DistanceUnit = 0;
        } else if (this._DistanceUnit == VEDistanceUnit.Kilometers) {
            mapData.DistanceUnit = 1;
        } else {
            mapData.DistanceUnit = this._DistanceUnit;
        }
        */

        if (mapData.EventName == "click") {
            var clickedLatLong = map.PixelToLatLong(new VEPixel(mapData.EventArgs.mapX, mapData.EventArgs.mapY));
            if (clickedLatLong.Latitude != null) {
                mapData.ClickedLatitude = clickedLatLong.Latitude;
                mapData.ClickedLongitude = clickedLatLong.Longitude;
            }
        }
        //Get ShapeLayers and Shapes to postback
        /*
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
        */

        return Sys.Serialization.JavaScriptSerializer.serialize(mapData);
    },
    _triggerDirectionsLoadedAsyncPostback: function _triggerDirectionsLoadedAsyncPostback(route) {
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

            var itinitemlen = routeLeg.Itinerary.Items.length;
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
    LoadAsyncEventData: function LoadAsyncEventData(data) {
        var m = this;
        var map = this.get_Map();
        var mapData = Sys.Serialization.JavaScriptSerializer.deserialize(data);

        if (mapData.MapType != null) {
            this.SetMapType(mapData.MapType);
        }

        if (mapData.DeleteLayersFirst != null) {
            if (mapData.DeleteLayersFirst) {
                this.DeleteAllShapeLayers();
            }
        }

        if (mapData.ShapeLayersToRemove) {
            var ids = mapData.ShapeLayersToRemove.split("|");
            for (var i = ids.length - 1; i >= 0; i--) {
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

        if (mapData.Layers) {
            this._loadShapeLayersFromCollection(mapData.Layers);
        }

        if (mapData.ZoomLevel && mapData.Latitude && mapData.Longitude) {
            map.SetCenterAndZoom(new Microsoft.Maps.Location(mapData.Latitude, mapData.Longitude), mapData.ZoomLevel);
        } else {
            if (mapData.ZoomLevel) {
                map.setView({ zoom: mapData.ZoomLevel });
            }
            if (mapData.Latitude && mapData.Longitude) {
                map.setView({ center: new Microsoft.Maps.Location(mapData.Latitude, mapData.Longitude) });
            }
        }

        if (mapData.Directions_Clear != null) {
            map.DeleteRoute();
        }

        if (mapData.Direction_Locations) {
            var locations = [];
            var dirloclen = mapData.Direction_Locations.length;
            for (var i = 0; i < dirloclen; i++) {
                var loc = mapData.Direction_Locations[i];
                if (typeof loc == "string") {
                    locations[i] = loc;
                } else {
                    locations[i] = new Microsoft.Maps.Location(loc.Latitude, loc.Longitude);
                }
            }
            var routeOptions = new VERouteOptions();
            routeOptions.RouteCallback = function (route) {
                if (route) {
                    m._triggerDirectionsLoadedAsyncPostback(route);
                }
            };
            var ro = mapData.Direction_RouteOptions;
            if (ro) {
                if (ro.DistanceUnit != null) {
                    routeOptions.DistanceUnit = ro.DistanceUnit == 1 ? VERouteDistanceUnit.Kilometer : VERouteDistanceUnit.Mile;
                }
                if (ro.DrawRoute != null) {
                    routeOptions.DrawRoute = ro.DrawRoute;
                }
                if (ro.RouteColor != null) {
                    routeOptions.RouteColor = this._getVEColor(ro.RouteColor);
                }
                if (ro.RouteMode != null) {
                    routeOptions.RouteMode = ro.RouteMode == 1 ? VERouteMode.Walking : VERouteMode.Driving;
                }
                if (ro.RouteOptimize != null) {
                    routeOptions.RouteOptimize = ro.RouteOptimize == 1 ? VERouteOptimize.MinimizeTime : ro.RouteOptimize == 2 ? VERouteOptimize.MinimizeDistance : VERouteOptimize.Default;
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
            map.FindLocations(loc, function (places) {
                m._findLocationsCallback(loc, places);
            });
        }
        //if (mapData.ImportShapeLayerData_shapeSource != null) {
        if (mapData.ImportShapeLayerData_shapeSource) {
            this._doImportShapeLayerData(mapData.ImportShapeLayerData_shapeSource, mapData.ImportShapeLayerData_setBestView);
        }
        return null;
    },
    _doImportShapeLayerData: function _doImportShapeLayerData(shapeSource, setBestView) {
        var m = this;
        this.ImportShapeLayerData(this._getVEShapeSourceSpecification(shapeSource), function (sl) {
            m._importShapeLayerDataCallback(sl);
        }, setBestView);
    },
    _importShapeLayerDataCallback: function _importShapeLayerDataCallback(shapeLayer) {
        var r = new Simplovation.Web.Maps.VE.ImportShapeLayerDataEventArgs();
        r.ShapeLayer = this._convertShapeLayerToPostback(shapeLayer);
        r.ShapeSource = new Simplovation.Web.Maps.VE.ShapeSourceSpecification();
        r.ShapeSource.LayerSource = shapeLayer.Spec.LayerSource;
        r.ShapeSource.Type = this._getIntFromVEDataType(shapeLayer.Spec.Type);
        var hf = document.getElementById(this.get_id() + "_UP_ISLDHF");
        hf.value = Sys.Serialization.JavaScriptSerializer.serialize(r);
        this._triggerAsyncPostback("importshapelayerdataloaded");
    },
    _findLocationsCallback: function _findLocationsCallback(loc, places) {
        var args = new Simplovation.Web.Maps.VE.FindLocationsCallbackArgs();
        args.Location = loc;
        args.Places = places;
        var hf = document.getElementById(this.get_id() + "_UP_HiddenFLField");
        hf.value = Sys.Serialization.JavaScriptSerializer.serialize(args);
        this._triggerAsyncPostback("findlocationsloaded");
    },
    _doFindFromFindArgs: function _doFindFromFindArgs(findArgs) {
        var m = this;
        this.Find(findArgs.What, findArgs.Where, VEFindType.Businesses, null, //shapeLayer
        findArgs.StartIndex, findArgs.NumberOfResults, findArgs.ShowResults, findArgs.CreateResults, findArgs.UseDefaultDisambiguation, findArgs.SetBestMapView, function (layer, resultsArray, places, hasMore, veErrorMessage) {
            m._findCallback(layer, resultsArray, places, hasMore, veErrorMessage);
        });
    },
    _findCallback: function _findCallback(layer, resultsArray, places, hasMore, veErrorMessage) {
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
    _getIntFromFindType: function _getIntFromFindType(f) {
        if (f == VEFindType.Businesses) {
            return 0;
        }
        return f;
    },
    _raiseClientSideEvent: function _raiseClientSideEvent(evtName, e) {
        var h = this.get_events().getHandler(evtName);
        if (h) {
            h(this, e);
        }
    },
    addHandler: function addHandler(eventName, method) {
        this.get_events().addHandler(eventName, method);
    },
    removeHandler: function removeHandler(eventName, method) {
        this.get_events().removeHandler(eventName, method);
    },
    AddHandler: function AddHandler(e, m) {
        this.addHandler(e, m);
    },
    RemoveHandler: function RemoveHandler(e, m) {
        this.removeHandler(e, m);
    },
    AttachEvent: function AttachEvent(e, m) {
        this.addHandler(e, m);
    },
    DetachEvent: function DetachEvent(e, m) {
        this.removeHandler(e, m);
    },
    _convertShapeLayerToPostback: function _convertShapeLayerToPostback(layer) {
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
    _convertShapeToPostback: function _convertShapeToPostback(shape) {
        var appPathDomain = Simplovation.Web.Maps.VE.Utils.AppPathDomain;

        var mapShape;
        var myShape = new Simplovation.Web.Maps.VE.Shape();
        if (typeof shape != "string") {
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
        } else {
            //if(shapeType==VEShapeType.Polyline)
            myShape.Type = 1;
        }
        myShape.ZIndex = mapShape.GetZIndex();
        myShape.Tag = mapShape.SimplovationTag;
        return myShape;
    },
    //MapEvents
    _onChangeMapType: function _onChangeMapType(e) {
        if (this.get_OnChangeMapType_Handled()) {
            this._triggerAsyncPostback("maptypechanged", e);
        }
        this._raiseClientSideEvent("maptypechanged", e);
    },
    _onChangeView: function _onChangeView(e) {
        if (this.get_OnChangeView_Handled()) {
            this._triggerAsyncPostback("onchangeview", e);
        }
        this._raiseClientSideEvent("onchangeview", e);
    },
    _onEndZoom: function _onEndZoom(e) {
        if (this.get_OnEndZoom_Handled()) {
            this._triggerAsyncPostback("onendzoom", e);
        }
        this._raiseClientSideEvent("onendzoom", e);
    },
    _onError: function _onError(e) {
        this._triggerAsyncPostback("onerror", e);
        this._raiseClientSideEvent("onerror", e);
    },
    _onStartZoom: function _onStartZoom(e) {
        this._raiseClientSideEvent("onstartzoom", e);
    },
    //MouseEvents
    _click: function _click(e) {
        if (this.get_Click_Handled()) {
            this._triggerAsyncPostback("click", e);
        }
        this._raiseClientSideEvent("click", e);
    },
    _onDoubleClick: function _onDoubleClick(e) {
        this._raiseClientSideEvent("dblclick", e);
    },
    _onMouseDown: function _onMouseDown(e) {
        this._raiseClientSideEvent("mousedown", e);
    },
    _onMouseMove: function _onMouseMove(e) {
        this._raiseClientSideEvent("mousemove", e);
    },
    _onMouseOut: function _onMouseOut(e) {
        this._raiseClientSideEvent("mouseout", e);
    },
    _onMouseOver: function _onMouseOver(e) {
        this._raiseClientSideEvent("mouseover", e);
    },
    _onMouseUp: function _onMouseUp(e) {
        this._raiseClientSideEvent("mouseup", e);
    },
    _onMouseWheel: function _onMouseWheel(e) {
        this._raiseClientSideEvent("onmousewheel", e);
    },
    //KeyboardEvents
    _onKeyPress: function _onKeyPress(e) {
        this._raiseClientSideEvent("keypress", e);
    },
    _onKeyDown: function _onKeyDown(e) {
        this._raiseClientSideEvent("keydown", e);
    },
    _onKeyUp: function _onKeyUp(e) {
        this._raiseClientSideEvent("keyup", e);
    }
};
Simplovation.Web.Maps.VE.Map.registerClass("Simplovation.Web.Maps.VE.Map", Simplovation.Web.Maps.VE.AsyncScriptControl);

Simplovation.Web.Maps.VE.AsyncMapData = function () {
    this.EventName = null;this.EventArgs = null;this.Width = null;this.Height = null;
    this.ZoomLevel = null;this.Latitude = null;this.Longitude = null;this.MapType = null;
    this.Direction_Locations = null;this.Direction_RouteOptions = null;this.MapLoadedEventArgs = null;
    this.ImportShapeLayerData_shapeSource = null;this.ImportShapeLayerData_setBestView = false;
};
Simplovation.Web.Maps.VE.FindCallbackArgs = function () {
    this.Places = null;
    this.Results = null;
};
Simplovation.Web.Maps.VE.FindLocationsCallbackArgs = function () {
    this.Location = null;
    this.Places = null;
};
Simplovation.Web.Maps.VE.Shape = function () {
    this.ClientID = null;
    this.CustomIcon = null;
    this.Description = null;
    this.FillColor = null;
    this.IconAnchor = null;
    this.LineColor = null;
    this.LineWidth = 2;
    this.MoreInfoURL = null;
    this.PhotoURL = null;
    this.Points = null;
    this.Title = null;
    this.Type = 0;
    this.Altitude = 0;
    this.AltitudeMode = 0;
};
Simplovation.Web.Maps.VE.Pixel = function (x, y) {
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
Simplovation.Web.Maps.VE.ShapeLayer = function () {
    this.Title = null;
    this.Description = null;
    this.Shapes = null;
    this.Visible = true;
};
Simplovation.Web.Maps.VE.ImportShapeLayerDataEventArgs = function () {
    this.ShapeLayer = null;
    this.BestMapView = null;
    this.ShapeSource = null;
};
Simplovation.Web.Maps.VE.ShapeSourceSpecification = function () {
    this.LayerSource = null;
    this.Type = null;
};

Type.registerNamespace("Simplovation.Web.Maps.VE.Utils");
Simplovation.Web.Maps.VE.Utils.AppPathDomain = location.protocol + "//" + location.host;
Type.registerNamespace("Simplovation.Web.Maps.VE.Utils.UrlHelper");
Simplovation.Web.Maps.VE.Utils.UrlHelper.ToAbsolute = function (s, appRoot) {
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

    var r = function r(s, o, n) {
        var ns = s;
        while (ns.indexOf(o) != -1) {
            ns = ns.replace(o, n);
        }
        return ns;
    };

    newstr = r(newstr, "<", "\\u003c");
    newstr = r(newstr, ">", "\\u003e");
    newstr = r(newstr, "&", "\\u0026");
    return newstr;
}
Sys.Application.notifyScriptLoaded();

