# Balanced BST / Segment Tree / BIT

## Operations involving a lot of insertion/deletion AND search
* **Logic**: 
  * BST supports O(log n) insertion/deletion and O(log n) for search
  * Balanced BST (along with BIT/ST) should often come to mind when data involves a lot of insertion and search ops

## Count of smaller/larger numbers after self (data follows some ordering)
* **Logic**: 
  * Some ordering of elements to the right or left of a given value can be computed using BST, BIT, ST etc. So if we build a BST/ST out of given data, we can answer questions regarding range data. 
* BIT/ST are particularly useful when underlying data is subject to change
* Questions that are similar:
	* Count of smaller numbers after self (315) (H)
	* Count reverse pairs (493) (H)

* **Side Notes:**
	* Some of the questions where underlying data doesn’t change, but can be solved by BST, can also be solved by using Divide and Conquer approach.
		* Ex: counting number of inversions, counting reverse pairs etc.
	* In some questions like counting number of smaller/larger numbers after self, when using BST, you would have to explicitly maintain additional fields to account for _duplicate values_ as Java allows only unique keys. The downside of this is that you have to handle the balancing part yourself.
		* An alternative to this is to store the count of times each element occurs as a value to the key. 
    * But then again the issue is, you have to iterate over all k,v pairs to generate size of subtree. This will end up being O(n)
