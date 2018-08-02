using NewsSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsSystem.Services
{
    public class Service
    {
        private NewsSystemContext context;
        public Service()
        {
            this.context = new NewsSystemContext();
        }

        public NewsSystemContext Context => this.context;
    }
}
