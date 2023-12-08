using Microsoft.AspNetCore.Mvc;
using PurrfectPair.Models;

namespace PurrfectPair.Services
{
    public interface IPetSubissionService 
    {
        Task<List<PetSubmission>> GetPetSubmissionsAsync();

        void AddSubmission(PetSubmission petSubmission);
    }
}
