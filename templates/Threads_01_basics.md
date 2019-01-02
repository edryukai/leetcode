## Introduction and basic concepts

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
  * _Guards access_ to shared data (primitives, arrays etc.) a.k.a helps in serializing access to shared state (i.e by letting only a single item access critical section)
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
  * Semaphores can be used for singalling, mutex can't. Ex: In producer-consumer problem, a producer can increase the semaphore count, thus notifying the consumer of the freshly produced item.

## Mutex vs Monitor

* **Monitor**:
  * In the producer-consumer problem, the consumer needs to wait on some conditional variable (aka _predicate_) to know that the producer has produced something
  * This typically has to be done in a while loop. There are two issues here:
    * a) Wastage of CPU cycles
    * b) A probability that some other thread could come and change value of the predicate we have been waiting on
  * While mutex and semaphores are OS level constructs, Monitors are programming language constructs
  * So **monitor = mutex + 1 or more condition variables**. A single monitor can have multiple condition variables but the vice versa is not true
  * Think about monitors as having two queues/sets: **entry set** and **wait set**
    * If no other thread owns the monitor (i.e no other thread is executing actively inside the monitor section), then a new thread trying to acquire the monitor will acquire and own it too
    * This thread (call it A), will execute within monitor section till it exits it, or till it calls **wait()** on an associated condition variable - in which case, it will get placed into **wait set/queue**
    * Any new threads that want access to the monitor will be placed in **entry set/queue**
    * Now let's say another thread, B wants to acquire the monitor. Since A is in wait queue, B can access the monitor, and execute it. If B exits monitor without calling **notify()** on the conditional variable, then A will remain in the wait set
    * On similar lines, B could also call wait() and be placed in wait set, in which case some other thread has to come along and call notify() to pull A or B out of wait set
  * Again, note that only one thread can own the monitor
  * tldr - Monitors are mutex + wait/entry sets. They allow mutual exclusion, along with some coordination because of the wait() and notify()/signal() semantics

## Monitors in Java

* **Java Monitors**:
  * Every object in java is a conditional variable, and has am **associated lock** that is intrinsic, hidden from developer
  * Each jaba object exposes `wait()` and `notify()` methods
  * Before we execute `wait()` on an object, we need to lock its hidden mutex. This is done implicitly through the **synchronized** keyword
    * If you call wait() or notify() outside a synchronized block, Java throws _IllegalMonitorStateException_ reminding that the mutex wasn't acquired before wait() on condition var was invoked
  * wait() and notify() can only be called by the thread after becoming owner of that monitor
  * Ownership of monitor can be achieved in following ways:
    * The method that the thread is executing has **synchronized** in its signature
    * Thread is executing a block, that is synchronized on the object on which wait() or notify() will be called
    * In case of a class, thread is executing a static method which is synchronized

## Semaphore vs Monitor

* Monitors and semaphores can be used interchangeably as theoretically, one can be constructed/reduced out of the other. However -
  * Monitors take care of atomically acquiring necessary locks
  * In Semaphores, developer is expected to acquire and release locks properly
* Semaphores are light weight compared to monitors. However, it's easier to misuse semaphores
* Semaphores allow access to several threads to a given resource/critical section and have no concept of ownership. Monitors however give way to only a single thread and a thread can own the monitor at any time
* Semaphores can manage missed signals, but with monitors, predicate has to be maintained along with conditional variable

## Amdahl's Law

* Amdahl's law specifies the cap on maximum speedup that can be achieved when parallelizing the execution of a program
* Let's say `P` is the fraction of program that is parallelizable, so it follows that `1-P` part has to be executed serially
* If `S(n)` denoted the speed up achieved by using *n* cores/threads, then:
  \Large S(n)=\frac{1}{(1\mP)\pfrac{P}{n}}

