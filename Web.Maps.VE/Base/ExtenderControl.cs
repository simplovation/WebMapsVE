/* ----------------------------------------------------------------------------------- */
/* Copyright (C) Simplovation LLC (http://Simplovation.com) 2014. All rights reserved. */
/* Licensing information available at http://webmapsve.codeplex.com                    */
/* ----------------------------------------------------------------------------------- */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.ComponentModel;

namespace Simplovation.Web.Maps.VE.Base
{
    public class ExtenderControl : System.Web.UI.ExtenderControl
    {
        protected override IEnumerable<System.Web.UI.ScriptDescriptor> GetScriptDescriptors(System.Web.UI.Control targetControl)
        {
            ScriptBehaviorDescriptor descriptor = new ScriptBehaviorDescriptor(this.GetType().FullName, targetControl.ClientID);

            // Make sure this ExtenderControl's ID is pushed down to the client so we can get ahold of it from within JavaScript using $find
            descriptor.AddProperty("id", this.ClientID);

            PropertyDescriptorCollection props = TypeDescriptor.GetProperties(this);
            foreach (PropertyDescriptor prop in props)
            {
                ExtenderControlPropertyAttribute propAttr = prop.Attributes[typeof(ExtenderControlPropertyAttribute)] as ExtenderControlPropertyAttribute;
                if (propAttr != null)
                {
                    object value = prop.GetValue(this);
                    string name = propAttr.Name ?? prop.Name;
                    if (value != null)
                    {
                        descriptor.AddProperty(name, value);
                    }
                }

                ExtenderControlComponentPropertyAttribute compAttr = prop.Attributes[typeof(ExtenderControlComponentPropertyAttribute)] as ExtenderControlComponentPropertyAttribute;
                if (compAttr != null)
                {
                    string name = compAttr.Name ?? prop.Name;
                    
                    string controlId = prop.GetValue(this) as string;

                    Control ctrl = this.ResolveControlByID(controlId);
                    if (ctrl != null)
                    {
                        controlId = ctrl.ClientID;
                    }
                                        
                    if (!string.IsNullOrEmpty(controlId))
                    {
                        descriptor.AddComponentProperty(name, controlId);
                    }
                }

                ExtenderControlEventAttribute eventAttr = prop.Attributes[typeof(ExtenderControlEventAttribute)] as ExtenderControlEventAttribute;
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

        protected override IEnumerable<System.Web.UI.ScriptReference> GetScriptReferences()
        {
            object[] scriptReferences = Attribute.GetCustomAttributes(this.GetType(), typeof(ClientScriptResourceAttribute), false);
            foreach (ClientScriptResourceAttribute r in scriptReferences)
            {
                yield return r.GetScriptReference();
            }
        }

        private Control _targetControl = null;
        protected Control TargetControl
        {
            get
            {
                Control ctrl = null;

                if (this._targetControl != null)
                {
                    ctrl = this._targetControl;
                }
                else
                {
                    ctrl = this.ResolveControlByID(this.TargetControlID);
                    this._targetControl = ctrl;
                }
                return ctrl;                
            }
        }

        protected Control ResolveControlByID(string controlId)
        {
            Control ctrl = base.FindControl(controlId);
            Control namingContainer = this.NamingContainer;
            while (ctrl == null && namingContainer != null)
            {
                ctrl = namingContainer.FindControl(controlId);
                namingContainer = namingContainer.NamingContainer;
            }
            return ctrl;
        }
    }
}
