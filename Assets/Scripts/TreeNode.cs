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

    public void TimeStep()
    {
    
    }

}
