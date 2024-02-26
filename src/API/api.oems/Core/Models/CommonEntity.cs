using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.oems.Core.Models
{
    public class CommonEntity
    {
        public virtual bool? IsActive { get; set; }
        
        public virtual string CreatedBy { get; set; }

        public virtual DateTime CreatedAt { get; set; }

        public virtual string UpdatedBy { get; set; }

        public virtual DateTime UpdatedAt { get; set; }

        public virtual  bool? IsDeleted { get; set; }

        public virtual string DeletedBy { get; set; }

        public virtual DateTime DeletedAt { get; set; }
    }
}
