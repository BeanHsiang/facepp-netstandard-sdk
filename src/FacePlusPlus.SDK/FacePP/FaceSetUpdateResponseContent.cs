using FacePlusPlus.Core;

namespace FacePlusPlus.FacePP
{
    public class FaceSetUpdateResponseContent : APIResponseContent
    {
        /// <summary>
        /// face set token
        /// </summary>
        public string FaceSet_Token { get; set; }

        /// <summary>
        /// custom out_id
        /// </summary>
        public string Outer_Id { get; set; }
    }
}
