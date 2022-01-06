namespace CSh_11
{
    class TeamsJournalEntry
    {
        public string CollectionName { get; set; }
        public string CollectionEvent { get; set; }
        public int NumberOfEl;
        public Revision Changes { get; set; }
        public TeamsJournalEntry(string Name, Revision Changes, string Ev, int numOfEl)
        {

            CollectionName = Name;
            this.Changes = Changes;
            CollectionEvent = Ev;
            NumberOfEl = numOfEl;
        }
        public override string ToString()
        {
            //return string.Format("Collection name: {0} \n Event: {1} \n Number of el {2} \n",this.CollectionName,this.CollectionEvent,this.NumberOfEl);
            return string.Format($"Name of collection {0} \n Changes {1} \n Name of changed property {2} \n Registration number of element {3} \n",
                this.CollectionName, this.Changes, this.CollectionEvent, this.NumberOfEl.ToString());
        }
    }
}
