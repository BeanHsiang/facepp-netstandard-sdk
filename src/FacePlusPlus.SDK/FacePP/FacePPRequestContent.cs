using System.Net.Http;
using FacePlusPlus.Core;

namespace FacePlusPlus.FacePP
{
    abstract class FacePPRequestContent<T> : APIRequestContent<T> where T : HttpContent
    {
        public override string Area => "facepp";

        public override string Version => "v3";
    }
}
