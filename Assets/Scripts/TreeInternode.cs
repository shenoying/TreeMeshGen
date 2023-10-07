using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeInternode
{

    TreeNode start;
    public TreeNode Start { get => start; set => start = value; }
    TreeNode end;
    public TreeNode End { get => end; set => end = value; }
    float size;
    public float Size { get => size; set => size = value; }

    public TreeInternode(TreeNode start, TreeNode end, float size)
    {
        this.start  = start;
        this.end    = end;
        this.size   = size;
    }

}
