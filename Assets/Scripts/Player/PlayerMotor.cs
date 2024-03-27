using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool isGrounded;
    public float speed = 5f;
    public float gravity = -9.8f;
    public float jumpingHeight = 3f;
    public int hp;
    [SerializeField] GameObject hpText;
    private TextMeshProUGUI hpt;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        hp = PlayerPrefs.GetInt("hp") == 0 ? 100 : PlayerPrefs.GetInt("hp");
        hpt = hpText.GetComponent<TextMeshProUGUI>();
        hpt.text = hp.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = controller.isGrounded;
        hpt.text = hp.ToString();
    }
    public void ProcessMove(Vector2 input) 
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;
        controller.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime);
        playerVelocity.y += gravity * Time.deltaTime;
        if (isGrounded && playerVelocity.y < 0)
            playerVelocity.y = 2f;
        controller.Move(playerVelocity * Time.deltaTime);
    }
    public void Jump() 
    {
        if (isGrounded)
        {
            playerVelocity.y = MathF.Sqrt(jumpingHeight * -3.0f * gravity);
        }
    }
}
