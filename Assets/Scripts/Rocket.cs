using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    Rigidbody _rb;
    [SerializeField]
    private float _speed = 20f;
    [SerializeField]
    private float _trailRate = 200;
    [SerializeField]
    private GameObject _smokeTrail;
    [SerializeField]
    private GameObject _explosion;

    void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        Physics.IgnoreLayerCollision(6, 7, true);
        Physics.IgnoreLayerCollision(7, 7, true);
    }

    private void OnEnable()
    {
        RocketLauncher.OnFired += OnMissileFired;
    }

    private void OnDisable()
    {
        RocketLauncher.OnFired -= OnMissileFired;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Destructable"))
        {
            var rocket = Instantiate(_explosion, collision.transform.position, Quaternion.identity);
            Destroy(rocket, 1.5f);
            Destroy(collision.collider.gameObject);
        }

        Destroy(gameObject);
    }

    private void OnMissileFired()
    {
        Vector3 forward = -_rb.transform.right;
        _rb.AddForce(forward * _speed, ForceMode.Impulse);
    }
}
