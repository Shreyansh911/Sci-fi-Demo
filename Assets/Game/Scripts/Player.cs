 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed = 3.5f;
    [SerializeField] private float _gravity = 9.81f;
    [SerializeField] private GameObject _shootingParticles;
    [SerializeField] private GameObject _hittingParticlePrefab;
    [SerializeField] private AudioClip _shootingSound;
    [SerializeField] private int _currentAmmo;
    [SerializeField] private GameObject _weapon;
    
    private int _totalAmmo = 50;
    private bool _isReloading = false;
    public bool _hasWeopen = false;


    public bool _isCoinCollected = false;

    private CharacterController _cc;
    private AudioSource _audioSource;
    private UIManager _uiManager;

    // Start is called before the first frame update
    void Start()
    {
        _cc = GetComponent<CharacterController>();
        _audioSource = GameObject.FindGameObjectWithTag("Weapon").GetComponent<AudioSource>();
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();

        if (_audioSource == null)
        {
            Debug.LogError("AudioScource is Null in Player");
        }
        else
        {
            _audioSource.clip = _shootingSound;
        }

        _shootingParticles.SetActive(false);
        _weapon.SetActive(false);

        _currentAmmo = _totalAmmo;

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();


        if (Input.GetMouseButton(0) && _currentAmmo > 0 && _hasWeopen == true)
        {
            Shoot();
        }

        else
        {
            _shootingParticles.SetActive(false);
            _audioSource.Stop();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }


        if (Input.GetKeyDown(KeyCode.R) && _isReloading == false)
        {
            _isReloading = true;
            StartCoroutine(Reload());
        }

    }

    void Shoot()
    {
        Ray rayOrigin = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hitInfo;

        _currentAmmo--;
        _uiManager.UpdateAmmo(_currentAmmo);

        if (Physics.Raycast(rayOrigin, out hitInfo))
        {
            Debug.Log("Hit : " + hitInfo.transform.name);
            Instantiate(_hittingParticlePrefab, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
        }

        Discructable crate = hitInfo.transform.GetComponent<Discructable>();
        if(crate != null)
        {
            crate.DestroyCrate();
        }

        _shootingParticles.SetActive(true);

        if (_audioSource.isPlaying == false)
        {
            _audioSource.Play();

        }
    }

    void Movement()
    {
        float HorizontalInput = Input.GetAxis("Horizontal");
        float VerticalInput = Input.GetAxis("Vertical");

        Vector3 Direction = new Vector3(HorizontalInput, 0, VerticalInput);
        Vector3 Velocity = Direction * _speed;

        Velocity.y -= _gravity;

        Velocity = transform.TransformDirection(Velocity);

        _cc.Move(Velocity * Time.deltaTime);
    }

    IEnumerator Reload()
    {
        yield return new WaitForSeconds(2.5f);
        _currentAmmo = _totalAmmo;
        _isReloading = false;
        _uiManager.UpdateAmmo(_currentAmmo);
    }

    public void Weapon()
    {
        _weapon.SetActive(true);
    }
}
