using System.ComponentModel.DataAnnotations;

namespace api.oems.Controllers.Resources.Category
{
    public class SaveCategoryResources
    {
        [Required(ErrorMessage = "Please enter Category Name")]
        public string CategoryName { get; set; }

        [Required(ErrorMessage = "Please select an Institute")]
        public int[] InstituteId { get; set; }

        public bool IsDeleted { get; set; }
    }
}
