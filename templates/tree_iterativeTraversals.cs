// Iterative in-order traversal

public List<int> InOrder(TreeNode root){
  var list = new List<int>();
  if(root == null) return list;

  var st = new Stack<int>();
  while(root != null || st.Count != 0){
    while(root != null){
      st.Push(root);
      root = root.left;
    }

    root = st.Pop();
    list.Add(root.val);
    root = root.right;
  }
  return list;
}
