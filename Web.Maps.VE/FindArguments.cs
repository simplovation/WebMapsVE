/* ----------------------------------------------------------------------------------- */
/* Copyright (C) Simplovation LLC (http://Simplovation.com) 2016. All rights reserved. */
/* Licensing information available at http://webmapsve.codeplex.com                    */
/* ----------------------------------------------------------------------------------- */
using System;
using System.Runtime.Serialization;

namespace Simplovation.Web.Maps.VE
{
    /// <summary>
    /// The Arguments used to perform Find operations on the Map.
    /// </summary>
    [DataContract]
    public class FindArguments
    {
        /// <summary>
        /// The business name, category, or other item for which the search is conducted. This parameter must be specified for a pushpin to be included in the results.
        /// </summary>
        [DataMember]
        public string What { get; set; }

        /// <summary>
        /// The address or place name of the area for which the search is conducted.
        /// </summary>
        [DataMember]
        public string Where { get; set; }

        /// <summary>
        /// The beginning index of the results returned. Default is 0
        /// </summary>
        [DataMember]
        public int StartIndex { get; set; }

        private int _NumberOfResults = 10;
        /// <summary>
        /// The number of results to be returned, starting at StartIndex, minimum is 1 and maximum is 20. Defaults is 10
        /// </summary>
        [DataMember]
        public int NumberOfResults
        {
            get { return this._NumberOfResults; }
            set
            {
                this._NumberOfResults = value;
                if (this._NumberOfResults < 1) this._NumberOfResults = 1;
                if (this._NumberOfResults > 20) this._NumberOfResults = 20;
            }
        }

        private bool _ShowResults = true;
        /// <summary>
        /// A boolean value specifying whether the resulting pushpins are visible. Default is True.
        /// </summary>
        [DataMember]
        public bool ShowResults
        {
            get { return this._ShowResults; }
            set { this._ShowResults = value; }
        }

        private bool _CreateResults = true;
        /// <summary>
        /// A boolean value specifying whether pushpins are created when a 'what' parameter is supplied. Default is True
        /// </summary>
        [DataMember]
        public bool CreateResults
        {
            get { return this._CreateResults; }
            set { this._CreateResults = value; }
        }

        private bool _UseDefaultDisambiguation = true;
        /// <summary>
        /// A boolean value specifying whether the map control displays a disambiguation box when multiple location matches are possible. Default is True
        /// </summary>
        [DataMember]
        public bool UseDefaultDisambiguation { 
            get { return this._UseDefaultDisambiguation; }
            set { this._UseDefaultDisambiguation = value; }
        }

        private bool _SetBestMapView = true;
        /// <summary>
        /// A boolean value specifying whether the map control moves the view to the first location match. Default is True
        /// </summary>
        [DataMember]
        public bool SetBestMapView {
            get { return this._SetBestMapView; }
            set { this._SetBestMapView = value; }
        }
    }
}