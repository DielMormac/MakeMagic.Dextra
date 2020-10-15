using System;
using System.Net;
using System.Threading.Tasks;
using MakeMagic.Dextra.Api.V1.Models.Characters.AddCharacter;
using MakeMagic.Dextra.Api.V1.Models.Characters.GetAllCharacters;
using MakeMagic.Dextra.Api.V1.Models.Characters.GetCharacter;
using MakeMagic.Dextra.Api.V1.Models.Characters.UpdateCharacter;
using MakeMagic.Dextra.Application.Commands.Characters.AddCharacter;
using MakeMagic.Dextra.Application.Commands.Characters.DeleteCharacter;
using MakeMagic.Dextra.Application.Commands.Characters.GetAllCharacters;
using MakeMagic.Dextra.Application.Commands.Characters.GetCharacter;
using MakeMagic.Dextra.Application.Commands.Characters.UpdateCharacter;
using MakeMagic.Dextra.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MakeMagic.Dextra.Api.V1.Controllers
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/character/")]
    [ApiController]
    public class CharacterController : BaseController
    {
        /// <summary>
        /// Get all characters registered to database.
        /// </summary>
        /// <param name="getAllCharactersUseCase">Service to execute the use case.</param>
        /// <returns><see cref="Task{IActionResult}"/>.</returns>
        /// <response code="200">Request executed with success.</response>
        /// <response code="400">Request could not be execute due to invalid parameters.</response>
        /// <response code="500">Request could not be executed due to internal server error.</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllCharacters(
                [FromServices] IGetAllCharactersUseCase getAllCharactersUseCase
            )
        {
            try
            {
                var result = await getAllCharactersUseCase.ExecuteAsync();

                if (result == null || result.Characters == null)
                    return NotFound();

                var response = new GetAllCharactersResponse(result.Characters);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return HandleExceptions(ex);
            }
        }

        /// <summary>
        /// Gets a character from specific Id.
        /// </summary>
        /// <param name="id">Character Id <see cref="Guid"/>.</param>
        /// <param name="getCharacterUseCase">Service to execute the use case.</param>
        /// <returns><see cref="Task{IActionResult}"/>.</returns>
        /// <response code="200">Request executed with success.</response>
        /// <response code="400">Request could not be execute due to invalid parameters.</response>
        /// <response code="500">Request could not be executed due to internal server error.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetCharacter(
                [FromRoute] Guid id,
                [FromServices] IGetCharacterUseCase getCharacterUseCase
            )
        {
            try
            {
                var result = await getCharacterUseCase.ExecuteAsync(id);

                if (result == null || result.Character == null)
                    return NotFound();

                var response = new GetCharacterResponse(result.Character);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return HandleExceptions(ex);
            }
        }

        /// <summary>
        /// Adds a character to database.
        /// </summary>
        /// <param name="request"><see cref="AddCharacterRequest"/>.</param>
        /// <param name="addCharacterUseCase">Service to execute the use case.</param>
        /// <returns><see cref="Task{IActionResult}"/>.</returns>
        /// <response code="200">Request executed with success.</response>
        /// <response code="400">Request could not be execute due to invalid parameters.</response>
        /// <response code="500">Request could not be executed due to internal server error.</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddCharacter(
            [FromBody] AddCharacterRequest request,
            [FromServices] IAddCharacterUseCase addCharacterUseCase
            )
        {
            try
            {
                var character = new Character(
                    request.Name,
                    request.Role,
                    request.School,
                    request.HouseId,
                    request.Patronus
                );

                var result = await addCharacterUseCase.ExecuteAsync(character);

                var response = new AddCharacterResponse(result.Character);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return HandleExceptions(ex);
            }
        }

        /// <summary>
        /// Update a character from a specific Id.
        /// </summary>
        /// <param name="id">Character Id <see cref="Guid"/>.</param>
        /// <param name="request"><see cref="UpdateCharacterRequest"/>.</param>
        /// <param name="updateCharacterUseCase">Service to execute the use case.</param>
        /// <returns><see cref="Task{IActionResult}"/>.</returns>
        /// <response code="200">Request executed with success.</response>
        /// <response code="400">Request could not be execute due to invalid parameters.</response>
        /// <response code="500">Request could not be executed due to internal server error.</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateCharacter(
                [FromRoute] Guid id,
                [FromBody] UpdateCharacterRequest request,
                [FromServices] IUpdateCharacterUseCase updateCharacterUseCase
            )
        {
            try
            {
                var result = await updateCharacterUseCase.ExecuteAsync(id, request.Role, request.School);

                if (result == null || result.Character == null)
                    return NotFound();

                var response = new UpdateCharacterResponse(result.Character);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return HandleExceptions(ex);
            }
        }

        /// <summary>
        /// Delete a character from a specific Id.
        /// </summary>
        /// <param name="id">Character Id <see cref="Guid"/>.</param>
        /// <param name="deleteCharacterUseCase">Service to execute the use case.</param>
        /// <returns><see cref="Task{IActionResult}"/>.</returns>
        /// <response code="200">Request executed with success.</response>
        /// <response code="400">Request could not be execute due to invalid parameters.</response>
        /// <response code="500">Request could not be executed due to internal server error.</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteCharacter(
                [FromRoute] Guid id,
                [FromServices] IDeleteCharacterUseCase deleteCharacterUseCase
            )
        {
            try
            {
                var result = await deleteCharacterUseCase.ExecuteAsync(id);

                if (result == null || result.Character == null)
                    return NotFound();

                return Ok();
            }
            catch (Exception ex)
            {
                return HandleExceptions(ex);
            }
        }
    }
}
