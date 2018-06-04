using FacePlusPlus.Core;

namespace FacePlusPlus.FacePP
{
    public class FaceAnalyzeResponseContent : APIResponseContent
    {
        /// <summary>
        /// faces
        /// </summary>
        public Face[] Faces { get; set; }
    }
}
