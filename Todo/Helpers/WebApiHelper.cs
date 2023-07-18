using Todo.Extensions;
using Todo.MyModels;
using Newtonsoft.Json;
using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace Todo.Helpers
{
    public class WebApiHelper
    {
        private string baseUrl = "";
        private static readonly Lazy<WebApiHelper> LazyInstance = new Lazy<WebApiHelper>(() => new WebApiHelper());
        public static WebApiHelper Instance { get { return LazyInstance.Value; } }
        

        public async Task<ReturnValueObject> DoRequestAsync<T>(string functionCode, string queryData = null, string paramsData = "null", string ContentType = "application/x-www-form-urlencoded", int TimeOutSeconds = 300, bool ShowMask = true)
        {
            try
            {

                #region 增加自動處理參數
                var SystemToken = "OLdPFd2FdklAXXXBfBwST03MPpdRrRSl5Q18tA6NEDgLMYYeqNEwd4DE7xspdbL4";
                dynamic param = JsonConvert.DeserializeObject<dynamic>(paramsData);
                if (param == null)
                {
                    param = new { UserId = GlobalData.LoginUser?.accountid ?? "System", SysToken = SystemToken };
                }
                else if (param.UserId == null)
                {
                    param.UserId = GlobalData.LoginUser?.accountid ?? "System";
                }
                paramsData = JsonConvert.SerializeObject(param);
                #endregion

                HttpClient client = GetNewClient(ContentType, TimeOutSeconds: TimeOutSeconds, functionCode);

                var dict = new Dictionary<string, string>();
                AESHelper aesHelper = new AESHelper();
                #region 加密處理
                //if (false)  //if (ConfigHelper.GetValueByFactoryId("UseEncrypt").ToBool())  UseEncrypt == false
                //{
                //    paramsData = aesHelper.Encrypt(paramsData).Data;
                //    queryData = aesHelper.Encrypt(queryData).Data;
                //}
                #endregion

                dict.Add("Params", paramsData);
                dict.Add("Data", queryData);

                var stringPayload = JsonConvert.SerializeObject(dict);
                var content = new StringContent(stringPayload, Encoding.UTF8, "application/json");
                string urlPath = $"{baseUrl}/api/{functionCode}";
                App.oplogger.Debug($"================ FunctionCode-<{functionCode}> ================");
                App.oplogger.Debug($"Payload-<{functionCode}>-<{stringPayload}>");
                HttpResponseMessage response = await client.PostAsync(urlPath, content);
                if (response.IsSuccessStatusCode)
                {
                    response.EnsureSuccessStatusCode();

                    // Return the URI of the created resource.
                    Stream receiveStream = await response.Content.ReadAsStreamAsync();
                    StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);
                    string c = readStream.ReadToEnd();

                    #region 解密處理
                    LCMessage d;

                    //if (false) //if (ConfigHelper.GetValueByFactoryId("UseEncrypt").ToBool())  UseEncrypt == false
                    //{
                    //    d = aesHelper.Decrypt(c);
                    //}
                    //else
                    //{
                    //    d = new LCMessage() { StatusCode = LCStatusCode.OK, StatusDesc = "", Data = c };
                    //}

                    d = new LCMessage() { StatusCode = LCStatusCode.OK, StatusDesc = "", Data = c };

                    #endregion

                    var r = JsonConvert.DeserializeObject<ReturnValueObject>(d.Data);
                    App.oplogger.Debug($"Result-<{functionCode}>-<{c}>");
                    return r;
                }
                else
                {
                    // Return the URI of the created resource.
                    Stream receiveStream = await response.Content.ReadAsStreamAsync();
                    StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);
                    string c = readStream.ReadToEnd();
                    App.oplogger.Debug($"Error-<{functionCode}>-<{c}>");
                    var rtn = new ReturnValueObject { StatusCode = StatusCode.ERROR, StatusMessage = c };
                    return rtn;
                }
            }
            catch (Exception ex)
            {
                App.oplogger.Error(ex, ex.Message);
                var rtn = new ReturnValueObject { StatusCode = StatusCode.ERROR, StatusMessage = ex.Message };
                return rtn;
            }
            finally
            {
                
            }
        }

        private HttpClient GetNewClient(string ContentType, int TimeOutSeconds = 300, string FunctionCode = "")
        {
            baseUrl = "http://192.168.0.180:2870";

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(baseUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(ContentType));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", GlobalData.ApiToken);
            client.Timeout = TimeSpan.FromSeconds(TimeOutSeconds);
            return client;
        }

        public async Task<ReturnValueObject> FormDataPostAsync(APIData apiData, string functionCode)
        {
            using (HttpClientHandler handler = new HttpClientHandler())
            {
                using (HttpClient client = new HttpClient(handler))
                {
                    try
                    {
                        baseUrl = "http://192.168.0.180:2870";

                        #region 呼叫遠端 Web API
                        //string FooUrl = $"{baseUrl}/api/{functionCode}";
                        string FooUrl = $"{baseUrl}/api/{functionCode}";
                        HttpResponseMessage response = null;

                        #region  設定相關網址內容
                        var fooFullUrl = $"{FooUrl}";

                        // Accept 用於宣告客戶端要求服務端回應的文件型態 (底下兩種方法皆可任選其一來使用)
                        //client.DefaultRequestHeaders.Accept.TryParseAdd("application/json");
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                        // Content-Type 用於宣告遞送給對方的文件型態
                        //client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");

                        //https://docs.microsoft.com/zh-tw/dotnet/csharp/language-reference/keywords/nameof
                        #region 使用 MultipartFormDataContent 產生要 Post 的資料
                        // 準備要 Post 的資料
                        Dictionary<string, string> formDataDictionary = new Dictionary<string, string>()
                        {
                            {nameof(APIData.Id), apiData.Id.ToString() },
                            {nameof(APIData.Name), apiData.Name },
                            {nameof(APIData.FilePath), apiData.FilePath },
                            {nameof(APIData.Updator), apiData.Updator }
                        };

                        // https://msdn.microsoft.com/zh-tw/library/system.net.http.multipartformdatacontent(v=vs.110).aspx

                        using (var content = new MultipartFormDataContent())
                        {
                            foreach (var keyValuePair in formDataDictionary)
                            {
                                content.Add(new StringContent(keyValuePair.Value), keyValuePair.Key);
                            }
                            using (var stream = File.OpenRead(apiData.FilePath))
                            {
                                using (var streamContent = new StreamContent(stream))
                                {
                                    content.Add(streamContent, "File", apiData.Name);
                                    response = await client.PostAsync(fooFullUrl, content);
                                }
                            }
                        }
                        #endregion

                        #endregion
                        #endregion

                        #region 處理呼叫完成 Web API 之後的回報結果
                        Stream receiveStream = await response.Content.ReadAsStreamAsync();
                        StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);
                        string c = readStream.ReadToEnd();

                        #region 解密處理
                        AESHelper aesHelper = new AESHelper();
                        LCMessage d;
                        if (false)
                        {
                            d = aesHelper.Decrypt(c);
                        }
                        else
                        {
                            d = new LCMessage() { StatusCode = LCStatusCode.OK, StatusDesc = "", Data = c };
                        }
                        #endregion


                        return JsonConvert.DeserializeObject<ReturnValueObject>(d.Data);
                        #endregion
                    }
                    catch (Exception ex)
                    {
                        var rtn = new ReturnValueObject { StatusCode = StatusCode.ERROR, StatusMessage = ex.Message };
                        return rtn;
                    }
                    finally
                    {
                        
                    }
                }
            }
        }
    }

    public class APIResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public Exception Payload { get; set; }
    }

    public class APIData
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string FilePath { get; set; }
        public string Updator { get; set; } = "";
    }

    public class ReturnValueObject
    {

        private StatusCode _StatusCode;
        public StatusCode StatusCode
        {
            get { return _StatusCode; }
            set
            {
                if (value == _StatusCode)
                    return;

                _StatusCode = value;
            }
        }


        private string _StatusMessage;
        public string StatusMessage
        {
            get { return _StatusMessage; }
            set
            {
                if (value == _StatusMessage)
                    return;

                _StatusMessage = value;
            }
        }


        private string _APIVersion;
        public string APIVersion
        {
            get { return _APIVersion; }
            set
            {
                if (value == _APIVersion)
                    return;

                _APIVersion = value;
            }
        }


        private dynamic _Detail;
        public dynamic Detail
        {
            get { return _Detail; }
            set
            {
                if (value == _Detail)
                    return;

                _Detail = value;
            }
        }

        public T GetResult<T>(Action ifNotOkAction = null)
        {
            if (this.StatusCode == StatusCode.OK) 
            {
                if (Object.ReferenceEquals(null, Detail)) // 檢查dynamic是否為null
                {
                    return default(T);
                }
                else
                {
                    string s = Detail.ToString();
                    return s.DeSerialize<T>();
                }
            }
            else
            {
                if(ifNotOkAction != null)
                {
                    ifNotOkAction();
                }
                return default(T);
            }
        }
    }

    public enum StatusCode
    {
        OK = 0,
        INVALID_PARAMETERS = 1,
        EMPTYRECORD = 2,
        DATAEXISTED = 3,
        JOBDONE = 11,
        LOADDONE = 12,
        DATA_DECRYPT_ERROR = 21,
        DATA_ENCRYPT_ERROR = 22,
        ERROR = 9999,
    }

    #region LCMessage
    public enum LCStatusCode
    {
        ERROR = -1,
        EMPTYRECORD = -2,
        OK = 0
    }

    public class LCMessage
    {

        private LCStatusCode _StatusCode;
        public LCStatusCode StatusCode
        {
            get { return _StatusCode; }
            set
            {
                if (value == _StatusCode)
                    return;

                _StatusCode = value;
            }
        }


        private string _StatusDesc;
        public string StatusDesc
        {
            get { return _StatusDesc; }
            set
            {
                if (value == _StatusDesc)
                    return;

                _StatusDesc = value;
            }
        }


        private string _Data;
        public string Data
        {
            get { return _Data; }
            set
            {
                if (value == _Data)
                    return;

                _Data = value;
            }
        }

    }
    #endregion
}
