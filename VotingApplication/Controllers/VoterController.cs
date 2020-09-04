using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http.Description;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VotingApplication.Entities;
using VotingApplication.Models.API_Models;
using VotingApplication.Services.Interfaces;
using VotingApplication.WebAPI.Extra;

namespace VotingApplication.WebAPI.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class VoterController : ControllerBase
    {
        private readonly IVoteManager VoteManager;
        private readonly IVoterManager VoterManager;

        public VoterController(IVoteManager voteManager, IVoterManager voterManager)
        {
            VoteManager = voteManager;
            VoterManager = voterManager;
        }

        /// <summary>
        /// Add a new voter
        /// </summary>
        /// <param name="model">Voter model</param>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /AddVoter
        ///     {
        ///        "name": "Voter Name",
        ///        "dob": "Voter date of birth"
        ///     }
        /// </remarks>
        /// <returns>A newly created voter</returns>
        /// <response code="201">Returns the newly created Voter</response>
        /// <response code="400">If the model is null</response> 
        [ResponseType(typeof(ContentActionResult<Voter>))]
        [HttpPost("AddVoter")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateVoter([FromBody] VoterVM model)
        {
            var result = await VoterManager.AddAsync(new Voter { Name = model.Name, DOB = model.DOB });
            return new ContentActionResult<Voter>((result == null) ? HttpStatusCode.BadRequest : HttpStatusCode.Created, result, (result == null) ? "BadRequest" : "OK", Request);
        }

        /// <summary>
        /// Voter cast vote
        /// </summary>
        /// <param name="model">Vote model</param>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST /ACastVoteddCandidate
        ///     {
        ///        "candidateId": "candidateId"
        ///        "categoryId": "categoryId"
        ///        "voterId": "voterId"
        ///     }
        /// </remarks>
        /// <returns>Vote casting status</returns>
        /// <response code="200">Returns vote casting status</response>
        /// <response code="400">If the model is null or candidateId, categoryId, voterId  doesn't exists.</response> 
        [ResponseType(typeof(ContentActionResult<string>))]
        [HttpPost("CastVote")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateVote([FromBody] VoteVM model)
        {
            var result = await VoteManager.CastVote(model.CandidateId, model.CategoryId, model.VoterId);
            return new ContentActionResult<string>((result) ? HttpStatusCode.OK : HttpStatusCode.BadRequest, result ? "Vote succesfully casted" : "Error", result ? "OK" : "BadRequest", Request);
        }

        /// <summary>
        /// Update voter
        /// </summary>
        /// <param name="model">Voter model</param>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST /UpdateVoter
        ///     {
        ///        "candidateId": "candidateId"
        ///        "categoryId": "categoryId"
        ///        "voterId": "voterId"
        ///     }
        /// </remarks>
        /// <returns>Voter update status</returns>
        /// <response code="200">Returns voter update status</response>
        /// <response code="400">If the model is null or voterId  doesn't exists.</response> 
        [ResponseType(typeof(ContentActionResult<string>))]
        [HttpPut("UpdateVoter")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateVoter([FromBody] VoterInfoVM model)
        {
            var result = await VoterManager.UpdateVoterInfo(model.VoterId, model.DOB);
            return new ContentActionResult<string>(result ? HttpStatusCode.OK : HttpStatusCode.BadRequest, result ? "Voter info updated" : "Error", result ? "OK" : "BadRequest", Request);
        }

    }
}