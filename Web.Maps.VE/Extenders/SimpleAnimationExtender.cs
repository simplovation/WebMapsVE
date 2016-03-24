/* ----------------------------------------------------------------------------------- */
/* Copyright (C) Simplovation LLC (http://Simplovation.com) 2014. All rights reserved. */
/* Licensing information available at http://webmapsve.codeplex.com                    */
/* ----------------------------------------------------------------------------------- */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Simplovation.Web.Maps.VE.Base;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;

[assembly: System.Web.UI.WebResource("Simplovation.Web.Maps.VE.Extenders.SimpleAnimationExtender.js", "text/javascript")]

namespace Simplovation.Web.Maps.VE.Extenders
{
    /// <summary>
    /// Adds the ability to automatically move the <see cref="Map">Map</see> through a series of <see cref="SimpleAnimationPoint">SimpleAnimationPoint</see> objects on timed interval.
    /// </summary>
    [Designer(typeof(TileLayerExtenderDesigner)),
    ClientScriptResource("Simplovation.Web.Maps.VE.Extenders.SimpleAnimationExtender.js", "Simplovation.Web.Maps.VE"),
    TargetControlType(typeof(Map)),
    ParseChildren(true), PersistChildren(false)]
    public class SimpleAnimationExtender : Simplovation.Web.Maps.VE.Base.ExtenderControl
    {
        private List<SimpleAnimationPoint> _Points = new List<SimpleAnimationPoint>();
        /// <summary>
        /// A List of <see cref="SimpleAnimationPoint">SimpleAnimationPoint</see> objects to animate through.
        /// </summary>
        [ExtenderControlProperty,
        PersistenceMode(PersistenceMode.InnerProperty)]
        public List<SimpleAnimationPoint> Points
        {
            get
            {
                return this._Points;
            }
            set
            {
                this._Points = value;
            }
        }

        /// <summary>
        /// The ID of the Control that will move the animation to the next point with its OnClientClick event
        /// </summary>
        [ExtenderControlProperty, IDReferenceProperty(typeof(Control))]
        public string NextControlID { get; set; }

        /// <summary>
        /// The ID of the Control that will move the animation to the previous point with its OnClientClick event
        /// </summary>
        [ExtenderControlProperty, IDReferenceProperty(typeof(Control))]
        public string PreviousControlID { get; set; }

        /// <summary>
        /// The ID of the Control that will move the animation to the first point with its OnClientClick event
        /// </summary>
        [ExtenderControlProperty, IDReferenceProperty(typeof(Control))]
        public string FirstControlID { get; set; }

        /// <summary>
        /// The ID of the Control that will move the animation to the last point with its OnClientClick event
        /// </summary>
        [ExtenderControlProperty, IDReferenceProperty(typeof(Control))]
        public string LastControlID { get; set; }

        /// <summary>
        /// The ID of the Control that will Start the animation with its OnClientClick event
        /// </summary>
        [ExtenderControlProperty, IDReferenceProperty(typeof(Control))]
        public string PlayControlID { get; set; }

        /// <summary>
        /// The ID of the Control that will Stop the animation with its OnClientClick event
        /// </summary>
        [ExtenderControlProperty, IDReferenceProperty(typeof(Control))]
        public string StopControlID { get; set; }

        /// <summary>
        /// The ID of the Control that will display the Title of the current SimpleAnimationPoint point being displayed
        /// </summary>
        [ExtenderControlProperty, IDReferenceProperty(typeof(Control))]
        public string TitleControlID { get; set; }

        /// <summary>
        /// The ID of the Control that will display the Description of the current SimpleAnimationPoint point being displayed
        /// </summary>
        [ExtenderControlProperty, IDReferenceProperty(typeof(Control))]
        public string DescriptionControlID { get; set; }

        /// <summary>
        /// A boolean value that determines if the Animation should automatically start when the page loads. Default is False.
        /// </summary>
        [ExtenderControlProperty]
        public bool AutoPlay { get; set; }

        protected override void OnPreRender(EventArgs e)
        {
            RemoveButtonPostBack(this.NextControlID);
            RemoveButtonPostBack(this.PreviousControlID);
            RemoveButtonPostBack(this.FirstControlID);
            RemoveButtonPostBack(this.LastControlID);
            RemoveButtonPostBack(this.PlayControlID);
            RemoveButtonPostBack(this.StopControlID);

            this.NextControlID = this.Parent.FindControl(this.NextControlID).ClientID;
            this.PreviousControlID = this.Parent.FindControl(this.PreviousControlID).ClientID;
            this.FirstControlID = this.Parent.FindControl(this.FirstControlID).ClientID;
            this.LastControlID = this.Parent.FindControl(this.LastControlID).ClientID;
            this.PlayControlID = this.Parent.FindControl(this.PlayControlID).ClientID;
            this.StopControlID = this.Parent.FindControl(this.StopControlID).ClientID;

            this.TitleControlID = this.Parent.FindControl(this.TitleControlID).ClientID;
            this.DescriptionControlID = this.Parent.FindControl(this.DescriptionControlID).ClientID;

            base.OnPreRender(e);
        }

        private void RemoveButtonPostBack(string buttonID)
        {
            if (!string.IsNullOrEmpty(buttonID))
            {
                var ctrl = this.Parent.FindControl(buttonID);
                if (ctrl is Button)
                {
                    var btn = ctrl as Button;
                    btn.UseSubmitBehavior = false;
                    btn.OnClientClick = "return true;";
                }
                else if (ctrl is LinkButton)
                {
                    var btn = ctrl as LinkButton;
                    btn.OnClientClick = "return true;";
                }
            }
        }
    }
}
