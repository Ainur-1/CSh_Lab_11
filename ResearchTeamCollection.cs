using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


namespace CSh_11
{
    class ResearchTeamCollection : ResearchTeam, IComparable, IEnumerable
    {
        //Поля
        private List<ResearchTeam> researches;

        //Кострукторы 
        public ResearchTeamCollection()
        {
            researches = new List<ResearchTeam>();
        }

        //Свойства
        public int MinRegNumber
        {
            get
            {
                if (researches.Count == 0)
                {
                    return 0;
                }
                return researches.Min(teams => teams.RegistrationNumber);
            }
        }
        public IEnumerable<ResearchTeam> TwoYearsLong
        {
            get
            {
                IEnumerable<ResearchTeam> TwoTearsL = researches.Where(time => time.DurationOfResearch == TimeFrame.TwoYears);
                return TwoTearsL;
            }
        }
        public string NameOfCollection { get; set; }

        //Методы
        public void AddDefaults()
        {
            researches.Add(new ResearchTeam());
        }
        public void AddResearchTeams(params ResearchTeam[] newResearchTeams)
        {
            researches.AddRange(newResearchTeams);
        }
        public override string ToString()
        {
            string stringResearches = "";
            foreach (var r in researches)
            {
                stringResearches += r.ToString() + "\r\n";
            }
            return stringResearches;
        }
        public override string ToShortString()
        {
            string stringResearches = "";
            foreach (var r in researches)
            {
                stringResearches += r.ToShortString() + "\r\n";
            }
            return stringResearches;
        }
        public void SortingByRegNum()
        {
            researches.Sort((x, y) => x.RegistrationNumber.CompareTo(y.RegistrationNumber));
        }
        public void SortByTheme()
        {
            researches.Sort();
        }
        public void SortByPublications()
        {
            ResearchTeamHelper comp = new ResearchTeamHelper();
            researches.Sort(comp);
        }
        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < researches.Count; i++)
            {
                yield return researches[i];
            }
        }
        public List<ResearchTeam> NGroup(int value)
        {
            IEnumerable<IGrouping<int, ResearchTeam>> someGroup = researches.GroupBy(team => team.ListOfParticipants.Count);

            foreach (IGrouping<int, ResearchTeam> teams in someGroup)
            {
                if (teams.Key == value)
                {
                    return teams.ToList<ResearchTeam>();
                }
                else
                {
                    throw new ArgumentNullException("There are no such number!");
                }
            }
            return null;
        }
        public bool Remove(ResearchTeam rt)
        {
            if (researches.Contains(rt))
            {
                int index = researches.FindIndex(s => s == rt);
                researches.Remove(rt);
                ResearchTeamRemoved(researches[index], new ResearchTeamsChangedEventArgs(NameOfCollection, Revision.Remove, "", researches[index].RegistrationNumber));
                return true;
            }
            else return false;
        }
        public bool Replase(ResearchTeam rtold, ResearchTeam rtnew)
        {
            if (researches.Contains(rtold))
            {
                int index = researches.FindIndex(s => s == rtold);

                if (index != -1) researches[index] = rtnew;
                ResearchTeamReplased(researches[index], new ResearchTeamsChangedEventArgs(NameOfCollection, Revision.Replase, "", researches[index].RegistrationNumber));
                return true;
            }
            else return false;
        }

        //Делегаты и события
        public delegate void ResearchTeamsListHandler(object source, ResearchTeamsChangedEventArgs args);
        public event ResearchTeamsListHandler ResearchTeamReplased;
        public event ResearchTeamsListHandler ResearchTeamRemoved;
    }
}
