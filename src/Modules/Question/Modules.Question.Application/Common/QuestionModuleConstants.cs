namespace Modules.Question.Application.Common;
public struct QuestionModuleConstants
{
    public const string SchemaName = "Question";
    public static string MigrationHistoryTableName = "__QuestionModuleMigrationHistory";

    public struct Route
    {
        public const string GetAllTags = "/api/question/tag";
        public const string GetTagDetailsById = "/api/question/tag/{tagId}";
        public const string CreateTag = "/api/question/tag";
        public const string UpdateTag = "/api/question/tag/{tagId}";
        public const string DeleteTag = "/api/question/tag/{tagId}";
    }

    public struct RouteTag
    {
        public const string TagEndPointTagName = "Tag";
    }
}
