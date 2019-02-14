namespace Cosmos.Validations.Abstractions
{
    public interface IValidationHandler
    {
        void Handle(ValidationResultCollection results);
    }
}