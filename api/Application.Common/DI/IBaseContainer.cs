using System;
using App.Common.Data;

namespace App.Common.DI
{
    public interface IBaseContainer
    {
        object Instance { get; }
        void RegisterPerRequest(Type type);
        void RegisterPerRequest<IInstance>() where IInstance : class;
        void RegisterPerRequest<IInterface, TInstance>()
            where IInterface : class
            where TInstance : IInterface;

        void RegisterSingleton<IInterface, IInstance>() where IInstance : IInterface where IInterface : class;
        void RegisterSingleton<IInterface, IInstance>(string refName) where IInstance : IInterface where IInterface : class;

        void RegisterTransient(Type type);
        void RegisterTransient<IInterface, IInstance>()
            where IInstance : IInterface
            where IInterface : class;
        void RegisterTransient<IInterface, IInstance>(string refName)
            where IInstance : IInterface
            where IInterface : class;

        IInterface Resolve<IInterface>(string refName) where IInterface : class;
        IInterface Resolve<IInterface>() where IInterface : class;
        IInterface Resolve<IInterface>(IUnitOfWork unitOfWork) where IInterface : class;
    }
}
