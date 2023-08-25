using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeInfo 
{
    
    float dieProb;
    public float DieProb {get => dieProb; set => value;}
    
    float pauseProb;
    public float PauseProb {get => pauseProb; set => value;}
    
    float branchProb;
    public float BranchProb {get => branchProb; set => value;}

    public TreeInfo (float die, float pause, float branch)
    {
        this.dieProb = die;
        this.pauseProb = pause;
        this.branchProb = branch;
    }
}