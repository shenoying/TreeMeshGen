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

    float height;
    public float Height { get => height; set => height = value; }
    int detail;
    public int Detail { get => detail;}
    Color color;
    public Color Color { get => color; set => color = value; }
    int numSteps;
    public int NumSteps { get => numSteps; }
    int maxDepth;
    public int MaxDepth { get => maxDepth;}

    
    public TreeInfo (float die, float pause, float branch, float height, int detail, Color color, int numSteps, int maxDepth)
    {
        this.dieProb = die;
        this.pauseProb = pause;
        this.branchProb = branch;
        this.height = height;
        this.detail = detail;
        this.color = color;
        this.numSteps = numSteps;
        this.maxDepth = maxDepth;
    }

    public void Resample() 
    {
        this.color = TreeMeshUtils.GenerateRandomColor();
    }
}