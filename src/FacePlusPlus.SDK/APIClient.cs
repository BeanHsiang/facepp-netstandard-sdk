using System.Net.Http;
using System.Threading.Tasks;

namespace FacePlusPlus
{
    public partial class APIClient
    {
        private APIProxy _proxy = null;

        public APIClient(string api_key, string api_secret) => _proxy = new APIProxy(api_key, api_secret);

        #region FacePP

        /// <summary>
        /// Face Detect Async
        /// </summary>
        /// <param name="image_path">path of image file</param>
        /// <param name="image_base64">byte array of image file base, encoded by base64</param>
        /// <param name="image_url">url of image file</param>
        /// <param name="return_landmark">whether return landmark</param>
        /// <param name="return_attributes">attributes list</param>
        /// <param name="calculate_all">whether detect all faces, else only five faces</param>
        /// <param name="face_rectangle">special rectangle: top, left, width, height</param>
        /// <returns></returns>
        public async Task<FacePP.DetectResponseContent> Face_DetectAsync(string image_path, byte[] image_base64 = null, string image_url = "", int? return_landmark = null, string return_attributes = "", int? calculate_all = null, string face_rectangle = "")
        {
            using (var request = new FacePP.DetectRequestContent()
            {
                Image_Path = image_path,
                Image_Base64 = image_base64,
                Image_Url = image_url,
                Return_Landmark = return_landmark,
                Return_Attributes = return_attributes,
                Calculate_All = calculate_all,
                Face_Rectangle = face_rectangle
            })
            {
                var response = await _proxy.Invoke<MultipartFormDataContent, FacePP.DetectResponseContent>(request);
                return response;
            }
        }

        /// <summary>
        /// Face Detect
        /// </summary>
        /// <param name="image_path">path of image file</param>
        /// <param name="image_base64">byte array of image file base, encoded by base64</param>
        /// <param name="image_url">url of image file</param>
        /// <param name="return_landmark">whether return landmark</param>
        /// <param name="return_attributes">attributes list</param>
        /// <param name="calculate_all">whether detect all faces, else only five faces</param>
        /// <param name="face_rectangle">special rectangle: top, left, width, height</param>
        /// <returns></returns>
        public FacePP.DetectResponseContent Face_Detect(string image_path, byte[] image_base64 = null, string image_url = "", int? return_landmark = null, string return_attributes = "", int? calculate_all = null, string face_rectangle = "")
        {
            var response = Face_DetectAsync(image_path, image_base64, image_url, return_landmark, return_attributes, calculate_all, face_rectangle);
            return response.Result;
        }

        /// <summary>
        /// Face Detect Async
        /// </summary>
        /// <param name="face_tokens">face tokens</param>
        /// <param name="faceset_token">face set token</param>
        /// <param name="image_path">path of image file</param>
        /// <param name="image_base64">byte array of image file base, encoded by base64</param>
        /// <param name="image_url">url of image file</param>
        /// <param name="outer_id">unique custom id</param>
        /// <param name="return_result_count">return result count</param>
        /// <param name="face_rectangle">special rectangle: top, left, width, height</param>
        /// <returns></returns>
        public async Task<FacePP.SearchResponseContent> Face_SearchAsync(string face_token, string faceset_token, string image_path = "", byte[] image_base64 = null, string image_url = "", string outer_id = "", int return_result_count = 1, string face_rectangle = "")
        {
            using (var request = new FacePP.SearchRequestContent()
            {
                Face_Token = face_token,
                FaceSet_Token = faceset_token,
                Image_Path = image_path,
                Image_Base64 = image_base64,
                Image_Url = image_url,
                Outer_Id = outer_id,
                Return_Result_Count = return_result_count,
                Face_Rectangle = face_rectangle
            })
            {
                var response = await _proxy.Invoke<MultipartFormDataContent, FacePP.SearchResponseContent>(request);
                return response;
            }
        }

        /// <summary>
        /// Face Detect
        /// </summary>
        /// <param name="face_tokens">face tokens</param>
        /// <param name="faceset_token">face set token</param>
        /// <param name="image_path">path of image file</param>
        /// <param name="image_base64">byte array of image file base, encoded by base64</param>
        /// <param name="image_url">url of image file</param>
        /// <param name="outer_id">unique custom id</param>
        /// <param name="return_result_count">return result count</param>
        /// <param name="face_rectangle">special rectangle: top, left, width, height</param>
        /// <returns></returns>
        public FacePP.SearchResponseContent Face_Search(string face_token, string faceset_token, string image_path = "", byte[] image_base64 = null, string image_url = "", string outer_id = "", int return_result_count = 1, string face_rectangle = "")
        {
            var response = Face_SearchAsync(face_token, faceset_token, image_path, image_base64, image_url, outer_id, return_result_count, face_rectangle);
            return response.Result;
        }

        /// <summary>
        /// Face Compare Async
        /// </summary>
        /// <param name="face_token1">face1 token</param>
        /// <param name="face_token2">face2 token</param>
        /// <param name="image_path1">path of image1 file</param>
        /// <param name="image_base64_1">byte array of image1 file base, encoded by base64</param>
        /// <param name="image_url1">url of image1 file</param>
        /// <param name="face_rectangle1">special face image1 rectangle: top, left, width, height</param>
        /// <param name="image_path2">path of image2 file</param>
        /// <param name="image_base64_2">byte array of image2 file base, encoded by base64</param>
        /// <param name="image_url2">url of image2 file</param>
        /// <param name="face_rectangle2">special face image2 rectangle: top, left, width, height</param>
        /// <returns></returns>
        public async Task<FacePP.CompareResponseContent> Face_CompareAsync(string face_token1, string face_token2, string image_path1 = "", byte[] image_base64_1 = null, string image_url1 = "", string face_rectangle1 = "", string image_path2 = "", byte[] image_base64_2 = null, string image_url2 = "", string face_rectangle2 = "")
        {
            using (var request = new FacePP.CompareRequestContent()
            {
                Face_Token1 = face_token1,
                Image_Path1 = image_path1,
                Image_Base64_1 = image_base64_1,
                Image_Url1 = image_url1,
                Face_Rectangle1 = face_rectangle1,
                Face_Token2 = face_token2,
                Image_Path2 = image_path2,
                Image_Base64_2 = image_base64_2,
                Image_Url2 = image_url2,
                Face_Rectangle2 = face_rectangle2,
            })
            {
                var response = await _proxy.Invoke<MultipartFormDataContent, FacePP.CompareResponseContent>(request);
                return response;
            }
        }

        /// <summary>
        /// Face Compare
        /// </summary>
        /// <param name="face_token1">face1 token</param>
        /// <param name="face_token2">face2 token</param>
        /// <param name="image_path1">path of image1 file</param>
        /// <param name="image_base64_1">byte array of image1 file base, encoded by base64</param>
        /// <param name="image_url1">url of image1 file</param>
        /// <param name="face_rectangle1">special face image1 rectangle: top, left, width, height</param>
        /// <param name="image_path2">path of image2 file</param>
        /// <param name="image_base64_2">byte array of image2 file base, encoded by base64</param>
        /// <param name="image_url2">url of image2 file</param>
        /// <param name="face_rectangle2">special face image2 rectangle: top, left, width, height</param>
        /// <returns></returns>
        public FacePP.CompareResponseContent Face_Compare(string face_token1, string face_token2, string image_path1 = "", byte[] image_base64_1 = null, string image_url1 = "", string face_rectangle1 = "", string image_path2 = "", byte[] image_base64_2 = null, string image_url2 = "", string face_rectangle2 = "")
        {
            var response = Face_CompareAsync(face_token1, face_token2, image_path1, image_base64_1, image_url1, face_rectangle1, image_path2, image_base64_2, image_url2, face_rectangle2);
            return response.Result;
        }

        #endregion

        #region FaceSet

        /// <summary>
        /// FaceSet Create Async
        /// </summary>
        /// <param name="display_name">name of face set</param>
        /// <param name="outer_id">unique custom id</param>
        /// <param name="tags">custom tags</param>
        /// <param name="face_tokens">face tokens</param>
        /// <param name="user_data">custom information</param>
        /// <param name="force_merge">whether merge the face toekn into face set if outer_id existed</param>
        /// <returns></returns>
        public async Task<FacePP.FaceSetCreateResponseContent> FaceSet_CreateAsync(string display_name, string outer_id = "", string tags = "", string face_tokens = "", string user_data = "", int force_merge = 0)
        {
            var request = new FacePP.FaceSetCreateRequestContent()
            {
                Display_Name = display_name,
                Outer_Id = outer_id,
                Tags = tags,
                Face_Tokens = face_tokens,
                User_Data = user_data,
                Force_Merge = force_merge
            };
            var response = await _proxy.Invoke<MultipartFormDataContent, FacePP.FaceSetCreateResponseContent>(request);
            return response;
        }

        /// <summary>
        /// FaceSet Create 
        /// </summary>
        /// <param name="display_name">name of face set</param>
        /// <param name="outer_id">unique custom id</param>
        /// <param name="tags">custom tags</param>
        /// <param name="face_tokens">face tokens</param>
        /// <param name="user_data">custom information</param>
        /// <param name="force_merge">whether merge the face toekn into face set if outer_id existed</param>
        /// <returns></returns>
        public FacePP.FaceSetCreateResponseContent FaceSet_Create(string display_name, string outer_id = "", string tags = "", string face_tokens = "", string user_data = "", int force_merge = 0)
        {
            var response = FaceSet_CreateAsync(display_name, outer_id, tags, face_tokens, user_data, force_merge);
            return response.Result;
        }

        /// <summary>
        /// FaceSet Add Face Async
        /// </summary>
        /// <param name="faceset_token">face set token</param>
        /// <param name="outer_id">unique custom id</param>
        /// <param name="face_tokens">face tokens</param>
        /// <returns></returns>
        public async Task<FacePP.FaceSetAddFaceResponseContent> FaceSet_AddFaceAsync(string faceset_token, string face_tokens, string outer_id = "")
        {
            var request = new FacePP.FaceSetAddFaceRequestContent()
            {
                FaceSet_Token = faceset_token,
                Outer_Id = outer_id,
                Face_Tokens = face_tokens
            };
            var response = await _proxy.Invoke<MultipartFormDataContent, FacePP.FaceSetAddFaceResponseContent>(request);
            return response;
        }

        /// <summary>
        /// FaceSet Add Face 
        /// </summary>
        /// <param name="faceset_token">face set token</param>
        /// <param name="outer_id">unique custom id</param>
        /// <param name="face_tokens">face tokens</param>
        /// <returns></returns>
        public FacePP.FaceSetAddFaceResponseContent FaceSet_AddFace(string faceset_token, string face_tokens, string outer_id = "")
        {
            var response = FaceSet_AddFaceAsync(faceset_token, face_tokens, outer_id);
            return response.Result;
        }

        /// <summary>
        /// FaceSet Remove Face Async
        /// </summary>
        /// <param name="faceset_token">face set token</param>
        /// <param name="outer_id">unique custom id</param>
        /// <param name="face_tokens">face tokens</param>
        /// <returns></returns>
        public async Task<FacePP.FaceSetRemoveFaceResponseContent> FaceSet_RemoveFaceAsync(string faceset_token, string face_tokens, string outer_id = "")
        {
            var request = new FacePP.FaceSetRemoveFaceRequestContent()
            {
                FaceSet_Token = faceset_token,
                Outer_Id = outer_id,
                Face_Tokens = face_tokens
            };
            var response = await _proxy.Invoke<MultipartFormDataContent, FacePP.FaceSetRemoveFaceResponseContent>(request);
            return response;
        }

        /// <summary>
        /// FaceSet Remove Face 
        /// </summary>
        /// <param name="faceset_token">face set token</param>
        /// <param name="outer_id">unique custom id</param>
        /// <param name="face_tokens">face tokens</param>
        /// <returns></returns>
        public FacePP.FaceSetRemoveFaceResponseContent FaceSet_RemoveFace(string faceset_token, string face_tokens, string outer_id = "")
        {
            var response = FaceSet_RemoveFaceAsync(faceset_token, face_tokens, outer_id);
            return response.Result;
        }

        /// <summary>
        /// FaceSet Update Async
        /// </summary>
        /// <param name="faceset_token">face set token</param>
        /// <param name="outer_id">unique custom id</param>
        /// <param name="display_name">name of face set</param>
        /// <param name="new_outer_id">unique new custom id</param>
        /// <param name="tags">custom tags</param>
        /// <param name="user_data">custom information</param>
        /// <returns></returns>
        public async Task<FacePP.FaceSetUpdateResponseContent> FaceSet_UpdateAsync(string faceset_token, string display_name, string outer_id = "", string new_outer_id = "", string tags = "", string user_data = "")
        {
            var request = new FacePP.FaceSetUpdateRequestContent()
            {
                FaceSet_Token = faceset_token,
                Outer_Id = outer_id,
                Display_Name = display_name,
                New_Outer_Id = new_outer_id,
                Tags = tags,
                User_Data = user_data
            };
            var response = await _proxy.Invoke<MultipartFormDataContent, FacePP.FaceSetUpdateResponseContent>(request);
            return response;
        }

        /// <summary>
        /// FaceSet Update
        /// </summary>
        /// <param name="faceset_token">face set token</param>
        /// <param name="outer_id">unique custom id</param>
        /// <param name="display_name">name of face set</param>
        /// <param name="new_outer_id">unique new custom id</param>
        /// <param name="tags">custom tags</param>
        /// <param name="user_data">custom information</param>
        /// <returns></returns>
        public FacePP.FaceSetUpdateResponseContent FaceSet_Update(string faceset_token, string display_name, string outer_id = "", string new_outer_id = "", string tags = "", string user_data = "")
        {
            var response = FaceSet_UpdateAsync(faceset_token, display_name, outer_id, new_outer_id, tags, user_data);
            return response.Result;
        }

        /// <summary>
        /// FaceSet GetDetail Async
        /// </summary>
        /// <param name="faceset_token">face set token</param>
        /// <param name="outer_id">unique custom id</param>
        /// <param name="start">sequence in face set, [1, 1000], maybe "next" value in lastest response</param>
        /// <returns></returns>
        public async Task<FacePP.FaceSetGetDetailResponseContent> FaceSet_GetDetailAsync(string faceset_token, string outer_id = "", int? start = null)
        {
            var request = new FacePP.FaceSetGetDetailRequestContent()
            {
                FaceSet_Token = faceset_token,
                Outer_Id = outer_id,
                Start = start
            };
            var response = await _proxy.Invoke<MultipartFormDataContent, FacePP.FaceSetGetDetailResponseContent>(request);
            return response;
        }

        /// <summary>
        /// FaceSet GetDetail
        /// </summary>
        /// <param name="faceset_token">face set token</param>
        /// <param name="outer_id">unique custom id</param>
        /// <param name="start">sequence in face set, [1, 1000], maybe "next" value in lastest response</param>
        /// <returns></returns>
        public FacePP.FaceSetGetDetailResponseContent FaceSet_GetDetail(string faceset_token, string outer_id = "", int? start = null)
        {
            var response = FaceSet_GetDetailAsync(faceset_token, outer_id, start);
            return response.Result;
        }

        /// <summary>
        /// FaceSet Delete Async
        /// </summary>
        /// <param name="faceset_token">face set token</param>
        /// <param name="outer_id">unique custom id</param> 
        /// <param name="check_empty">custom information</param>
        /// <returns></returns>
        public async Task<FacePP.FaceSetDeleteResponseContent> FaceSet_DeleteAsync(string faceset_token, string outer_id = "", int? check_empty = null)
        {
            var request = new FacePP.FaceSetDeleteRequestContent()
            {
                FaceSet_Token = faceset_token,
                Outer_Id = outer_id,
                Check_Empty = check_empty
            };
            var response = await _proxy.Invoke<MultipartFormDataContent, FacePP.FaceSetDeleteResponseContent>(request);
            return response;
        }

        /// <summary>
        /// FaceSet Delete
        /// </summary>
        /// <param name="faceset_token">face set token</param>
        /// <param name="outer_id">unique custom id</param> 
        /// <param name="check_empty">custom information</param>
        /// <returns></returns>
        public FacePP.FaceSetDeleteResponseContent FaceSet_Delete(string faceset_token, string outer_id = "", int? check_empty = null)
        {
            var response = FaceSet_DeleteAsync(faceset_token, outer_id, check_empty);
            return response.Result;
        }

        /// <summary>
        /// FaceSet GetFaceSets Async
        /// </summary>
        /// <param name="tags">custom tags</param>
        /// <param name="start">sequence in face set, [1, 100], maybe "next" value in lastest response</param>
        /// <returns></returns>
        public async Task<FacePP.FaceSetGetFaceSetsResponseContent> FaceSet_GetFaceSetsAsync(string tags = "", int? start = null)
        {
            var request = new FacePP.FaceSetGetFaceSetsRequestContent()
            {
                Tags = tags,
                Start = start
            };
            var response = await _proxy.Invoke<MultipartFormDataContent, FacePP.FaceSetGetFaceSetsResponseContent>(request);
            return response;
        }

        /// <summary>
        /// FaceSet GetFaceSets
        /// </summary>
        /// <param name="tags">custom tags</param>
        /// <param name="start">sequence in face set, [1, 100], maybe "next" value in lastest response</param>
        /// <returns></returns>
        public FacePP.FaceSetGetFaceSetsResponseContent FaceSet_GetFaceSets(string tags = "", int? start = null)
        {
            var response = FaceSet_GetFaceSetsAsync(tags, start);
            return response.Result;
        }

        #endregion

        #region Face

        /// <summary>
        /// Face Analyze Async
        /// </summary>
        /// <param name="face_tokens">face tokens</param>
        /// <param name="return_landmark">whether return landmark</param>
        /// <param name="return_attributes">attributes list</param>
        /// <returns></returns>
        public async Task<FacePP.FaceAnalyzeResponseContent> Face_AnalyzeAsync(string face_tokens, int? return_landmark, string return_attributes)
        {
            var request = new FacePP.FaceAnalyzeRequestContent()
            {
                Face_Tokens = face_tokens,
                Return_Landmark = return_landmark,
                Return_Attributes = return_attributes
            };
            var response = await _proxy.Invoke<MultipartFormDataContent, FacePP.FaceAnalyzeResponseContent>(request);
            return response;
        }

        /// <summary>
        /// Face Analyze 
        /// </summary>
        /// <param name="face_tokens">face tokens</param>
        /// <param name="return_landmark">whether return landmark</param>
        /// <param name="return_attributes">attributes list</param>
        /// <returns></returns>
        public FacePP.FaceAnalyzeResponseContent Face_Analyze(string face_tokens, int? return_landmark, string return_attributes)
        {
            var response = Face_AnalyzeAsync(face_tokens, return_landmark, return_attributes);
            return response.Result;
        }

        /// <summary>
        /// Face GetDetail Async
        /// </summary>
        /// <param name="face_token">face token</param>
        /// <returns></returns>
        public async Task<FacePP.FaceGetDetailResponseContent> Face_GetDetailAsync(string face_token)
        {
            var request = new FacePP.FaceGetDetailRequestContent()
            {
                Face_Token = face_token
            };
            var response = await _proxy.Invoke<MultipartFormDataContent, FacePP.FaceGetDetailResponseContent>(request);
            return response;
        }

        /// <summary>
        /// Face GetDetail 
        /// </summary>
        /// <param name="face_token">face token</param>
        /// <returns></returns>
        public FacePP.FaceGetDetailResponseContent Face_GetDetail(string face_token)
        {
            var response = Face_GetDetailAsync(face_token);
            return response.Result;
        }

        /// <summary>
        /// Face SetUserId Async
        /// </summary>
        /// <param name="face_token">face token</param>
        /// <param name="user_id">user id</param>
        /// <returns></returns>
        public async Task<FacePP.FaceSetUserIdResponseContent> Face_SetUserIdAsync(string face_token, string user_id)
        {
            var request = new FacePP.FaceSetUserIdRequestContent()
            {
                Face_Token = face_token,
                User_Id = user_id
            };
            var response = await _proxy.Invoke<MultipartFormDataContent, FacePP.FaceSetUserIdResponseContent>(request);
            return response;
        }

        /// <summary>
        /// Face SetUserId 
        /// </summary>
        /// <param name="face_token">face token</param>
        /// <param name="user_id">user id</param>
        /// <returns></returns>
        public FacePP.FaceSetUserIdResponseContent Face_SetUserId(string face_token, string user_id)
        {
            var response = Face_SetUserIdAsync(face_token, user_id);
            return response.Result;
        }

        #endregion
    }
}