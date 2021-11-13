using System;
using System.Collections.Generic;
using System.Text;

namespace Mood_Analyser
{
    public class CustomizeException : Exception
    {
        MyException Exception;
        public enum MyException
        {
            NULL_ARGUMENT, EMPTY_INPUT_MRSSAGE, CONSTRUCTOR_NOT_FOUND, CLASS_NOT_FOUND, METHOD_NOT_FOUND
        }

        public CustomizeException(MyException exception, string message) : base(message)
        {
            this.Exception = exception;
        }
    }
}
