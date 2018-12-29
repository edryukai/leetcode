// 406 M https://leetcode.com/problems/queue-reconstruction-by-height/description/
// Logic:
//          - Sort by h
//          - Observe: if you pick the number with least height first, it's index is the absolute index in final array
//                     because every number that stands before it will be larger than it
//          - So start filling from smallest element in final array
//          - While filling, check such that you're counting for "k" slots to be filled either by larger guys/should be empty 
// Think:
//          Can you use SegT/BIT/BST to make it better than O(n^2)?

public class Solution {
    public int[,] ReconstructQueue(int[,] people) {
        int l = people.GetLength(0);
        Pair[] pair = new Pair[l];
        
        for(int i = 0; i < l; i++) {
            pair[i] = new Pair(people[i,0], people[i,1]);
        }
        Array.Sort(pair, new MyCustomComparer());
        
        // Init final result
        int[,] res = new int[l,2];
        for(int i = 0; i < l; i++) {
            res[i,0] = -1;
            res[i,1] = -1;
        }
        
        for(int i = 0; i < l; i++) {
            int num = pair[i].x;
            int posn = pair[i].y;
            int finalPosition = GetFirstEmptyAfterK(res,num,posn);
            res[finalPosition,0] = num;
            res[finalPosition,1] = posn;
        }
        
        return res;
    }
      
    private int GetFirstEmptyAfterK(int[,] a, int curr, int k) {
        int emptyCnt = 0;
        for(int i = 0; i < a.GetLength(0); i++) {
            if(emptyCnt == k && a[i,0] == -1) return i;
            if(a[i,0] >= curr || a[i,0] == -1)
                emptyCnt++;
        }
        return 0;
    }
}

public class Pair {
    public int x,y;
    public Pair(int x, int y) {
        this.x = x;
        this.y = y;
    }
}

public class MyCustomComparer : IComparer<Pair> {
    public int Compare(Pair p, Pair q) {
        return p.x - q.x;
    }
}
