using System.Collections;
using System.Collections.Generic;
using Unity.XR.PXR;
using UnityEngine;
using UnityEngine.XR;

public class MarkerScanning : MonoBehaviour
{
    private void Start()
    {
        PXR_Enterprise.InitEnterpriseService();
        PXR_Enterprise.BindEnterpriseService((bound) => ScanMarkers());
    }

    private Dictionary<int, GameObject> markerObjectList = new Dictionary<int, GameObject>();
    public GameObject[] prefabArray;

    // Update is called once per frame
    void ScanMarkers()
    {
        Debug.Log("Scanning ArUcos...");

        Debug.Log("Scanning result: " + PXR_Enterprise.SetMarkerInfoCallback(TrackingOriginModeFlags.Floor, 0, markers =>
        {
            Debug.Log("Marker list count: " + markers.Count);
            for (int i = 0; i < markers.Count; i++)
            {
                GameObject prefab = GetPrefabForMarker(markers[i].iMarkerId);

                Debug.Log("Marker " + markers[i] + " identified");

                if (markerObjectList.ContainsKey(markers[i].iMarkerId))
                {
                    // If the marker is already in the scene, update its position and rotation
                    GameObject cubeToUpdate = markerObjectList[markers[i].iMarkerId];
                    cubeToUpdate.transform.position = new Vector3((float)markers[i].posX, (float)markers[i].posY, (float)markers[i].posZ); 
                    cubeToUpdate.transform.rotation = new Quaternion((float)markers[i].rotationX, (float)markers[i].rotationY, (float)markers[i].rotationZ, (float)markers[i].rotationW); 

                    Debug.Log("Marker " + markers[i].iMarkerId + " identified, updating position");
                }
                else
                {
                    //Otherwise, instantiate a new one
                    GameObject cube = Instantiate(prefab, null, true);
                    cube.transform.position = new Vector3((float)markers[i].posX, (float)markers[i].posY, (float)markers[i].posZ);
                    cube.transform.rotation = new Quaternion((float)markers[i].rotationX, (float)markers[i].rotationY, (float)markers[i].rotationZ, (float)markers[i].rotationW);

                    Debug.Log("New marker " + markers[i].iMarkerId + " identified, creating prefab");
                    markerObjectList.Add(markers[i].iMarkerId, cube);
                }
            }
        }));
    }

    GameObject GetPrefabForMarker(int markerId)
    {
        // Assuming the marker IDs correspond to indices in the prefabArray
        int prefabIndex = markerId % prefabArray.Length;
        Debug.Log("Identified Marker: " + markerId + ", returning prefab: " + prefabIndex);
        return prefabArray[prefabIndex];
    }
}
