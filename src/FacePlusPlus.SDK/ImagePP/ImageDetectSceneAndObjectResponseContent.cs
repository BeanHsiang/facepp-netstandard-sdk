using FacePlusPlus.Core;

namespace FacePlusPlus.ImagePP
{
    public class ImageDetectSceneAndObjectResponseContent : APIResponseContent
    {
        /// <summary>
        /// scenes
        /// </summary>
        public SceneAndObjectValue[] Scenes { get; set; }

        /// <summary>
        /// objects
        /// </summary>
        public SceneAndObjectValue[] Objects { get; set; }

        /// <summary>
        /// image id
        /// </summary>
        public string Image_Id { get; set; }
    }

    public struct SceneAndObjectValue
    {
        public float confidence;
        public string value;
    }
}
