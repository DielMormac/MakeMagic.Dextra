using MakeMagic.Dextra.Application.Commands.Characters.DeleteCharacter;
using MakeMagic.Dextra.Domain.Entities;
using MakeMagic.Dextra.Infrastructure.Repositories.Interfaces;
using NSubstitute;
using System;
using Xunit;

namespace MakeMagic.Dextra.Tests.Application.Commands.Characters
{
    public class DeleteCharacterUseCaseTests
    {
        private readonly ICharacterRepository characterRepository;
        private readonly IDeleteCharacterUseCase deleteCharacterUseCase;
        private readonly Guid id = Guid.NewGuid();
        private readonly string name = "character_name";
        private readonly string role = "character_role";
        private readonly string school = "character_school";
        private readonly string houseId = "character_houseId";
        private readonly string houseName = "character_houseName";
        private readonly string patronus = "character_patronus";
        private readonly DateTime createdAt = DateTime.UtcNow;
        private readonly DateTime updatedAt = DateTime.UtcNow;

        public DeleteCharacterUseCaseTests()
        {
            characterRepository = Substitute.For<ICharacterRepository>();
            deleteCharacterUseCase = new DeleteCharacterUseCase(characterRepository);
        }

        [Fact]
        public void WhenDeletingAValidCharacter_MarkAsDeleted()
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

            characterRepository.DeleteCharacterAsync(id).Returns(validCharacter);

            var result = deleteCharacterUseCase.ExecuteAsync(id).Result;

            Assert.Equal(validCharacter.Id, result.Character.Id);
            Assert.Equal(validCharacter.Name, result.Character.Name);
            Assert.Equal(validCharacter.Role, result.Character.Role);
        }
    }
}
