using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class LogRepository
    {
        private readonly BookStoreContext context;
        public LogRepository(BookStoreContext context_)
        {
            context = context_;
        }
        public async Task Agregar(Log log)
        {
            using (context)
            {
                context.Logs.Add(log);
                await context.SaveChangesAsync();
            }
        }
    }
}
