using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunAmmoBox : Interactable
{
    [SerializeField] GameObject gun;

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
        gun.GetComponent<Gun>().currentAmmo += 5;
    }
}
