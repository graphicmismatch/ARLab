using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirtualObj : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        InteractionManager.Interactibles.Add(this.gameObject);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
