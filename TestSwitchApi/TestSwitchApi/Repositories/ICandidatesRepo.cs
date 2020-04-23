﻿using System.Collections.Generic;
using TestSwitchApi.Models.DataModels;
using TestSwitchApi.Models.Request;

namespace TestSwitchApi.Repositories
{
    public interface ICandidatesRepo
    {
            IEnumerable<CandidateDataModel> GetAllCandidates(PageRequest pageRequest);
            CandidateDataModel GetCandidateById(int id);
            int Count(PageRequest pageRequest);
    }
}