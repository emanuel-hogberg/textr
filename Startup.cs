using StringTransforms.Interfaces;
using StringTransforms.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Windows.Forms;

namespace emanuel.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection ConfigureTextrServices(this IServiceCollection services) =>
            services
                .AddSingleton<Form, TextTransforms>()
                .AddSingleton<ITransformService, TransformService>()
                .AddSingleton<ITransformFactoryService, TransformFactoryService>()
                .AddSingleton<ITransformMacroFactoryService, TransformMacroFactoryService>();
    }
}
