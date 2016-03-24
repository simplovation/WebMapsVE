/* ----------------------------------------------------------------------------------- */
/* Copyright (C) Simplovation LLC (http://Simplovation.com) 2016. All rights reserved. */
/* Licensing information available at http://webmapsve.codeplex.com                    */
/* ----------------------------------------------------------------------------------- */
using System;

namespace Simplovation.Web.Maps.VE.Base
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class ExtenderControlPropertyAttribute : Attribute
    {
        public ExtenderControlPropertyAttribute() { }

        public ExtenderControlPropertyAttribute(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }
    }
}
