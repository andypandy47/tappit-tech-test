using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using TappitTechTest.Api.Controllers;
using TappitTechTest.Core.Interfaces.Repositories;
using TappitTechTest.Core.Models;
using Xunit;

namespace TappitTechTest.Api.Tests
{
    public class SportsControllerTests
    {
        [Fact]
        public async Task GetSports_ReturnsOk()
        {
            //Arrange
            var expected = new List<Sport>
            {
                new Sport
                {
                    SportId = 1,
                    Name = "American football ball",
                    FavouritedCount = 2,
                    Enabled = false
                }
            };

            this.SportsRepository.GetAll().Returns(expected);

            var sut = this.Sut;

            //Act
            var response = await sut.GetAll();

            //Arrange
            var result = Assert.IsType<OkObjectResult>(response);

            expected.Should().BeEquivalentTo((List<Sport>)result.Value);
        }

        private SportsController Sut => new SportsController(this.SportsRepository);

        private ISportsRepository SportsRepository { get; } = Substitute.For<ISportsRepository>();
    }
}
