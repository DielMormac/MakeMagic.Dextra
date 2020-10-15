using MakeMagic.Dextra.Domain.Entities;
using MakeMagic.Dextra.Infrastructure.EntityFrameworkDataAccess;
using MakeMagic.Dextra.Infrastructure.Repositories;
using MakeMagic.Dextra.Infrastructure.Repositories.Interfaces;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace MakeMagic.Dextra.Tests.Infrastructure.Repositories
{
    public class CharacterRepositoryTests
    {
        private readonly IContext context;
        private readonly ICharacterRepository characterRepository;
        private readonly Guid id = Guid.NewGuid();
        private readonly string name = "character_name";
        private readonly string role = "character_role";
        private readonly string school = "character_school";
        private readonly string houseId = "character_houseId";
        private readonly string houseName = "character_houseName";
        private readonly string patronus = "character_patronus";
        private readonly DateTime createdAt = DateTime.UtcNow;
        private readonly DateTime updatedAt = DateTime.UtcNow;
        private List<Character> characters;

        public CharacterRepositoryTests()
        {
            context = new Context();
            characterRepository = new CharacterRepository(context);
            characters = new List<Character>();
        }

        [Fact]
        public async void WhenGettingCharacter_ReturnCharacter()
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

            var result1 = await characterRepository.AddCharacterAsync(character);
            var result2 = await characterRepository.GetCharacterAsync(id);

            Assert.Equal(result1.Id, result2.Id);
            Assert.Equal(result1.Name, result2.Name);
            Assert.Equal(result1.UpdatedAt.ToString(), result2.UpdatedAt.ToString());
        }

        [Fact]
        public async void WhenGettingAllCharacters_ReturnCharacters()
        {
            var guid1 = Guid.NewGuid();
            var guid2 = Guid.NewGuid();

            var character1 = Character.Load(
                    guid1,
                    "name_1",
                    "role_1",
                    "school_1",
                    "houseId_1",
                    "houseName_1",
                    "patronus_1",
                    DateTime.UtcNow,
                    DateTime.UtcNow
                );

            var character2 = Character.Load(
                    guid2,
                    "name_2",
                    "role_2",
                    "school_2",
                    "houseId_2",
                    "houseName_2",
                    "patronus_2",
                    DateTime.UtcNow,
                    DateTime.UtcNow
                );

            var result1 = await characterRepository.AddCharacterAsync(character1);
            var result2 = await characterRepository.AddCharacterAsync(character2);
            var result3 = (List<Character>) await characterRepository.GetAllCharactersAsync();

            Assert.NotEmpty(result3);
        }

        [Fact]
        public async void WhenDeletingCharacter_MarkAsDeleteCharacter()
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

            var result1 = await characterRepository.AddCharacterAsync(character);
            var result2 = await characterRepository.DeleteCharacterAsync(id);
            var result3 = await characterRepository.GetCharacterAsync(id);

            Assert.Equal(result1.Id, result2.Id);
            Assert.Equal(result1.Name, result2.Name);
            Assert.Equal(result1.UpdatedAt.ToString(), result2.UpdatedAt.ToString());
            Assert.Null(result3);
        }


        [Fact]
        public async void WhenAddingCharacter_ReturnCharacter()
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

            var result = await characterRepository.AddCharacterAsync(character);

            Assert.Equal(character.Id, result.Id);
            Assert.Equal(character.Name, result.Name);
            Assert.Equal(character.UpdatedAt.ToString(), result.UpdatedAt.ToString());
        }

        [Fact]
        public async void WhenUpdatingCharacter_ReturnCharacter()
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

            var newRole = "new_role";
            var newSchool = "new_school";

            var result1 = await characterRepository.AddCharacterAsync(character);
            var result2 = await characterRepository.UpdateCharacterAsync(id, newRole, newSchool);

            Assert.NotEqual(result1.Role, result2.Role);
            Assert.NotEqual(result1.School, result2.School);
        }
    }
}
