using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuLembrete.Core.Util
{
    [System.Serializable]
    public class LembreteValidationException : Exception
    {
        public LembreteValidationException() { }
        public LembreteValidationException(string message) : base(message) { }
        public LembreteValidationException(string message, Exception inner) : base(message, inner) { }
        protected LembreteValidationException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }

}
