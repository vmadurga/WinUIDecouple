using System.Threading.Tasks;

namespace WinUIDecouple.Contracts.Services
{
    public interface IActivationService
    {
        Task ActivateAsync(object activationArgs);
    }
}
