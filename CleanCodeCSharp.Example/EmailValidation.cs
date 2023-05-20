using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Order;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace CleanCodeCSharp.Example
{
    [MemoryDiagnoser]
    [RankColumn]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [SimpleJob(RuntimeMoniker.Net70, baseline: true)]
    public class EmailValidation
    {
        [Benchmark(Baseline = true)]
        public bool CheckEmail_Regex()
        {
            // RFC 2822  compliant regex
            var validateEmailRegex = new Regex(@"^[a-zA-Z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-zA-Z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-zA-Z0-9](?:[a-zA-Z0-9-]*[a-zA-Z0-9])?\.)+[a-zA-Z]{2,}$");

            return validateEmailRegex.IsMatch("thisisnabi@outlook.com");
        }

        [Benchmark()]

        // RFC 2822 compliant regex
        public bool CheckEmail_MailAddress() =>
            MailAddress.TryCreate("thisisnabi@outlook.com", out var _);
    }
}
