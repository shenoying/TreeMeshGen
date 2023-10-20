using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeGrowth 
{

    public TreeInfo info;
    List<TreeInternode> internodes;
    public List<TreeInternode> Internodes { get => internodes; set => internodes = value; }
    List<TreeBranch> branches;
    public List<TreeBranch> Branches { get => branches; set => branches = value; }
    GameObject leafParent;
    public GameObject LeafParent { get => leafParent; }


    public TreeGrowth(TreeInfo info, GameObject leafParent)
    {
        this.info       = info;
        this.internodes = new List<TreeInternode>();
        this.branches   = new List<TreeBranch>();
        this.leafParent = leafParent;
    }

    public void Step()
    {
        int branchCount = branches.Count;
        for (int i = 0; i < branchCount; i++) 
        {
            TreeBranch branch = branches[i];
            List<TreeNode> nodes = branch.Nodes;
            int nodeCount = nodes.Count;
            for (int j = 0; j < nodeCount; j++)
            {
                TreeNode node = nodes[j];
                int budCount = node.Buds.Count;
                for (int k = 0; k < budCount; k++) 
                {
                    TreeBud bud = node.Buds[k];
                    if (!bud.Alive) continue;
                    bud.IncrementAge();
                    if (Random.Range(0.0f, 1.0f) < info.DieProb && bud.Order > 3)
                    {
                        bud.Alive = false;
                        node.Buds.Remove(bud);
                        node.GrowLeaf(node.Position, bud.Order, info, this.leafParent);
                    }
                    else if (Random.Range(0.0f, 1.0f) > info.PauseProb)
                    {
                        // create internode and create tip node
                        TreeInternode newInternode = node.CreateInternode(bud, info);
                        branch.Nodes.Add(newInternode.End);
                        internodes.Add(newInternode);
                        
                        if (Random.Range(0.0f, 1.0f) < info.BranchProb && bud.Order <= info.MaxDepth)
                        {
                            // create side buds
                            TreeBud sidebud = node.CreateSideBuds(bud, info);
                            float rad = info.Thickness;
                            if (sidebud != null) CreateSideBranch(node, sidebud, sidebud.Order, rad);
                        }
                    }
                }
            }
        }
    } 

    public void Reset()
    {
        info.Resample();
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

    public void CreateSideBranch(TreeNode parent, TreeBud bud, int order, float rad)
    {
        TreeNode node = new TreeNode(parent.Position, parent.Depth);
        node.Buds.Add(bud);

        TreeBranch branch = new TreeBranch(node, order, rad);
        branches.Add(branch);
    }

}