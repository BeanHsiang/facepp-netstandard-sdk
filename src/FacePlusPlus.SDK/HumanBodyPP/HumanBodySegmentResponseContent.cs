using FacePlusPlus.Core;
using System.Collections.Generic;

namespace FacePlusPlus.HumanBodyPP
{
    public class HumanBodySegmentResponseContent : APIResponseContent
    {
        /// <summary>
        /// result, base64 image string
        /// </summary>
        public string result { get; set; }

        /// <summary>
        /// image id
        /// </summary>
        public string Image_Id { get; set; }
    }
}
