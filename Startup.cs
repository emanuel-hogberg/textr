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
                .AddSingleton<IMathService, MathService>()
                .AddSingleton<IEditEventService, EditEventService>()
                .AddSingleton<ITransformService, TransformService>()
                .AddSingleton<ITransformFactoryService, TransformFactoryService>()
                .AddSingleton<IMacroFactoryService, MacroFactoryService>()
                .AddSingleton<Form, TextTransforms>();
    }
}
