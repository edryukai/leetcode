// 347 M Top K frequent elements
// https://leetcode.com/problems/top-k-frequent-elements/description/

import java.util.*;

class Solution {
    public List<Integer> topKFrequent(int[] nums, int k) {
        if(k <= 0 || nums.length == 0) return new ArrayList<Integer>();
        HashMap<Integer,Integer> h = new HashMap<Integer,Integer>();
        for(int i = 0; i < nums.length; i++) {
            if(h.containsKey(nums[i]))
                h.put(nums[i], 1 + h.get(nums[i]));
            else
                h.put(nums[i],1);
        }

        PriorityQueue<Pair> pq = new PriorityQueue<>(new Comparator<Pair>(){
            @Override
            public int compare(Pair a, Pair b) {
                return Integer.compare(b.freq, a.freq);
            }
        });

        Iterator it = h.entrySet().iterator();
        while(it.hasNext()) {
            Map.Entry pair = (Map.Entry)it.next();
            pq.offer(new Pair((int)pair.getKey(), (int)pair.getValue()));
        }

        List<Integer> res = new ArrayList<Integer>();
        while(k-- > 0) {
            Pair p = pq.poll();
            res.add(p.val);
        }

        return res;
    }
}

class Pair {
    int val;
    int freq;
    public Pair(int val, int freq) {
        this.val = val;
        this.freq = freq;
    }
}
