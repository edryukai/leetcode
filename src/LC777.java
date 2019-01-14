// 777 M https://leetcode.com/problems/swap-adjacent-in-lr-string/description/
// * Given: `XL -> LX` and `RX -> XR` and we have to check if s1 can be transformed to s2
// * **For any question that involves transforming from one state to another, we have to ask ourselves about invariants**
// * **Invariants here**:
//     1. `L` and `R` can never cross each other
//     2. After transforming, `L` can only move left and `R` can only move right
// * `X` doesn't really matter
// * So we check for above two conditions in solution

class Solution {
    public boolean canTransform(String start, String end) {
        if (!start.replace("X", "").equals(end.replace("X", "")))
            return false;
        
        int t = 0;
        for (int i = 0; i < start.length(); ++i)
            if (start.charAt(i) == 'L') {
                // scan end till we hit a corresponding L
                // since L can't move right, this index must be <= i
                while (end.charAt(t) != 'L') t++;
                if (i < t++) return false;
            }

        t = 0;
        for (int i = 0; i < start.length(); ++i)
            if (start.charAt(i) == 'R') {
                // scan end till we hit a corresponding R
                // since R can't move left, this index must be >= i
                while (end.charAt(t) != 'R') t++;
                if (i > t++) return false;
            }

        return true;
    }
}

