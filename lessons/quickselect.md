# Quickselect
#datastr

## First k / k-th largest
* Accomplishes the following in O(n) time and O(1) space. Worst case time if sorted array: O(n^2)
	* Find first k large elements (in no particular order)
	* Find just the k-th largest element
	* Partially sorts the data

* **Side Notes:**
	* If you need to find first k elements in sorted fashion, you have to use heap
	* Similarly, if you need to find k-th largest element, but k keeps changing, then use heap
