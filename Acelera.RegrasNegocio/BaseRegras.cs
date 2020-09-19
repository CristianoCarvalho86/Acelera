using Acelera.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.RegrasNegocio
{
    public abstract class BaseRegras
    {
        protected IMyLogger logger { get; set; }
        public BaseRegras(IMyLogger logger)
        {
            this.logger = logger;
        }
    }
}
