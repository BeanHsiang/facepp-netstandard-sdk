using System.Net.Http;
using FacePlusPlus.Core;

namespace FacePlusPlus.ImagePP
{
    abstract class ImagePPRequestContent<T> : APIRequestContent<T> where T : HttpContent
    {
        public override string Area => "imagepp";

        public override string Version => "v1";
    }
}
