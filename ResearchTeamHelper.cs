using System.Collections.Generic;

namespace CSh_11
{
    class ResearchTeamHelper : ResearchTeam, IComparer<ResearchTeam>
    {
        int IComparer<ResearchTeam>.Compare(ResearchTeam x, ResearchTeam y)
        {
            return x.ListOfPublication.Count.CompareTo(y.ListOfPublication.Count);
        }
    }
}
