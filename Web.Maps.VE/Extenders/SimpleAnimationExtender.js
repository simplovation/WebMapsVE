/* ----------------------------------------------------------------------------------- */
/* Copyright (C) Simplovation LLC (http://Simplovation.com) 2016. All rights reserved. */
/* Licensing information available at http://webmapsve.codeplex.com                    */
/* ----------------------------------------------------------------------------------- */
/*SimpleAnimationExtender.js*/
Type.registerNamespace("Simplovation.Web.Maps.VE.Extenders");
Simplovation.Web.Maps.VE.Extenders.SimpleAnimationExtender=function(element){
    Simplovation.Web.Maps.VE.Extenders.SimpleAnimationExtender.initializeBase(this, [element]);
    this.map=null;
    this._Points=null;
    this._currentPointIndex=-1;
    this._nextControlID=null;this._previousControlID=null;this._firstControlID=null;this._lastControlID=null;
    this._playControlID=null;this._stopControlID=null;
    this._timerReference=null;
    this._isPlaying=true;
    this._titleControlID=null;
    this._descriptionControlID=null;
};
Simplovation.Web.Maps.VE.Extenders.SimpleAnimationExtender.prototype={
    initialize:function(){
        Simplovation.Web.Maps.VE.Extenders.SimpleAnimationExtender.callBaseMethod(this,"initialize");
        this.map=$find(this.get_element().id);
        if(this._nextControlID!=null){this._attachClickHandler(this._nextControlID,Function.createDelegate(this,this._nextButton));}
        if(this._previousControlID!=null){this._attachClickHandler(this._previousControlID,Function.createDelegate(this,this._prevButton));}
        if(this._firstControlID!=null){this._attachClickHandler(this._firstControlID,Function.createDelegate(this,this._firstButton));}
        if(this._lastControlID!=null){this._attachClickHandler(this._lastControlID,Function.createDelegate(this,this._lastButton));}
        if(this._playControlID!=null){this._attachClickHandler(this._playControlID,Function.createDelegate(this,this._play));}
        if(this._stopControlID!=null){this._attachClickHandler(this._stopControlID,Function.createDelegate(this,this._stop));}
        this.First();
    },
    dispose:function(){Simplovation.Web.Maps.VE.Extenders.SimpleAnimationExtender.callBaseMethod(this,"dispose");},
    _attachClickHandler:function(controlId, handler){
        if (controlId!=null){
            var elem=$find(controlId);
            if(elem==null){elem=$get(controlId);}
            if(elem!=null){$addHandler(elem,"click",handler);elem.href="javascript:return void(0);";}
        }
    },
    _play:function(){this.Play();return false;},
    _stop:function(){this.Stop();return false;},
    _nextButton:function(){this.Next();return false;},
    _prevButton:function(){this.Previous();return false;},
    _firstButton:function(){this.First();return false;},
    _lastButton:function(){this.Last();return false;},
    GoTo:function(index){
        this._currentPointIndex=index;
        if (this._currentPointIndex>=this._Points.length){this._currentPointIndex=0;}
        if (this._currentPointIndex<0){this._currentPointIndex=this._Points.length-1;}
        var point=this._Points[this._currentPointIndex];
        var latlong=this.map._getVELatLong(point.LatLong);
        if (this.map.GetZoomLevel()==point.ZoomLevel)
        {
            this.map.SetCenter(latlong);
        }
        else
        {
            this.map.SetCenterAndZoom(latlong,point.ZoomLevel);
        }
        if(this._titleControlID!=null)
        {
            var title=$find(this._titleControlID);
            if(title==null){title=$get(this._titleControlID);}
            if(title!=null){
                title.innerHTML=point.Title;
            }
        }
        if(this._descriptionControlID!=null)
        {
            var desc=$find(this._descriptionControlID);
            if(desc==null){desc=$get(this._descriptionControlID);}
            if(desc!=null){
                desc.innerHTML=point.Description;
            }
        }        
        if(this._timerReference!=null){
            window.clearTimeout(this._timerReference);
        }
        if(this._isPlaying==true){
            this._timerReference=window.setTimeout("$find('"+this.get_id()+"').Next()",point.Duration);
        }
    },
    IsPlaying:function(){return this._isPlaying;},
    Play:function(){if(this._isPlaying!=true){this._isPlaying=true;this.Next();}},
    Stop:function(){if(this._isPlaying==true){this._isPlaying=false;if(this._timerReference!=null){window.clearTimeout(this._timerReference);}}},
    First:function(){this.GoTo(0);},
    Last:function(){this.GoTo(this._Points.length-1);},
    Next:function(){this.GoTo(this._currentPointIndex+1);},
    Previous:function(){this.GoTo(this._currentPointIndex-1);},
    GetCurrentPointTitle:function(){return this._Points[this._currentPointIndex].Title;},
    GetCurrentPointDescription:function(){return this._Points[this._currentPointIndex].Description;},
    get_Points:function(){return this._Points;},set_Points:function(v){this._Points=v;this.raisePropertyChanged("Points");},
    get_NextControlID:function(){return this._nextControlID;},set_NextControlID:function(v){this._nextControlID=v;this.raisePropertyChanged("NextControlID");},
    get_PreviousControlID:function(){return this._previousControlID;},set_PreviousControlID:function(v){this._previousControlID=v;this.raisePropertyChanged("PreviousControlID");},
    get_FirstControlID:function(){return this._firstControlID;},set_FirstControlID:function(v){this._firstControlID=v;this.raisePropertyChanged("FirstControlID");},
    get_LastControlID:function(){return this._lastControlID;},set_LastControlID:function(v){this._lastControlID=v;this.raisePropertyChanged("LastControlID");},
    get_PlayControlID:function(){return this._playControlID;},set_PlayControlID:function(v){this._playControlID=v;this.raisePropertyChanged("PlayControlID");},
    get_StopControlID:function(){return this._stopControlID;},set_StopControlID:function(v){this._stopControlID=v;this.raisePropertyChanged("StopControlID");},
    get_AutoPlay:function(){return this._isPlaying;},set_AutoPlay:function(v){this._isPlaying=v;this.raisePropertyChanged("AutoPlay");},
    get_TitleControlID:function(){return this._titleControlID;},set_TitleControlID:function(v){this._titleControlID=v;this.raisePropertyChanged("TitleControlID");},
    get_DescriptionControlID:function(){return this._descriptionControlID;},set_DescriptionControlID:function(v){this._descriptionControlID=v;this.raisePropertyChanged("DescriptionControlID");}
};
Simplovation.Web.Maps.VE.Extenders.SimpleAnimationExtender.registerClass("Simplovation.Web.Maps.VE.Extenders.SimpleAnimationExtender",Sys.UI.Behavior);
Sys.Application.notifyScriptLoaded();