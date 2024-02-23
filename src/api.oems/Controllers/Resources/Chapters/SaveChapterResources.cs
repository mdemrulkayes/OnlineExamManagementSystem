using System.ComponentModel.DataAnnotations;

namespace api.oems.Controllers.Resources.Chapters
{
    public class SaveChapterResources
    {
        [Required(ErrorMessage = "Please enter Chapter Name")]
        public string ChapterName { get; set; }

        public string ChapterCode { get; set; }

        public bool IsDeleted { get; set; }

        [Required(ErrorMessage = "Please enter Subject Id")]
        public int SubjectId { get; set; }

        [Required(ErrorMessage = "Please enter Chapter Details")]
        public string ChapterDetails { get; set; }
    }
}
