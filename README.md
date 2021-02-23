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

Generated 1000000 values in 3433ms (throughput = 291259,161 ops per second)  
Mean latency = 3,392mcs  
99% observations less than = 10,500mcs  
99.99% observations less than = 986,500mcs

0) 1,900 - 2,7600 = 689740
1) 2,760 - 3,6200 = 199819
2) 3,620 - 4,4800 = 56410
3) 4,480 - 5,3400 = 17897
4) 5,340 - 6,2000 = 7799
5) 6,200 - 7,0600 = 5354
6) 7,060 - 7,9200 = 3514
7) 7,920 - 8,7800 = 2476
8) 8,780 - 9,6400 = 2896
9) 9,640 - 10,5000 = 4452

### NLog

Generated 1000000 values in 2564ms (throughput = 389893,174 ops per second)  
Mean latency = 2,512mcs  
99% observations less than = 3,700mcs  
99.99% observations less than = 1945,500mcs  

0) 1,100 - 1,3600 = 735053
1) 1,360 - 1,6200 = 90460
2) 1,620 - 1,8800 = 13521
3) 1,880 - 2,1400 = 102645
4) 2,140 - 2,4000 = 34569
5) 2,400 - 2,6600 = 4360
6) 2,660 - 2,9200 = 3581
7) 2,920 - 3,1800 = 1887
8) 3,180 - 3,4400 = 2701
9) 3,440 - 3,7000 = 1224

# Benchmarks 2

### Arrange

Write target: File  
Test input count: 5000000  
Producer: 1  

### Serilog

Generated 5000000 values in 16495ms (throughput = 303110,984 ops per second)  
Mean latency = 3,261mcs  
99% observations less than = 11,200mcs  
99.99% observations less than = 955,200mcs  

0) 1,900 - 2,8300 = 3707027
1) 2,830 - 3,7600 = 920038
2) 3,760 - 4,6900 = 174384
3) 4,690 - 5,6200 = 39953
4) 5,620 - 6,5500 = 22729
5) 6,550 - 7,4800 = 16608
6) 7,480 - 8,4100 = 12911
7) 8,410 - 9,3400 = 9397
8) 9,340 - 10,2700 = 20284
9) 10,270 - 11,2000 = 27096

### NLog

Generated 5000000 values in 12803ms (throughput = 390529,235 ops per second)  
Mean latency = 2,511mcs  
99% observations less than = 3,600mcs  
99.99% observations less than = 1971,700mcs  

0) 1,200 - 1,4400 = 4236069
1) 1,440 - 1,6800 = 24155
2) 1,680 - 1,9200 = 197400
3) 1,920 - 2,1600 = 273239
4) 2,160 - 2,4000 = 165324
5) 2,400 - 2,6400 = 14370
6) 2,640 - 2,8800 = 9969
7) 2,880 - 3,1200 = 13943
8) 3,120 - 3,3600 = 8822
9) 3,360 - 3,6000 = 7194