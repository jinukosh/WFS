using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WFS.Domain;

namespace WFS.Service.Bootstrap
{
    public static class Bootstrapper
    {
        public static void Setup(Container container)
        {
            //Use Domain for register 
            WFS.Domain.Bootstrap.Bootstrapper.Setup(container);
        }
    }
}
