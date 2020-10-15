using MakeMagic.Dextra.Api.V1.Models.Entities;
using System.Collections.Generic;

namespace MakeMagic.Dextra.Api.V1.Models.Characters.GetCharacter
{
    public class GetCharacterResponse
    {
        /// <summary>
        /// <see cref="Character"/>.
        /// </summary>
        public Character Result { get; set; }

        public GetCharacterResponse(Domain.Entities.Character character)
        {
            Result = new Character()
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
            };
        }
    }
}
