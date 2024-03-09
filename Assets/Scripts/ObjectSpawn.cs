using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
public class ObjectSpawn : MonoBehaviour
{

    public ManomotionManager Man;
    public GameObject Spawn;
    public GameObject ind;
    public static ObjectSpawn instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.GI.mano_gesture_trigger == ManoGestureTrigger.CLICK) {
            spawnCube();
        }
    }

    public void spawnCube() {
        TrackingInfo tracking = ManomotionManager.Instance.Hand_infos[0].hand_info.tracking_info;
        GameObject g = Instantiate(instance.Spawn, Camera.main.ViewportToWorldPoint(new Vector3(tracking.palm_center.x, tracking.palm_center.y, tracking.depth_estimation)), Quaternion.identity);
        instance.ind.SetActive(true);
        }
    }

