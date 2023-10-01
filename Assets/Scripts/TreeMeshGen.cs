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
    public int detail = 8;
    public float height = 5.0f;
    public float stepSize = 1.5f;
    public int maxDepth = 7;
    public int numSteps = 100;


    // Start is called before the first frame update
    void Start()
    {
        Random.InitState(seed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
