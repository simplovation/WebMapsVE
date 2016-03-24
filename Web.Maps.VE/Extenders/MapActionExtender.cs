/* ----------------------------------------------------------------------------------- */
/* Copyright (C) Simplovation LLC (http://Simplovation.com) 2016. All rights reserved. */
/* Licensing information available at http://webmapsve.codeplex.com                    */
/* ----------------------------------------------------------------------------------- */
using System;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;
using Simplovation.Web.Maps.VE.Base;

[assembly: System.Web.UI.WebResource("Simplovation.Web.Maps.VE.Extenders.MapActionExtender.js", "text/javascript")]

namespace Simplovation.Web.Maps.VE.Extenders
{
    /// <summary>
    /// An extender control that allows you to easily attach a specific client-side event (usually Click event) of a Control to perform a specific <see cref="MapAction">MapAction</see> to manipulate the <see cref="Map">Map</see>.
    /// </summary>
    [Designer(typeof(MapActionExtenderDesigner))]
    [ClientScriptResource("Simplovation.Web.Maps.VE.Extenders.MapActionExtender.js", "Simplovation.Web.Maps.VE")]
    [TargetControlType(typeof(Control))]
    public class MapActionExtender : Simplovation.Web.Maps.VE.Base.ExtenderControl
    {
        /// <summary>
        /// The ID of the <see cref="Map">Map</see> control to attach to.
        /// </summary>
        [ExtenderControlComponentProperty("MapControl"),
        DefaultValue(""),
        IDReferenceProperty(typeof(Simplovation.Web.Maps.VE.Map))]
        public string MapControlID { get; set; }


        private MapAction _MapAction = MapAction.ZoomIn;
        /// <summary>
        /// The specific <see cref="MapAction">MapAction</see> to manipulate the <see cref="Map">Map</see> with.
        /// </summary>
        [ExtenderControlProperty,
        DefaultValue(MapAction.ZoomIn)]
        public MapAction MapAction
        {
            get
            {
                //return GetPropertyValue("MapAction", MapAction.ZoomIn);
                return this._MapAction;
            }
            set
            {
                //SetPropertyValue("MapAction", value);
                this._MapAction = value;
            }
        }

        private string _EventName = "click";
        /// <summary>
        /// The client-side event that will trigger the <see cref="MapAction">MapAction</see> to be triggered. Default is the "click" event.
        /// </summary>
        [ExtenderControlProperty,
        DefaultValue("click")]
        public string EventName
        {
            get
            {
                //return GetPropertyValue("EventName", "click");
                return this._EventName;
            }
            set
            {
                //SetPropertyValue("EventName", value);
                this._EventName = value;
            }
        }

        /// <summary>
        /// A Value that is used by the specified <see cref="MapAction">MapAction</see>.
        /// </summary>
        /// <remarks>
        /// For example, when Panning the <see cref="Map">Map</see> using the MapAction.PanUp action, you can set the Value to 50 to Pan the Map Up by 50 pixels.
        /// </remarks>
        [ExtenderControlProperty]
        public string Value { get; set; }

        protected override void OnPreRender(EventArgs e)
        {
            if (this.TargetControl.GetType() == typeof(Button))
            {
                Button btn = this.TargetControl as Button;
                if (btn != null)
                {
                    btn.UseSubmitBehavior = false;
                    btn.OnClientClick = "return true;";
                }
            }
            else if (this.TargetControl is LinkButton)
            {
                LinkButton lbtn = this.TargetControl as LinkButton;
                if (lbtn != null)
                {
                    lbtn.OnClientClick = "return true;";
                }
            }

            base.OnPreRender(e);
        }

    }
}
