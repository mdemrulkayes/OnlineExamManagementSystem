using System.ComponentModel.DataAnnotations;

namespace api.oems.Core.Models
{
    public class QuestionType
    {
        [Key]
        public int Id { get; set; }

        public string Type { get; set; }
    }
}
