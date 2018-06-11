### Summary
Logging performance comparison between Serilog and NLog.

### Dev info

1. Windows 10 Education x64
2. Microsoft Visual Studio Enterprise 2017 15.7.3
3. .NET Core 2.0

### Computer infomation

1. Intel i5-7500 3.40GHz
2. 16GB
3. Intel 600P 256G

### Involving library

1. [LibLog](https://github.com/damianh/LibLog)

### Referenced document

1. [Serilog vs NLog Benchmarks](https://www.darylcumbo.net/serilog-vs-nlog-benchmarks/)

2. [.NET low latency logging. Part 1 - Testing environment, Sample application, Best performance!](https://deep-depth.blogspot.com/2014/01/choose-solution-for-low-latency-logging.html)

# Benchmarks 1

### Arrange

Write target: File
Test input count: 1000000
Producer: 1

### Serilog

Generated 1000000 values in 3506ms (throughput = 285199.451 ops per second)
Mean latency = 3.474mcs
99% observations less than = 15.624mcs
99.99% observations less than = 125.596mcs
0) 2.404 - 3.7258 = 950441
1) 3.726 - 5.0479 = 15937
2) 5.048 - 6.3699 = 2294
3) 6.370 - 7.6920 = 3218
4) 7.692 - 9.0141 = 10559
5) 9.014 - 10.3361 = 1593
6) 10.336 - 11.6582 = 630
7) 11.658 - 12.9803 = 705
8) 12.980 - 14.3023 = 466
9) 14.302 - 15.6244 = 5128

### NLog

Generated 1000000 values in 7256ms (throughput = 137812.554 ops per second)
Mean latency = 7.225mcs
99% observations less than = 434.178mcs
99.99% observations less than = 1055.547mcs
0) 0.901 - 44.2290 = 989657
1) 44.229 - 87.5566 = 46
2) 87.557 - 130.8843 = 12
3) 130.884 - 174.2119 = 230
4) 174.212 - 217.5395 = 43
5) 217.540 - 260.8671 = 6
6) 260.867 - 304.1948 = 1
7) 304.195 - 347.5224 = 2
8) 347.522 - 390.8500 = 0
9) 390.850 - 434.1776 = 5

# Benchmarks 2

### Arrange

Write target: File
Test input count: 5000000
Producer: 1

### Serilog

Generated 5000000 values in 17053ms (throughput = 293191.681 ops per second)
Mean latency = 3.381mcs
99% observations less than = 15.324mcs
99.99% observations less than = 120.789mcs
0) 2.404 - 3.6958 = 4746369
1) 3.696 - 4.9878 = 97342
2) 4.988 - 6.2798 = 7559
3) 6.280 - 7.5718 = 6611
4) 7.572 - 8.8638 = 58916
5) 8.864 - 10.1559 = 10432
6) 10.156 - 11.4479 = 3673
7) 11.448 - 12.7399 = 1609
8) 12.740 - 14.0319 = 1525
9) 14.032 - 15.3239 = 19770

### NLog

Generated 5000000 values in 38294ms (throughput = 130567.331 ops per second)
Mean latency = 7.628mcs
99% observations less than = 462.422mcs
99.99% observations less than = 1126.458mcs
0) 0.901 - 47.0534 = 4947863
1) 47.053 - 93.2055 = 445
2) 93.205 - 139.3575 = 825
3) 139.357 - 185.5095 = 684
4) 185.510 - 231.6616 = 116
5) 231.662 - 277.8136 = 29
6) 277.814 - 323.9656 = 16
7) 323.966 - 370.1176 = 5
8) 370.118 - 416.2697 = 1
9) 416.270 - 462.4217 = 17