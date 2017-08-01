using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Utilidades
{
    public class MisExcepciones : Exception
    {
        public MisExcepciones()
            : base()
        {
        }

        public MisExcepciones(String message)
            : base(message)
        {
        }

        public MisExcepciones(String message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected MisExcepciones(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {

        }
    }
}
