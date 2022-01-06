namespace CSh_11
{
    interface INameAndCopy
    {
        string Name { get; set; }
        object DeepCopy();
    }
}
