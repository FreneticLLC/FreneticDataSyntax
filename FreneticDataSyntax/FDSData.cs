﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreneticDataSyntax
{
    /// <summary>
    /// Represents a piece of data within an FDS Section.
    /// </summary>
    public class FDSData
    {
        /// <summary>
        /// The list of comments preceding this data piece.
        /// </summary>
        public List<string> PrecedingComments;

        /// <summary>
        /// The internal represented data.
        /// </summary>
        public object Internal;

        /// <summary>
        /// Returns the output-able string representation of this data.
        /// </summary>
        /// <returns>The resultant data.</returns>
        public string Outputable()
        {
            if (Internal is List<FDSData>)
            {
                StringBuilder sb = new StringBuilder();
                foreach (FDSData dat in (List<FDSData>)Internal)
                {
                    sb.Append(dat.Outputable()).Append("|");
                }
                return sb.ToString();
            }
            if (Internal is byte[])
            {
                return Convert.ToBase64String((byte[])Internal, Base64FormattingOptions.None);
            }
            if (Internal is bool)
            {
                return ((bool)Internal) ? "true" : "false";
            }
            return FDSUtility.Escape(Internal.ToString());
        }
    }
}
