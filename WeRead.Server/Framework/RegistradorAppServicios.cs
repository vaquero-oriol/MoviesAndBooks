using App;
using Repos;
using System.Reflection;

namespace WebApi.Framework
{
    public static class RegistradorAppServicios
    {
        public static void AddAppServicios(this IServiceCollection servicios)
        {
            var assembly = Assembly.GetAssembly(typeof(TmbdService));

            var typesFromAssembly =
                assembly!.DefinedTypes.Where(x =>
                    x.Name.EndsWith("Service"));

            foreach (var type in typesFromAssembly)
            {
                servicios.AddTransient(type);
            }
        }

        //public static void AddWebServicios(this IServiceCollection servicios)
        //{
        //    var assembly = Assembly.GetAssembly(typeof(UnidadesOrganizacionSelectListItemsServicio));

        //    var typesFromAssembly =
        //        assembly!.DefinedTypes.Where(x =>
        //            x.Name.EndsWith("Servicio"));

        //    foreach (var type in typesFromAssembly)
        //    {
        //        servicios.AddTransient(type);
        //    }
        //}

        public static void AddRepositorios(this IServiceCollection servicios)
        {
            var assembly = Assembly.GetAssembly(typeof(MovieRepo));

            var typesFromAssembly =
                assembly!.DefinedTypes.Where(x =>
                    x.Name.EndsWith("Repo"));

            foreach (var type in typesFromAssembly)
            {
                servicios.AddTransient(type);
            }
        }
    }
}