using FacePlusPlus.Core;

namespace FacePlusPlus.FacePP
{
    public class FaceSetCreateResponseContent : APIResponseContent
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
        /// count of face tokens whitch added into face set in current request
        /// </summary>
        public int Face_Added { get; set; }

        /// <summary>
        /// total count of face tokens in face set after current request
        /// </summary>
        public int Face_Count { get; set; }

        /// <summary>
        /// failure details
        /// </summary>
        public FaceSetFailureDetail[] Failure_Detail { get; set; }
    }

    public class FaceSetFailureDetail
    {
        /// <summary>
        /// reason about failure
        /// </summary>
        public string Reason { get; set; }

        /// <summary>
        /// failure face token
        /// </summary>
        public string Face_token { get; set; }
    }

}
