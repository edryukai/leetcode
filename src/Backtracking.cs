/*
Subsets [Distinct integers in input]
https://leetcode.com/problems/subsets/
*/

public List<List<int>> Subsets(int[] nums) {
    List<List<int>> result = new List<List<int>>();
    Array.Sort(nums);   /* makes it more generic */
    Backtrack(result, new List<int>(), nums, 0);

    return result;
}

private void Backtrack(
    List<List<int>> result,
    List<int> templist,
    int[] nums,
    int start)
{
    result.Add(new List<int>(templist));
    for(int i = start; i < nums.Length; i++) {
        templist.Add(nums[i]);
        Backtrack(result, templist, nums, i+1);
        templist.RemoveAt(templist.Count - 1);
    }
}

// -----------------------------------------------------------------------------------------------

/*
Subsets-2 [Contains Duplicates in input]
https://leetcode.com/problems/subsets-ii/
*/

public List<List<int>> SubsetsWithDup(int[] nums) {
    List<List<int>> result = new List<List<int>>();
    Array.Sort(nums);
    Backtrack(result, new List<int>(), nums, 0);

    return result;
}

private void Backtrack(
    List<List<int>> result,
    List<int> templist,
    int[] nums,
    int start)
{
    result.Add(new List<int>(templist));
    for(int i = start; i < nums.Length; i++) {
        if(i > start && nums[i] == nums[i-1]) continue;   /* skip duplicates, this works because we sorted input array */
        templist.Add(nums[i]);
        Backtrack(result, templist, nums, i+1);
        templist.RemoveAt(templist.Count - 1);
    }
}

// -----------------------------------------------------------------------------------------------

/*
Permutations [Distinct elements in input]
https://leetcode.com/problems/permutations/description/
*/

public IList<IList<int>> Permute(int[] nums) {
    IList<IList<int>> result = new List<IList<int>>();
    Array.Sort(nums);   /* not necessary here */
    Backtrack(result, new List<int>(), nums);

    return result;
}

private void Backtrack(
    IList<IList<int>> result,
    List<int> templist,
    int[] nums)
{
    if(templist.Count == nums.Length) {
        result.Add(new List<int>(templist));
    }
    else {
        for(int i = 0; i < nums.Length; i++) {
            if(templist.Contains(nums[i]))  continue;   /* element already exists, skip */
            templist.Add(nums[i]);
            Backtrack(result, templist, nums);
            templist.RemoveAt(templist.Count - 1);
        }
    }
}

// -----------------------------------------------------------------------------------------------

/*
Permutations-2 [Contains Duplicates in input]
https://leetcode.com/problems/permutations-ii/
*/

public IList<IList<int>> PermuteUnique(int[] nums) {
    IList<IList<int>> result = new List<IList<int>>();
    Array.Sort(nums);   /* necessary here */
    Backtrack(result, new List<int>(), nums, new bool[nums.Length]);

    return result;
}

private void Backtrack(
    IList<IList<int>> result,
    List<int> templist,
    int[] nums,
    bool[] used)
{
    if(templist.Count == nums.Length) {
        result.Add(new List<int>(templist));
    }
    else {
        for(int i = 0; i < nums.Length; i++) {
            if(used[i] || i > 0 && nums[i] == nums[i-1] && !used[i-1])  continue;
            used[i] = true;
            templist.Add(nums[i]);
            Backtrack(result, templist, nums, used);
            used[i] = false;
            templist.RemoveAt(templist.Count - 1);
        }
    }
}

// -----------------------------------------------------------------------------------------------

/*
Combination Sum [Can use duplicates from input]
Given an int[] array and a target T, find all combinations in array that sum to T
https://leetcode.com/problems/combination-sum/description/

This is like finding subsets. So we need a "start" parameter.
In Subsets, we didn't bother about any condition to add to result. Here we have a constraint (add to Target), so we keep track of how much is remaining
Since we can use duplicates, we pass i instead of i+1 to backtracking call recursively
*/

public IList<IList<int>> CombinationSum(int[] nums, int target) {
    IList<IList<int>> result = new List<IList<int>>();
    Array.Sort(nums);
    Backtrack(result, new List<int>(), nums, target, 0);

    return result;
}

private void Backtrack(
    IList<IList<int>> result,
    List<int> templist,
    int[] nums,
    int remaining,
    int start)
{
    if(remaining < 0) return;
    else if(remaining == 0)   result.Add(new List<int>(templist));
    else {
        for(int i = start; i < nums.Length; i++) {
            templist.Add(nums[i]);
            Backtrack(result, templist, nums, remaining - nums[i], i);    /* not i+1 because we can re use same elements */
            templist.RemoveAt(templist.Count - 1);
        }
    }
}

// -----------------------------------------------------------------------------------------------

/*
Combination Sum-2 [No Duplicates]
Given an int[] array and a target T, find all combinations in array that sum to T
Cannot use the same number twice to form a target, input can contain duplicates
https://leetcode.com/problems/combination-sum/description/
*/

public IList<IList<int>> CombinationSum2(int[] nums, int target) {
    IList<IList<int>> result = new List<IList<int>>();
    Array.Sort(nums);
    Backtrack(result, new List<int>(), nums, target, 0);

    return result;
}

private void Backtrack(
    IList<IList<int>> result,
    List<int> templist,
    int[] nums,
    int remaining,
    int start)
{
    if(remaining < 0) return;
    else if(remaining == 0)   result.Add(new List<int>(templist));
    else {
        for(int i = start; i < nums.Length; i++) {
            if(i > start && nums[i] == nums[i-1]) continue;   /* skip duplicates */
            templist.Add(nums[i]);
            Backtrack(result, templist, nums, remaining - nums[i], i + 1);  /* i+1 here because we can't reuse same elements */
            templist.RemoveAt(templist.Count - 1);
        }
    }
}

// -----------------------------------------------------------------------------------------------

/*
Palindrome partitioning
Given a string s, partition it such that every substring of the partition is a palindrome
https://leetcode.com/problems/palindrome-partitioning/
*/
public IList<IList<string>> Partition(string s) {
    IList<IList<string>> result = new List<IList<string>>();
    Backtrack(result, new List<string>(), s, 0);

    return result;
}

public void Backtrack(
    IList<IList<string>> result,
    List<string> templist,
    string s,
    int start)
{
    if(start == s.Length) result.Add(new List<string>(templist));
    else {
        for(int i = start; i < s.Length; i++) {
            if(IsPalindrome(s, start, i)) {
                templist.Add(s.Substring(start, i + 1 - start));   // i.e from index start to index i+1
                Backtrack(result, templist, s, i + 1);             // Substring(start_index, length) [in java, subString(start_index, end_index)]
                templist.RemoveAt(templist.Count - 1);
            }
        }
    }
}

public bool IsPalindrome(string s, int start, int end) {
    while (start < end) {
        if(s[start++] != s[end--])  return false;
    }
    return true;
}

// -----------------------------------------------------------------------------------------------
