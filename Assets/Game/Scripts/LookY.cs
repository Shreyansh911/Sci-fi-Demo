using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookY : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float MouseY = Input.GetAxis("Mouse Y");


        Vector3 RotationY = transform.localEulerAngles;
        RotationY.x -= MouseY;
        transform.localEulerAngles = RotationY;

    }
}
