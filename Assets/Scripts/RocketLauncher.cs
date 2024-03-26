using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLauncher : MonoBehaviour
{
    [SerializeField]
    private bool _canShoot = false;
    [SerializeField]
    private GameObject _missile;
    public delegate void FireAction();
    public static event FireAction OnFired;
    void Update()
    {
        if (Input.GetButtonDown("Fire3")) 
        {
            if (_canShoot) 
            {
                Instantiate(_missile, _missile.transform.position, _missile.transform.rotation);
                OnFired();
            }
        }
    }
}
