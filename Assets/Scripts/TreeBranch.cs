using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeBranch 
{
    List<TreeNode> nodes;
    public List<TreeNode> Nodes { get => nodes; set => nodes = value; }

    public TreeBranch()
    {
        nodes = new List<TreeNode>();
    }

}