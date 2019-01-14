// Trie
// Insert("apple")
// Search("apple")
// StartsWith("app")

public class  TrieNode {
    // item => word that ends at this node
    public string item = "";
    public TrieNode[] children = new TrieNode[26];
}

public class Trie  {
    public TrieNode root;

    public Trie() {
        root = new TrieNode();
    }

    // traverse from root till you encounter a char that has not been created along the path
    public void Insert(string word) {
        var node = root;
        foreach(char x in word.ToCharArray()) {
            if(node.children[x-'0'] == null) {
                node.children[x-'0'] = new TrieNode();
            }
            node = node.children[x-'0'];
        }
        node.item = word;
    }

    public bool Search(string word) {
        var node = root;
        foreach(char x in word.ToCharArray()) {
            if(node.children[x-'0'] == null)
                return false;
            node = node.children[x-'0'];
        }
        return node.item.Equals(word);
    }

    public bool StartsWith(string word) {
        var node = root;
        foreach (char x in word.ToCharArray()) {
            if(node.children[x-'0'] == null)
                return false;
            node = node.children[x-'0'];
        }
        return true;
    }
}