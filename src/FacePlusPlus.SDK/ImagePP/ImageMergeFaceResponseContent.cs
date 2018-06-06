using FacePlusPlus.Core;

namespace FacePlusPlus.ImagePP
{
    public class ImageMergeFaceResponseContent : APIResponseContent
    {
        /// <summary>
        /// result, base64 image string
        /// </summary>
        public string result { get; set; }
    }
}
