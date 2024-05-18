using System;
using System.Collections.Generic;

namespace Common
{
    public class ResponseDTO
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public Dictionary<string, string> KeyValuePairs { get; set; }

        public ResponseDTO()
        {
            this.KeyValuePairs = new Dictionary<string, string>();
        }
    }
}
