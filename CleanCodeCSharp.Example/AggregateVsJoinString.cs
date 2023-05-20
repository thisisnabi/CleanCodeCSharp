using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Order;
using System.Text;

namespace CleanCodeCSharp.Example;

[MemoryDiagnoser]
[RankColumn]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[SimpleJob(RuntimeMoniker.Net70, baseline: true)]
 
public class AggregateVsJoinString
{

    private List<string> listOfString;

    [GlobalSetup]
    public void Setup()
    {
        listOfString = new List<string>();

        for (int i = 0; i < 20_000; i++) 
        {
            listOfString.Add(DateTime.Now.AddDays(i).ToShortDateString());
        }
    }


    [Benchmark(Baseline = true)]
    public void Aggregate()
    {
        string dataString = listOfString.Aggregate((current, next) => current + "," + next)
                                            .ToString();
    }

    [Benchmark()]
    public void Aggregate_StringBuilder()
    {
        string dataString = listOfString.Aggregate(new StringBuilder(),(current, next) => current.Append(",").Append(next))
                                            .ToString();
    }


    [Benchmark()]
    public void StringJoin()
    {
        string dataString = string.Join(",", listOfString);
    }
}

