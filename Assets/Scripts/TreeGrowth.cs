using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeGrowth 
{

    GameObject parent;
    public TreeInfo info;
    public List<Node> nodes;

    public TreeGrowth(GameObject parent, TreeInfo info)
    {
        this.parent = parent;
        this.info = info;

    }

    public void Step()
    {
        foreach (TreeNode node in nodes)
        {
            foreach (TreeBud bud in node.Buds)
            {
                if (!bud.Alive) continue;
                if (Random.Range(0.0f, 1.0f) < info.DieProb)
                {
                    bud.Alive = false;
                }
                else if (Random.Range(0.0f, 1.0f) > info.PauseProb)
                {
                    // create internode
                    // create tip node
                    if (Random.Range(0.0f, 1.0f) < info.BranchProb)
                    {
                        // create side buds
                    }
                }    
            }
        }
    }

}