// One guy in a group of k guys should be paid exactly same as min wage (intuition, think)
// So we fix that one guy and find the set of k possible guys
// This is greedy approach
// Time: O(n^2 log n)
public class Solution {
    public double MincostToHireWorkers(int[] quality, int[] wage, int K) {
        double ans = (double)Int32.MaxValue;
        for(int capt = 0; capt < quality.Length; capt++) {
            double ratio = (double)wage[capt]/(double)quality[capt];
            List<double> pricesInCurrGroup = new List<double>();
            pricesInCurrGroup.Add(wage[capt]);
            
            for(int j = 0; j < quality.Length; j++) {
                if(j == capt) continue;
                double price = ratio * quality[j];
                if(price < wage[j]) continue; // everyone should be at least paid min wage. If they are not, they are invalid for our group
                else pricesInCurrGroup.Add(price);
            }
            
            double[] pricesArr = pricesInCurrGroup.ToArray();
            Array.Sort(pricesArr);
            if(pricesArr.Length < K) continue;  // if we don't have at least K people in our group, it's an invalid group
            double curr_ans = 0.0;
            for(int it = 0; it < K; it++) {
                curr_ans += pricesArr[it];
            }
            
            ans = Math.Min(ans, curr_ans);
        }
        return ans;
    }
}

// Optimal solution
// - final_wage[i]/qual[i] = final_wage[j]/qual[j]
//   and there will be at least one guy in a group whose final_wage will be same as min_wage
//   let's call that guy "captain" and ratio as final_wage[capt]/qual[capt] which is same as min_wage[capt]/qual[capt]
// - In a group of K people,
//     capt determines the ratio. 
//     From the equation in first step, final_wage[x] = ratio[capt] * qual[x]
//     So if we fix the capt, we fix a ratio and we can get final_wage of everyone in the group
// - Naively, this can be done greedily by fixing ratio and trying out all workers to see which k workers are best
// - Optimally, we note a few things:
//     * total_wage = ratio * qual[1] + ratio * qual[2] + ... + ratio * qual[k]
//     * which is same as total_wage = ratio * sum(quality_of_group)
//     * To minimize total_wage, we need a small ratio. So we iterate over ratios and pick an optimal group
//     * So we first calculate ratio of all workers, and sort them by ratio. Let's pick the first K workers now
//     * So total_wage now is ratio[k-1]*sum(quality[0..k-1])
//     * When we consider the next guy for our group of size k, we get guy with next higher ratio. This means ratio for entire group increased.
//     * Who do we out? The guy in our group with highest quality. Coz higher quality increases total wage
//         * Think about it. Pick some random guy in the group. This guy has some wage and some quality 
//         * But the ratio is fixed, so his wage doesn't matter. So the only factor that affects our total sum is quality
//         * total_wage is directly proportional to quality so we kick the guy with max quality off the group 
//     * tldr: for a given ratio of wage/quality, find minimum total_wage of k workers
// - FAQ: When we remove the worker with highest quality, it could as well be our new worker. Then we would be using his ratio, while he is not there.
//     * This case doesn't matter because, we will then be left with the same group as before, and we already calculate total_wage for that group with a lower ratio (since we are picking people based on sorted ratios, remember?)

public double minCostToHireWorkers(int[] quality, int[] wage, int K) {
    // index 0 -> ratio
    // index 1 -> quality 
    double[][] workers = new double[quality.length][2];
    double res = Double.MAX_VALUE, quality_sum = 0;

    for(int i = 0; i < quality.length; i++) {
        workers[i] = new double[] {(double)(wage[i])/quality[i], (double)quality[i]};
    }

    Arrays.sort(workers, (a,b) -> Double.compare(a[0],b[0]));
    PriorityQueue<Double> pq = new PriorityQueue<>();

    for(double[] curr_worker : workers) {
        quality_sum += curr_worker[1];
        pq.add(-curr_worker[1]);     // add negative to make this act as a max pq wrt quality 
        // once we have more than K people, remove the one with highest quality 
        // and remove his sum from quality_sum
        // since pq has negative elements, removing his sum is same as adding pq.poll()
        // and since it's a min pq it will return the one with highest quality coz of adding -ve numbers :)
        if(pq.size() > K) {
            quality_sum += pq.poll();
        }
        // if we have a group of K people, update result using quality_sum * ratio 
        // where ratio is being iterated over, so it's curr_worker[0]
        if(pq.size() == K) {
            res = Math.min(res, quality_sum * curr_worker[0]);
        }
    }

    return res;
}

// Time: O(n log n) + O(n log k)
