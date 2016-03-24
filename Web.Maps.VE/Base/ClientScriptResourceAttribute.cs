/* ----------------------------------------------------------------------------------- */
/* Copyright (C) Simplovation LLC (http://Simplovation.com) 2016. All rights reserved. */
/* Licensing information available at http://webmapsve.codeplex.com                    */
/* ----------------------------------------------------------------------------------- */
using System;
using System.Web.UI;

namespace Simplovation.Web.Maps.VE.Base
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class ClientScriptResourceAttribute : Attribute
    {
        public ClientScriptResourceAttribute(string path)
        {
            this.Path = path;
        }

        public ClientScriptResourceAttribute(string name, string assembly)
        {
            this.Name = name;
            this.Assembly = assembly;
        }

        private string _path = null;
        public string Path
        {
            get { return _path; }
            set { _path = value; }
        }

        private string _name = null;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _assembly = null;
        public string Assembly
        {
            get { return _assembly; }
            set { _assembly = value; }
        }

        public ScriptReference GetScriptReference()
        {
            ScriptReference r = null;

            if (this.Path == null)
            {
                r = new ScriptReference(this.Name, this.Assembly);
            }
            else
            {
                r = new ScriptReference(this.Path);
            }

            return r;
        }
    }
}
