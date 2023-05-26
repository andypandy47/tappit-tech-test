using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using TappitTechTest.Api.Controllers;
using TappitTechTest.Core.Interfaces.Services;
using TappitTechTest.Core.Models;
using Xunit;

namespace TappitTechTest.Api.Tests
{
    public class PeopleControllerTests
    {
        [Fact]
        public async Task GetAll_ReturnsOk()
        {
            //Arrange
            var expected = new List<Person>
            {
                new Person
                {
                    Id = 1,
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

            this.PeopleService.GetAll().Returns(expected);

            var sut = this.Sut;

            //Act
            var response = await sut.GetAll();

            //Assert
            var result = Assert.IsType<OkObjectResult>(response);

            expected.Should().BeEquivalentTo((List<Person>)result.Value);
        }

        [Fact]
        public async Task Get_PersonDoesNotExist_ReturnsNotFound()
        {
            //Arrange
            var personId = 1;

            var sut = this.Sut;

            //Act
            var response = await sut.Get(personId);

            //Assert
            Assert.IsType<NotFoundResult>(response);

            await this.PeopleService.Received().Get(personId);
        }

        [Fact]
        public async Task Get_PersonExists_ReturnsOk()
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

            this.PeopleService.Get(personId).Returns(expected);

            var sut = this.Sut;

            //Act
            var response = await sut.Get(personId);

            //Assert
            var result = Assert.IsType<OkObjectResult>(response);

            expected.Should().BeEquivalentTo(result.Value);

            await this.PeopleService.Received().Get(personId);
        }

        [Fact]
        public async Task Update_NullPersonUpdated_ReturnsBadRequest()
        {
            //Arrange
            var personId = 1;

            var sut = this.Sut;

            //Act
            var response = await sut.Update(personId, null);

            //Assert
            Assert.IsType<BadRequestResult>(response);

            await this.PeopleService.DidNotReceive().Get(personId);
            await this.PeopleService.DidNotReceive().Update(Arg.Any<int>(), Arg.Any<PersonUpdate>());
        }

        [Fact]
        public async Task Update_PersonDoesNotExist_ReturnsNotFound()
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
                FavouriteSports = new List<int>
                {
                    1,
                    2
                }
            };

            var sut = this.Sut;

            //Act
            var response = await sut.Update(personId, personUpdate);

            //Assert
            Assert.IsType<NotFoundResult>(response);

            await this.PeopleService.Received().Get(personId);
            await this.PeopleService.DidNotReceive().Update(Arg.Any<int>(), Arg.Any<PersonUpdate>());
        }

        [Fact]
        public async Task Update_ValidPersonUpdate_ReturnsOk()
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
                FavouriteSports = new List<int>
                {
                    1,
                    2
                }
            };

            var person = new Person
            {
                Id = personId,
                FirstName = "test",
                LastName = "test",
                Authorised = false,
                Enabled = false,
                Valid = true,
            };

            this.PeopleService.Get(personId).Returns(person);

            var sut = this.Sut;

            //Act
            var response = await sut.Update(personId, personUpdate);

            //Assert
            Assert.IsType<OkResult>(response);

            await this.PeopleService.Received().Get(personId);
            await this.PeopleService.Received().Update(personId, personUpdate);
        }

        private PeopleController Sut => new PeopleController(this.PeopleService);

        private IPeopleService PeopleService { get; } = Substitute.For<IPeopleService>();
    }
}
