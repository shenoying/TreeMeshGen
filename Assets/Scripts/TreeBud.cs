using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeBud
{

    Vector3 direction;
    public Vector3 Direction {get => direction; set => value;}
    TreeInfo info;
    public TreeInfo Info {get => info; set => value;}
    
    int age;
    public int Age {get => age;}
    
    int order;
    public int Order {get => order;}
    bool alive;
    public bool Alive {get => alive;}
    TreeNode parent;
    public TreeNode Parent {get => parent;}

    public TreeBud(Vector3 direction, TreeInfo info, TreeNode parent) 
    { 
        
        this.alive = true;
        this.info = info;
        this.parent = parent;
    }

    public void TimeStep()
    {
        if (Random.Range(0.0f, 1.0f) > pauseProb) 
        {
            // create internode
        } 
    }

    public TreeInfo info

}