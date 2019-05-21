using System;
using System.Runtime.Serialization;

namespace Advance.Lesson_5
{
    [Serializable]
    public class InvalidCreditCalculatorParameterException<T>: Exception
    {
        public InvalidCreditCalculatorParameterException()
        {
        }

        public InvalidCreditCalculatorParameterException(string message) : base(message)
        {
        }

        public InvalidCreditCalculatorParameterException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidCreditCalculatorParameterException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public InvalidCreditCalculatorParameterException(T value, String parameter, string message) : base(message)
        {
            this.Value = value;
            this.ParameterName = parameter;
        }        

        T Value { get; set; }
        String ParameterName { get; set; }
    }
}
