using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quiziffy.Data
{
    public abstract class BaseEntity : IAudithBase
    {
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}