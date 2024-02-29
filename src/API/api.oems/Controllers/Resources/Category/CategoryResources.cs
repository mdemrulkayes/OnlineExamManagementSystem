using System;
using System.Collections.Generic;
using api.oems.Controllers.Resources.CategoriesInInstitutes;

namespace api.oems.Controllers.Resources.Category
{
    public class CategoryResources
    {
        public int Id { get; set; }

        public string CategoryName { get; set; }

        public bool IsDeleted { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public virtual ICollection<CategoriesInInstituteResources> Institutes { get; set; }
    }
}
