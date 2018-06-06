using System.Net.Http;
using FacePlusPlus.Core;

namespace FacePlusPlus.CardPP
{
    abstract class CardPPRequestContent<T> : APIRequestContent<T> where T : HttpContent
    {
        public override string Area => "cardpp";
    }
}
