using Application.Commons;
using Application.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Application.UserTaskApplication.Query
{
    public class GetAllUserTasksViaUserIdQuery : IQuery<List<UserTaskDTO>>
    {
        string AspNetUserId;
        public GetAllUserTasksViaUserIdQuery(string AspNetUserId)
        {
            this.AspNetUserId = AspNetUserId;
        }

        public List<UserTaskDTO> ExecuteQuery()
        {
            string responsedata = string.Empty;

            try
            {
                string url = UtilitySettings.WebApiUrl + "UserTask/GetAllUserTasksViaUserId";
                url = url + "?UserId=" + AspNetUserId;
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
                request.Method = "GET";

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    Stream dataStream = response.GetResponseStream();
                    StreamReader reader = new StreamReader(dataStream);

                    responsedata = reader.ReadToEnd();

                    reader.Close();
                    dataStream.Close();
                }

                return JsonConvert.DeserializeObject<List<UserTaskDTO>>(responsedata);
            }
            catch (Exception ex)
            {
                throw new System.InvalidOperationException(ex.Message);
            }
        }
    }
}
