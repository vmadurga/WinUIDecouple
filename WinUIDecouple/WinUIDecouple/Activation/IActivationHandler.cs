using System.Threading.Tasks;

namespace WinUIDecouple.Activation
{
    public interface IActivationHandler
    {
        bool CanHandle(object args);

        Task HandleAsync(object args);
    }
}
