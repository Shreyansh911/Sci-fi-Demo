using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Discructable : MonoBehaviour
{
    [SerializeField] private GameObject _woodenCrate;

    public void DestroyCrate()
    {
        Instantiate(_woodenCrate, transform.position, transform.rotation);
        Destroy(this.gameObject);
    }
}
