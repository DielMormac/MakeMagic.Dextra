using MakeMagic.Dextra.Application.Commands.Characters.GetAllCharacters;
using MakeMagic.Dextra.Domain.Entities;
using MakeMagic.Dextra.Infrastructure.Repositories.Interfaces;
using NSubstitute;
using System;
using System.Collections.Generic;
using Xunit;

namespace MakeMagic.Dextra.Tests.Application.Commands.Characters
{
    public class GetAllCharactersUseCaseTests
    {
        private readonly ICharacterRepository characterRepository;
        private readonly IGetAllCharactersUseCase getAllCharactersUseCase;
        private List<Character> characters;

        public GetAllCharactersUseCaseTests()
        {
            characterRepository = Substitute.For<ICharacterRepository>();
            getAllCharactersUseCase = new GetAllCharactersUseCase(characterRepository);

            characters = new List<Character>();
        }

        [Fact]
        public void WhenDataBaseContainsResults_ReturnFullList()
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

            characters.Add(character1);
            characters.Add(character2);

            characterRepository.GetAllCharactersAsync().Returns(characters);

            var result = getAllCharactersUseCase.ExecuteAsync().Result;

            Assert.NotEmpty(result.Characters);
            Assert.Equal(character1.Id, result.Characters[0].Id);
            Assert.Equal(character2.Id, result.Characters[1].Id);
            Assert.Equal(character1.CreatedAt.ToString(), result.Characters[0].CreatedAt.ToString());
            Assert.Equal(character2.CreatedAt.ToString(), result.Characters[1].CreatedAt.ToString());
        }

        [Fact]
        public void WhenDataBaseIsEmpty_ReturnEmptyList()
        {
            var result = getAllCharactersUseCase.ExecuteAsync().Result;

            Assert.Empty(result.Characters);
        }
    }
}
