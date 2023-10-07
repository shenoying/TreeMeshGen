using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeBud
{

    Vector3 tangent;
    public Vector3 Tangent {get => tangent; set => tangent = value;}
    Vector3 normal;
    public Vector3 Normal {get => normal; set => normal = value;}
    Vector3 binormal;
    public Vector3 Binormal {get => binormal; set => binormal = value;}
    int age;
    public int Age { get => age; set => age = value; }
    
    int order;
    public int Order {get => order;}
    bool alive;
    public bool Alive {get => alive; set => alive = value;}


    public TreeBud(Vector3 tangent, Vector3 normal, Vector3 binormal, int order) 
    { 
        
        this.alive      = true;
        this.tangent    = tangent;
        this.normal     = normal;
        this.binormal   = binormal;
        this.order      = order;
        this.age        = 0;
    }

    public void IncrementAge()
    {
        this.Age++;
    }

    public void TimeStep()
    {
        
    }


}