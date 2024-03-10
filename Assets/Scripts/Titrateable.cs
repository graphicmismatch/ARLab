using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Titrateable : MonoBehaviour
{
    public bool canFill;
    public float cd;
    private float timer = 0;
    public bool filling;
    public Animator anim;
    bool filled = false;
    Vector3 lastPos;
    public float threshold;
    public float maxTitration;
    private float curTitration;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (filling) {
            curTitration += Time.deltaTime;
        }
        if (canFill)
        {
            if (filling && !filled)
            {
                anim.SetTrigger("Fill");
                filled = true;
                timer = 0;
                canFill = false;
            }
        }
        else {
            timer += Time.deltaTime;
            canFill = timer>=cd;
        }

        if (filled && maxTitration>curTitration) {
            if (Vector3.Distance(this.transform.position, lastPos) / Time.deltaTime >= threshold) {
                anim.SetTrigger("Dissipate");
            }
        }

        lastPos = this.transform.position;
    }
}
