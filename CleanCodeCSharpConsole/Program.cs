

using BenchmarkDotNet.Running;
using CleanCodeCSharp.Example;



// aggregate vs string.join in array string
BenchmarkRunner.Run<EmailValidation>();