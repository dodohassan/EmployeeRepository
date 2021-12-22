using System;
using System.Collections.Generic;
using System.Text;

namespace Employee.Services.IResponseServices
{
    public class ResponseObjVM<T> where T : class
    {
        public bool IsPassed { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }

        public ResponseObjVM()
        {

        }

        private ResponseObjVM(string ErrorMessage)
        {
            Message = ErrorMessage;
            IsPassed = false;
            Data = null;
        }

        public ResponseObjVM(T data, string message)
        {
            IsPassed = true;
            Data = data;
            Message = message;
        }

        public static implicit operator ResponseObjVM<T>(string ErrorMessage)
        {
            return new ResponseObjVM<T>(ErrorMessage);
        }
    }

}
