using FacePlusPlus.Core;

namespace FacePlusPlus.FacePP
{
    public class FaceGetDetailResponseContent : APIResponseContent
    {
        /// <summary>
        /// image id
        /// </summary>
        public string Image_Id { get; set; }

        /// <summary>
        /// face token
        /// </summary>
        public string Face_Token { get; set; }

        /// <summary>
        /// user id
        /// </summary>
        public string User_Id { get; set; }

        public FaceRectangle Face_Rectangle { get; set; }

        public FaceSet FaceSets { get; set; }
    }
}
