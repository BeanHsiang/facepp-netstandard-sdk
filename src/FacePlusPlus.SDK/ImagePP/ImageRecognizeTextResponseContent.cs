using FacePlusPlus.Core;

namespace FacePlusPlus.ImagePP
{
    public class ImageRecognizeTextResponseContent : APIResponseContent
    {
        /// <summary>
        /// result
        /// </summary>
        public Result[] result { get; set; }

        /// <summary>
        /// image id
        /// </summary>
        public string Image_Id { get; set; }
    }

    public struct Result
    {
        [Newtonsoft.Json.JsonProperty("child-objects")]
        public Result[] childobjects;
        public Position[] position;
        public string type;
        public string value;
    }

    public struct Position
    {
        public int y;
        public int x;
    }
}
