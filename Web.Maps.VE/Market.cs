/* ----------------------------------------------------------------------------------- */
/* Copyright (C) Simplovation LLC (http://Simplovation.com) 2016. All rights reserved. */
/* Licensing information available at http://webmapsve.codeplex.com                    */
/* ----------------------------------------------------------------------------------- */
using System;
using System.Collections.Generic;
using System.Text;

/*
List of Market Culture Codes:
http://download1.swsoft.com/SiteBuilder/Windows/docs/3.2/en_US/sitebulder-3.2-win-sdk-localization-pack-creation-guide/30801.htm

Markets supposed to be supported by MS Virtual Earth:
http://msdn2.microsoft.com/en-us/library/bb429645.aspx
*/

namespace Simplovation.Web.Maps.VE
{
    /// <summary>
    /// An enumeration of the International Markets supported by the Virtual Earth API.
    /// </summary>
    public enum Market : int
    {
        /// <summary>
        /// English - United States (en-us)
        /// </summary>
        English = 1,
        /// <summary>
        /// English - Canada (en-ca) - MS Virtual Earth may not support this localization option yet.
        /// </summary>
        en_ca = 3,
        /// <summary>
        /// English - United Kingdom (en-gb) - MS Virtual Earth may not support this localization option yet.
        /// </summary>
        en_gb = 4,
        /// <summary>
        /// Japanese - Japan (ja-jp)
        /// </summary>
        ja_jp = 5,
        /// <summary>
        /// Czech - Czech Republic (cs-cz) - MS Virtual Earth may not support this localization option yet.
        /// </summary>
        cs_cz = 6,
        /// <summary>
        /// Danish - Denmark (da-dk) - MS Virtual Earth may not support this localization option yet.
        /// </summary>
        da_dk = 7,
        /// <summary>
        /// Dutch - The Netherlands (nl-nl) - MS Virtual Earth may not support this localization option yet.
        /// </summary>
        nl_nl = 8,
        /// <summary>
        /// Finnish - Finland (fi-fi) - MS Virtual Earth may not support this localization option yet.
        /// </summary>
        fi_fi = 9,
        /// <summary>
        /// French - France (fr-fr) - MS Virtual Earth may not support this localization option yet.
        /// </summary>
        fr_fr = 10,
        /// <summary>
        /// German - Germany (de-de) - MS Virtual Earth may not support this localization option yet.
        /// </summary>
        de_de = 11,
        /// <summary>
        /// Italian - Italy (it-it) - MS Virtual Earth may not support this localization option yet.
        /// </summary>
        it_it = 12,
        /// <summary>
        /// Norwegian - Norway (nb-no) - MS Virtual Earth may not support this localization option yet.
        /// </summary>
        nb_no = 13,
        /// <summary>
        /// Portuguese - Portugal (pt-pt) - MS Virtual Earth may not support this localization option yet.
        /// </summary>
        pt_pt = 14,
        /// <summary>
        /// Spanish - Spain (es-es) - MS Virtual Earth may not support this localization option yet.
        /// </summary>
        es_es = 15,
        /// <summary>
        /// Swedish - Sweden (sv-se) - MS Virtual Earth may not support this localization option yet.
        /// </summary>
        sv_se = 16
    }
}
