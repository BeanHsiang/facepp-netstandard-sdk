using FacePlusPlus.Core;
using System.Collections.Generic;

namespace FacePlusPlus.FacePP
{
    public class CompareResponseContent : APIResponseContent
    {
        /// <summary>
        /// confidence
        /// </summary>
        public float Confidence { get; set; }

        /// <summary>
        /// thresholds
        /// </summary>
        public IDictionary<string, float> Thresholds { get; set; }

        public string Image_Id1 { get; set; }

        public string Image_Id2 { get; set; }

        public Face[] Faces1 { get; set; }

        public Face[] Faces2 { get; set; }
    }
}
