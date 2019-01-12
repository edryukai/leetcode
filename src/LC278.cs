/* The isBadVersion API is defined in the parent class VersionControl.
      bool IsBadVersion(int version); */
// 278 E https://leetcode.com/problems/first-bad-version/description/
// Logic similar to 34 - finding first and last occurance of a number
// 1. If current version is not bad then we have to search right so we make lo = mid+1
// 2. If current version is bad and there's no other bad versions to the left we return current
// 3. Else we have more bad versions to left, so we make hi = mid-1
public class Solution : VersionControl {
    public int FirstBadVersion(int n) {
        int lo = 0, hi = n;
        while(lo < hi) {
            int mid = lo + (hi - lo)/2;
            if(!IsBadVersion(mid))
                lo = mid+1;
            else if((mid == 1 && IsBadVersion(mid)) || (IsBadVersion(mid) && !IsBadVersion(mid-1)))
                return mid;
            else
                hi = mid-1;
        }
        return IsBadVersion(lo) ? lo : -1;
    }
}
