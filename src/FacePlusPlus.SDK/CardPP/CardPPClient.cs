using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FacePlusPlus
{
    public partial class APIClient
    {
        #region CardPP

        /// <summary>
        /// OCR IdCard Async
        /// </summary>
        /// <param name="image_path">path of image file</param>
        /// <param name="image_base64">byte array of image file base, encoded by base64</param>
        /// <param name="image_url">url of image file</param>
        /// <param name="legality">whether return legality ocr result</param>
        /// <returns></returns>
        public async Task<CardPP.OCRIdCardResponseContent> OCR_IdCardAsync(string image_path, byte[] image_base64 = null, string image_url = "", int? legality = null)
        {
            using (var request = new CardPP.OCRIdCardRequestContent()
            {
                Image_Path = image_path,
                Image_Base64 = image_base64,
                Image_Url = image_url,
                Legality = legality
            })
            {
                var response = await _proxy.Invoke<MultipartFormDataContent, CardPP.OCRIdCardResponseContent>(request);
                return response;
            }
        }

        /// <summary>
        /// OCR IdCard
        /// </summary>
        /// <param name="image_path">path of image file</param>
        /// <param name="image_base64">byte array of image file base, encoded by base64</param>
        /// <param name="image_url">url of image file</param>
        /// <param name="legality">whether return legality ocr result</param>
        /// <returns></returns>
        public CardPP.OCRIdCardResponseContent OCR_IdCard(string image_path, byte[] image_base64 = null, string image_url = "", int? legality = null)
        {
            var response = OCR_IdCardAsync(image_path, image_base64, image_url, legality);
            return response.Result;
        }

        /// <summary>
        /// OCR Driver License Async
        /// </summary>
        /// <param name="image_path">path of image file</param>
        /// <param name="image_url">url of image file</param>
        /// <param name="return_score">whether return ocr score</param>
        /// <returns></returns>
        public async Task<CardPP.OCRDriverLicenseResponseContent> OCR_DriverLicenseAsync(string image_path, string image_url = "", int? return_score = null)
        {
            using (var request = new CardPP.OCRDriverLicenseRequestContent()
            {
                Image_Path = image_path,
                Image_Url = image_url,
                Return_Score = return_score
            })
            {
                var response = await _proxy.Invoke<MultipartFormDataContent, CardPP.OCRDriverLicenseResponseContent>(request);
                return response;
            }
        }

        /// <summary>
        /// OCR Driver License
        /// </summary>
        /// <param name="image_path">path of image file</param>
        /// <param name="image_url">url of image file</param>
        /// <param name="return_score">whether return ocr score</param>
        /// <returns></returns>
        public CardPP.OCRDriverLicenseResponseContent OCR_DriverLicense(string image_path, string image_url = "", int? return_score = null)
        {
            var response = OCR_DriverLicenseAsync(image_path, image_url, return_score);
            return response.Result;
        }

        /// <summary>
        /// OCR Vehicle License Async
        /// </summary>
        /// <param name="image_path">path of image file</param>
        /// <param name="image_base64">byte array of image file base, encoded by base64</param>
        /// <param name="image_url">url of image file</param>
        /// <returns></returns>
        public async Task<CardPP.OCRVehicleLicenseResponseContent> OCR_VehicleLicenseAsync(string image_path, byte[] image_base64 = null, string image_url = "")
        {
            using (var request = new CardPP.OCRVehicleLicenseRequestContent()
            {
                Image_Path = image_path,
                Image_Base64 = image_base64,
                Image_Url = image_url
            })
            {
                var response = await _proxy.Invoke<MultipartFormDataContent, CardPP.OCRVehicleLicenseResponseContent>(request);
                return response;
            }
        }

        /// <summary>
        /// OCR Vehicle License
        /// </summary>
        /// <param name="image_path">path of image file</param>
        /// <param name="image_base64">byte array of image file base, encoded by base64</param>
        /// <param name="image_url">url of image file</param>
        /// <returns></returns>
        public CardPP.OCRVehicleLicenseResponseContent OCR_VehicleLicense(string image_path, byte[] image_base64 = null, string image_url = "")
        {
            var response = OCR_VehicleLicenseAsync(image_path, image_base64, image_url);
            return response.Result;
        }

        /// <summary>
        /// OCR Bank Card Async
        /// </summary>
        /// <param name="image_path">path of image file</param>
        /// <param name="image_base64">byte array of image file base, encoded by base64</param>
        /// <param name="image_url">url of image file</param>
        /// <returns></returns>
        public async Task<CardPP.OCRBankCardResponseContent> OCR_BankCardAsync(string image_path, byte[] image_base64 = null, string image_url = "")
        {
            using (var request = new CardPP.OCRBankCardRequestContent()
            {
                Image_Path = image_path,
                Image_Base64 = image_base64,
                Image_Url = image_url
            })
            {
                var response = await _proxy.Invoke<MultipartFormDataContent, CardPP.OCRBankCardResponseContent>(request);
                return response;
            }
        }

        /// <summary>
        /// OCR Bank Card
        /// </summary>
        /// <param name="image_path">path of image file</param>
        /// <param name="image_base64">byte array of image file base, encoded by base64</param>
        /// <param name="image_url">url of image file</param>
        /// <returns></returns>
        public CardPP.OCRBankCardResponseContent OCR_BankCard(string image_path, byte[] image_base64 = null, string image_url = "")
        {
            var response = OCR_BankCardAsync(image_path, image_base64, image_url);
            return response.Result;
        }

        #endregion
    }
}
