using MakeMagic.Dextra.Api.V1.Models.Entities;
using System.Collections.Generic;

namespace MakeMagic.Dextra.Api.V1.Models.Characters.GetAllCharacters
{
    public class GetAllCharactersResponse
    {
        /// <summary>
        /// <see cref="List{Character}"/>.
        /// </summary>
        public List<Character> Result { get; set; }

        public GetAllCharactersResponse(List<Domain.Entities.Character> characters)
        {
            Result = new List<Character>();

            foreach (var character in characters)
            {
                Result.Add(
                    new Character()
                    {
                        Id = character.Id,
                        Name = character.Name,
                        Role = character.Role,
                        HouseId = character.HouseId,
                        HouseName = character.HouseName,
                        School = character.School,
                        Patronus = character.Patronus,
                        CreatedAt = character.CreatedAt,
                        UpdatedAt = character.UpdatedAt
                    }
                );
            }
        }
    }
}
