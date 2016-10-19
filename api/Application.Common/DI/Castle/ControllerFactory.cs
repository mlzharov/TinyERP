using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Castle.MicroKernel;
using App.Common.Logging;

namespace App.Common.DI.Castle
{
    public class ControllerFactory : DefaultControllerFactory
    {
        private readonly IKernel kernel;
        public ControllerFactory(IKernel kernel )
        {
            this.kernel = kernel;
        }

        public override void ReleaseController(IController controller)
        {
            kernel.ReleaseComponent(controller);
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            if (controllerType == null)
            {
                throw new HttpException(404, string.Format("The controller for path '{0}' could not be found.", requestContext.HttpContext.Request.Path));
            }
            IController controller;
            try
            {
                controller = kernel.Resolve(controllerType) as IController;
            }
            catch (Exception ex)
            {
                controller = base.GetControllerInstance(requestContext, controllerType);
            }
            return controller;
        }
    }
}
