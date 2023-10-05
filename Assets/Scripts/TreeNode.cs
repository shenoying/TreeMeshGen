using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeNode
{

    Vector3 position;
    public Vector3 Position { get => position; set => position = value; }
    List<TreeBud> buds;
    public List<TreeBud> Buds { get => buds; }


    public TreeNode(Vector3 position) 
    {
        this.position = position;
        this.buds = new List<TreeBud>();
    } 


    public void CreateSideBuds(TreeBud bud, TreeInfo info)
    {
        if (bud.Order + 1 > info.MaxDepth) return;
        // modify to allow more side buds?
        //if (bud.Order <= 3)
        //{
            Vector3 newT = (
                (Quaternion.AngleAxis(Random.Range(-30.0f, 30.0f), bud.Binormal)) * 
                (Quaternion.AngleAxis(Random.Range(-30.0f, 30.0f), bud.Normal) * bud.Tangent)
                ).normalized;
            Vector3 newB = Vector3.Cross(newT, bud.Normal).normalized;
            Vector3 newN = Vector3.Cross(newB, newT);

            TreeBud newBud = new TreeBud(newT, newN, newB, bud.Order + 1);
            buds.Add(newBud);
        //}
        
    }

    // should this be of type TreeNode?
    public TreeInternode CreateInternode(TreeNode node, TreeBud bud, TreeInfo info)
    {
        // try to decrease dT with increasing depth
        float dT = 4.0f * ((info.MaxDepth + 1.0f - bud.Order) / info.MaxDepth);
        Vector3 newPos = node.Position + bud.Tangent * dT;
        TreeNode newNode = new TreeNode(newPos);

        /**
        Vector3 rand = new Vector3(0.001f + Random.Range(-0.01f, 0.01f), 0.001f + Random.Range(0.0f, 0.02f), 0.001f + Random.Range(-0.01f, 0.01f));
        Vector3 newT = rand.normalized;
        Vector3 newN = bud.Normal * Mathf.Cos(30.0f) + bud.Binormal * Mathf.Sin(30.0f);
        Vector3 newB = Vector3.Cross(newT, newN).normalized;
        TreeBud newBud = new TreeBud(newT, newN, newB, bud.Order + 1);
        
        newNode.Buds.Add(newBud);
        **/

        TreeInternode internode = new TreeInternode(node, newNode, 0.01f);

        return internode;
    }

    // apical growth
    public void CreateTipNode(TreeBud bud, TreeInfo info)
    {

    }

    public void GrowLeaf()
    {

    }

}
