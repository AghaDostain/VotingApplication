using System;
using System.Threading.Tasks;
using VotingApplication.Entities;

namespace VotingApplication.Services.Interfaces
{
    public interface IVoterManager : IManager<Voter>
    {
        Task<bool> UpdateVoterInfo(int voterId, DateTime dob);
    }
}
