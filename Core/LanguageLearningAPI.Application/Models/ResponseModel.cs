using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageLearningAPI.Application.Models
{
    public class ResponseModel<T>
    {
        public T Data { get; set; }
        public int StatusCode { get; set; }

    }
}
