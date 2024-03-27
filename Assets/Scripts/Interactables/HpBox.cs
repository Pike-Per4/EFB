using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpBox : Interactable
{
    [SerializeField] GameObject player;

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
        player.GetComponent<PlayerMotor>().hp += 5;
    }
}
