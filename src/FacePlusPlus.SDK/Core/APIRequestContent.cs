using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace FacePlusPlus.Core
{
    /// <summary>
    /// Base api request content
    /// </summary>
    abstract class APIRequestContent<T> where T : HttpContent
    {
        /// <summary>
        /// api key from face++ application management
        /// </summary>
        internal string API_Key { get; set; }

        /// <summary>
        /// api secret from face++ application management
        /// </summary>
        internal string API_Secret { get; set; }

        /// <summary>
        /// area of face++ api 
        /// </summary>
        public abstract string Area { get; }

        /// <summary>
        /// version of face++ api
        /// </summary>
        public abstract string Version { get; }

        /// <summary>
        /// name of face++ api
        /// </summary> 
        public abstract string Name { get; }

        /// <summary>
        /// set data parts into form data content
        /// </summary>
        /// <param name="content"></param>
        public void Internal_AddToMultipartContent(Dictionary<string, dynamic> content)
        {
            if (typeof(T) == typeof(MultipartFormDataContent))
            {
                content.Add("api_key", new StringContent(API_Key));
                content.Add("api_secret", new StringContent(API_Secret));
            }
            else
            {
                content.Add("api_key", API_Key);
                content.Add("api_secret", API_Secret);
            }

            AddToMultipartContent(content);
        }

        /// <summary>
        /// generate a http content object
        /// </summary>
        /// <returns></returns>
        public HttpContent Internal_GenerateHttpContent()
        {
            var parameters = new Dictionary<string, dynamic>();
            Internal_AddToMultipartContent(parameters);

            if (typeof(T) == typeof(MultipartFormDataContent))
            {
                var ie = parameters.GetEnumerator();
                var content = new MultipartFormDataContent();
                while (ie.MoveNext())
                {
                    if (ie.Current.Value is ValueTuple<StreamContent, string> imageFile)
                        content.Add(imageFile.Item1, ie.Current.Key, imageFile.Item2);
                    else
                        content.Add(ie.Current.Value as HttpContent, ie.Current.Key);
                }
                return content;
            }
            else
            {
                var content = new StringContent(JsonConvert.SerializeObject(parameters), Encoding.UTF8, "application/json");
                return content;
            }
        }

        /// <summary>
        /// build request url from properties
        /// </summary>
        /// <param name="base_url"></param>
        /// <returns></returns>
        public string BuildUrl(string base_url) => $"{base_url}/{Area}/{Version}/{Name}";

        /// <summary>
        /// set data parts into form data content
        /// </summary>
        /// <param name="content"></param>
        public abstract void AddToMultipartContent(Dictionary<string, dynamic> content);
    }
}