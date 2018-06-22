using FacePlusPlus.Core;

namespace FacePlusPlus.FacePP
{
    public class FaceSetGetFaceSetsResponseContent : APIResponseContent
    {
        /// <summary>
        /// face set token
        /// </summary>
        public FaceSet[] FaceSets { get; set; }

        /// <summary>
        /// sequence start value in next request
        /// </summary>
        public string Next { get; set; }
    }

    public class FaceSet
    {
        /// <summary>
        /// face set token
        /// </summary>
        public string FaceSet_Token { get; set; }

        /// <summary>
        /// custom out_id
        /// </summary>
        public string Outer_Id { get; set; }

        /// <summary>
        /// name of face set, max length: 255, exclude: ^@,&=*'"
        /// </summary>
        public string Display_Name { get; set; }

        /// <summary>
        /// custom tags, comma-separated, max length: 255, exclude: ^@,&=*'"
        /// </summary>
        public string Tags { get; set; }
    }
}