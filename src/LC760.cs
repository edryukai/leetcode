// 760 E https://leetcode.com/problems/find-anagram-mappings/description/
// Space: O(n)
// Time: O(n)
// Logic:
//          Map all elements of B array with key as element and value as indexes where element is found
//          Process A array to populate result

public class Solution {
    public int[] AnagramMappings(int[] A, int[] B) {
        int[] res = new int[A.Length];
        
        Dictionary<int,List<int>> d = new Dictionary<int,List<int>>();
        
        for(int i = 0; i < B.Length; i++) {
            if(d.ContainsKey(B[i]))
                d[B[i]].Add(i);
            else
                d[B[i]] = new List<int>() {i};
        }
        
        for(int i = 0; i < A.Length; i++) {
            int key = A[i];
            List<int> val = d[key];
            res[i] = val[0];
            
            // remove that element from val coz we could have duplicates
            // in the context of this question, duplicate values are okay
            // but in case they are not, the following logic works
            val.RemoveAt(0);
            d[key] = val;
        }
        
        return res;
    }
}