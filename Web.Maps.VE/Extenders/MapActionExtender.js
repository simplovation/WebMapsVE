/* ----------------------------------------------------------------------------------- */
/* Copyright (C) Simplovation LLC (http://Simplovation.com) 2016. All rights reserved. */
/* Licensing information available at http://webmapsve.codeplex.com                    */
/* ----------------------------------------------------------------------------------- */
/*MapActionExtender.js - Simplovation.Web.Maps.VE.Extenders*/
Type.registerNamespace("Simplovation.Web.Maps.VE.Extenders");
Simplovation.Web.Maps.VE.Extenders.MapActionExtender=function(element){Simplovation.Web.Maps.VE.Extenders.MapActionExtender.initializeBase(this,[element]);this._MapControl=null;this._MapAction=Simplovation.Web.Maps.VE.MapAction.ZoomIn;this._EventName="click";this._Value=null;this._actionHandler=null;this._GenerateAsyncPostback=false;};
Simplovation.Web.Maps.VE.Extenders.MapActionExtender.prototype={
    initialize:function(){Simplovation.Web.Maps.VE.Extenders.MapActionExtender.callBaseMethod(this,'initialize');if(this._MapControl){this._actionHandler=Function.createDelegate(this,this._onEvent);$addHandler(this.get_element(),this._EventName,this._actionHandler);this.get_element().href="javascript:return void(0);";}},
    dispose:function(){$removeHandler(this.get_element(),this._EventName,this._actionHandler);Simplovation.Web.Maps.VE.Extenders.MapActionExtender.callBaseMethod(this,'dispose');},
    get_MapControl:function(){return this._MapControl;},set_MapControl:function(v){this._MapControl=v;},
    get_MapAction:function(){return this._MapAction;},set_MapAction:function(v){this._MapAction=v;},
    get_EventName:function(){return this._EventName;},set_EventName:function(v){this._EventName=v;},
    get_Value:function(){return this._Value;},set_Value:function(v){this._Value=v;},
    get_GenerateAsyncPostback:function(){return this._GenerateAsyncPostback;},set_GenerateAsyncPostback:function(v){this._GenerateAsyncPostback=v;},
    _onEvent:function(e){
        var map=this.get_MapControl();
        switch(this._MapAction){
            case Simplovation.Web.Maps.VE.MapAction.ZoomIn:
                map.ZoomIn();
                break;
            case Simplovation.Web.Maps.VE.MapAction.ZoomOut:
                map.ZoomOut();
                break;
            case Simplovation.Web.Maps.VE.MapAction.SetMapStyleRoad:
                map.SetMapStyle(VEMapStyle.Road);
                break;
            case Simplovation.Web.Maps.VE.MapAction.SetMapStyleAerial:
                map.SetMapStyle(VEMapStyle.Aerial);
                break;
            case Simplovation.Web.Maps.VE.MapAction.SetMapStyleHybrid:
                map.SetMapStyle(VEMapStyle.Hybrid);
                break;
            case Simplovation.Web.Maps.VE.MapAction.SetMapStyleBirdseye:
                map.SetMapStyle(VEMapStyle.Birdseye);
                break;
            case Simplovation.Web.Maps.VE.MapAction.SetMapStyleShaded:
                map.SetMapStyle(VEMapStyle.Shaded);
                break;
            case Simplovation.Web.Maps.VE.MapAction.SetMapMode2D:
                map.SetMapMode(VEMapMode.Mode2D);
                break;
            case Simplovation.Web.Maps.VE.MapAction.SetMapMode3D:
                map.SetMapMode(VEMapMode.Mode3D);
                break;
            case Simplovation.Web.Maps.VE.MapAction.ClearAllShapes:
                map.DeleteAllShapes();
                break;
            case Simplovation.Web.Maps.VE.MapAction.ShowTraffic:
                map.LoadTraffic(true);
                break;
            case Simplovation.Web.Maps.VE.MapAction.ClearTraffic:
                map.ClearTraffic();
                break;
            case Simplovation.Web.Maps.VE.MapAction.ShowTrafficLegend:
                map.ShowTrafficLegend();
                break;
            case Simplovation.Web.Maps.VE.MapAction.HideTrafficLegend:
                map.HideTrafficLegend();
                break;
            case Simplovation.Web.Maps.VE.MapAction.PanLeft:
                var x=0-this.ParseInt(this.get_Value(),50);
                map.Pan(x,0);
                break;
            case Simplovation.Web.Maps.VE.MapAction.PanRight:
                var x=this.ParseInt(this.get_Value(),50);
                map.Pan(x,0);
                break;
            case Simplovation.Web.Maps.VE.MapAction.PanDown:
                var y=this.ParseInt(this.get_Value(),50);
                map.Pan(0,y);
                break;
            case Simplovation.Web.Maps.VE.MapAction.PanUp:
                var y=0-this.ParseInt(this.get_Value(),50);
                map.Pan(0,y);
                break;
        }
        if(this.get_GenerateAsyncPostback()){map._triggerPostback("",null,null);}
        return false;
    },
    ParseInt:function(s,d){var r=d;if(s!=null){if(s.length>0){if(!isNaN(s)){r=parseInt(s);}}}return r;}
};
Simplovation.Web.Maps.VE.Extenders.MapActionExtender.registerClass("Simplovation.Web.Maps.VE.Extenders.MapActionExtender",Sys.UI.Behavior);
Simplovation.Web.Maps.VE.MapAction=function(){throw Error.invalidOperation();};
Simplovation.Web.Maps.VE.MapAction.prototype={ZoomIn:0,ZoomOut:1,ShowDashboard:2,HideDashboard:3,SetMapStyleRoad:4,SetMapStyleAerial:5,SetMapStyleHybrid:6,SetMapStyleBirdseye:7,SetMapMode2D:9,SetMapMode3D: 10,ClearAllShapes:11,ShowTraffic:12,ClearTraffic:13,ShowTrafficLegend:14,HideTrafficLegend:15,SetMapStyleShaded:16,PanUp:17,PanDown:18,PanLeft:19,PanRight:20};
Simplovation.Web.Maps.VE.MapAction.registerEnum("Simplovation.Web.Maps.VE.MapAction");
Sys.Application.notifyScriptLoaded();