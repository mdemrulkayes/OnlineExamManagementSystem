using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.oems.Controllers.Resources.Category;

namespace api.oems.Controllers.Resources.Subjects
{
    public class SubjectResources
    {
        public int Id { get; set; }

        public string SubjectName { get; set; }

        public string SubjectCode { get; set; }

        public string CreatedBy { get; set; }

        public int CategoryId { get; set; }

        public DateTime CreatedDate { get; set; }

        public string UpdatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }

        public bool IsDeleted { get; set; }

        public virtual CategoryResources Category { get; set; }
    }
}
