using DevIO.UI.Site.Interfaces;

namespace DevIO.UI.Site.Data
{
    public class Operation : IOperationTransient, IOperationScoped, IOperationSingleton
    {
        public Operation()
        {
            OperationId = Guid.NewGuid().ToString()[^4..];
        }

        public string OperationId { get; }
    }
}
