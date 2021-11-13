using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Mood_Analyser
{
    public class MoodAnalyserFactory
    {
        public object CreatingObjectWithMethod(string className, string constructorName)
        {
            string pattern = @"." + constructorName + "$";
            Regex regex = new Regex(pattern);
            if (regex.Match(className).Success)
            {
                try
                {
                    Assembly assembly = Assembly.GetExecutingAssembly();
                    Type classNameStore = assembly.GetType(className);
                    var obj = Activator.CreateInstance(classNameStore);
                    return obj;
                }
                catch
                {
                    throw new CustomizeException(CustomizeException.MyException.CLASS_NOT_FOUND, "Class does not exist");

                }

            }
            else
            {
                throw new CustomizeException(CustomizeException.MyException.CONSTRUCTOR_NOT_FOUND, "Class does not have such Constructor");
            }
        }
        //To create object from Parameterised Constructor
        public object CreatingParameterisedObjectWithMethod(string className, string constructorName, string[] message)
        {
            Type type = typeof(MoodAnalyser);
            if (type.Name.Equals(className) || type.FullName.Equals(className))
            {
                try
                {
                    ConstructorInfo constructorInfo = type.GetConstructor(new[] { typeof(string[]) });
                    object obj = constructorInfo.Invoke(new object[] { message });
                    return obj;
                }
                catch
                {
                    throw new CustomizeException(CustomizeException.MyException.CLASS_NOT_FOUND, "Class does not exist");

                }

            }
            else
            {
                throw new CustomizeException(CustomizeException.MyException.CONSTRUCTOR_NOT_FOUND, "Class does not have such Constructor");
            }
        }
    }
}