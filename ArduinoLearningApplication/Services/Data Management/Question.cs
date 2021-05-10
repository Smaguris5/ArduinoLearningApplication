using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArduinoLearningApplication.Services.Data_Management
{
    class Question
    {
        public int QuestionNo { get; set; }
        public int Selection { get; set; }
        public int CorrectAnswer { get; set; }
    }
}
