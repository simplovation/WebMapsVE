/* ----------------------------------------------------------------------------------- */
/* Copyright (C) Simplovation LLC (http://Simplovation.com) 2016. All rights reserved. */
/* Licensing information available at http://webmapsve.codeplex.com                    */
/* ----------------------------------------------------------------------------------- */
using System.Web.UI;
namespace Simplovation.Web.Maps.VE.Extenders
{
    /// <summary>
    /// A specific Animation Point used by the <see cref="SimpleAnimationExtender">SimpleAnimationExtender</see>.
    /// </summary>
    [ParseChildren(true)]
    public class SimpleAnimationPoint
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SimpleAnimationPoint">SimpleAnimationPoint</see> object.
        /// </summary>
        public SimpleAnimationPoint() { }

        /// <summary>
        /// The Title of this animation point
        /// </summary>
        public string Title { get; set; }
        
        /// <summary>
        /// The Description of this animation point
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The LatLong point to move the center of the map to for this animation point
        /// </summary>
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public LatLong LatLong { get; set; }
        
        /// <summary>
        /// The Zoom level to set the map to for this animation point
        /// </summary>
        public int ZoomLevel { get; set; }

        private int _Duration = 3000;
        /// <summary>
        /// The number of Milliseconds to display this animation point before moving on to the next animation point (1,000 milliseconds = 1 second) Default is 3,000
        /// </summary>
        public int Duration {
            get { return this._Duration; }
            set { this._Duration = value; }
        }
    }
}