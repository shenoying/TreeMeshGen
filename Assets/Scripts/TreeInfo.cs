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
    float orthoProb;
    public float OrthoProb { get => orthoProb; set => orthoProb = value; }

    float height;
    public float Height { get => height; set => height = value; }
    float thickness;
    public float Thickness { get => thickness; set => thickness = value; }
    int detail;
    public int Detail { get => detail;}
    Color color;
    public Color Color { get => color; set => color = value; }
    int numSteps;
    public int NumSteps { get => numSteps; }
    int maxDepth;
    public int MaxDepth { get => maxDepth;}
    float stepSize;
    public float StepSize { get => stepSize; } 
    bool branchesUp;
    public bool BranchesUp { get => branchesUp; }
    
    public TreeInfo (float die, float pause, float branch, float ortho, float height, float thickness, int detail, Color color, int numSteps, int maxDepth, float stepSize, float orthoProb)
    {
        this.dieProb    = die;
        this.pauseProb  = pause;
        this.branchProb = branch;
        this.orthoProb  = ortho;
        this.height     = height;
        this.thickness  = thickness;
        this.detail     = detail;
        this.color      = color;
        this.numSteps   = numSteps;
        this.maxDepth   = maxDepth;
        this.stepSize   = stepSize;
        this.branchesUp = (Random.Range(0.0f, 1.0f) < orthoProb);
    }

    public void Resample() 
    {
        this.color = TreeMeshUtils.GenerateRandomColor();
        this.branchesUp = (Random.Range(0.0f, 1.0f) < orthoProb);
    }
}