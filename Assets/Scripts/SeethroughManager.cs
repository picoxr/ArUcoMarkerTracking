using System.Collections;
using System.Collections.Generic;
using Unity.XR.PXR;
using UnityEngine;
using UnityEngine.XR;

public class SeethroughManager : MonoBehaviour
{

    private void Start()
    {
        PXR_MixedReality.EnableVideoSeeThrough(true);
    }

    // Re-enable seethrough after the app resumes
    void OnApplicationPause(bool pause)
    {
        if (!pause)
        {
            PXR_MixedReality.EnableVideoSeeThrough(true);
        }
    }

}
