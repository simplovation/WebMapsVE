/*-----------------------------------------------------------------------------------*/
/*Copyright (C) Simplovation LLC (http://Simplovation.com) 2014. All rights reserved.*/
/* Licensing information available at http://webmapsve.codeplex.com                  */
/*-----------------------------------------------------------------------------------*/
/*AsyncScriptControl.js*/
Type.registerNamespace("Simplovation.Web.Maps.VE");
Simplovation.Web.Maps.VE.AsyncScriptControl=function(element){Simplovation.Web.Maps.VE.AsyncScriptControl.initializeBase(this,[element]);this._hiddenFieldAlreadySet=false;this._lastPageLoadDataItem=null;this._pageLoadingHandler$delegate=Function.createDelegate(this,this._pageLoadingHandler);this._pageBeginRequestHandler$delegate=Function.createDelegate(this,this._pageBeginRequestHandler);};
Simplovation.Web.Maps.VE.AsyncScriptControl.prototype = {
    initialize: function() { Simplovation.Web.Maps.VE.AsyncScriptControl.callBaseMethod(this, "initialize"); Sys.WebForms.PageRequestManager.getInstance().add_pageLoading(this._pageLoadingHandler$delegate); Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(this._pageBeginRequestHandler$delegate); },
    dispose: function() { if (typeof (Sys.WebForms) !== "undefined" && typeof (Sys.WebForms.PageRequestManager) !== "undefined") { Sys.WebForms.PageRequestManager.getInstance().remove_pageLoading(this._pageLoadingHandler$delegate); Sys.WebForms.PageRequestManager.getInstance().remove_beginRequest(this._pageBeginRequestHandler$delegate); } Simplovation.Web.Maps.VE.AsyncScriptControl.callBaseMethod(this, "dispose"); },
    _triggerAsyncPostback: function() {
        var data = this._setHiddenFieldMapData(arguments);
        this._hiddenFieldAlreadySet = true;
        if (data != null) {
            //TriggerPostback
            var lb = document.getElementById(this.get_id() + "_UP_LB");
            var s = lb.href.substring(lb.href.indexOf(":") + 1);
            eval(s);
        } 
    },
    _pageLoadingHandler: function(sender, args) { var dataItems = args.get_dataItems(); document.getElementById(this.get_id() + "_UP_HiddenField").value = ""; if (this._lastPageLoadDataItem != dataItems[this.get_id()]) { var data = dataItems[this.get_id()]; this.LoadAsyncEventData(data); this._lastPageLoadDataItem = data; } },
    _pageBeginRequestHandler: function(sender, args) {
        if (!this._hiddenFieldAlreadySet) {
            this._setHiddenFieldMapData("");
            //AddMapDataToRequest
            var hiddenField = document.getElementById(this.get_id() + '_UP_HiddenField');
            var hiddenFieldPostbackName = hiddenField.name;
            while (hiddenFieldPostbackName.indexOf("$") > -1) {
                hiddenFieldPostbackName = hiddenFieldPostbackName.replace("$", "%24");
            }
            var newHiddenFieldPostbackValue = hiddenFieldPostbackName + '=' + hiddenField.value;
            var items = args.get_request().get_body().split("&");
            var newBody = "";
            var hiddenFieldAlreadyIncluded = false;

            var l = items.length;
            for (var i = 0; i < l; i++) {
                if (newBody.length != 0) {
                    newBody += "&";
                }
                if (items[i].substring(0, hiddenFieldPostbackName.length) == hiddenFieldPostbackName && !hiddenFieldAlreadyIncluded) {
                    newBody += newHiddenFieldPostbackValue; hiddenFieldAlreadyIncluded = true;
                } else {
                    newBody += items[i];
                }
            }
            args.get_request().set_body(newBody);
        }
        this._hiddenFieldAlreadySet = false;
    },
    _setHiddenFieldMapData: function(args) {
        var hf = document.getElementById(this.get_id() + '_UP_HiddenField');
        var data = this.GetAsyncEventData(args);
        hf.value = data;
        return data; 
    },
    GetAsyncEventData: function(args) {
        return null; 
    },
    LoadAsyncEventData: function(args) {
        return null; 
    }
};
Simplovation.Web.Maps.VE.AsyncScriptControl.registerClass("Simplovation.Web.Maps.VE.AsyncScriptControl", Sys.UI.Control);
if (typeof (Sys) !== "undefined") {
    Sys.Application.notifyScriptLoaded();
}