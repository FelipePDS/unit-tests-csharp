namespace JornadaMilhas.Model.Interface
{
    public interface IValidator
    {
        bool IsValid { get; }
        Errors Errors { get; }
    }
}
