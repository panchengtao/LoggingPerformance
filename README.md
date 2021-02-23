### Summary
Logging performance comparison between Serilog and NLog.

### Dev info

1. Windows 10 Enterprise 64-bit (Build 18363) 
2. Microsoft Visual Studio Enterprise 2019 16.8.4
3. .NET 5
4. Platform target: 64bit 

### Computer infomation

1. Intel Core i7 8665U @ 1.90GHz
2. 16GB DDR4-2667 (1333 MHz)
3. Seagate FireCuda 520 SSD 1TB

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

Generated 1000000 values in 6519ms (throughput = 153375,423 ops per second)
Mean latency = 6,468mcs
99% observations less than = 17,000mcs
99.99% observations less than = 226,800mcs
0) 4,500 - 5,7500 = 850512
1) 5,750 - 7,0000 = 61423
2) 7,000 - 8,2500 = 38397
3) 8,250 - 9,5000 = 15669
4) 9,500 - 10,7500 = 7763
5) 10,750 - 12,0000 = 4334
6) 12,000 - 13,2500 = 3697
7) 13,250 - 14,5000 = 3101
8) 14,500 - 15,7500 = 5296
9) 15,750 - 17,0000 = 5351

### NLog

Generated 1000000 values in 2710ms (throughput = 368929,577 ops per second)
Mean latency = 2,658mcs
99% observations less than = 4,200mcs
99.99% observations less than = 1979,300mcs
0) 1,100 - 1,4100 = 756134
1) 1,410 - 1,7200 = 11581
2) 1,720 - 2,0300 = 111748
3) 2,030 - 2,3400 = 61373
4) 2,340 - 2,6500 = 28529
5) 2,650 - 2,9600 = 5891
6) 2,960 - 3,2700 = 5260
7) 3,270 - 3,5800 = 5621
8) 3,580 - 3,8900 = 2497
9) 3,890 - 4,2000 = 1413

# Benchmarks 2

### Arrange

Write target: File
Test input count: 5000000
Producer: 1

### Serilog

Generated 5000000 values in 29975ms (throughput = 166805,337 ops per second)
Mean latency = 5,950mcs
99% observations less than = 16,100mcs
99.99% observations less than = 206,800mcs
0) 4,400 - 5,5700 = 4285842
1) 5,570 - 6,7400 = 374515
2) 6,740 - 7,9100 = 110965
3) 7,910 - 9,0800 = 48389
4) 9,080 - 10,2500 = 38320
5) 10,250 - 11,4200 = 19108
6) 11,420 - 12,5900 = 11534
7) 12,590 - 13,7600 = 11428
8) 13,760 - 14,9300 = 20614
9) 14,930 - 16,1000 = 30396

### NLog

Generated 5000000 values in 12431ms (throughput = 402201,458 ops per second)
Mean latency = 2,436mcs
99% observations less than = 3,400mcs
99.99% observations less than = 1976,300mcs
0) 1,100 - 1,3300 = 4126122
1) 1,330 - 1,5600 = 178115
2) 1,560 - 1,7900 = 22494
3) 1,790 - 2,0200 = 278309
4) 2,020 - 2,2500 = 174330
5) 2,250 - 2,4800 = 115672
6) 2,480 - 2,7100 = 29218
7) 2,710 - 2,9400 = 7554
8) 2,940 - 3,1700 = 7879
9) 3,170 - 3,4000 = 12038