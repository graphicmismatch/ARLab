using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burette : MonoBehaviour
{
    public float radius;
    public Titrateable inRange;
    public GameObject particle;
    public GameObject pt;
    public bool on;
    string[] lm = { "Default", "XR Simulation" };
    ProximitySense[] colls;
    // Start is called before the first frame update
    void Start()
    {
        colls = FindObjectsByType<ProximitySense>(FindObjectsSortMode.None);
    }

    // Update is called once per frame
    void Update()
    {
        particle.SetActive(inRange != null);
        

        foreach (ProximitySense c in colls)
        {
            if (Mathf.Abs(Vector3.Distance(c.gameObject.transform.position, pt.transform.position)) <= radius)
            {
                //if (c.gameObject != inRange.gameObject && inRange != null)
                //{
                //    inRange.filling = false;
                //}
                inRange = c.gameObject.GetComponent<Titrateable>();
                inRange.filling = true;
            }
            else {
                inRange.filling = false;
                inRange = null;
            }
        }
        if (colls.Length == 0)
        {
            
        }
    }
}


