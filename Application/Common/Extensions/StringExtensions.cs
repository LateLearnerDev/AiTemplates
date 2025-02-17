namespace Application.Common.Extensions;

public static partial class StringExtensions
{
    public static string RemoveMarkdownNewLinesAndSpaces(this string rawSql)
    {
        if (string.IsNullOrWhiteSpace(rawSql))
            return string.Empty;

        return MarkdownNewLinesAndSpacesRegex().Replace(rawSql, " ")
            .Trim();
    }

    [System.Text.RegularExpressions.GeneratedRegex(@"```sql|```|\n|\r")]
    private static partial System.Text.RegularExpressions.Regex MarkdownNewLinesAndSpacesRegex();
}