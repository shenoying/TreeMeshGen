using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeMeshGen : MonoBehaviour
{

    public int seed = 70;

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
