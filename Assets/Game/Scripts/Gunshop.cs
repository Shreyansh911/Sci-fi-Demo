using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gunshop : MonoBehaviour
{
    private AudioSource _audio;

    private Player _player;
    private UIManager _uiManager;

    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        _audio = GetComponent<AudioSource>();

        if(_player == null)
        {
            Debug.LogError("Player is Null in GunShop");
        }

        if(_uiManager == null)
        {
            Debug.LogError("UIManager is null in Gunshop");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
           if (_player._isCoinCollected == true)
           {
                if(Input.GetKeyDown(KeyCode.E))
                {
                    _player._isCoinCollected = false;
                    _uiManager._coinImage.gameObject.SetActive(false);
                    _audio.Play();
                    _player.Weapon();
                    _player._hasWeopen = true;
                }
           }
        }
        else
        {
            Debug.Log("GET THE FUCK OUT OF HERE!!!");
        }
       
    }
}
