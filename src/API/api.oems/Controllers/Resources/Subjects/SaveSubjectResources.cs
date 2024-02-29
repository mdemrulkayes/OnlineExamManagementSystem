using System.ComponentModel.DataAnnotations;

namespace api.oems.Controllers.Resources.Subjects
{
    public class SaveSubjectResources
    {
        [Required(ErrorMessage = "Please enter Subject Name")]
        public string SubjectName { get; set; }

        [Required(ErrorMessage = "Please enter Subject Code")]
        public string SubjectCode { get; set; }

        [Required(ErrorMessage = "Please enter Category")]
        public int CategoryId { get; set; }

        public bool IsDeleted { get; set; }
    }
}
