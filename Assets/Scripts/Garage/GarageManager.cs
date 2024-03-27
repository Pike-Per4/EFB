using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GarageManager : MonoBehaviour
{
    [SerializeField] GameObject timer;
    [SerializeField] GameObject gun;
    [SerializeField] GameObject rocket;
    [SerializeField] GameObject player;

    private void OnEnable()
    {
        Entrance.PlayerEntered += Entrance_PlayerEntered;
    }

    private void OnDisable()
    {
        Entrance.PlayerEntered -= Entrance_PlayerEntered;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Entrance_PlayerEntered()
    {
        StartCoroutine(StartTimer());
    }

    IEnumerator StartTimer()
    {
        int sec = 10;
        while (sec > 0) 
        {
            yield return new WaitForSeconds(1);
            sec--;
            var text = timer.GetComponent<TextMeshProUGUI>();
            text.text = sec.ToString();
        }
        StartCoroutine(ReloadScene());
        yield return null;
    }

    IEnumerator ReloadScene()
    {
        StartCoroutine(SaveData());
        SceneManager.LoadScene(0);
        yield return null;
    }

    IEnumerator SaveData()
    {
        var gunScript = gun.GetComponent<Gun>();
        var rocketScript = rocket.GetComponent<RocketLauncher>();
        var playerScript = player.GetComponent<PlayerMotor>();

        PlayerPrefs.SetInt("gunAmmo", gunScript.currentAmmo);
        PlayerPrefs.SetInt("rocketAmmo", rocketScript.currentAmmo);
        PlayerPrefs.SetInt("hp", playerScript.hp);
        PlayerPrefs.Save();
        yield return null;
    }
}
