using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using TestSwitchApi.Controllers;
using TestSwitchApi.Models.DataModels;
using TestSwitchApi.Models.Request;
using TestSwitchApi.Models.Response;
using TestSwitchApi.Repositories;

namespace TestSwitchApi.Tests
{
    public class CandidatesListResponseTest
    {
        public CandidatesListResponseTest()
        {
        }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestingForNoCandidates()
        {
            var candidates = new List<CandidateDataModel>();
            var pageRequest = new PageRequest
            {
                Page = 1,
                PageSize = 10,
            };
            var candidatesListResponse = CandidateListResponse.Create(pageRequest, candidates, 0);
            candidatesListResponse.TotalNumberOfItems.Should().Be(0);
            candidatesListResponse.Items.Count().Should().Be(0);
            candidatesListResponse.Page.Should().Be(1);
            candidatesListResponse.PageSize.Should().Be(10);
            candidatesListResponse.PreviousPage.Should().BeNullOrEmpty();
            candidatesListResponse.NextPage.Should().BeNullOrEmpty();
        }

        [Test]
        public void CheckingFirstPageOfCandidates()
        {
            var candidates = new List<CandidateDataModel>();
            for (int cnt = 0; cnt < 10; cnt++)
            {
                var candidateDataModel = new CandidateDataModel
                {
                    Id = cnt,
                    FirstName = "test" + cnt,
                    LastName = "Name",
                    Email = "test" + cnt + "." + "Name@test.com",
                };
                candidates.Add(candidateDataModel);
            }

            var pageRequest = new PageRequest
            {
                Page = 1,
                PageSize = 10,
            };
            var candidatesListResponse = CandidateListResponse.Create(pageRequest, candidates, 15);
            candidatesListResponse.TotalNumberOfItems.Should().Be(15);
            candidatesListResponse.Items.Count().Should().Be(10);
            candidatesListResponse.Page.Should().Be(1);
            candidatesListResponse.PageSize.Should().Be(10);
            candidatesListResponse.PreviousPage.Should().BeNullOrEmpty();
            candidatesListResponse.NextPage.Should().Be("/candidates?page=2&pageSize=10");
        }

        [Test]
        public void CheckingThatNextPageAndPrevPageAreEnabled()
        {
            var candidates = new List<CandidateDataModel>();
            for (int cnt = 0; cnt < 10; cnt++)
            {
                var candidateDataModel = new CandidateDataModel
                {
                    Id = cnt,
                    FirstName = "test" + cnt,
                    LastName = "Name",
                    Email = "test" + cnt + "." + "Name@test.com",
                };
                candidates.Add(candidateDataModel);
            }

            var pageRequest = new PageRequest
            {
                Page = 2,
                PageSize = 10,
            };
            var candidatesListResponse = CandidateListResponse.Create(pageRequest, candidates, 25);
            candidatesListResponse.TotalNumberOfItems.Should().Be(25);
            candidatesListResponse.Items.Count().Should().Be(10);
            candidatesListResponse.Page.Should().Be(2);
            candidatesListResponse.PageSize.Should().Be(10);
            candidatesListResponse.PreviousPage.Should().Be("/candidates?page=1&pageSize=10");
            candidatesListResponse.NextPage.Should().Be("/candidates?page=3&pageSize=10");
        }

        [Test]
        public void CheckingThatOnlyPrevPageIsEnabledForTheLastPage()
        {
            var candidates = new List<CandidateDataModel>();
            for (int cnt = 0; cnt < 5; cnt++)
            {
                var candidateDataModel = new CandidateDataModel
                {
                    Id = cnt,
                    FirstName = "test" + cnt,
                    LastName = "Name",
                    Email = "test" + cnt + "." + "Name@test.com",
                };
                candidates.Add(candidateDataModel);
            }

            var pageRequest = new PageRequest
            {
                Page = 3,
                PageSize = 10,
            };
            var candidatesListResponse = CandidateListResponse.Create(pageRequest, candidates, 15);
            candidatesListResponse.TotalNumberOfItems.Should().Be(15);
            candidatesListResponse.Items.Count().Should().Be(5);
            candidatesListResponse.Page.Should().Be(3);
            candidatesListResponse.PageSize.Should().Be(10);
            candidatesListResponse.PreviousPage.Should().Be("/candidates?page=2&pageSize=10");
            candidatesListResponse.NextPage.Should().BeNullOrEmpty();
        }
    }
}