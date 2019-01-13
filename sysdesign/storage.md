# Storage Devices:
* Three factors measure performance of a storage device:
	1. Latency
	2. Throughput
	3. IOPS

* **Latency** - How long does the device take to start an IO task
* **Throughput** - How much data can the device read/write per unit time
* **IOPS** - How many Input/Output operations per second can the device handle


* On an average, you can assume that HDDs are capable of 200 IOPS

* Storage devices come with NCQ and AHCI these days.
    * AHCI - Advanced Host Controller Interface
    * NCQ - Native Command Queueing

### Let’s compare the read and write IOPS characteristics of a storage device that is reading and writing 4 Kb file randomly (4 Kb is base memory page size in Linux x64 OS)

* Without AHCI and NCQ enabled:

    * HDD:  	
        * 200 read IOPS
		* 300 write IOPS

    * SSD:	
        * 10,000 read IOPS
		* 30,000 write IOPS

* With AHCI and NCQ enabled:

    * HDD:	
        * 400 read IOPS
		* 300 write IOPS

    * SSD:	
        * 90,000 read IOPS
		* 60,000 write IOPS

* RAMDisk:   
    * 1 million IOPS as blocked device
	* 10 million IOPS as memory mapped access
	* So we don’t really have to consider IOPS as a limiting factor when we consider RAM
	* We have other things to worry about like how many machines we need

### Comparing Throughputs of a storage device that is reading and writing 4 Kb file randomly

* Without AHCI and NCQ enabled:
    * HDD:  	
        * 0.69 MB/s read
		* 1.20 MB/s write
		* avg: 1 MB/s

    * SSD:	
        * 30 MB/s read
		* 120 MB/s write

* With AHCI and NCQ enabled:
    * HDD:  	
        * 1.50 MB/s read
		* 1.20 MB/s write
		* avg: 1.20 MB/s

    * SSD:	
        * 350 MB/s read
		* 200 MB/s write

    * RAM:  
        * About 20 times faster than SSD (2 - 20 GB/s)
	    * Again, read/write speeds are not really an issue when we are considering reading data from RAM
		* Limiting factors would be more geared towards how many machines we need

### Comparing Latencies
* HDD: 15 ms
* SSD: 0.03 ms

### Top of the line facts
Samsung SSD 960 Pro, 2 TB Model
* 450,000 read IOPS
* 350,000 write IOPS
* 3 GB/s read
* 2 GB/s write

## Relevant Links:
* [SSD Throughput, Latency and IOPS Explained – Learning To Run With Flash | The SSD Review](http://www.thessdreview.com/featured/ssd-throughput-latency-iopsexplained/)
* http://www.thessdreview.com/featured/ssd-throughput-latency-iopsexplained/2/
* [IOPS - Wikipedia](https://en.wikipedia.org/wiki/IOPS)
* [Is the speed of SSD and RAM the same? - Quora](https://www.quora.com/Is-the-speed-of-SSD-and-RAM-the-same)

