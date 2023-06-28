using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class AC : MonoBehaviour
{
    public int c;
    float speed;
    private InputActionAsset inputAsset;
    private InputActionMap player;
    private InputAction move;
    bool fired;
    InputAction.CallbackContext context;
    private int i;
    private float j;
    private void Awake()
    {
        inputAsset = this.GetComponent<PlayerInput>().actions;
        player = gameObject.GetComponent<PlayerInput>().currentActionMap;
    }

    private void OnEnable()
    {
        move = player.FindAction("Move");
        player.FindAction("Fire").started += Fire => {
            if (!fired)
            {
                Static.CreateNewBullet(gameObject, c);
                fired = true;
            } 
        };
        move.performed += ctx => context = ctx;
        player.Enable();
    }

    private void OnDisable()
    {
        move.performed -= ctx => context = ctx;
        player.Disable();
    }
    private void Update()
    {
        transform.position = new Vector2(transform.position.x + (context.ReadValue<Vector2>().x > 0 ? 8f : -8f * (context.ReadValue<Vector2>().x == 0 ? 0 : 1) ) * Time.deltaTime * speed, transform.position.y) ;
        if (context.ReadValue<Vector2>().x < 0 || context.ReadValue<Vector2>().x > 0)
        {
            speed += Time.deltaTime;
        }
        else
        {
            speed = 0;
        }
        if (transform.position.x >= 6)
        {
            transform.position = new Vector2(-5.9f, transform.position.y);
        }
        else if (transform.position.x <= -6) { 
            transform.position = new Vector2(5.9f, transform.position.y);
        }
        if (fired && j < 0.15f) {
            j += 1f * Time.deltaTime;
        }
        if (j >= 0.15f) {
            j = 0;
            fired = false;
        }
    }
}
