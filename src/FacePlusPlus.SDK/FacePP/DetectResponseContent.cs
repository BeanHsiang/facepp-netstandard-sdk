using FacePlusPlus.Core;

namespace FacePlusPlus.FacePP
{
    public class DetectResponseContent : APIResponseContent
    {
        /// <summary>
        /// faces
        /// </summary>
        public Face[] Faces { get; set; }

        /// <summary>
        /// image id
        /// </summary>
        public string Image_Id { get; set; }
    }

    public class Face
    {
        /// <summary>
        /// face token
        /// </summary>
        public string Face_Token { get; set; }

        public FaceRectangle Face_Rectangle { get; set; }

        public FaceLandmark Landmark { get; set; }

        public FaceAttributes Attributes { get; set; }

    }

    public class FaceRectangle
    {
        public int Top { get; set; }

        public int Left { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }
    }

    public class FaceLandmark
    {
    }

    public class FaceAttributes
    { }
}
