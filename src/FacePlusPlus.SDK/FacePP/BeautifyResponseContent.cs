using FacePlusPlus.Core;

namespace FacePlusPlus.FacePP
{
    public class BeautifyResponseContent : APIResponseContent
    {
        /// <summary>
        /// base64 image after beautified
        /// </summary>
        public string Result { get; set; }
    }
}
