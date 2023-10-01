using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeBud
{

    Vector3 direction;
    public Vector3 Direction {get => direction; set => direction = value;}
    Vector3 tangent;
    public Vector3 Tangent {get => tangent; set => tangent = value;}
    Vector3 normal;
    public Vector3 Normal {get => normal; set => normal = value;}
    Vector3 binormal;
    public Vector3 Binormal {get => binormal; set => binormal = value;}
    // TreeInfo info;
    // public TreeInfo Info {get => info; set => info = value;}
    // float dieProb;
    // public float DieProb { get => dieProb; set => dieProb = value; }
    
    // float pauseProb;
    // public float PauseProb { get => pauseProb; set => pauseProb = value; }
    
    // float branchProb;
    // public float BranchProb { get => branchProb; set => branchProb = value; }
    
    int age;
    public int Age {get => age;}
    
    int order;
    public int Order {get => order;}
    bool alive;
    public bool Alive {get => alive; set => alive = value;}
    Vector3 position;
    public TreeNode Position {get => position;}

    public TreeBud(Vector3 position, Vector3 tangent, Vector3 normal, Vector3 binormal, int order) 
    { 
        
        this.alive = true;
        this.position = position;
        this.tangent = tangent;
        this.normal = normal;
        this.binormal = binormal;
        this.order = order;
        this.age = 0;
    }

    public void IncrementAge()
    {
        this.Age++;
    }

    public void TimeStep()
    {
        
    }


}