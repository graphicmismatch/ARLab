using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public static GestureInfo GI;
    // Start is called before the first frame update
    void Start()
    {
        ManomotionManager.Instance.ShouldRunFastMode(true);
        ManomotionManager.Instance.ShouldCalculateGestures(true);
        ManomotionManager.Instance.ShouldCalculateSkeleton3D(false);
        ManomotionManager.Instance.SetManoMotionSmoothingValue(0.65f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
