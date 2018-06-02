using FacePlusPlus.Core;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace FacePlusPlus
{
    class APIProxy
    {
        const string Base_Url = "https://api-cn.faceplusplus.com";
        readonly string _api_key = string.Empty;
        readonly string _api_secret = string.Empty;

        public APIProxy(string api_key, string api_secret)
        {
            _api_key = api_key;
            _api_secret = api_secret;
        }

        async internal Task<TOut> Invoke<TIn, TOut>(APIRequestContent<TIn> content) where TIn : HttpContent where TOut : APIResponseContent
        {
            content.API_Key = _api_key;
            content.API_Secret = _api_secret;
            int retry = 10;

            using (var multipartFormDataContent = content.Internal_GenerateHttpContent())
            {
                while (true)
                {
                    using (var client = new HttpClient())
                    {
                        var response = await client.PostAsync(content.BuildUrl(Base_Url), multipartFormDataContent).ConfigureAwait(false);
                        var result = JsonConvert.DeserializeObject<TOut>(await response.Content.ReadAsStringAsync());
                        if (response.StatusCode == HttpStatusCode.OK)
                        {
                            return result;
                        }
                        else
                        {
                            if (retry-- <= 0)
                                throw new HttpRequestException(result.Error_Message);
                            Thread.Sleep(5000);
                        }
                    }
                }
            }
        }
    }
}

