using Newtonsoft.Json.Linq;
using UPSAssignment.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPSAssignment.Model;
using System.Configuration;

namespace UPSAssignment.Service
{
    public class Service : IService
    {
        //private string _serviceURL = ConfigurationManager.AppSettings["ServiceApiURL"].ToString();
        //private string _token = ConfigurationManager.AppSettings["ApiToken"].ToString();
        private string _serviceURL = string.Empty;
        private string _token = string.Empty;


        LogManager.Logger _logger = new LogManager.Logger();

        public async Task<UserInfoResponse> GetUser(int userId)
        {
            UserInfoResponse userResponse = new UserInfoResponse();
            try
            {
                using (var client = new CustomRestClient(_serviceURL, _token))
                {
                    var response = await client.GetAsync<ServiceMainResponse>($"/users/{userId}");
                    if (response.Code == 200)
                    {
                        userResponse.IsSuccess = true;
                        userResponse.UserInfo = ((JObject)response.Data).ToObject<UserInfo>();

                    }
                    else if (response.Code == 404)
                    {
                        userResponse.IsSuccess = false;
                        userResponse.ErrorInfo = ((JObject)response.Data).ToObject<MessageData>().Message;
                    }
                };
            }
            catch
            {
                userResponse.IsSuccess = false;
                userResponse.ErrorInfo = Resource.Messages.ErrorMessage;
            }
            return userResponse;
        }
        public async Task<OperationResponse> DeleteUser(int userId)
        {
            OperationResponse userResponse = new OperationResponse();
            try
            {
                 using (var client = new CustomRestClient(_serviceURL, _token))
                {
                    var response = await client.DeleteAsync<ServiceMainResponse>($"/users/{userId}");
                    if (response.Code == 201 || response.Code == 204)
                    {
                        userResponse.IsSuccess = true;
                        userResponse.ErrorInfo =Resource. Messages.DeleteRecordSuccess;
                    }
                    else if (response.Code == 404)
                    {
                        userResponse.IsSuccess = false;
                        userResponse.ErrorInfo = ((JObject)response.Data).ToObject<MessageData>().Message;
                    }
                };
            }
            catch
            {
                userResponse.IsSuccess = false;
                userResponse.ErrorInfo = Resource.Messages.ErrorMessage;
            }
            return userResponse;
        }
        public async Task<UserListResponse> GetUserList(int pageno)
        {
            UserListResponse userResponse = new UserListResponse();
            try
            {
                using (var client = new CustomRestClient(_serviceURL, _token))
                {
                    var response = await client.GetAsync<ServiceMainResponse>($"/users?page={pageno}");
                    if (response.Code == 200)
                    {
                        userResponse.IsSuccess = true;
                        userResponse.UserInfoList = ((JArray)response.Data).ToObject<List<UserInfo>>();
                        userResponse.Meta = response.Meta;
                    }
                    else if (response.Code == 404)
                    {
                        userResponse.IsSuccess = false;
                        userResponse.ErrorInfo = ((JObject)response.Data).ToObject<MessageData>().Message;
                    }
                };
            }
            catch
            {
                userResponse.IsSuccess = false;
                userResponse.ErrorInfo = Resource.Messages.ErrorMessage;
            }
            return userResponse;
        }

        public async Task<OperationResponse> SaveUser(User user)
        {
            //Concurrency is managed by checking the Updated_at field. If Updated_at is having the same value then allowing to submit the record otherwise
            //returning concurrency error message.
            OperationResponse userResponse = new OperationResponse();
            ServiceMainResponse response = new ServiceMainResponse();
            try
            {
                using (var client = new CustomRestClient(_serviceURL, _token))
                {

                    if (user.ID > 0)
                    {
                        UserInfoResponse userInfoDetail = await GetUser(user.ID);

                        if (userInfoDetail.IsSuccess == false)
                        {
                            userResponse = userInfoDetail;
                        }
                        else
                        {
                            if (userInfoDetail.UserInfo.Updated_At == user.Updated_At)
                            {

                                response = await client.PutGetAsync<User, ServiceMainResponse>(user, $"/users/{user.ID}");
                            }
                            else
                            {
                                userResponse.IsSuccess = false;
                                userResponse.ErrorInfo = Resource. Messages.ConcurrencyError;
                            }
                        }
                    }
                    else
                    {
                        response = await client.PostGetAsync<User, ServiceMainResponse>(user, "/users");
                    }
                    if (response.Code == 201 || response.Code == 200)
                    {///SAVED SUCCESS
                        userResponse.IsSuccess = true;
                        userResponse.ErrorInfo = "";
                    }
                    else if (response.Code == 422)///VALIDATION FAILED
                    {
                        userResponse.IsSuccess = false;
                        userResponse.ErrorInfo = string.Join(",", ((JArray)response.Data).ToObject<List<MessageData>>().Select(m => m.ToString()).ToArray());
                    }
                    else if (response.Code == 401 || response.Code == 404)
                    {
                        userResponse.IsSuccess = false;
                        userResponse.ErrorInfo = ((JObject)response.Data).ToObject<MessageData>().Message;
                    }
                };



            }
            catch
            {
                userResponse.IsSuccess = false;
                userResponse.ErrorInfo = Resource.Messages.ErrorMessage;
            }
            return userResponse;
        }

        public async Task<UserListResponse> SearchUser(User user)
        {
            UserListResponse userResponse = new UserListResponse();
            try
            {
                string searchURL = GetSearchURL(user);
                using (var client = new CustomRestClient(_serviceURL, _token))
                {
                    var response = await client.GetAsync<ServiceMainResponse>($"/users?{searchURL}");
                    if (response.Code == 200)
                    {
                        userResponse.IsSuccess = true;
                        userResponse.UserInfoList = ((JArray)response.Data).ToObject<List<UserInfo>>();
                        userResponse.Meta = response.Meta;
                    }
                    else if (response.Code == 404)
                    {
                        userResponse.IsSuccess = false;
                        userResponse.ErrorInfo = ((JObject)response.Data).ToObject<MessageData>().Message;
                    }
                };
            }
            catch
            {
                userResponse.IsSuccess = false;
                userResponse.ErrorInfo = Resource.Messages.ErrorMessage;
            }
            return userResponse;
        }

        private string GetSearchURL(User searchParams)
        {
            string searchURL = string.Empty;

            try
            {
                var array = new[]{
                    string.Concat("id;",  searchParams.ID>0?searchParams.ID : (int?)null),
                    string.Concat("email;",  searchParams.Email),
                    string.Concat("name;", searchParams.Name),
                    string.Concat("gender;",searchParams.Gender==User.SexOfPerson.NA ? null: Convert.ToString(searchParams.Gender)),
                    string.Concat("status;",searchParams.Status == User.UserStatus.NA ?null: Convert.ToString(searchParams.Status))
                };
                for (var i = 0; i < array.Length; i++)
                {
                    string[] data = array[i].Split(';');
                    if (!string.IsNullOrEmpty(data[1]))
                        searchURL = string.Concat(searchURL, "&", data[0], "=", data[1]);
                }
                if (searchURL.StartsWith("&"))
                    searchURL = searchURL.Remove(0, 1);
            }
            catch
            {
                throw;
            }
            return searchURL;
        }

        public void SetConfiguration(string URL, string ApiKey)
        {
            _serviceURL = URL;
            _token = ApiKey;
        }
    }
}
