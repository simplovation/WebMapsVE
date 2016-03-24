/* ----------------------------------------------------------------------------------- */
/* Copyright (C) Simplovation LLC (http://Simplovation.com) 2016. All rights reserved. */
/* Licensing information available at http://webmapsve.codeplex.com                    */
/* ----------------------------------------------------------------------------------- */
using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using System.ComponentModel;

namespace Simplovation.Web.Maps.VE.Base
{
    public abstract class ScriptControl : System.Web.UI.ScriptControl, INamingContainer
    {
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            
            ScriptManager sm = ScriptManager.GetCurrent(this.Page);
            if (sm == null)
            {
                throw new InvalidOperationException("The control with ID '" + this.ID + "' requires a ScriptManager on the page. The ScriptManager must appear before any controls that need it.");
            }
        }

        protected override IEnumerable<ScriptDescriptor> GetScriptDescriptors()
        {
            ScriptControlDescriptor descriptor = new ScriptControlDescriptor(this.GetType().FullName, this.ClientID);

            // Add all the ScriptControls Client-Side Object Properties
            //// help -> reference the ScriptObjectBuilder object in the AjaxControlToolkit
            PropertyDescriptorCollection props = TypeDescriptor.GetProperties(this);
            foreach (PropertyDescriptor prop in props)
            {
                ScriptControlPropertyAttribute propAttr = prop.Attributes[typeof(ScriptControlPropertyAttribute)] as ScriptControlPropertyAttribute;
                if (propAttr != null)
                {
                    object value = prop.GetValue(this);
                    string name = (propAttr.Name != null) ? propAttr.Name : prop.Name;
                    if (value != null)
                    {
                        descriptor.AddProperty(name, value);
                    }
                }

                ScriptControlEventAttribute eventAttr = prop.Attributes[typeof(ScriptControlEventAttribute)] as ScriptControlEventAttribute;
                if (eventAttr != null)
                {
                    string name = eventAttr.Name ?? prop.Name;
                    string handler = prop.GetValue(this) as string;
                    if (handler != null)
                    {
                        descriptor.AddEvent(name, handler);
                    }
                }
            }

            yield return descriptor;
        }

        protected override IEnumerable<ScriptReference> GetScriptReferences()
        {
            object[] scriptReferences = Attribute.GetCustomAttributes(this.GetType(), typeof(ClientScriptResourceAttribute), false);
            foreach (ClientScriptResourceAttribute r in scriptReferences)
            {
                yield return r.GetScriptReference();
            }
        }
    }
}
