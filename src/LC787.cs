// 787 M https://leetcode.com/problems/cheapest-flights-within-k-stops/discuss/

// Input
// flights have src, dst, price
// f[0] - src
// f[1] - dest
// f[2] - price
public int findCheapestPrice(int n, int[][] flights, int src, int dst, int k) {
    var pricesDict = new Dictionary<int, Dictionary<int,int>>(); 
    // by end of following loop, we have prices map which is:
    // < source, map of <dest, price> for every dest accessible from this source>
    for (int[] f : flights) {
        if (!pricesDict.ContainsKey(f[0])) pricesDict[f[0]] = new Dictionary<int,int>();
        pricesDict[f[0]].Put(f[1], f[2]);
    }

    // it's a min pq on price
    PriorityQueue<Destination> pq = new PriorityQueue<>((a,b) -> (Integer.compare(a.price, b.price)));
    pq.add(new Destination(0, src, k+1));
    
    // We start with src
    // put all possible destinations from src into pq with stops = stops-1 meaning we covered one hub
    // pick the greediest one based on price so that the first time we hit our dest within <= k stops, we can return price 
    while (!pq.isEmpty()) {
        if (curr.city == dst) return curr.price;
        if (curr.remStops > 0) {
            // find accessible places from this hub <dest_city,price>
            Dictionary<int,int> adjaceny = pricesDict[curr.city];
            foreach (int dest_city in adjaceny.Keys) {
                pq.add(new Destination(curr.price + adjaceny[dest_city], dest_city, curr.remStops-1));
            }
        }
        // if remStops are <= 0, then there's no point in exploring cities from that hub so we ignore and move ahead 
        // to exploring destinations via other cities we have in pq
    }
    return -1;
}

class Destination {
    int price;
    int city;
    int remStops;

    public Destination(int p, int c, int s) {
        price = p;
        city = c;
        remStops = s;
    }
}
