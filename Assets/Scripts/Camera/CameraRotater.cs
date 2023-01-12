using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotater : MonoBehaviour{
    [SerializeField] Transform cameraT;

    private void LateUpdate(){
        transform.rotation = Quaternion.Euler(0, cameraT.rotation.eulerAngles.y, 0);
    }
}
