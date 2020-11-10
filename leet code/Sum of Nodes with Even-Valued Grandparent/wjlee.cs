public class Solution
{
    public int GrandChildSum(TreeNode root)
    {
        var childrenCandidate = new int?[] {
                root?.left?.left?.val,
             root?.left?.right?.val,
             root?.right?.left?.val,
             root?.right?.right?.val };

        var children = childrenCandidate.Where(x => x.HasValue).Select(x => x.Value);
        return children.Sum();
    }
    public bool isEven(TreeNode a) => isEven(a.val);
    public bool isEven(int a) => a % 2 == 0;

    public int SumEvenGrandparent(TreeNode root)
    {
        return recursiveInorder(root);
    }

    public int recursiveInorder(TreeNode root)
    {
        if (root == null)
        {
            return 0;
        }

        if (isEven(root))
        {
            return GrandChildSum(root) + recursiveInorder(root.left) + recursiveInorder(root.right);
        }
        else
        {
            return recursiveInorder(root.left) + recursiveInorder(root.right);
        }
    }
}
