using System;
using System.Collections.Generic;
using System.Text;

namespace Employee.Services.IResponseServices
{
    public class ResponseListVM<T> where T : class
    {
        public bool IsPassed { get; set; }
        public string Message { get; set; }
        public IEnumerable<T> Data { get; set; }
        public dynamic Extra { get; set; }

        public ResponseListVM()
        {

        }

        private ResponseListVM(string ErrorMessage)
        {
            Message = ErrorMessage;
            IsPassed = false;
            Data = null;
        }

        public ResponseListVM(IEnumerable<T> data, string message)
        {
            IsPassed = true;
            Message = message;
            Data = data;
        }

        public static implicit operator ResponseListVM<T>(string ErrorMessage)
        {
            return new ResponseListVM<T>(ErrorMessage);
        }
    }
}
