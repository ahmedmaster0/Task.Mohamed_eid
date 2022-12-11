using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Task.Mohamed_eid.Models
{
    public class BaseModel
    {
        public int Id { get; set; }

        [Display(Name="الاسم")]
        [StringLength(100,ErrorMessage ="اقصي عدد 100 حرف")]
        public string Name { get; set; }
    }
}
