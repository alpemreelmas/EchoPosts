using Applciation.Abstract;
using Application.Concrete;
using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Persistence.Concrete.EntityFramework;
using Persistence.Abstract;
using System.Reflection;
using Module = Autofac.Module;
using Application.ValidationRules.FluentValidation;
using Autofac.Core;
using FluentValidation;
using Microsoft.AspNetCore.Hosting;
using Application.Dtos;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterType<CategoryManager>().As<ICategoryService>().SingleInstance();
            builder.RegisterType<EfCategoryDal>().As<ICategoryDal>().SingleInstance();

        }
    }
}
