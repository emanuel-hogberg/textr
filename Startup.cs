using Microsoft.Extensions.DependencyInjection;
using StringTransforms.Interfaces;
using StringTransforms.Services;
using System.Windows.Forms;

namespace emanuel.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection ConfigureTextrServices(this IServiceCollection services) =>
            services
                .AddSingleton<IEditEventService, EditEventService>()
                .AddSingleton<ITransformService, TransformService>()
                .AddSingleton<ITransformFactoryService, TransformFactoryService>()
                .AddSingleton<ITransformMacroFactoryService, TransformMacroFactoryService>()
                .AddSingleton<Form, TextTransforms>();
    }
}
