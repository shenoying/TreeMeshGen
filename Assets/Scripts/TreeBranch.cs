using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeBranch 
{
    List<TreeNode> nodes;
    public List<TreeNode> Nodes { get => nodes; set => nodes = value; }
    int order;
    public int Order { get => order; }
    float radius;
    public float Radius { get => radius; }

    public TreeBranch(TreeNode root, int order, float radius)
    {
        nodes = new List<TreeNode>();
        nodes.Add(root);
        this.order = order;
        this.radius = radius;
    }

}