# Simple benchmark to compare StringBuilder vs string.Join

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19043.1165 (21H1/May2021Update)

Intel Core i7-9850H CPU 2.60GHz, 1 CPU, 12 logical and 6 physical cores

.NET SDK=6.0.300

  [Host]     : .NET Core 3.1.25 (CoreCLR 4.700.22.21202, CoreFX 4.700.22.21303), X64 RyuJIT
  
  DefaultJob : .NET Core 3.1.25 (CoreCLR 4.700.22.21202, CoreFX 4.700.22.21303), X64 RyuJIT

### Array of 26 strings 

|            Method |     Mean |   Error |  StdDev |  Gen 0 | Allocated |
|------------------ |---------:|--------:|--------:|-------:|----------:|
|    JoinStringTest | 498.3 ns | 1.70 ns | 1.51 ns | 0.0429 |     272 B |
| StringBuilderTest | 397.0 ns | 1.99 ns | 1.77 ns | 0.1221 |     768 B |

StringBuilder is ~20% faster but allocates almost +200% memory with respect to string.Join

### Array of 4 strings

|            Method |      Mean |    Error |   StdDev |  Gen 0 | Allocated |
|------------------ |----------:|---------:|---------:|-------:|----------:|
|    JoinStringTest | 138.83 ns | 1.980 ns | 1.852 ns | 0.0153 |      96 B |
| StringBuilderTest |  66.91 ns | 0.256 ns | 0.214 ns | 0.0242 |     152 B |

string.Join performances become worse when concatenating fewer strings
