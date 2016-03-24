/* ----------------------------------------------------------------------------------- */
/* Copyright (C) Simplovation LLC (http://Simplovation.com) 2014. All rights reserved. */
/* Licensing information available at http://webmapsve.codeplex.com                    */
/* ----------------------------------------------------------------------------------- */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Simplovation.Web.Maps.VE.Collections;
using System.Runtime.Serialization;
using System.Web.UI;

namespace Simplovation.Web.Maps.VE
{
    /// <summary>
    /// Contains information about a Shape Layer.
    /// </summary>
    [DataContract]
    [ParseChildren(true)]
    public class ShapeLayer
    {
        /// <summary>
        /// Initializes a new instance of the ShapeLayer object.
        /// </summary>
        public ShapeLayer()
        {
            this.Visible = true;
        }

        private DirtyStateList<Shape> _Shapes = new DirtyStateList<Shape>();
        /// <summary>
        /// The default collection of Shapes to be plotted on the map.
        /// </summary>
        [DataMember]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public DirtyStateList<Shape> Shapes
        {
            get { return _Shapes; }
            set { _Shapes = value; }
        }

        /// <summary>
        /// The Description of the ShapeLayer
        /// </summary>
        [DataMember]
        public string Description { get; set; }

        /// <summary>
        /// The Title of the ShapeLayer
        /// </summary>
        [DataMember]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the value determining whether the ShapeLayer is visible on the Map
        /// </summary>
        [DataMember]
        public bool Visible { get; set; }

        /// <summary>
        ///  Gets or sets string that contains data about the ShapeLayer
        /// </summary>
        [DataMember]
        public string Tag { get; set; }

        public override string ToString()
        {
            // Return a more friendly string that makes debugging easier
            //return base.ToString();
            return string.Format("Title = '{0}', Shapes = {1}, Tag = '{2}'", this.Title, this.Shapes.Count.ToString(), this.Tag);
        }

        /// <summary>
        /// Return the first Shape that has its Tag property set to the passed in value.
        /// </summary>
        /// <param name="tag">The Shape.Tag value to search for.</param>
        /// <returns>The Shape with the Tag property that matches the "tag" passed in.</returns>
        public Shape GetShapeByTag(string tag)
        {
            foreach (var s in this.Shapes)
            {
                if (s.Tag == tag)
                {
                    return s;
                }
            }
            return null;
        }
    }
}
