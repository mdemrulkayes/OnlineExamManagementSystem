namespace Modules.Question.Application.Common;
public struct QuestionModuleConstants
{
    public const string SchemaName = "Question";
    public static string MigrationHistoryTableName = "__QuestionModuleMigrationHistory";

    public struct Route
    {
        public struct TagRoute
        {
            public const string GetAllTags = "/api/question/tag";
            public const string GetTagDetailsById = "/api/question/tag/{tagId}";
            public const string CreateTag = "/api/question/tag";
            public const string UpdateTag = "/api/question/tag/{tagId}";
            public const string DeleteTag = "/api/question/tag/{tagId}";
        }

        public struct QuestionSetRoute
        {
            public const string GetAllQuestionSets = "/api/question/questionSet";
            public const string GetQuestionSetDetailsById = "/api/question/questionSet/{tagId}";
            public const string CreateQuestionSet = "/api/question/questionSet";
            public const string UpdateQuestionSet = "/api/question/questionSet/{setId}";
            public const string DeleteQuestionSet = "/api/question/questionSet/{setId}";
        }
    }

    public struct RouteTag
    {
        public const string TagEndPointTagName = "Tag";
        public const string TagEndPointQuestionSetName = "QuestionSet";
    }
}
