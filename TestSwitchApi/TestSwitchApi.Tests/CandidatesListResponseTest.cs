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
        [Test]
        public void PrevNextIsNullForNoCandidates()
        {
            var candidates = new List<CandidateDataModel>();
            var pageRequest = new PageRequest
            {
                Page = 1,
                PageSize = 10,
            };
            var candidatesListResponse = new CandidateListResponse(pageRequest, candidates, 0);
            candidatesListResponse.TotalNumberOfItems.Should().Be(0);
            candidatesListResponse.Items.Count().Should().Be(0);
            candidatesListResponse.Page.Should().Be(1);
            candidatesListResponse.PageSize.Should().Be(10);
            candidatesListResponse.PreviousPage.Should().BeNullOrEmpty();
            candidatesListResponse.NextPage.Should().BeNullOrEmpty();
        }

        [Test]
        public void PrevIsNullNextIsEnabledFirstTime()
        {
            var candidates = CreateCandidateDataModels(10);

            var pageRequest = new PageRequest
            {
                Page = 1,
                PageSize = 10,
            };
            var candidatesListResponse = new CandidateListResponse(pageRequest, candidates, 15);
            candidatesListResponse.TotalNumberOfItems.Should().Be(15);
            candidatesListResponse.Items.Count().Should().Be(10);
            candidatesListResponse.Page.Should().Be(1);
            candidatesListResponse.PageSize.Should().Be(10);
            candidatesListResponse.PreviousPage.Should().BeNullOrEmpty();
            candidatesListResponse.NextPage.Should().Be("/candidates?page=2&pageSize=10");
        }

        [Test]
        public void NextPageAndPrevPageAreEnabledWhenDataMoreThanPageSize()
        {
            var candidates = CreateCandidateDataModels(10);

            var pageRequest = new PageRequest
            {
                Page = 2,
                PageSize = 10,
            };
            var candidatesListResponse = new CandidateListResponse(pageRequest, candidates, 25);
            candidatesListResponse.TotalNumberOfItems.Should().Be(25);
            candidatesListResponse.Items.Count().Should().Be(10);
            candidatesListResponse.Page.Should().Be(2);
            candidatesListResponse.PageSize.Should().Be(10);
            candidatesListResponse.PreviousPage.Should().Be("/candidates?page=1&pageSize=10");
            candidatesListResponse.NextPage.Should().Be("/candidates?page=3&pageSize=10");
        }

        [Test]
        public void OnlyPrevPageIsEnabledForTheLastPage()
        {
            var candidates = CreateCandidateDataModels(5);
            var pageRequest = new PageRequest
            {
                Page = 3,
                PageSize = 10,
            };
            var candidatesListResponse = new CandidateListResponse(pageRequest, candidates, 15);
            candidatesListResponse.TotalNumberOfItems.Should().Be(15);
            candidatesListResponse.Items.Count().Should().Be(5);
            candidatesListResponse.Page.Should().Be(3);
            candidatesListResponse.PageSize.Should().Be(10);
            candidatesListResponse.PreviousPage.Should().Be("/candidates?page=2&pageSize=10");
            candidatesListResponse.NextPage.Should().BeNullOrEmpty();
        }

        private List<CandidateDataModel> CreateCandidateDataModels(int numModels)
        {
            var candidates = new List<CandidateDataModel>();
            for (int i = 0; i < numModels; i++)
            {
                var candidateDataModel = new CandidateDataModel
                {
                    Id = i,
                    FirstName = "test" + i,
                    LastName = "Name",
                    Email = $"test{i}.Name@test.com",
                };
                candidates.Add(candidateDataModel);
            }

            return candidates;
        }
    }
}