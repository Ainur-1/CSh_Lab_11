using System.Collections.Generic;

namespace CSh_11
{
    class TeamsJournal
    {
        // List that contains collections changes:
        private List<TeamsJournalEntry> ListOfChanges = new List<TeamsJournalEntry>();
        public void TeamEventHandler(object o, ResearchTeamsChangedEventArgs args)
        {
            ListOfChanges.Add(new TeamsJournalEntry(args.NameOfCollection, args.Changes, args.NameOfChangedProperty, args.ElementRegNum));
        }
        public override string ToString()
        {
            string str = "";
            foreach (TeamsJournalEntry en in ListOfChanges)
            {
                str += en.ToString() + "\n";
            }
            return str;
        }
    }
}
