using EduTech.Models;

namespace EduTech.Services
{
    public class DataService : IDataService
    {
        private readonly EduTechContext _context;

        public DataService(EduTechContext context)
        {
            _context = context;
        }
    }
}
