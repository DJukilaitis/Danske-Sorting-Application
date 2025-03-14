```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.26100.3194)
Intel Core i7-8700 CPU 3.20GHz (Coffee Lake), 1 CPU, 12 logical and 6 physical cores
.NET SDK 9.0.201
  [Host]     : .NET 9.0.3 (9.0.325.11113), X64 RyuJIT AVX2 [AttachedDebugger]
  DefaultJob : .NET 9.0.3 (9.0.325.11113), X64 RyuJIT AVX2


```
| Method              | Mean     | Error    | StdDev   |
|-------------------- |---------:|---------:|---------:|
| SortUsingBubbleSort | 819.6 ns | 10.96 ns | 10.26 ns |
| SortUsingQuickSort  | 995.0 ns | 11.48 ns | 10.73 ns |
