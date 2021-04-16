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

Generated 1000000 values in 4541ms (throughput = 220180,668 ops per second)  
Mean latency = 4,500mcs  
99% observations less than = 10,100mcs  
99.99% observations less than = 6068,900mcs

0) 1,800 - 2,6300 = 453451
1) 2,630 - 3,4600 = 443718
2) 3,460 - 4,2900 = 64609
3) 4,290 - 5,1200 = 10908
4) 5,120 - 5,9500 = 3786
5) 5,950 - 6,7800 = 3105
6) 6,780 - 7,6100 = 2710
7) 7,610 - 8,4400 = 1313
8) 8,440 - 9,2700 = 1226
9) 9,270 - 10,1000 = 5529

### NLog

Generated 1000000 values in 2532ms (throughput = 394849,270 ops per second)  
Mean latency = 2,483mcs  
99% observations less than = 3,000mcs  
99.99% observations less than = 2006,100mcs

0) 1,100 - 1,2900 = 229206
1) 1,290 - 1,4800 = 610634
2) 1,480 - 1,6700 = 4284
3) 1,670 - 1,8600 = 31350
4) 1,860 - 2,0500 = 62533
5) 2,050 - 2,2400 = 32473
6) 2,240 - 2,4300 = 10990
7) 2,430 - 2,6200 = 4577
8) 2,620 - 2,8100 = 2385
9) 2,810 - 3,0000 = 2084

# Benchmarks 2

### Arrange

Write target: File  
Test input count: 5000000  
Producer: 1  

### Serilog

Generated 5000000 values in 21804ms (throughput = 229308,208 ops per second)  
Mean latency = 4,322mcs  
99% observations less than = 10,300mcs  
99.99% observations less than = 6132,500mcs  

0) 1,900 - 2,7400 = 3352251
1) 2,740 - 3,5800 = 1196751
2) 3,580 - 4,4200 = 283497
3) 4,420 - 5,2600 = 38472
4) 5,260 - 6,1000 = 16407
5) 6,100 - 6,9400 = 15284
6) 6,940 - 7,7800 = 8545
7) 7,780 - 8,6200 = 4784
8) 8,620 - 9,4600 = 7933
9) 9,460 - 10,3000 = 31267

### NLog

Generated 5000000 values in 12230ms (throughput = 408807,710 ops per second)  
Mean latency = 2,397mcs  
99% observations less than = 2,600mcs  
99.99% observations less than = 1938,000mcs

0) 1,100 - 1,2500 = 1290664
1) 1,250 - 1,4000 = 3163826
2) 1,400 - 1,5500 = 9390
3) 1,550 - 1,7000 = 17602
4) 1,700 - 1,8500 = 29994
5) 1,850 - 2,0000 = 223645
6) 2,000 - 2,1500 = 245122
7) 2,150 - 2,3000 = 76199
8) 2,300 - 2,4500 = 39976
9) 2,450 - 2,6000 = 12144