using Domain.Interfaces.Email;
using Email;
using Email.Services;
using Ninject;

namespace IoC.Containers
{
    public static class EmailContainer
    {
        public static void Register(IKernel kernel)
        {
            kernel.Bind<IFaleConoscoService>().To<FaleConoscoService>();
        }
    }
}