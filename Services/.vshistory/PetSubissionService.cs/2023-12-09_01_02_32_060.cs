using Microsoft.EntityFrameworkCore;
using PurrfectPair.Data;
using PurrfectPair.Models;

namespace PurrfectPair.Services
{
    public class PetSubissionService : IPetSubissionService
    {
        private List<PetSubmission> _submissions;
        private ApplicationDbContext _appDbContext;

        //app db context
        public PetSubissionService(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            _submissions = new List<PetSubmission>();
        }

        public async Task<List<PetSubmission>> GetPetSubmissionsAsync()
        {
            var petsubmissions = await _appDbContext.PetSubmissions.ToListAsync();
            return petsubmissions;
        }

        public List<PetSubmission> GetPetSubmissions()
        {
            return _submissions;
        }

        public void AddPetSubmission(PetSubmission petsubmission)
        {
            //_appDbContext.Pet
        }

        public void AddSubmission(PetSubmission petSubmission)
        {
            throw new NotImplementedException();
        }
    }
}
