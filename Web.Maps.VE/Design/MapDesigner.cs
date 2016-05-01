/* ----------------------------------------------------------------------------------- */
/* Copyright (C) Simplovation LLC (http://Simplovation.com) 2016. All rights reserved. */
/* Licensing information available at http://webmapsve.codeplex.com                    */
/* ----------------------------------------------------------------------------------- */
using System;
using System.Web.UI.Design;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics;

namespace Simplovation.Web.Maps.VE.Design
{
    [System.Security.SecurityCritical]
    public class MapDesigner : ControlDesigner
    {
        [System.Security.SecurityCritical]
        public override string GetDesignTimeHtml()
        {
            Map myMap = this.Component as Map;
            return string.Format("<table width='{0}' height='{1}' cellspacing='0' cellpadding='0' style='border:1px solid #000000;'><tr><td>[<b>Map</b> - {2}]</td></tr></table>", 
                myMap.Width, myMap.Height, this.ID);
        }

        public override bool AllowResize {
            [System.Security.SecurityCritical]
            get { return true; }
        }

        private DesignerActionListCollection _ActionList = null;

        public override DesignerActionListCollection ActionLists
        {
            [System.Security.SecurityCritical]
            get
            {
                if (_ActionList == null)
                {
                    _ActionList = base.ActionLists;
                    _ActionList.Add(new MapDesignerActionList((Map)Component));
                }
                return _ActionList;
            }
        }
    }

    public class MapDesignerActionList : DesignerActionList
    {
        private Map _map = null;

        public MapDesignerActionList(Map map)
            : base(map)
        {
            _map = map;
            this.AutoShow = true;
        }

        public override DesignerActionItemCollection GetSortedActionItems()
        {
            DesignerActionItemCollection items = new DesignerActionItemCollection(); // base.GetSortedActionItems();

            items.Add(new DesignerActionHeaderItem("Location", "location"));
            items.Add(new DesignerActionPropertyItem("Latitude", "Latitude:", "location"));
            items.Add(new DesignerActionPropertyItem("Longitude", "Longitude:", "location"));
            items.Add(new DesignerActionPropertyItem("Zoom", "Zoom Level:", "location"));

            items.Add(new DesignerActionHeaderItem("Other", "other"));
            items.Add(new DesignerActionPropertyItem("DashboardSize", "Dashboard Size:", "other", "The maps dashboard size and type."));
            items.Add(new DesignerActionPropertyItem("MapMode", "Mode:", "other", "Specifies whether to load the map in 2D or 3D mode."));
            items.Add(new DesignerActionPropertyItem("ShowSwitch", "Show Map Mode Switch", "other", "Specifies whether to show the map mode switch on the dashboard control."));
            items.Add(new DesignerActionPropertyItem("Fixed", "Fixed Map", "other", "Specifies whether the map view is displayed as a fixed map that the user cannot change."));

            items.Add(new DesignerActionHeaderItem("", "information"));
            items.Add(new DesignerActionTextItem("Copyright (c) 2009 Simplovation LLC", "information"));
            items.Add(new DesignerActionMethodItem(this, "About", "About Web.Maps.VE...", "information", "A message about the Web.Maps.VE.Map control.", true));

            return items;
        }

        private PropertyDescriptor GetPropertyByName(string name)
        {
            PropertyDescriptor pd = TypeDescriptor.GetProperties(_map)[name];

            if (null == pd)
                throw new ArgumentException("Property '" + name + "' not found on " + _map.GetType().Name);

            return pd;
        }

        public double Latitude
        {
            get { return _map.Latitude; }
            set { GetPropertyByName("Latitude").SetValue(_map, value); }
        }

        public double Longitude
        {
            get { return _map.Longitude; }
            set { GetPropertyByName("Longitude").SetValue(_map, value); }
        }

        public double Zoom
        {
            get { return _map.Zoom; }
            set
            {
                int i;
                if (int.TryParse(value.ToString(), out i))
                    GetPropertyByName("Zoom").SetValue(_map, i);
                else
                    GetPropertyByName("Zoom").SetValue(_map, value);
            }
        }

        public bool Fixed
        {
            get { return _map.Fixed; }
            set { GetPropertyByName("Fixed").SetValue(_map, value); }
        }
       
        public DashboardSize DashboardSize
        {
            get { return _map.DashboardSize; }
            set
            {
                try
                {
                    GetPropertyByName("DashboardSize").SetValue(_map, value);
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Source + "\n" + ex.Message + "\n\n" + ex.StackTrace);
                }
            }
        }

        public bool ShowSwitch
        {
            get { return _map.ShowSwitch; }
            set { GetPropertyByName("ShowSwitch").SetValue(_map, value); }
        }

        public void About()
        {
            try
            {
                Process.Start("http://simplovation.com/Page/WebMapsVE.aspx");
            }
            catch (Exception)
            {
                System.Windows.Forms.MessageBox.Show("Simplovation.Web.Maps.VE v1.0\nCopyright (c) 2007 Simplovation LLC\nhttp://simplovation.com");
            }
        }
    }
}
