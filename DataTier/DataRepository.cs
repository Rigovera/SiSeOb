using DataTier.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DataTier
{
    public class DataRepository
    {
        public siseobEntities _siseobDB;
        public DataRepository()
        {
            _siseobDB = new siseobEntities();
        }
    }
}
