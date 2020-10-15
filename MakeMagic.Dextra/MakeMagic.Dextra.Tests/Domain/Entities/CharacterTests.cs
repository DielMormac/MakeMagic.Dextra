using MakeMagic.Dextra.Domain.Entities;
using System;
using Xunit;

namespace MakeMagic.Dextra.Tests.Domain.Entities
{
    public class CharacterTests
    {
        private readonly Guid id = Guid.NewGuid();
        private readonly string name = "character_name";
        private readonly string role = "character_role";
        private readonly string school = "character_school";
        private readonly string houseId = "character_houseId";
        private readonly string houseName = "character_houseName";
        private readonly string patronus = "character_patronus";
        private readonly DateTime createdAt = DateTime.UtcNow;
        private readonly DateTime updatedAt = DateTime.UtcNow;

        [Fact]
        public void WhenInstantiatingACharacter_InstantiateCharacter()
        {


            var character = new Character(
                    name,
                    role,
                    school,
                    houseId,
                    patronus
                );

            Assert.Equal(name, character.Name);
            Assert.Equal(role, character.Role);
            Assert.Equal(school, character.School);
            Assert.Equal(houseId, character.HouseId);
            Assert.Equal(patronus, character.Patronus);
        }

        [Fact]
        public void WhenLoadingACharacter_LoadCharacter()
        {


            var character = Character.Load(
                    id,
                    name,
                    role,
                    school,
                    houseId,
                    houseName,
                    patronus,
                    createdAt,
                    updatedAt
                );

            Assert.Equal(id, character.Id);
            Assert.Equal(name, character.Name);
            Assert.Equal(role, character.Role);
            Assert.Equal(school, character.School);
            Assert.Equal(houseId, character.HouseId);
            Assert.Equal(houseName, character.HouseName);
            Assert.Equal(patronus, character.Patronus);
            Assert.Equal(createdAt, character.CreatedAt);
            Assert.Equal(updatedAt, character.UpdatedAt);
        }
    }
}
