using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketAmmoBox : Interactable
{
    [SerializeField] GameObject rocketLauncher;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    protected override void Interact()
    {
        rocketLauncher.GetComponent<RocketLauncher>().currentAmmo += 5;
    }
}
