/* ----------------------------------------------------------------------------------- */
/* Copyright (C) Simplovation LLC (http://Simplovation.com) 2016. All rights reserved. */
/* Licensing information available at http://webmapsve.codeplex.com                    */
/* ----------------------------------------------------------------------------------- */
using System;
using System.Text;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Web.Script.Serialization;

namespace Simplovation.Web.Maps.VE.Util
{
    class JSONHelper
    {
        public static string DecodeString(string str)
        {
            string strReturn = str;
            strReturn = strReturn.Replace("\\u003c", "<");
            strReturn = strReturn.Replace("\\u003e", ">");
            strReturn = strReturn.Replace("\\u0026", "&");
            return strReturn;
        }

        public static string Serialize<T>(T obj)
        {
            
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(obj.GetType());
            MemoryStream ms = new MemoryStream();
            serializer.WriteObject(ms, obj);
            string retVal = Encoding.Default.GetString(ms.ToArray());
            return retVal;
            
            //JavaScriptSerializer jss = new JavaScriptSerializer();
            //return jss.Serialize(obj);
        }

        public static T Deserialize<T>(string json)
        {
            
            T obj = Activator.CreateInstance<T>();
            MemoryStream ms = new MemoryStream(Encoding.Unicode.GetBytes(json));
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(obj.GetType());
            obj = (T)serializer.ReadObject(ms);
            ms.Close();
            return obj;
            
            //JavaScriptSerializer jss = new JavaScriptSerializer();
            //return jss.Deserialize<T>(json);
        }
    }
}