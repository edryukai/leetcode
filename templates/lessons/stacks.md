# Stacks	
#datastr


## Next greater/smaller element to current element
* Can be done in O(n) time and O(n) space
* **Logic**: 
	* If there’s a decrease followed by increase, then the increase is the next greater element for all the elements in decreasing sequence. So basically pop out all elements from stack, and record the current element as the nextGreater
	* (For questions like “Remove Duplicate Letters”, you can also store the index of this next greater element)

* **Side notes:**
To find greatest element to right, we just do a reverse scan and update
To find number of greater elements to right,
	If all elements are unique, we can use a self balancing BST/ST
	If elements are not unique, you have to build the BST/use ST
To find next greater element, use stack

* **Questions that can be solved this way**:
	* Next Greater Element 1 (496) (E)
	* Next Greater Element 2 (503) (M)
	* Find next warmer day distance (739) (M)

## Parentheses fashioned questions
* If questions follow a “contained”/“parentheses” order, you can use stacks.
* Store the aux result till you encounter a matching closing parentheses, for example in merging intervals

* Questions that can be solved this way:
	* Valid Parentheses (20) (E)
	* Merge Intervals (56) (M)

## Reversals
* Example: Zig zag level order traversal




