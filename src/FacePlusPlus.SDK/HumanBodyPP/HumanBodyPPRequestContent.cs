using System.Net.Http;
using FacePlusPlus.Core;

namespace FacePlusPlus.HumanBodyPP
{
    abstract class HumanBodyPPRequestContent<T> : APIRequestContent<T> where T : HttpContent
    {
        public override string Area => "humanbodypp";

        public override string Version => "v1";
    }
}
