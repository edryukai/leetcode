// 692 M Top K Frequent words
// Straight forward heap implementation

import java.util.*;
class Solution {
    public List<String> topKFrequent(String[] words, int k) {
        if(k <= 0 || words.length == 0)
            return new ArrayList<String>();
        
        HashMap<String,Integer> h = new HashMap<>();
        for(String word : words) {
            if(h.containsKey(word)) {
                h.put(word, h.get(word)+1);
            }
            else 
                h.put(word,1);
        }
        
        PriorityQueue<Pair> pq = new PriorityQueue<>(new PairComparator());
        Iterator it = h.entrySet().iterator();
        while (it.hasNext()) {
            Map.Entry me = (Map.Entry)it.next();
            Pair temp = new Pair(me.getKey().toString(), (int)me.getValue());
            pq.offer(temp);
        }
        
        List<String> res = new ArrayList<String>();
        while(k-- > 0) {
            Pair temp = pq.poll();
            res.add(temp.word);
        }
        
        return res;
    }
}

class Pair {
    String word;
    int frequency;
    
    public Pair(String word, int frequency) {
        this.word = word;
        this.frequency = -1*frequency;
    }
}

class PairComparator implements Comparator<Pair> {
     public int compare(Pair p1, Pair p2)
     {
         if(p1.frequency == p2.frequency) {
             return p1.word.compareTo(p2.word);
         }
         else 
             return p1.frequency - p2.frequency;
     }
 }
