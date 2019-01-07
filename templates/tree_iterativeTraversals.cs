// Iterative Pre Order

public List<int> preorder(TreeNode root) {
    var result = new List<int>();
    var stack = new Stack<int>();
    TreeNode p = root;

    while(stack.Count != 0 || p != null) {
        if(p != null) {
            stack.Push(p);
            result.Add(p.val);  // add before going to children
            p = p.left;
        }
        // if we came here, this means p was null 
        // which means no left child
        else {
            TreeNode node = stack.Pop();
            p = node.right;
        }
    }

    return result;
}

// Iterative In-Order

public List<int> inorder(TreeNode root) {
    var result = new List<int>();
    var stack = new Stack<int>();
    TreeNode p = root;

    while(stack.Count != 0 || p != null) {
        if(p != null) {
            stack.Push(p);
            p = p.left;
        }
        else {
            TreeNode node = stack.Pop();
            result.Add(node.val);
            p = node.right;
        }
    }

    return result;
}

// Iterative post order

public List<int> postorder(TreeNode root) {
    var result = new List<int>();
    var stack = new Stack<int>();
    TreeNode p = root;

    while(stack.Count != 0 && p != null) {
        if(p != null) {
            stack.Push(p);
            result.AddAt(0,p.val);      // reverse pre-order
            p = p.right;                // reverse pre-order
        }
        else {
            TreeNode node = stack.Pop();
            p = node.left;              // reverse pre-order
        }
    }
    return result;
}
