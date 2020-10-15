using MakeMagic.Dextra.Api.V1.Models.Entities;

namespace MakeMagic.Dextra.Api.V1.Models.Characters.AddCharacter
{
    public class AddCharacterResponse
    {
        /// <summary>
        /// <see cref="Character"/>.
        /// </summary>
        public Character Result { get; set; }

        public AddCharacterResponse(Domain.Entities.Character character)
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
