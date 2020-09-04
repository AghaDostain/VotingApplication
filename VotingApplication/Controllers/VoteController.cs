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
    public class VoteController : ControllerBase
    {
        private readonly IVoteManager VoteManager;
        private readonly IVoterManager VoterManager;

        public VoteController(IVoteManager voteManager, IVoterManager voterManager)
        {
            VoteManager = voteManager;
            VoterManager = voterManager;
        }

        /// <summary>
        /// Voter cast vote
        /// </summary>
        /// <param name="model">Vote model</param>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /AddCandidate
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
        public async Task<IActionResult> CreateCandidate([FromBody] VoteVM model)
        {
            var result = await VoteManager.CastVote(model.CandidateId, model.CategoryId, model.VoterId);
            return new ContentActionResult<string>((result) ? HttpStatusCode.OK : HttpStatusCode.BadRequest, result ? "Vote succesfully casted" : "Error", result ? "OK" : "BadRequest", Request);
        }

    }
}