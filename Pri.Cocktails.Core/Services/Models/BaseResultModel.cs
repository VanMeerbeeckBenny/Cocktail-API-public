using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pri.Cocktails.Core.Services.Models
{
    public class BaseResultModel
    {
        public IEnumerable<ValidationResult> ValidationResults { get; set; }
        public bool IsSucces { get; set; }
    }
}
