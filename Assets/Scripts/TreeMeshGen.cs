using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeMeshGen : MonoBehaviour
{

    public int seed = 70;
    [Range(0.0f, 1.0f)]
    public float dieProb = 0.25f;
    [Range(0.0f, 1.0f)]
    public float branchProb = 0.52f;
    [Range(0.0f, 1.0f)]
    public float pauseProb = 0.37f;
    [Range(0.0f, 1.0f)]
    public float orthoProb = 0.55f;
    public int detail = 8;
    public float height = 5.0f;
    [Range(0.1f, 3.0f)]
    public float thickness = 1.0f;
    public float stepSize = 1.5f;
    public int maxDepth = 7;
    [Range(0, 75)]
    public int numSteps = 25;
    public List<TreeGrowth> growth = new List<TreeGrowth>();

    // Start is called before the first frame update
    void Start()
    {
        Random.InitState(seed);
        Color color = TreeMeshUtils.GenerateRandomColor();
        ///TODO: add thickness param
        TreeInfo info = new TreeInfo (
            dieProb, pauseProb, branchProb, orthoProb, height, thickness, detail, color, numSteps, maxDepth, stepSize, orthoProb
        );

        GameObject world = new GameObject("Trees");

        for (int i = 0; i < 3; i++) 
        {
            Vector3 l = new Vector3(i * 40.0f - 40.0f, 0.0f, 40.0f);
            CreateTree(l, world, info);
        }
    }

    public void CreateTree(Vector3 position, GameObject parent, TreeInfo info)
    {
        info.Resample();

        GameObject tree = new GameObject("PCG Tree");
        GameObject leaves = new GameObject("Leaf Parent");

        tree.AddComponent<MeshFilter>();
        tree.AddComponent<MeshRenderer>();

        tree.transform.parent = parent.transform;
        leaves.transform.parent = tree.transform;
        
        float h = info.Height;

        TreeGrowth tg = new TreeGrowth(info, leaves);
        TreeBud bud = new TreeBud (
            new Vector3(0.0f, 1.0f, 0.0f),
            new Vector3(0.0f, 0.0f, 1.0f),
            new Vector3(1.0f, 0.0f, 0.0f),
            0
        );

        TreeNode trunkNode = new TreeNode(position, 0);
        TreeNode apicalNode = new TreeNode(new Vector3(position.x, h, position.z), 1);
        
        apicalNode.Buds.Add(bud);
        TreeBranch b = new TreeBranch(trunkNode, 0, info.Thickness);
        b.Nodes.Add(apicalNode);
        
        tg.Branches.Add(b);
        tg.Internodes.Add(new TreeInternode(trunkNode, apicalNode, 1.00f));

        tg.Grow(info);
        growth.Add(tg);

        TreeMeshUtils.RenderTreeCR(tg, info, tree);
        
        Debug.Log("Internodes: " + tg.Internodes.Count + ", Branches: " + tg.Branches.Count);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}