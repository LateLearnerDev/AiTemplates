namespace Application.OpenAi.Completions.Exceptions;

public class CompletionResponseNullException : Exception
{
    public override string Message => "Completion returned null.";
}