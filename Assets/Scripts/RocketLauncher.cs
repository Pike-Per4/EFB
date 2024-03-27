using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class RocketLauncher : MonoBehaviour
{
    [SerializeField]
    private bool _canShoot = false;
    [SerializeField]
    private GameObject rocketSocket;
    [SerializeField]
    private GameObject _missile;

    [SerializeField] GameObject ammoText;

    public int currentAmmo;
    private TextMeshProUGUI ammo;

    public delegate void FireAction();
    public static event FireAction OnFired;

    private void Start()
    {
        currentAmmo = PlayerPrefs.GetInt("rocketAmmo") == 0 ? 100 : PlayerPrefs.GetInt("rocketAmmo");
        ammo = ammoText.GetComponent<TextMeshProUGUI>();
        ammo.text = currentAmmo.ToString();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire2")) 
        {
            if (_canShoot) 
            {
                Instantiate(_missile, rocketSocket.transform.position, rocketSocket.transform.rotation);
                OnFired();
                currentAmmo--;
            }
        }

        ammo.text = currentAmmo.ToString();
    }
}
