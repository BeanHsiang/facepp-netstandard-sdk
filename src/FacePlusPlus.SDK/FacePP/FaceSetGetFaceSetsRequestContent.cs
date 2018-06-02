using System.Collections.Generic;
using System.Net.Http;

namespace FacePlusPlus.FacePP
{
    class FaceSetGetFaceSetsRequestContent : FacePPRequestContent<MultipartFormDataContent>
    {
        public override string Name => "faceset/getfacesets";

        /// <summary>
        /// custom tags, comma-separated, max length: 255, exclude: ^@,&=*'"
        /// </summary>
        public string Tags { get; set; }

        /// <summary>
        /// sequence in face set, [1, 100], maybe "next" value in lastest response
        /// </summary>
        public int? Start { get; set; }

        public override void AddToMultipartContent(Dictionary<string, dynamic> content)
        {
            if (!string.IsNullOrWhiteSpace(Tags))
            {
                content.Add("tags", new StringContent(Tags));
            }

            if (Start.HasValue)
            {
                content.Add("start", new StringContent(Start.Value.ToString()));
            }
        }
    }
}
