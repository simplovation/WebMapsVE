/* ----------------------------------------------------------------------------------- */
/* Copyright (C) Simplovation LLC (http://Simplovation.com) 2016. All rights reserved. */
/* Licensing information available at http://webmapsve.codeplex.com                    */
/* ----------------------------------------------------------------------------------- */
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using Simplovation.Web.Maps.VE.Interfaces;
using System.Web;
using System.Web.UI;
using System.Runtime.Serialization;

namespace Simplovation.Web.Maps.VE
{
    /// <summary>
    /// The Shape object provides Polygon, Polyline and Pushpin functionality combined within a single common object type.
    /// </summary>
    ///[TypeConverter(typeof(GenericConverter)),
    [DataContract,
    ParseChildren(true)]
    public class Shape : IClientID
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the Shape object of type Pushpin.
        /// </summary>
        public Shape() { }

        /// <summary>
        /// Initializes a new instance of the Shape object of type Pushpin.
        /// </summary>
        /// <param name="point">The location of the Pushpin</param>
        public Shape(LatLong point)
        {
            this.Type = ShapeType.Pushpin;
            this.Points.Add(point);
        }

        /// <summary>
        /// Initializes a new instance of the Shape object.
        /// </summary>
        /// <param name="type">The type of shape.</param>
        /// <param name="points">An array of LatLong objects representing the points that make up the pushpin, polyline or polygon. If shape is of type Pushpin, a single LatLong is required. If shape is of type polyline, at least two points are required. If shape is of type polygon, at least three points are required.</param>
        public Shape(ShapeType type, LatLong[] points)
        {
            this.Type = type;
            if (type == ShapeType.Pushpin && points.Length == 0)
            {
                throw new Exception("A Shape of type Pushpin requires at least a single point.");
            }
            else if (type == ShapeType.Polyline && points.Length < 2)
            {
                throw new Exception("A Shape of type Polyline requires at least two points.");
            }
            else if (type == ShapeType.Polygon && points.Length < 3)
            {
                throw new Exception("A Shape of type Polygon requires at least three points.");
            }

            foreach (LatLong ll in points)
            {
                this.Points.Add(ll);
            }
        }

        /// <summary>
        /// Initializes a new instance of the Shape object.
        /// </summary>
        /// <param name="type">The type of shape.</param>
        /// <param name="points">An array of LatLong objects representing the points that make up the pushpin, polyline or polygon. If shape is of type Pushpin, a single LatLong is required. If shape is of type polyline, at least two points are required. If shape is of type polygon, at least three points are required.</param>
        public Shape(ShapeType type, List<LatLong> points)
        {
            this.Type = type;
            if (type == ShapeType.Pushpin && points.Count == 0)
            {
                throw new Exception("A Shape of type Pushpin requires at least a single point.");
            }
            else if (type == ShapeType.Polyline && points.Count < 2)
            {
                throw new Exception("A Shape of type Polyline requires at least two points.");
            }
            else if (type == ShapeType.Polygon && points.Count < 3)
            {
                throw new Exception("A Shape of type Polygon requires at least three points.");
            }
            this.Points.AddRange(points);
        }

        #endregion

        #region Properties

        /// <summary>
        /// This is the unique ID that identifies this Shape on the client. Any value this property is set to from Server-Side code, will be ignored.
        /// </summary>
        [DataMember]
        public string ClientID { get; set; }

        /// <summary>
        /// Determines whether to show/hide the icon associated with a Polyline or Polygon. This is ignored for Pushpins.
        /// </summary>
        [DataMember]
        public bool ShowIcon { get; set; }

        /// <summary>
        /// The Shapes custom icon.
        /// </summary>
        [DataMember]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public CustomIconSpecification CustomIcon { get; set; }

        /// <summary>
        /// The description of the Shape.
        /// </summary>
        [DataMember]
        public string Description { get; set; }

        private Simplovation.Web.Maps.VE.Color _FillColor = null;
        /// <summary>
        /// The fill color and transparency for a polygon.
        /// </summary>
        [DataMember]
        public Simplovation.Web.Maps.VE.Color FillColor
        {
            get { return _FillColor; }
            set { _FillColor = value; }
        }

        /// <summary>
        /// A LatLong object representing the Shape's custom icon anchor point.
        /// </summary>
        [DataMember]
        public LatLong IconAnchor { get; set; }

        private Simplovation.Web.Maps.VE.Color _LineColor = new Simplovation.Web.Maps.VE.Color();
        /// <summary>
        /// The line color or transparency for a polyline or polygon.
        /// </summary>
        [DataMember]
        public Simplovation.Web.Maps.VE.Color LineColor
        {
            get { return _LineColor; }
            set { _LineColor = value; }
        }

        private int _LineWidth = 2;
        /// <summary>
        /// The line width of a polyline or polygon.
        /// </summary>
        [DefaultValue(2)]
        [DataMember]
        public int LineWidth
        {
            get { return _LineWidth; }
            set { _LineWidth = value; }
        }

        /// <summary>
        /// The Shape's "more info" URL.
        /// </summary>
        [DataMember]
        public string MoreInfoURL { get; set; }

        /// <summary>
        /// The Shape's "photo" URL.
        /// </summary>
        [DataMember]
        public string PhotoURL { get; set; }

        private List<LatLong> _Points = new List<LatLong>();
        /// <summary>
        /// An array of LatLong objects representing the points that make up the pushpin, polyline or polygon.
        /// </summary>
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DataMember]
        public List<LatLong> Points
        {
            get { return _Points; }
            set { _Points = value; }
        }

        /// <summary>
        /// Returns the First LatLong Point in the Shapes Points collection. Read-Only
        /// </summary>
        public LatLong LatLong
        {
            get
            {
                if (this.Points.Count > 0)
                    return this.Points[0];
                else
                    return new LatLong();
            }
        }

        /// <summary>
        /// The title of the Shape object.
        /// </summary>
        [DataMember]
        public string Title { get; set; }

        /// <summary>
        /// The type of Shape object.
        /// </summary>
        [DataMember]
        public ShapeType Type { get; set; }

        private int _ZIndex = 1000;
        /// <summary>
        /// The z-index of a pushpin shape or pushpin attached to a polyline or polygon.
        /// </summary>
        [DataMember]
        public int ZIndex
        {
            get { return _ZIndex; }
            set { _ZIndex = value; }
        }

        /// <summary>
        /// Gets or sets string that contains data about the Shape
        /// </summary>
        [DataMember]
        public string Tag { get; set; }

        /// <summary>
        /// The altitude for the Shape
        /// </summary>
        [DataMember]
        public double? Altitude { get; set; }

        /// <summary>
        /// Specifies the mode in which the Shapes Altitude is represented
        /// </summary>
        [DataMember]
        public AltitudeMode AltitudeMode { get; set; }

        /// <summary>
        /// A boolean value indicating whether the Shape is is draggable on the Map by using the mouse. Default is False.
        /// </summary>
        [DataMember]
        public bool Draggable { get; set; }

        #endregion

        public override string ToString()
        {
            // Return a more friendly string that makes debugging easier
            //return base.ToString();

            var pointString = string.Empty;
            if (this.Type == ShapeType.Pushpin)
            {
                if (this.Points.Count > 0)
                {
                    pointString = string.Format("{0}", this.Points[0].ToString());
                }
            }
            else
            {
                pointString = string.Format("{0} Points", this.Points.Count.ToString());
            }

            return string.Format("{0} ({1}) Title = '{2}'", this.Type.ToString(), pointString, this.Title);
        }
    }
}
