using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookX : MonoBehaviour
{
    [SerializeField] private float _sensitivity = 2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float MouseX = Input.GetAxis("Mouse X");


        Vector3 RotationX = transform.localEulerAngles;
        RotationX.y += MouseX * _sensitivity;
        transform.localEulerAngles = RotationX;

    }
}
