using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcApplication2.Models
{
    public class EvenIntegerAttribute : DataTypeAttribute
    {
        public EvenIntegerAttribute()
            : base("EvenInteger")
        {
        }

        public override bool IsValid(object value)
        {
            int? target = value as int?;

            return target.HasValue && target.Value % 2 == 0;
        }
    }
}