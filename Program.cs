using System;

namespace CSh_11
{
    class Program
    {
        static void Main(string[] args)
        {
            ResearchTeamCollection collection1 = new ResearchTeamCollection();
            ResearchTeamCollection collection2 = new ResearchTeamCollection();

            TeamsJournal journal1 = new TeamsJournal();

            collection1.ResearchTeamRemoved += journal1.TeamEventHandler;
            collection1.ResearchTeamReplased += journal1.TeamEventHandler;

            collection2.ResearchTeamRemoved += journal1.TeamEventHandler;
            collection2.ResearchTeamReplased += journal1.TeamEventHandler;

            ResearchTeam RT1 = new ResearchTeam("Chaos", "IRE", 1, TimeFrame.Year);
            collection1.AddDefaults();
            collection1.AddResearchTeams(RT1);
            collection2.AddDefaults();
            collection2.Replase(new ResearchTeam("Another", "IRE", 1, TimeFrame.Year), RT1);
            collection2.Remove(RT1);

            Console.WriteLine(journal1.ToString());
            Console.WriteLine();
        }
    }
}