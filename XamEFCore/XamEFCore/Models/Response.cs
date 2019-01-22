using System;
using System.Collections.Generic;
using System.Text;

namespace XamEFCore.Models
{
    public class Response
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public int StatusCode { get; set; }
        public object DataResult { get; set; }
        public object ConnectionType { get; set; }
    }
}
