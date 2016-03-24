/* ----------------------------------------------------------------------------------- */
/* Copyright (C) Simplovation LLC (http://Simplovation.com) 2016. All rights reserved. */
/* Licensing information available at http://webmapsve.codeplex.com                    */
/* ----------------------------------------------------------------------------------- */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Web;

[assembly: System.Web.UI.WebResource("Simplovation.Web.Maps.VE.Base.AsyncScriptControl.js", "text/javascript")]
[assembly: System.Web.UI.WebResource("Simplovation.Web.Maps.VE.Base.AsyncScriptControl.min.js", "text/javascript")]

namespace Simplovation.Web.Maps.VE.Base
{
    public abstract class AsyncScriptControl : Simplovation.Web.Maps.VE.Base.ScriptControl
    {
        protected abstract void LoadAsyncData(string asyncData);
        protected abstract string GetAsyncData();

        private UpdatePanel _InternalUpdatePanel = new UpdatePanel();

        public AsyncScriptControl()
        {
            this._InternalUpdatePanel.ID = "UP";
            this._InternalUpdatePanel.RenderMode = UpdatePanelRenderMode.Inline;
            this._InternalUpdatePanel.UpdateMode = UpdatePanelUpdateMode.Always;
        }

        /// <summary>
        /// Gets a reference to the UpdatePanel used internally to enable Asynchronous ScriptControl functionality.
        /// </summary>
        protected UpdatePanel InternalUpdatePanel
        {
            get { return this._InternalUpdatePanel; }
        }

        protected override IEnumerable<ScriptDescriptor> GetScriptDescriptors()
        {
            return base.GetScriptDescriptors();
        }

        protected override IEnumerable<ScriptReference> GetScriptReferences()
        {
            List<ScriptReference> references = new List<ScriptReference>();
            if (HttpContext.Current.IsDebuggingEnabled)
            {
                references.Add(new ScriptReference("Simplovation.Web.Maps.VE.Base.AsyncScriptControl.js", "Simplovation.Web.Maps.VE"));
            }
            else
            {
                references.Add(new ScriptReference("Simplovation.Web.Maps.VE.Base.AsyncScriptControl.min.js", "Simplovation.Web.Maps.VE"));
            }
            references.AddRange(base.GetScriptReferences());
            return references;
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            ScriptManager sm = ScriptManager.GetCurrent(Page);
            if (sm.IsInAsyncPostBack)
            {
                sm.RegisterDataItem(this, this.GetAsyncData());
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            ScriptManager sm = ScriptManager.GetCurrent(Page);
            if (sm.IsInAsyncPostBack)
            {
                string asyncData = null;
                HttpRequest r = HttpContext.Current.Request;
                foreach (string k in r.Form.Keys)
                {
                    if (k != null)
                    {
                        if (k.EndsWith(this.ID + "$UP_HiddenField"))
                        {
                            string props = Page.Request.Form[k];
                            if (props.Length > 0)
                            {
                                asyncData = props;
                            }
                        }
                    }
                }
                if (asyncData != null)
                {
                    this.LoadAsyncData(asyncData);
                }
            }
        }

        protected override void CreateChildControls()
        {
            UpdatePanel up = _InternalUpdatePanel;
            
            System.Web.UI.WebControls.HiddenField h = new System.Web.UI.WebControls.HiddenField();
            h.ID = up.ID + "_HiddenField";
            h.Value = string.Empty;
            up.ContentTemplateContainer.Controls.Add(h);

            System.Web.UI.WebControls.LinkButton lb = new System.Web.UI.WebControls.LinkButton();
            lb.ID = up.ID + "_LB"; // "_LinkButton";
            up.ContentTemplateContainer.Controls.Add(lb);

            this.Controls.Add(up);

            base.CreateChildControls();
        }
    }
}
