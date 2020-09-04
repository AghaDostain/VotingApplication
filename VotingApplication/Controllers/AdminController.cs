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
    public class AdminsController : ControllerBase
    {
        private readonly ICandidateManager CandidateManager;
        private readonly ICategoryManager CategoryManager;

        public AdminsController(ICandidateManager candidateManager, ICategoryManager categoryManager)
        {
            CandidateManager = candidateManager;
            CategoryManager = categoryManager;
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
        [HttpPost("Candidate")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateCandidate([FromBody] CandidateVM model)
        {
            var result = await CandidateManager.AddAsync(new Candidate { Name = model.Name });
            return new ContentActionResult<Candidate>((result == null) ? HttpStatusCode.BadRequest : HttpStatusCode.Created, result, (result == null) ? "BadRequest" : "Created", Request);
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
        [HttpPost("Category")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateCategory([FromBody] CategoryVM model)
        {
            var result = await CategoryManager.AddAsync(new Category { Name = model.Name });
            return new ContentActionResult<Category>((result == null) ? HttpStatusCode.BadRequest : HttpStatusCode.Created, result, (result == null) ? "BadRequest" : "Created", Request);
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
        [HttpPost("Candidte/Category")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddCandidateCategory([FromBody] CandidateCategoryVM model)
        {
            var result = await CandidateManager.AddCandidateToCategory(model.CandidateId, model.CategoryId);
            return new ContentActionResult<string>(result ? HttpStatusCode.Created : HttpStatusCode.BadRequest, result.ToString(), result ? "Created" : "BadRequest", Request);
        }

        /// <summary>
        /// Get candidate vote count
        /// </summary>
        /// <param name="Id">CandidateId</param>
        /// <returns>Candidate result object</returns>
        /// <response code="200">Returns the candidate result object</response>
        [ResponseType(typeof(ContentActionResult<CandidateVoteInfoVM>))]
        [HttpGet("Candidte/{Id:int}/VoteCount")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetCandidateVoteCount([FromQuery]int Id)
        {
            var result = await CandidateManager.GetVotesCountForCandidate(Id);
            return new ContentActionResult<CandidateVoteInfoVM>(HttpStatusCode.OK, result, "OK", Request);
        }
    }
}
