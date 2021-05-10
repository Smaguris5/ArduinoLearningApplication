using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Newtonsoft.Json;

namespace ArduinoLearningApplication.Services.Data_Management
{
    class QuestionWriter
    {
        public QuestionWriter(int questionNo, int selection, int correctAnswer)
        {
            Question question = new Question()
            {
                QuestionNo = questionNo,
                Selection = selection,
                CorrectAnswer = correctAnswer
            };
            List<Question> questions = new List<Question>();
            questions.Add(question);
            string JSONresult = JsonConvert.SerializeObject(questions, Formatting.Indented);
            string path = "questionnaire.json";

            if(File.Exists(path))
            {
                questions = JsonConvert.DeserializeObject<List<Question>>(File.ReadAllText(path));
                questions.Add(question);
                JSONresult = JsonConvert.SerializeObject(questions, Formatting.Indented);
                File.Delete(path);
            }
            using (var tw = new StreamWriter(path, true))
            {
                tw.WriteLine(JSONresult.ToString());
                tw.Close();
            }
        }
    }
}
