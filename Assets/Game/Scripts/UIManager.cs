using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text _ammoCount;
    public Image _coinImage;

    private Player _player;

    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();

        _coinImage.gameObject.SetActive(false);
    }

    void Update()
    {
        if(_player._isCoinCollected == true)
        {
            _coinImage.gameObject.SetActive(true);
        }
    }

    public void UpdateAmmo(int Count)
    {
        _ammoCount.text = "Ammo : " + Count.ToString();
    }
}
