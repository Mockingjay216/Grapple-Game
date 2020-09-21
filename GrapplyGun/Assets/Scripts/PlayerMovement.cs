using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController controller;
    private WeaponSwitching weaponSwitcher;

    public int selectedWeapon;

    public float speed;
    public float gravity = -11f;

    Vector3 velocity;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    public float jumpHeight = 3.0f;

    bool isGrounded;

    private void Start()
    {
        weaponSwitcher = GetComponentInChildren<WeaponSwitching>();
    }

    // Update is called once per frame
    void Update()
    {
        selectedWeapon = weaponSwitcher.selectedWeapon;

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (selectedWeapon == 1)
        {
            speed = 5;
            gravity = -20;
        }
        else if (selectedWeapon == 0)
        {
            speed = 10;
            gravity = -11f;
        }

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        if (Input.GetButtonDown("Jump"))
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}