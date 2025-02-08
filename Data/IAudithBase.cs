using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quiziffy.Data
{
    public class IAudithBase
    {
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}