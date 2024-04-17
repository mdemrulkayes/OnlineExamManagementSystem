namespace Modules.Question.Application.Common;
public struct QuestionModuleConstants
{
    public const string SchemaName = "Question";
    public static string MigrationHistoryTableName = "__QuestionModuleMigrationHistory";

    public struct Route
    {
        public const string Tag = "/api/question/tag";
    }

    public struct RouteTag
    {
        public const string TagEndPointTagName = "Tag";
    }
}
