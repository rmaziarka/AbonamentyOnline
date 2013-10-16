using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Abon.Core
{
    public class JsonModel
    {
        public JsonModel()
        {
            Errors = new List<string>();
        }
        public object Data { get; set; }

        public IEnumerable<string> Errors { get; set; }

        public bool Success
        {
            get
            {
                return  !Errors.Any();
            }
        }
    }
}