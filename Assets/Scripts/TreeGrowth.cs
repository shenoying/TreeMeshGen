using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeGrowth 
{

    public TreeInfo info;
    List<TreeNode> nodes;
    public List<TreeNode> Nodes { get => nodes; set => nodes = value; }
    List<TreeInternode> internodes;
    public List<TreeInternode> Internodes { get => internodes; set => internodes = value; }

    public TreeGrowth(TreeInfo info)
    {
        this.info = info;
        this.nodes = new List<TreeNode>();
        this.internodes = new List<TreeInternode>();
    }

    public void Step()
    {
        for (int i = 0; i < Nodes.Count; i++)
        {
            TreeNode node = Nodes[i];
            for (int j = 0; j < node.Buds.Count; j++)
            {
                TreeBud bud = node.Buds[j];
                if (!bud.Alive) continue;
                bud.IncrementAge();
                if (Random.Range(0.0f, 1.0f) < info.DieProb && bud.Order > 3)
                {
                    bud.Alive = false;
                    // grow leaves here
                    node.Buds.Remove(bud);
                    node.GrowLeaf();
                }
                else if (Random.Range(0.0f, 1.0f) > info.PauseProb)
                {
                    // create internode
                    TreeInternode newInternode = node.CreateInternode(node, bud, info);
                    internodes.Add(newInternode);
                    nodes.Add(newInternode.End);
                    // create tip node
                    node.CreateTipNode(bud, info);

                    if (Random.Range(0.0f, 1.0f) < info.BranchProb)
                    {
                        // create side buds
                        node.CreateSideBuds(bud, info);
                    }
                }    
            }
        }
    }

    public void Reset()
    {
        info.Resample();
        this.nodes.Clear();
        this.internodes.Clear();
    }

    public void Grow(TreeInfo info)
    {
        for (int i = 0; i < info.NumSteps; i++)
        {
            Step();
        }
    }

}