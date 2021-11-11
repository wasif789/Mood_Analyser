using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mood_Analyser
{
    public class MoodAnalyser
    {
        string[] message;
        //Parameterised Constructor
        public MoodAnalyser(string[] message)
        {
            this.message = message;
        }

        public string ReturnMessage()
        {
            if (message.Contains("sad"))
            {
                return "Sad";
            }
            else
            {
                return "Happy";
            }
        }
    }
}
