using FacePlusPlus.Core;
using System.Collections.Generic;

namespace FacePlusPlus.FacePP
{
    public class SearchResponseContent : APIResponseContent
    {
        public SearchResult[] Results { get; set; }

        /// <summary>
        /// thresholds
        /// </summary>
        public IDictionary<string, float> Thresholds { get; set; }

        /// <summary>
        /// image id
        /// </summary>
        public string Image_Id { get; set; }

        public Face[] Faces { get; set; }
    }

    public class SearchResult
    {
        /// <summary>
        /// face token
        /// </summary>
        public string Face_Token { get; set; }

        /// <summary>
        /// confidence
        /// </summary>
        public float Confidence { get; set; }

        /// <summary>
        /// user id
        /// </summary>
        public string User_Id { get; set; }
    }
}
