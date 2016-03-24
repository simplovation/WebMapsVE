/* ----------------------------------------------------------------------------------- */
/* Copyright (C) Simplovation LLC (http://Simplovation.com) 2014. All rights reserved. */
/* Licensing information available at http://webmapsve.codeplex.com                    */
/* ----------------------------------------------------------------------------------- */
using System.Runtime.Serialization;
using System.Web.UI;

namespace Simplovation.Web.Maps.VE
{
    /// <summary>
    /// Specifies the appearance of a Shape object's custom icon.
    /// </summary>
    [DataContract]
    public class CustomIconSpecification
    {
        /// <summary>
        /// Initializes a new instance of the CustomIconSpecification class.
        /// </summary>
        /// <overloads>Initializes a new instance of the CustomIconSpecification class.</overloads>
        public CustomIconSpecification()
        {
        }

        /// <summary>
        /// Initializes a new instance of the CustomIconSpecification class.
        /// </summary>
        /// <param name="customHTML">The Custom HTML representing the pin's appearance. This is used for 2D views only.</param>
        public CustomIconSpecification(string customHTML)
        {
            this.CustomHTML = customHTML;
        }

        /// <summary>
        /// Gets or sets a Color object representing the icon's background color and transparency
        /// </summary>
        [DataMember]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public Color BackColor { get; set; }

        /// <summary>
        /// Gets or sets Custom HTML representing the pin's appearance. This is used for 2D views only.
        /// </summary>
        [DataMember]
        public string CustomHTML { get; set; }

        /// <summary>
        /// Gets or sets a Color object representing the icon's text color and transparency
        /// </summary>
        [DataMember]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public Color ForeColor { get; set; }

        /// <summary>
        /// Gets or sets a String representing the URL of an image file
        /// </summary>
        [DataMember]
        public string Image { get; set; }

        /// <summary>
        /// A Pixel object representing the image's offset from the icon's anchor
        /// </summary>
        [DataMember]
        public Pixel ImageOffset { get; set; }

        /// <summary>
        /// Specifies whether the text for the icon should be bold
        /// </summary>
        [DataMember]
        public bool TextBold { get; set; }

        /// <summary>
        /// Gets or sets the actual text to display for the icon
        /// </summary>
        [DataMember]
        public string TextContent { get; set; }

        /// <summary>
        /// Gets or sets a String containing the name of the font to use for the icon text
        /// </summary>
        [DataMember]
        public string TextFont { get; set; }

        /// <summary>
        /// Specifies whether the text for the icon should be italic
        /// </summary>
        [DataMember]
        public bool TextItalics { get; set; }

        /// <summary>
        /// A Pixel object representing the amount to offset text from the top left corner
        /// </summary>
        [DataMember]
        public Pixel TextOffset { get; set; }

        /// <summary>
        /// Specifies the size at which to display text, in points
        /// </summary>
        [DataMember]
        public int TextSize { get; set; }

        /// <summary>
        /// Specifies whether the text for the icon should be underlined
        /// </summary>
        [DataMember]
        public bool TextUnderline { get; set; }

        /*
        [DataMember]
        public int ImageWidth { get; set; }
        [DataMember]
        public int ImageHeight { get; set; }
        */
    }
}
