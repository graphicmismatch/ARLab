using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    public GameObject InHand;
    public bool Interactable = false;
    public GameObject Hand;
    public static List<GameObject> Interactibles = new List<GameObject>();
    public GameObject Spawn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TrackingInfo tracking = ManomotionManager.Instance.Hand_infos[0].hand_info.tracking_info;
        if (Interactable)
        {
            if (GameManager.GI.mano_class == ManoClass.PINCH_GESTURE)
            {
                if (GameManager.GI.mano_gesture_trigger == ManoGestureTrigger.PICK)
                {
                    if (!InHand)
                    {
                        GameObject closest;
                        float d = 1000;
                        closest = Interactibles[0];
                        foreach (GameObject g in Interactibles)
                        {
                            if (Vector3.Distance(g.transform.position, Hand.transform.position) < d)
                            {
                                d = Vector3.Distance(g.transform.position, Hand.transform.position);
                                closest = g;
                            }
                        }
                        InHand = closest;
                        if (InHand.GetComponent<Rigidbody>())
                        {
                            InHand.GetComponent<Rigidbody>().isKinematic = false;
                        }
                    }
                    InHand.transform.position = Camera.main.ViewportToWorldPoint(new Vector3(tracking.palm_center.x, tracking.palm_center.y, tracking.depth_estimation));
                }
                else if (GameManager.GI.mano_gesture_continuous == ManoGestureContinuous.HOLD_GESTURE) {
                    InHand.transform.position = Camera.main.ViewportToWorldPoint(new Vector3(tracking.palm_center.x, tracking.palm_center.y, tracking.depth_estimation));
                    if (InHand.GetComponent<Rigidbody>())
                    {
                        InHand.GetComponent<Rigidbody>().isKinematic = false;
                    }
                }
                else if (GameManager.GI.mano_gesture_trigger == ManoGestureTrigger.DROP)
                {
                    if (InHand)
                    {
                        InHand.transform.position = Camera.main.ViewportToWorldPoint(new Vector3(tracking.palm_center.x, tracking.palm_center.y, tracking.depth_estimation));
                        
                        if (InHand.GetComponent<Rigidbody>())
                        {
                            InHand.GetComponent<Rigidbody>().isKinematic = true;
                        }
                        InHand = null;
                    }
                }
               
            }
            else
            {
                if (InHand)
                {
                    if (InHand.GetComponent<Rigidbody>())
                    {
                        InHand.GetComponent<Rigidbody>().isKinematic = true;
                    }
                    InHand = null;
                }
            }

            
        }

        if (GameManager.GI.mano_gesture_trigger == ManoGestureTrigger.CLICK && !Interactable)
        {
            Instantiate(Spawn, Camera.main.ViewportToWorldPoint(new Vector3(tracking.palm_center.x, tracking.palm_center.y, tracking.depth_estimation)), Quaternion.identity);
            Interactable = true;
        }
    }

    public float CalcVirtdist(GameObject a, GameObject b) {
        Vector3.Distance(a.transform.position, b.transform.position);

        return 0f;
    }
}
