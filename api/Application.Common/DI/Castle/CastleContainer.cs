using System;
using Castle.Windsor;
using Castle.MicroKernel.Registration;
using App.Common.Data;

namespace App.Common.DI.Castle
{
    public class CastleContainer : IBaseContainer
    {
        #region Constructor and Private
        private readonly IWindsorContainer windsorContainer;
        public CastleContainer(IWindsorContainer windsorContainer)
        {
            this.windsorContainer = windsorContainer;
        }
        #endregion

        #region Singleton
        public void RegisterSingleton<TInterface, TInstance>()
            where TInterface : class
            where TInstance : TInterface
        {
            windsorContainer.Register(Component.For<TInterface>().ImplementedBy<TInstance>());
        }

        public void RegisterSingleton<TInterface, TInstance>(string refName)
            where TInterface : class
            where TInstance : TInterface
        {
            windsorContainer.Register(Component.For<TInterface>().ImplementedBy<TInstance>().Named(refName));
        }
        #endregion

        #region Transient
        public void RegisterTransient(Type type)
        {
            windsorContainer.Register(Component.For(type).LifestyleTransient());
        }

        public void RegisterTransient<TInterface, TInstance>()
            where TInterface : class
            where TInstance : TInterface
        {
            windsorContainer.Register(Component.For<TInterface>().ImplementedBy<TInstance>().LifestyleTransient());
        }

        public void RegisterTransient<TInterface, TInstance>(string refName)
            where TInterface : class
            where TInstance : TInterface
        {
            windsorContainer.Register(Component.For<TInterface>().ImplementedBy<TInstance>().Named(refName).LifestyleTransient());
        }
        #endregion

        #region PerRequest
        public void RegisterPerRequest<TInstance>() where TInstance : class
        {
            windsorContainer.Register(Component.For<TInstance>().LifestylePerWebRequest());
        }
        public void RegisterPerRequest(Type type)
        {
            windsorContainer.Register(Component.For(type).LifestylePerWebRequest());
        }

        public void RegisterPerRequest<TInterface, TInstance>() 
            where TInterface: class 
            where TInstance: TInterface
        {
            windsorContainer.Register(Component.For<TInterface>().ImplementedBy<TInstance>().LifestylePerWebRequest());
        }

        #endregion

        #region Resolve
        public TInterface Resolve<TInterface>(string refName) where TInterface : class
        {
            return windsorContainer.Resolve<TInterface>(refName);
        }
        public TInterface Resolve<TInterface>() where TInterface : class
        {
            return windsorContainer.Resolve<TInterface>();
        }
        public TInterface Resolve<TInterface>(IUnitOfWork unitOfWork) where TInterface : class
        {
            return windsorContainer.Resolve<TInterface>(new { uow = unitOfWork });
        }
        #endregion

        public object Instance {
            get
            {
                return this.windsorContainer;    
            }
        }
    }
}
