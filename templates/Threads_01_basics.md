## Canada Expansion

### Small
- [x] Sanket's PR: necessary fields and how they are used [9-9.30]
- [x] Sanket's PR: new fields added [9.30 - 9.45]
- [x] Wei's new PR? [9.45 - 10.15]

### Medium
- [x] Prakhar's changes (new function to return net languages) [10.15 - 10.45]
- [x] Where are existing fields added in Supply logs? Add new field there [10.45 - 11.15]
- [x] Function where they need to be initialized [11.15 - 11.45]
- [ ] Wherever logging happens/init happens, set the net language as well [11.45 - 12.15]

### Large
- [ ] Raise MR


### Sanket's changes
#### Common types
- _array<string> contentLanguages_
- int adSelectionPolicy
- long contentProvideOrgId

#### Supply log event
- string mescalValidationStatus
- array<AdCount> requestedAds


SupplyLogEvent.java
Follow the trail of requestedAdOps
array<string> requestedAdOps = null
protected List<String> requestedAdOps = new ArrayList<String>();

Q: How do we add field in: SupplyLogEvent$Builder class?
Q: What is the function that Prakhar wrote?


# Concurrency in Practice

## Introduction

* Thread is the most basic unit of execution. It executes instructions serially 
* A process can have multiple threads running as a part of it
* Usually, there is a state (variables) associated with a process that is shared amongst the threads, and each thread can have a private state to itself
* Special attention needs to be paid when changes are made to this shared state
* In multi-processor CPUs, processes can be scheduled on multiple CPUs. In multi-core CPUs, threads can be scheduled on each core
* While processes don't share anything between them, threads belonging to a process share the resources allocated to that process, including memory address space

### Advantages

### Hazards
* Failures in multi threaded environments can be elusive because they depend on the _relative timing_ of events in different threads, and don't always manifest itself in dev/testing

* **Safety**: 
  * Threads share same memory address space and run concurrently, so multiple threads could be modifying a single variable leading to undesired results
  * _Critical Section_ is any piece of code that has the possiblity of being executed concurrently by more than one thread of the application, and exposes any shared data/resources
  * Such conditions are called 'race conditions' and the programs that don't handle these are called _thread unsafe_ or _@NotThreadSafe_ 
  * Java gives _synchronized_ keyword for a multi-threaded program to coordinate access such that race conditions don't occur
  * When your program is _@ThreadSafe_, users can use it confidently in multi threaded environment. Maintainers are put on notice about the thread safe guarantees that must be preserved
  * In the absence of synchronization, the compiler, hardware and runtime are allowed to take substantial liberties with the timing and ordering of actions

* **Liveness**:
  * _Safety_ => nothing bad happens
  * _Liveness_ => something good eventually happens
  * Liveness issues are typically ones where activity gets into such a state that there is no progress
  * Examples: deadlock, livelock, resource starvation

* **Perf hazards**:
  * Performance issues usually can occur in following areas: poor service time, responsiveness, throughput, resource consumption, scalability
  * If applns are well designed, threads usually result in performance gain
  * Threads carry some runtime overhead such as context switches
  * _Context Switches_: Scheduler suspends active thread so that another one can be run
    * Cost of saving and restoring execution context
    * Loss of locality
    * CPU time spent scheduling threads instead of running them
    * Synchronization mechanisms can inhibit optimizations at compiler level, can flush or invalidate memory caches, create sync traffic on memory bus

## Important concurrency concepts

* **Deadlocks**: Two or more threads don't make progress because resource required by first thread is held by the second and resource required by second thread is held by the first 
* **Liveness**: It's the ability of a program to execute in a timely manner. If a program experiences deadlock, it is not exhibiting liveness
* **Livelock**: A live lock happens when two threads keep taking actions in response to the other thread instead of making progress. Analogy - think of two people trying to cross each other in a hallway and both keep blocking each other
* **Starvation**: A thread experiences starvation when it doesn't get CPU time or access to shared resources because other threads are hogging the resources
* **Re-entrant lock**: A reentrant mutex (aka recrusive mutex/lock) is a type of mutex that may be locked multiple times by the same process/thread, without causing deadlock. 
  * Attempts to perform lock operation on an ordinary lock would either fail or block if the mutex is already locked
  * In a reentrant lock, this operation will succeed iff the locking thread is the one that already holds the lock
  * Reentrant mutex tracks the number of times it has been locked and requires an equal number of unlock operations before other threads may lock it

## Mutex vs Semaphore

* Locking and signalling mechanisms in a multi threaded environment
* **Mutex**
  * "Mutual Exclusion"
  * _Guards access_ to shared data (primitives, arrays etc.) a.k.a helps in serializing access to shared state
  * Allows only a single thread to access the resource
* **Semaphore**
  * _Limits access_ to a collection of resources
  * Think of semaphore as someone who has a limited number of permits to give out. If all permits are given out, whoever is next in queue has to wait till a permit returns to the semaphore
  * A semaphore with single permit is called binary semaphore
  * _Semaphores can also be used for signaling among threads_. This allows threads to cooperatively work towards finishing a task
  * Mutex on the other hand is strictly limited to serializing access to shared state
* **Key differences**
  * In case of mutex, same thread must call acquire and then release the mutex
  * In binary semaphore, different threads can call acquire and release
  * i.e a mutex is owned _by the thread acquiring it_ till the point it releases it (if a thread that doesn't own the mutex tries to unlock it, unexpected behavior occurs)
  * There is _no notion of ownership_ for semaphore
  * Semaphores can be used for singalling, mutex can't
## Mutex vs Monitor

## Java Monitor, Hoare vs Mesa monitors

## Semaphore vs Monitor

## Amdahl's Law
