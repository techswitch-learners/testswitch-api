using System;
using System.Text;

namespace TestSwitchApi.Models.DataModels
{
    public class CandidateDataModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Guid { get; set; }
    }
}