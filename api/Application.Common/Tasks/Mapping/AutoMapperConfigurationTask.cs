using System;
using System.Linq;
using App.Common.Mapping;
using System.Reflection;
using System.Web;
using App.Common.Helpers;
using AutoMapper;

namespace App.Common.Tasks.Mapping
{
    public class AutoMapperConfigurationTask : BaseTask<TaskArgument<System.Web.HttpApplication>>, IApplicationStartedTask<TaskArgument<System.Web.HttpApplication>>
    {
        public AutoMapperConfigurationTask():base(ApplicationType.All)
        {
        }
        public override void Execute(TaskArgument<System.Web.HttpApplication> arg)
        {
            if (!this.IsValid(arg.Type)) { return; }

            var types = AssemblyHelper.GetAllApplicationTypes();
            //var types = Assembly.Load("Application.Common").GetTypes().ToList();
            //types.AddRange(Assembly.Load("Omega.Context").GetTypes());
            ConfigStandardMappings(types.ToArray());
        }

        private static void ConfigStandardMappings(Type[] types)
        {
            var maps = (from type in types
                        from i in type.GetInterfaces()
                        where i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMappedFrom<>)
                        && !type.IsAbstract && !type.IsInterface
                        select new
                        {
                            Source = i.GenericTypeArguments[0],
                            Dest = type
                        }).ToArray();
            foreach (var map in maps)
            {
                AutoMapper.Mapper.CreateMap(map.Source, map.Dest);
                AutoMapper.Mapper.CreateMap(map.Dest, map.Source);
            }
        }
        //public static IMappingExpression<TSource, TDestination> IgnoreAllNonExisting<TSource, TDestination>(this IMappingExpression<TSource, TDestination> expression)
        //{
        //    var sourceType = typeof(TSource);
        //    var destinationType = typeof(TDestination);
        //    var existingMaps = Mapper.GetAllTypeMaps().First(x => x.SourceType.Equals(sourceType)
        //        && x.DestinationType.Equals(destinationType));
        //    foreach (var property in existingMaps.GetUnmappedPropertyNames())
        //    {
        //        expression.ForMember(property, opt => opt.Ignore());
        //    }
        //    return expression;
        //}
    }
}
