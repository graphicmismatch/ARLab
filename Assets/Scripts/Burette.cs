using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burette : MonoBehaviour
{
    public GameObject area;
    public float radius;
    public Titrateable inRange;
    public GameObject particle;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        particle.SetActive(inRange);
        Collider[] colls = Physics.OverlapSphere(area.transform.position, radius);
        foreach (Collider c in colls)
        {
            if (c.gameObject.GetComponent<ProximitySense>())
            {
                if (c.gameObject != inRange.gameObject && inRange != null)
                {
                    inRange.filling = false;
                }
                inRange = c.gameObject.GetComponent<Titrateable>();
                inRange.filling = true;
            }
        }
        if (colls.Length == 0)
        {
            inRange.filling = false;
            inRange = null;
        }
    }
}


