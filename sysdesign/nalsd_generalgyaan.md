1. Architectural Considerations
2. Handling Failure (A)
3. Handling Consistency and State (C)

## Architectural Considerations

### 1. Requirements
* Data freshness needs
* Current scale and future scale
* Treating some data differently? (hot vs warm vs cold paths)

### 2. Scale
* How much data do I have now, what is the future growth?
* Where should the data live?
* How many copies of data do I need?
* What dimensions do I scale and which dimension dominates?
* SLOs should be guiding principles
* Which data needs to be available and which data needs high consistency?

## Handling Failure

### 1. Failure domains
A set of things that can experience correlated failure
* single process
* machine
* rack
* data center
* servers on the same software
* global configuration system

### 2. Decouple servers
* Spread responsibilities across multiple processes
* Canary changes before prod rollout
* Keep serving in case of corrupt configs

### 3. Use multiple datacenters
* You have to deal with distributed consensus
* Works well with load balancing
* Doesn't work well if data has to be moved around DCs a lot

### 4. Be N+2
* One unit for upgrade, another for failing
* Each unit should be able to handle extra load
* Units should be interchangeable (cattle, not pets)

## Managing Consistency and State

### 1. Don't keep state
* Stateless servers are easy
* Best state is no state

### 2. Shard
* Sharding works well with consistent hashing

### 3. Distributed consensus protocols
* Agrees on one consistent result between a collection of unreliable processes
* Paxos, Raft, Zab (Zookeeper)
* Individual replicas may be slow to converge
* Uses of distributed consensus protocols:
    * Distributed locking, slow filestores
    * From that, we can build master election
    * From that, we can make sure only one of our replicas owns a shard
    * We can also make sure we find replicas
    * Great for metadata overall, not so much for the rest


