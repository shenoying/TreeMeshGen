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
    List<TreeBranch> branches;
    public List<TreeBranch> Branches { get => branches; set => branches = value; }

    public TreeGrowth(TreeInfo info)
    {
        this.info       = info;
        this.nodes      = new List<TreeNode>();
        this.internodes = new List<TreeInternode>();
        this.branches   = new List<TreeBranch>();
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
                    node.Buds.Remove(bud);
                    //node.GrowLeaf(node.Position, bud.Order, info);
                }
                else if (Random.Range(0.0f, 1.0f) > info.PauseProb)
                {
                    // create internode and create tip node
                    TreeInternode newInternode = node.CreateInternode(bud, info);
                    internodes.Add(newInternode);
                    nodes.Add(newInternode.End);

                    if (Random.Range(0.0f, 1.0f) < info.BranchProb)
                    {
                        // create side buds
                        node.CreateSideBuds(bud, info);
                    }
                }    
            }
        }
    }

    public void BranchStep()
    {
        List<TreeBranch> newBranches = new List<TreeBranch>();
        for (int i = 0; i < branches.Count; i++) 
        {
            TreeBranch branch = branches[i];
            List<TreeNode> nodes = branch.Nodes;
            for (int j = 0; j < nodes.Count; j++)
            {
                TreeNode node = nodes[j];
                for (int k = 0; k < node.Buds.Count; k++) 
                {
                    TreeBud bud = node.Buds[k];
                    if (!bud.Alive) continue;
                    bud.IncrementAge();
                    if (Random.Range(0.0f, 1.0f) < info.DieProb && bud.Order > 3)
                    {
                        bud.Alive = false;
                        node.Buds.Remove(bud);
                        //node.GrowLeaf(node.Position, bud.Order, info);
                    }
                    else if (Random.Range(0.0f, 1.0f) > info.PauseProb)
                    {
                        // create internode and create tip node
                        TreeInternode newInternode = node.CreateInternode(bud, info);
                        branch.Nodes.Add(newInternode.End);
                        internodes.Add(newInternode);
                        nodes.Add(newInternode.End);

                        if (Random.Range(0.0f, 1.0f) < info.BranchProb && bud.Order <= info.MaxDepth)
                        {
                            // create side buds
                            node.CreateSideBuds(bud, info);
                            //TreeBranch b = new TreeBranch(node);
                            //omit 1 node branches
                            //give nodes children references
                            //do dfs with children nodes to draw
                            //newBranches.Add(b);
                        }
                    }
                }
            }
        }

        foreach (TreeBranch branch in newBranches)
        {
            branches.Add(branch);
        }
    } 

    public void Reset()
    {
        info.Resample();
        this.nodes.Clear();
        this.internodes.Clear();
        this.branches.Clear();
    }

    public void Grow(TreeInfo info)
    {
        for (int i = 0; i < info.NumSteps; i++)
        {
            Step();
        }
    }

}