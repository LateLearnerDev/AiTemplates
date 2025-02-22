namespace Application.Common.Extensions;

public static partial class StringExtensions
{
    public static string RemoveMarkdownNewLinesAndSpaces(this string rawSql)
    {
        if (string.IsNullOrWhiteSpace(rawSql))
            return string.Empty;

        // Remove ```sql and ``` markers, and normalize spaces
        string cleanedSql = MarkdownNewLinesAndSpacesRegex().Replace(rawSql, " ")
            .Trim();

        return cleanedSql;
    }

    [System.Text.RegularExpressions.GeneratedRegex(@"```sql|```|\n|\r")]
    private static partial System.Text.RegularExpressions.Regex MarkdownNewLinesAndSpacesRegex();
}