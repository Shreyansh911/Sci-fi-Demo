﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitParticles : MonoBehaviour
{
    

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, 0.5f);
    }
}
