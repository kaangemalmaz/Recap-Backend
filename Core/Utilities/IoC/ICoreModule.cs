using Microsoft.Extensions.DependencyInjection;

namespace Core.Utilities.IoC
{
    public interface ICoreModule
    {
        //Bağımlılıkların çözüldüğü yer tüm proje içn lazım olan bağımlılığı çözdüğümüz yer module => bağımlılık çözücü.

        void Load(IServiceCollection collection);
    }
}
