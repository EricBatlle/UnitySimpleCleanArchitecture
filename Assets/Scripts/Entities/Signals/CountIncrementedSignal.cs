using System.Collections.Generic;
using SCA;

public class CountIncrementedSignal
{
    public Dictionary<CountType, Count> counts;

    public CountIncrementedSignal(Dictionary<CountType, Count> counts)
    {
        this.counts = counts;
    }

    public int GetTotalCount()
    {
        return counts[CountType.A].Num + counts[CountType.B].Num;
    }
}
