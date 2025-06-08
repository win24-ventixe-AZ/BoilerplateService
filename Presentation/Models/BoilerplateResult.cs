namespace Presentation.Models;

public class BoilerplateResult
{
    public bool Success { get; set; }
    public string? Error { get; set; }
}

public class BoilerplateResult<T> : BoilerplateResult
{
    public T? Result { get; set; }
}

