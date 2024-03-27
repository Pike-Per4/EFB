using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static RocketLauncher;

public class Entrance : MonoBehaviour
{
    [SerializeField] GameObject blackOut;
    [SerializeField] GameObject spawnPoint;

    public static event Action PlayerEntered;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameObject player = other.gameObject;
            StartCoroutine(StartBlackout());
            StartCoroutine(EndBlackout());
            PlayerEntered?.Invoke();
        }
    }

    IEnumerator StartBlackout()
    {
        Image image = blackOut.GetComponent<Image>();
        Color color = image.color;
        color.a = 1f;
        image.color = color;
        yield return null;
    }

    IEnumerator EndBlackout()
    {
        Image image = blackOut.GetComponent<Image>();
        Color color = image.color;
        while (color.a > 0f)
        {
            color.a -= 0.5f * Time.deltaTime;
            image.color = color;
            yield return null;
        }
    }
}
