using System.Net;
using System.Threading.Tasks;
using System.Web.Http.Description;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VotingApplication.Entities;
using VotingApplication.Models.API_Models;
using VotingApplication.Services.Interfaces;
using VotingApplication.WebAPI.Extra;

namespace VotingApplication.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly ICandidateManager CandidateManager;
        private readonly ICategoryManager CategoryManager;
        private readonly IVoteManager VoteManager;
        private readonly IVoterManager VoterManager;

        public AdminController(ICandidateManager candidateManager, ICategoryManager categoryManager, IVoteManager voteManager, IVoterManager voterManager)
        {
            CandidateManager = candidateManager;
            CategoryManager = categoryManager;
            VoteManager = voteManager;
            VoterManager = voterManager;
        }

        /// <summary>
        /// Add a new candidate
        /// </summary>
        /// <param name="model">Candidate model</param>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /AddCandidate
        ///     {
        ///        "name": "Candidate Name"
        ///     }
        /// </remarks>
        /// <returns>A newly created candidate</returns>
        /// <response code="201">Returns the newly created candidate</response>
        /// <response code="400">If the model is null</response> 
        [ResponseType(typeof(ContentActionResult<Candidate>))]
        [HttpPost("AddCandidate")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateCandidate([FromBody] CandidateVM model)
        {
            var result = await CandidateManager.AddAsync(new Candidate { Name = model.Name });
            return new ContentActionResult<Candidate>((result == null) ? HttpStatusCode.BadRequest : HttpStatusCode.Created, result, (result == null) ? "BadRequest" : "OK", Request);
        }

        /// <summary>
        /// Add a new category
        /// </summary>
        /// <param name="model">Category model</param>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /AddCategory
        ///     {
        ///        "name": "Category Name"
        ///     }
        /// </remarks>
        /// <returns>A newly created category</returns>
        /// <response code="201">Returns the newly created category</response>
        /// <response code="400">If the model is null</response> 
        [ResponseType(typeof(ContentActionResult<Category>))]
        [HttpPost("AddCategory")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateCategory([FromBody] CategoryVM model)
        {
            var result = await CategoryManager.AddAsync(new Category { Name = model.Name });
            return new ContentActionResult<Category>((result == null) ? HttpStatusCode.BadRequest : HttpStatusCode.Created, result, (result == null) ? "BadRequest" : "OK", Request);
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
        /// Add a candidate to category
        /// </summary>
        /// <param name="model">Category model</param>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /AddCategory
        ///     {
        ///        "categoryId": "Category Id"
        ///        "candidateId": "Candidate Id"
        ///     }
        /// </remarks>
        /// <returns>A newly created category</returns>
        /// <response code="200">Returns the newly created category</response>
        /// <response code="400">If the model is null or categoryid or candidateid doesn't exists</response> 
        [ResponseType(typeof(ContentActionResult<string>))]
        [HttpPost("Candidte/AddCategory")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddCandidateCategory([FromBody] CandidateCategoryVM model)
        {
            var result = await CandidateManager.AddCandidateToCategory(model.CandidateId, model.CategoryId);
            return new ContentActionResult<string>(result ? HttpStatusCode.OK : HttpStatusCode.BadRequest, result.ToString(), result ? "OK" : "BadRequest", Request);
        }

        /// <summary>
        /// Get candidate vote count
        /// </summary>
        /// <param name="candidateId">CandidateId</param>
        /// <returns>Candidate result object</returns>
        /// <response code="200">Returns the candidate result object</response>
        [ResponseType(typeof(ContentActionResult<CandidateVoteInfoVM>))]
        [HttpGet("Candidte/{candidateId:int}/CountVote")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetCandidateVoteCount([FromQuery]int candidateId)
        {
            var result = await CandidateManager.GetVotesCountForCandidate(candidateId);
            return new ContentActionResult<CandidateVoteInfoVM>(HttpStatusCode.OK, result, "OK", Request);
        }
    }
}
