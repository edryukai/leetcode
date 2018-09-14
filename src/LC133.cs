// 133 M https://leetcode.com/problems/clone-graph/description/
// Logic: Use BFS to clone nodes
// Space: O(V+E)
// Time: O(V+E)

/**
 * Definition for undirected graph.
 * public class UndirectedGraphNode {
 *     public int label;
 *     public IList<UndirectedGraphNode> neighbors;
 *     public UndirectedGraphNode(int x) { label = x; neighbors = new List<UndirectedGraphNode>(); }
 * };
 */
public class Solution {
    public UndirectedGraphNode CloneGraph(UndirectedGraphNode node) {
        if(node == null) return null;
        UndirectedGraphNode root_of_clone = new UndirectedGraphNode(node.label);
        
        // Using dictionary to track discovered nodes
        // key: original node, val: cloned node
        var discoveredNodes = new Dictionary<UndirectedGraphNode,UndirectedGraphNode>();
        
        // BFS
        var q = new Queue<UndirectedGraphNode>();
        discoveredNodes[node] = root_of_clone;
        q.Enqueue(node);
        
        while(q.Count != 0) {
            UndirectedGraphNode curr = q.Dequeue();
            
            foreach(UndirectedGraphNode neighbor in curr.neighbors) {
                if(!discoveredNodes.ContainsKey(neighbor)) {
                    discoveredNodes[neighbor] = new UndirectedGraphNode(neighbor.label);
                    q.Enqueue(neighbor);
                }
                
                // discoveredNodes[curr] is the clone of curr node which is already present in dict since it was retrieved from q
                // we add clones of every neighbor of curr node to neighbors list of cloned curr node
                discoveredNodes[curr].neighbors.Add(discoveredNodes[neighbor]);
            }
        }
        
        return root_of_clone;
    }
}