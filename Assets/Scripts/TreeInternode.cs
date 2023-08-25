using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeInternode
{

    TreeNode start, end;
    float length;

    public TreeInternode (TreeNode start, TreeNode end) 
    {
        this.start = start;
        this.end = end;
        length = (end.Position - start.Position).length;
    }

}