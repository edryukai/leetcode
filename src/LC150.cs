// 150 M RPN/Postfix notation
// Push non-operands into stack
// Whenever you encounter an operand, pop top two numbers, evaluate and push it back into stack
public class Solution {
    public int EvalRPN(string[] tokens) {
        if(tokens == null || tokens.Length == 0) return 0;
        
        var h = new HashSet<string>() {"+","-","*","/"};
        var st = new Stack<string>();
        
        foreach(string x in tokens) {
            if(h.Contains(x)) {
                int num2 = Convert.ToInt32(st.Pop());
                int num1 = Convert.ToInt32(st.Pop());
                int res = Evaluate(num1,num2,x);
                st.Push(res.ToString());
            }
            else
                st.Push(x);
        }
        
        return Convert.ToInt32(st.Pop());
    }
    
    private int Evaluate(int num1, int num2, string op) {
        if(op.Equals("+")) return num1+num2;
        else if(op.Equals("-")) return num1-num2;
        else if(op.Equals("*")) return num1*num2;
        else return num1/num2;
    }
}
