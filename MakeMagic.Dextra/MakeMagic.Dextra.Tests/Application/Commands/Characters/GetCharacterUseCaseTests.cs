using MakeMagic.Dextra.Application.Commands.Characters.GetCharacter;
using MakeMagic.Dextra.Domain.Entities;
using MakeMagic.Dextra.Infrastructure.Repositories.Interfaces;
using NSubstitute;
using System;
using Xunit;

namespace MakeMagic.Dextra.Tests.Application.Commands.Characters
{
    public class GetCharacterUseCaseTests
    {
        private readonly ICharacterRepository characterRepository;
        private readonly IGetCharacterUseCase getCharacterUseCase;
        private readonly Guid id = Guid.NewGuid();
        private readonly string name = "character_name";
        private readonly string role = "character_role";
        private readonly string school = "character_school";
        private readonly string houseId = "character_houseId";
        private readonly string houseName = "character_houseName";
        private readonly string patronus = "character_patronus";
        private readonly DateTime createdAt = DateTime.UtcNow;
        private readonly DateTime updatedAt = DateTime.UtcNow;

        public GetCharacterUseCaseTests()
        {
            characterRepository = Substitute.For<ICharacterRepository>();
            getCharacterUseCase = new GetCharacterUseCase(characterRepository);
        }

        [Fact]
        public void WhenUsingAValidId_ReturnCharacter()
        {
            var validCharacter = Character.Load(
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

            characterRepository.GetCharacterAsync(id).Returns(validCharacter);

            var result = getCharacterUseCase.ExecuteAsync(id).Result;

            Assert.Equal(validCharacter.Id, result.Character.Id);
            Assert.Equal(validCharacter.Name, result.Character.Name);
            Assert.Equal(validCharacter.Role, result.Character.Role);
        }

        [Fact]
        public void WhenUsingAInvalidId_ReturnNull()
        {
            var result = getCharacterUseCase.ExecuteAsync(id).Result;

            Assert.Null(result);
        }
    }
}
