using DataTier.EntityModel;

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
