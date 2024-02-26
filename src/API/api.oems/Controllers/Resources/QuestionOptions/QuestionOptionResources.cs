namespace api.oems.Controllers.Resources.QuestionOptions
{
    public class QuestionOptionResources
    {
        public int Id { get; set; }

        public string OptionA { get; set; }

        public string OptionB { get; set; }

        public string OptionC { get; set; }

        public string OptionD { get; set; }

        public string OptionE { get; set; }

        public string CorrectAnswer { get; set; }

        public int QuestionId { get; set; }

        public bool Isdeleted { get; set; }
    }
}
