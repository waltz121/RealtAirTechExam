﻿using Application.Commons;
using Application.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Application.UserApplication.Command
{
    public class CreateUserCommand : ICommand<UserDTO>
    {
      
        public CreateUserCommand()
        {
        }

        public void ExecuteCommand(UserDTO obj)
        {
            string responsedata = string.Empty;

            try
            {
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(UtilitySettings.WebApiUrl + "User/CreateUser");
                request.ContentType = "application/json";
                request.Method = "POST";

                using (StreamWriter streamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    string json = Newtonsoft.Json.JsonConvert.SerializeObject(obj);

                    streamWriter.Write(json);
                    streamWriter.Flush();
                }

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    Stream dataStream = response.GetResponseStream();
                    StreamReader reader = new StreamReader(dataStream);

                    responsedata = reader.ReadToEnd();

                    reader.Close();
                    dataStream.Close();
                }
            }
            catch(Exception ex)
            {
                throw new System.InvalidOperationException(ex.Message);
            }
        
        }
    }
}
