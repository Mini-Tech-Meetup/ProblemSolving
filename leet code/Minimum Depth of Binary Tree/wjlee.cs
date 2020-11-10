public class Solution
{
    public int MinDepth(TreeNode root)
    {
        return recursiveInorder(root);
    }


    public int recursiveInorder(TreeNode root)
    {
        if (root == null)
        {
            return 0;
        }
        else if (root.left == null && root.right == null)
        {
            return 1;
        }
        else if (root.left == null && root.right != null)
        {
            return recursiveInorder(root.right) + 1;
        }
        else if (root.right == null && root.left != null)
        {
            return recursiveInorder(root.left) + 1;
        }


        var left = recursiveInorder(root.left) + 1;
        var rigth = recursiveInorder(root.right) + 1;
        return left < rigth ? left : rigth;
    }
}
