using Application.Commons;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Application.UserTaskApplication.Command
{
    public class MarkUserTaskAsDoneCommand : ICommand<int>
    {
        public void ExecuteCommand(int obj)
        {
            string responsedata = string.Empty;

            try
            {
                string url = UtilitySettings.WebApiUrl + "UserTask/UserTaskMarkAsDone";
                url = url + "?id=" + obj;
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
            }
            catch (Exception ex)
            {
                throw new System.InvalidOperationException(ex.Message);
            }
        }
    }
}
