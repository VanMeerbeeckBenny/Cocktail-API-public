using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pri.Cocktails.Core.Services.Models
{
    public class AuthenticateResultModel
    {
        public bool IsSucces { get; set; }
        public IEnumerable<string> Messages { get; set; }
    }
}
