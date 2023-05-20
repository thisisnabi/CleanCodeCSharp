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
        private static Regex _validateEmailRegex = new Regex(@"^[a-zA-Z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-zA-Z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-zA-Z0-9](?:[a-zA-Z0-9-]*[a-zA-Z0-9])?\.)+[a-zA-Z]{2,}$", RegexOptions.Compiled);
        
        // 3
        [Benchmark(Baseline = true)]
        public bool CheckEmail_Regex()
        {
            // RFC 2822  compliant regex
            var validateEmailRegex = new Regex(@"^[a-zA-Z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-zA-Z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-zA-Z0-9](?:[a-zA-Z0-9-]*[a-zA-Z0-9])?\.)+[a-zA-Z]{2,}$");

            return validateEmailRegex.IsMatch("thisisnabi@outlook.com");
        }

        [Benchmark()]
        public bool CheckEmail_Regex_Compiled()
        {
            // RFC 2822  compliant regex
            var validateEmailRegex = new Regex(@"^[a-zA-Z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-zA-Z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-zA-Z0-9](?:[a-zA-Z0-9-]*[a-zA-Z0-9])?\.)+[a-zA-Z]{2,}$", RegexOptions.Compiled);

            return validateEmailRegex.IsMatch("thisisnabi@outlook.com");
        }
        // 1
        [Benchmark()]
        public bool CheckEmail_Regex_Compiled_Static()
        {
            return _validateEmailRegex.IsMatch("thisisnabi@outlook.com");
        }
        
        // 2
        [Benchmark()]
        // RFC 2822 compliant regex
        public bool CheckEmail_MailAddress() =>
            MailAddress.TryCreate("thisisnabi@outlook.com", out var _);
    }
}
