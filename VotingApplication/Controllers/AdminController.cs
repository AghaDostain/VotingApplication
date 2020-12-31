using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http.Description;
using VotingApplication.Entities;
using VotingApplication.Models.API_Models;
using VotingApplication.Models.ViewModel;
using VotingApplication.Services.Interfaces;
using VotingApplication.WebAPI.Extra;

namespace VotingApplication.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class AdminsController : ControllerBase
    {
        private readonly ICandidateManager _candidateManager;
        private readonly ICategoryManager _categoryManager;

        public AdminsController(ICandidateManager candidateManager, ICategoryManager categoryManager)
        {
            _candidateManager = candidateManager;
            _categoryManager = categoryManager;
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
            var result = await _candidateManager.AddAsync(new Candidate { Name = model.Name });
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
            var result = await _categoryManager.AddAsync(new Category { Name = model.Name });
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
        ///        "candidateId": "Candidate Id"
        ///        "categoryId": "Category Id"
        ///     }
        /// </remarks>
        /// <returns>A newly created category</returns>
        /// <response code="200">Returns the newly created category</response>
        /// <response code="400">If the model is null or categoryid or candidateid doesn't exists</response> 
        [ResponseType(typeof(ContentActionResult<string>))]
        [HttpPost("Candidate/Category")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddCandidateCategory([FromBody] CandidateCategoryVM model)
        {
            var result = await _candidateManager.AddCandidateToCategory(model.CandidateId, model.CategoryId);
            return new ContentActionResult<string>(result ? HttpStatusCode.OK : HttpStatusCode.BadRequest, result.ToString(), result ? "OK" : "BadRequest", Request);
        }

        /// <summary>
        /// Get candidate vote count
        /// </summary>
        /// <param name="id">CandidateId</param>
        /// <returns>Candidate result object</returns>
        /// <response code="200">Returns the candidate result object</response>
        /// <response code="400">If candidateid doesn't exists</response> 
        [ResponseType(typeof(ContentActionResult<CandidateVoteInfoVM>))]
        [HttpGet("Candidate/{Id:int}/VoteCount")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetCandidateVoteCount([FromRoute] int id)
        {
            if ((await _candidateManager.GetAsync(id)) != null)
            {
                var result = await _candidateManager.GetVotesCountForCandidate(id);
                return new ContentActionResult<CandidateVoteInfoVM>(HttpStatusCode.OK, result, "OK", Request);
            }

            return new ContentActionResult<CandidateVoteInfoVM>(HttpStatusCode.BadRequest, null, "Candidate Not Found", Request);
        }

        /// <summary>
        /// Delete candidate
        /// </summary>
        /// <param name="id">CandidateId</param>
        /// <returns>Deleteion success status</returns>
        /// <response code="200">When suucesfully deleted</response>
        /// <response code="400">If candidateid doesn't exists</response> 
        [ResponseType(typeof(ContentActionResult<string>))]
        [HttpDelete("Candidate/{Id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteCandidate([FromRoute] int id)
        {
            var candidate = await _candidateManager.GetAsync(id);

            if (candidate != null)
            {
                await _candidateManager.DeletCandidateAsync(id);
                return new ContentActionResult<string>(HttpStatusCode.OK, "Successfully deleted", "OK", Request);
            }

            return new ContentActionResult<string>(HttpStatusCode.BadRequest, null, "Candidate Not Found", Request);
        }
    }
}
