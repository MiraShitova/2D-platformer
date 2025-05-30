using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform Target;
    
    private void Update() 
    {
        transform.position = new Vector3(Target.position.x, Target.transform.position.y, -10); 
    }
}
