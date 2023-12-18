# Description
ArUco markers are a type of visual marker designed for use in mixed reality (MR) and computer vision applications. These markers are typically black-and-white square patterns that can be easily detected and recognized by computer vision systems. ArUco markers are widely used for camera calibration, pose estimation, and object tracking in MR applications.
In the PICO OS, ArUco markers are used to enhance the play space calibration in the LBE (Play Space) mode. The Enterprise SDK also includes an interface (SetMarkerInfoCallback) to retrieve marker information at runtime in Unity/Unreal apps.
# Demo requirements
- PICO Play Space (LBE Mode) must be enabled beforehand. For more information, refer to Configure LBE
- A4 ArUco markers, ideally printed. Refer to: Play Space Recommendations section 2.
- Unity 2022.3.f1
- PICO XR SDK 2.4.0
# Dependencies (UPM)
- XR Interaction Toolkit 2.5.2 + Starter Assets
- Android Logcat
# About SetMarkerInfoCallback
```
int SetMarkerInfoCallback (TrackingOriginModeFlags trackingMode, float cameraYOffset, Action< List< MarkerInfo > > markerInfos)
 ```
> Gets the pose and ID of the marker
## Parameters
| Parameter  | Description |
| ------------- | ------------- |
| trackingMode  | Specify a tracking origin mode from the following: <ul><li>TrackingOriginModeFlags.Device: Device mode. The system sets the device's initial position as the origin. The device's height from the floor is not calculated.</li><li>TrackingOriginModeFlags.Floor: Floor mode. The system sets an origin based on the device's original position and the device's height from the floor.</li></ul>|   |
| cameraYOffset | Set the offset added to the camera's Y direction, which is for simulating a user's height and is only applicable if you select the 'Device' mode. |
| markerInfos | The callback function for returning marker information. |

## Returns
- 0: success 
- 1: failure

# Demo
In this demo, you will be able to dynamically track up to 10 different ArUco markers, with size A4. The prefabs in "Prefab Array" will correspond to each marker's ID. So element 0 in the array will be assigned to the marker A4_0, and so on.
![image](https://github.com/picoxr/ArUcoMarkerTracking/assets/15983798/41e8bed4-a11c-478b-94b0-8434159d43f5)
![image](https://github.com/picoxr/ArUcoMarkerTracking/assets/15983798/0cff9a28-2f5d-4a17-8ffc-88cc485128d6)

The code can be modified to recognize other ArUco markers. For more details, check the MarkerScanning.cs file.


