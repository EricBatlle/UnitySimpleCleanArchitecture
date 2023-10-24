using System.Collections.Generic;
using SCA;

public class CountIncrementedSignal
{
    public Dictionary<CountType, Count> counts;

    public CountIncrementedSignal(Dictionary<CountType, Count> counts)
    {
        this.counts = counts;
    }
}
