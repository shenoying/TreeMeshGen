using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeInfo 
{
    
    float dieProb;
    public float DieProb { get => dieProb; set => dieProb = value; }
    
    float pauseProb;
    public float PauseProb { get => pauseProb; set => pauseProb = value; }
    
    float branchProb;
    public float BranchProb { get => branchProb; set => branchProb = value; }

    float thickness;
    public float Thickness { get => thickness; set => thickness = value; }
    int detail;
    public float Detail { get => detail;}
    Color color;
    public Color Color { get => color; set => color = value; }
    int numSteps;
    public int NumSteps { get => numSteps; }

    
    public TreeInfo (float die, float pause, float branch, float thickness, int detail, Color color, int numSteps)
    {
        this.dieProb = die;
        this.pauseProb = pause;
        this.branchProb = branch;
        this.thickness = thickness;
        this.detail = detail;
        this.color = color;
        this.numSteps = numSteps;
    }

    public void Resample() 
    {
        this.color = TreeMeshUtils.GenerateRandomColor();
    }
}