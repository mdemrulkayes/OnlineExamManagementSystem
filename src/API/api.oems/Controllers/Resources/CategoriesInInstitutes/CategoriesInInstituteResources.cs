﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.oems.Controllers.Resources.CategoriesInInstitutes
{
    public class CategoriesInInstituteResources
    {
        public int Id { get; set; }

        public int InstituteId { get; set; }

        public int CategoryId { get; set; }
    }
}