// https://leetcode.com/problems/logger-rate-limiter/description/
// Design a logger system that receive stream of messages along with its timestamps, each message should be printed if and only if it is not printed in the last 10 seconds.
// Space complexity: O(n)
// Time complexity per call: O(1)

public class Logger {

    // <message, max recent timestamp>
    Dictionary<string,int> logs;
    
    /** Initialize your data structure here. */
    public Logger() {
        logs = new Dictionary<string,int>();    
    }
    
    public bool ShouldPrintMessage(int timestamp, string message) {
        
        // Message has never been printed before
        if(!logs.ContainsKey(message)) {
            logs[message] = timestamp;
            return true;
        }
        else {
            int maxRecentPrintedTS = logs[message];
            bool shouldPrint = Math.Abs(timestamp - maxRecentPrintedTS) >= 10;
            
            // Update printed timestamp if current message will end up being printed
            if(shouldPrint) {
                logs[message] = timestamp > maxRecentPrintedTS ? timestamp : maxRecentPrintedTS;    
            }
            
            return shouldPrint;
        }
    }
}