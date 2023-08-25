using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeNode
{

    Vector3 position;
    public Vector3 Position { get => position; set => position = value; }
    public List<TreeBud> buds;


    public TreeNode(Vector3 position, float phase) 
    {
        this.position = position;
        this.phase = phase;

        this.buds = new List<TreeBud>();
    } 

    public void TimeStep()
    {
    
    }

}
