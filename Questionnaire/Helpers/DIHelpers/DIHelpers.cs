using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace Questionnaire.Helpers.DIHelpers
{
    public static class DIHelpers
    {
        //register services and get services provider
        public static ServiceProvider getServiceProvider()
        {
            return new ServiceCollection()

                .BuildServiceProvider();
        }
    }
}
