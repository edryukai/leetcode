# Queue

 Queue
* If the nature of data in the problem follows a FIFO pattern then think of queue
	* In level order traversal, parent is processed first, and it will exit first before processing children
	* In problems involving moving averages, or removing stale data, it will follow a FIFO order
* If nature of data follows a pattern such that inserts and deletes happen at both ends, think of deque
	* In snake game, snake body movements could be considered as a new head being added while a tail gets removed, so deque
