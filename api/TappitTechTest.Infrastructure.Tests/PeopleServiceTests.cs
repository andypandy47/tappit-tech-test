using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using NSubstitute;
using TappitTechTest.Core.Interfaces.Repositories;
using TappitTechTest.Core.Models;
using TappitTechTest.Infrastructure.Services;
using Xunit;

namespace TappitTechTest.Infrastructure.Tests
{
    public class PeopleServiceTests
    {
        [Fact]
        public async Task Get_ReturnsExpected()
        {
            //Arrange
            var personId = 1;
            var expected = new Person
            {
                Id = personId,
                FirstName = "test",
                LastName = "test",
                Authorised = false,
                Enabled = false,
                Valid = true,
                FavouriteSports = new List<SportDto>
                    {
                        new SportDto
                        {
                            SportId = 1,
                            Name = "test sport"
                        }
                    }
            };

            this.PeopleRepository.Get(personId).Returns(expected);

            var sut = this.Sut;

            //Act
            var result = await sut.Get(personId);

            //Assert
            expected.Should().BeEquivalentTo(result);
        }

        [Fact]
        public async Task GetAll_ReturnsExpected()
        {
            //Arrange
            var personId = 1;
            var expected = new List<Person>
            {
                new Person
                {
                    Id = personId,
                    FirstName = "test",
                    LastName = "test",
                    Authorised = false,
                    Enabled = false,
                    Valid = true,
                    FavouriteSports = new List<SportDto>
                        {
                            new SportDto
                            {
                                SportId = 1,
                                Name = "test sport"
                            }
                        }
                }
            };

            this.PeopleRepository.GetAll().Returns(expected);

            var sut = this.Sut;

            //Act
            var result = await sut.GetAll();

            //Assert
            expected.Should().BeEquivalentTo(result);
        }

        [Fact]
        public async Task Update_NullPersonUpdate_ThrowsNullArgumentException()
        {
            //Arrange
            var personId = 1;

            var sut = this.Sut;

            //Act / Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() => sut.Update(personId, null));

            await this.PeopleRepository.DidNotReceive().Update(Arg.Any<int>(), Arg.Any<PersonUpdate>());
            await this.FavouriteSportsRepository.DidNotReceive().Delete(Arg.Any<int>());
            await this.FavouriteSportsRepository.DidNotReceive().Add(Arg.Any<int>(), Arg.Any<int>());
        }

        [Fact]
        public async Task Update_ValidPersonUpdateEmptyFavouriteSports_CallsExpectedDependencies()
        {
            //Arrange
            var personId = 1;
            var personUpdate = new PersonUpdate
            {
                FirstName = "test",
                LastName = "test",
                Authorised = false,
                Enabled = false,
                Valid = true,
                FavouriteSports = new List<int>()
            };

            var sut = this.Sut;

            //Act / Assert
            await sut.Update(personId, personUpdate);

            await this.PeopleRepository.Received().Update(personId, personUpdate);
            await this.FavouriteSportsRepository.Received().Delete(personId);
            await this.FavouriteSportsRepository.DidNotReceive().Add(Arg.Any<int>(), Arg.Any<int>());
        }

        [Fact]
        public async Task Update_ValidPersonUpdateWithFavouriteSports_CallsExpectedDependencies()
        {
            //Arrange
            var personId = 1;
            var favouriteSportId = 1;
            var personUpdate = new PersonUpdate
            {
                FirstName = "test",
                LastName = "test",
                Authorised = false,
                Enabled = false,
                Valid = true,
                FavouriteSports = new List<int>
                {
                    favouriteSportId
                }
            };

            var sut = this.Sut;

            //Act / Assert
            await sut.Update(personId, personUpdate);

            await this.PeopleRepository.Received().Update(personId, personUpdate);
            await this.FavouriteSportsRepository.Received().Delete(personId);
            await this.FavouriteSportsRepository.Received().Add(personId, favouriteSportId);
        }

        private PeopleService Sut => new PeopleService(this.PeopleRepository, this.FavouriteSportsRepository);

        private IPeopleRepository PeopleRepository { get; } = Substitute.For<IPeopleRepository>();

        private IFavouriteSportsRepository FavouriteSportsRepository { get; } = Substitute.For<IFavouriteSportsRepository>();
    }
}
