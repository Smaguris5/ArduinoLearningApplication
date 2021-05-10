using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArduinoLearningApplication.Services.Data_Management
{
    class CreateUser
    {
        public CreateUser(string userName)
        {
            UserData user = new UserData()
            {
                name = userName
            };
            string JSONresult = JsonConvert.SerializeObject(user, Formatting.Indented);
            string path = "user.json";

            using (var tw = new StreamWriter(path, true))
            {
                tw.WriteLine(JSONresult.ToString());
                tw.Close();
            }
        }
    }
}
