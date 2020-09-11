using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace UPSAssignment.Service
{
    public class CustomRestClient : IDisposable
    {
        private bool _disposed;
        private string _serviceURL = string.Empty;
        private string _authorizationKey = string.Empty;

        public string Response { get; set; }
        public CustomRestClient(string baseServiceURL, string authorizationKey)
        {
            _serviceURL = baseServiceURL;
            _authorizationKey = authorizationKey;
        }

        private async Task<HttpClient> GetClient()
        {
            HttpClient client = new HttpClient();
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                ServicePointManager.ServerCertificateValidationCallback +=
                    (sender, cert, chain, sslPolicyErrors) => { return true; };

                
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + _authorizationKey);
                client.BaseAddress = new Uri(_serviceURL);

                //client.DefaultRequestHeaders.Add("authorization-key", AuthorizationKey);
            }
            catch (Exception)
            {

                throw;
            }
          

            return client;
        }

        public async Task<T2> PostGetAsync<T1, T2>(T1 type, string methodName)
        {
            object responseResult = null;
            try
            {
                using (var httpClient = await GetClient())
                {
                    httpClient.MaxResponseContentBufferSize = 256000;
                    var json = JsonConvert.SerializeObject(type);
                    using (HttpContent httpContent = new StringContent(json, Encoding.UTF8))
                    {
                        httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                        HttpResponseMessage result = await httpClient.PostAsync(_serviceURL + methodName, httpContent);
                        var _ObjResponseStr = Response = await result.Content.ReadAsStringAsync();
                        responseResult = JsonConvert.DeserializeObject<T2>(_ObjResponseStr);
                    }
                }
            }
            catch (HttpRequestException e)
            {
                throw e;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return (T2)responseResult;
        }

        public async Task<T2> PutGetAsync<T1, T2>(T1 type, string methodName)
        {
            object responseResult = null;
            try
            {
                using (var httpClient = await GetClient())
                {
                    httpClient.MaxResponseContentBufferSize = 256000;
                    var json = JsonConvert.SerializeObject(type);
                    using (HttpContent httpContent = new StringContent(json, Encoding.UTF8))
                    {
                        httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                        HttpResponseMessage result = await httpClient.PutAsync(_serviceURL + methodName, httpContent);
                        var _ObjResponseStr = Response = await result.Content.ReadAsStringAsync();
                        responseResult = JsonConvert.DeserializeObject<T2>(_ObjResponseStr);
                    }
                }
            }
            catch (HttpRequestException e)
            {
                throw e;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return (T2)responseResult;
        }

        public async Task<T> DeleteAsync<T>(string methodName)
        {
            object responseResult = null;
            try
            {
                using (var httpClient = await GetClient())
                {
                    HttpResponseMessage result = await httpClient.DeleteAsync(_serviceURL + methodName);
                    var objResponseStr = Response = await result.Content.ReadAsStringAsync();
                    responseResult = JsonConvert.DeserializeObject<T>(objResponseStr);
                }
            }
            catch (HttpRequestException e)
            {
                throw e;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return (T)responseResult;
        }

        public async Task<T> GetAsync<T>(string methodName)
        {
            object responseResult = null;
            try
            {
                using (var httpClient = await GetClient())
                {
                    HttpResponseMessage result = await httpClient.GetAsync(_serviceURL + methodName);
                    var objResponse = Response = await result.Content.ReadAsStringAsync();
                    responseResult = JsonConvert.DeserializeObject<T>(objResponse);
                }
            }
            catch (HttpRequestException e)
            {
                throw e;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return (T)responseResult;
        }

        public async Task<string> GetAsync(string methodName)
        {
            try
            {
                using (var httpClient = await GetClient())
                {
                    HttpResponseMessage result = await httpClient.GetAsync(_serviceURL + methodName);
                    var objResponse = Response = await result.Content.ReadAsStringAsync();
                    return (objResponse);
                }
            }
            catch (HttpRequestException e)
            {
                throw e;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing || this._disposed)
            {
                return;
            }

            this._disposed = true;
        }
    }
}
