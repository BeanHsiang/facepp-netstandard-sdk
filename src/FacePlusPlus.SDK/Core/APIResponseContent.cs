namespace FacePlusPlus.Core
{
    /// <summary>
    /// Base api response content
    /// </summary>
    public abstract class APIResponseContent
    {
        /// <summary>
        /// a unique identifier per request
        /// </summary>
        public string Request_Id { get; set; }

        /// <summary>
        /// the time spent during the request (millisecond)
        /// </summary>
        public int Time_Used { get; set; }

        /// <summary>
        /// the informations returned when request was error
        /// </summary>
        /// <remarks>https://console.faceplusplus.com.cn/documents/5672651</remarks>
        public string Error_Message { get; set; }
    }
}
