using System;

namespace CSh_11
{
    class ResearchTeamsChangedEventArgs : EventArgs
    {
        //Свойства
        public string NameOfCollection { get; set; }
        public Revision Changes { get; set; }
        public string NameOfChangedProperty { get; set; }
        public int ElementRegNum { get; set; }

        //Конструкторы
        public ResearchTeamsChangedEventArgs(string NameOfCollection, Revision Changes, string NameOfChangedProperty, int ElementRegNum)
        {
            this.NameOfCollection = NameOfCollection;
            this.Changes = Changes;
            this.NameOfChangedProperty = NameOfChangedProperty;
            this.ElementRegNum = ElementRegNum;
        }

        //Свойства
        public override string ToString()
        {
            return string.Format($"Name of collection {0} \n Changes {1} \n Name of changed property {2} \n Registration number of element {3} \n",
                NameOfCollection, Changes, NameOfChangedProperty, ElementRegNum.ToString());
        }
    }
}
