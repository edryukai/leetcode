# Approaching the problem

* Goal: Come up with architecture and design, including bill of materials (#machines needed)
* Reason about data volume
* Focus on general architecture first, then on dimensioning important aspects

## 1. Gather Requirements

* List down SLOs so that you can justify these at the end of your design
* Input data characteristics (what are the different types of data we need to handle)
* What are the machine types we have available. This will also contain information about:
    * RAM, Storage, Ethernet bandwidth (aka compute, storage, networking)
    * Ex: 24 GB RAM, 8 Cores, 2x2 TB HDD, 1 Gb ethernet
    * Ex: 24 GB RAM, 8 Cores, 2x1 TB SSD, 1 Gb ethernet

## 2. Design a naive solution and iterate on it

* Design a basic solution that works if every other resource were infinite
* Now see what the bottlenecks are and how they can be scaled
* This is where you introduce the general functioning of the system - like what are the various functional components your service uses
* Find out functional feedbacks and how you would solve them (Ex: introducing queues, map reduce, paxos etc)

## 3. Scale all the newly introduced components

* Draw your functional components using a different color
* All of these will need to be scaled or dimensioned

## 4. What goes into dimensioning ?

* There are three areas to be dimensioned for every component:
    1. Dimension bandwidth
    2. Dimension storage
    3. Dimension throughput and latency
* The steps involved in dimensioning each of the above three are - 
    1. Figure out what's the inflow + outflow of each factor
    2. Figure out bottleneck of each factor
    3. Based on these two, decide on the number of machines you need and the latency incurred

* **Dimensioning bandwidth**:
    * Compute:
        1. Inflow and outflow of data from the component per second
    * Bottleneck:
        1. Does the network support this?

* **Dimensioning storage**:
    * Compute:
        1. For each storage type available (hdd,sd,ram), how many disks would I need to hold my data?
    * Bottleneck:
        * N/A (we'll see IOPS in throughput section)

* **Dimensioning throughput and latency**:
    * Compute:
        1. How many read QPS and write QPS (or if it's ambiguous - just net QPS)
        2. What is the data inflow + outflow of this component? (since this is compute, we might be sending out additional data, or storing additional data)
    * Bottleneck:
        1. Can my network line support the amount of data that is being handled by this component? (since there's more new data)
        2. Storage has limitations on QPS, IOPS and Latency. Calculate how many machines would I need to support my net qps after computing `latency per query` from table below
        3. Note: according to 2012 Jeff Dean slide, disk seek is 10 ms, most current day disks do it at 3-5 ms

Component | Max (Write) | Max (Read) | Latency | Computed latency per query
----------|-------------|------------|---------|----------------------------
HDD       | 300 QPS     | 400 QPS    | 5 ms seek + Read 20-30 MB/s or 0.05 ms for 1kB) | Write can be same as read speed 
SSD       | 60000 QPS   | 90000 QPS  | 1 GB/s  read | 0.5 GB/s write |
RAM       | doesn't matter | doesn't matter | 4 GB/s | 

* **Important considerations**
    * If you are using timetaking mechanisms like distributed consensus:
        * Cross-continent latency is in the order of `200 ms`
        * This means it's around `5-6 QPS`
        * You can either shard, or batch your write requests
            * Ex: If we need `3000 QPS`, we can batch in sizes of `3000/6 = 500 queries/batch` to support 6 QPS bottleneck for Paxos/Raft
            * So your write QPS now becomes `500 QPS` for your machine
    * Note: since consistent hashing is constant lookup, it can be coupled into the QPS needed by storage device

## 5. Generate the following final table:

ComponentName | Bandwidth | Footprint | Storage | Footprint | Throughput | Latency | Footprint 
--------------|-----------|-----------|---------|-----------|------------|---------|-----------

## 6. Make design more robust

* Account for disaster recovery (more replication, probably just the final state)
* Account for spikes in traffic
* Reduce footprint by introducing ELB, distributed queues, nosql dbs etc.

## 7. Useful stuff to know

Entity | Value
-------|------
1B per day | 12000 per second
Convert anything from day to second | divide by pow(10,5) and increase it by 12%
1 year | PI * pow(10,7) seconds
1 quarter | pow(10,7) seconds
1 month | 1/3 * pow(10,7) seconds

## 8. ToDo

* Throughput and latency numbers for caches, loadbalancers, nosql databases
