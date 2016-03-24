/* ----------------------------------------------------------------------------------- */
/* Copyright (C) Simplovation LLC (http://Simplovation.com) 2016. All rights reserved. */
/* Licensing information available at http://webmapsve.codeplex.com                    */
/* ----------------------------------------------------------------------------------- */
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Simplovation.Web.Maps.VE.Util
{
    internal class ControlHelper
    {
        public static Map FindTargetMap(Control ctrl, string TargetMapID, string TargetContentPlaceHolderID)
        {
            if (TargetMapID == null)
                throw new ArgumentNullException("The TargetMapID property must be set.");

            Map map = null;

            if (TargetContentPlaceHolderID == null)
                map = ControlHelper.CustomFindControlInParent(ctrl, TargetMapID) as Map;
            else
            {
                // Search within specific ContentPlaceHolder
                ContentPlaceHolder cph = ctrl.Page.Master.FindControl(TargetContentPlaceHolderID) as ContentPlaceHolder;
                if (cph == null)
                    throw new ArgumentNullException("ContentPlaceHolder with the ID '{0}' not found within Master page", TargetContentPlaceHolderID);

                map = cph.FindControl(TargetMapID) as Map;
            }

            return map;
        }

        public static Control CustomFindControlInParent(Control parentControl, string controlId)
        {
            Control ctrl = parentControl.FindControl(controlId);

            if (ctrl == null && parentControl.Parent != null)
            {
                ctrl = ControlHelper.CustomFindControlInParent(parentControl.Parent, controlId);
            }

            return ctrl;
        }
    }
}
