using Microsoft.Extensions.DependencyInjection;
using System;

namespace Core.Utilities.IoC
{
    //Biz projeye startupda belli servisleri ekliyoruz. Ancak bu servislerin bazıları merkezleştirilebilir. Cache bunlardan biridir. Bunu sağlayan yapıya biz servicetool deriz. Bu yapı IoC'dur. Bu service tool bize eklenilen servislerin çağırıldığı yerde create edilerek yapılandırılmasını sağlıyor.
    public static class ServiceTool
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        public static IServiceCollection Create(IServiceCollection services)
        {
            ServiceProvider = services.BuildServiceProvider();
            return services;
        }
    }
}
