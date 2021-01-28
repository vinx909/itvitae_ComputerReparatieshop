using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComputerReparatieshop.Data.Models;

namespace ComputerReparatieshop.Data.Services
{
    public class InMemoryStatusData : IStatusData
    {
        private List<Status> statuses;

        public InMemoryStatusData()
        {
            statuses = new List<Status>()
            {
                new Status(){Id=0, StatusDescription="in afwachting"},
                new Status(){Id=1, StatusDescription="in behandeling"},
                new Status(){Id=2, StatusDescription="wacht op onderdelen"},
                new Status(){Id=3, StatusDescription="klaar"}
            };
        }

        public Status Get(int id)
        {
            return statuses.Find(s => s.Id == id);
        }

        public IEnumerable<Status> GetAll()
        {
            return statuses;
        }
    }
}
