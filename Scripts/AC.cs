using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class AC : MonoBehaviour
{
    public int c;
    private InputActionAsset inputAsset;
    private InputActionMap player;
    private InputAction move;

    InputAction.CallbackContext context;
    private int i;
    private void Awake()
    {
        inputAsset = this.GetComponent<PlayerInput>().actions;
        player = gameObject.GetComponent<PlayerInput>().currentActionMap;
    }

    private void OnEnable()
    {
        move = player.FindAction("Move");
        player.FindAction("Fire").started += Fire => { Static.CreateNewBullet(gameObject, c); };
        move.performed += ctx => context = ctx;
        player.Enable();
    }

    private void OnDisable()
    {
        move.performed -= ctx => context = ctx;
        player.FindAction("Fire").started -= Fire => { Static.CreateNewBullet(gameObject, c); };
        player.Disable();
    }
    private void Update()
    {
        transform.position = new Vector2(transform.position.x + (context.ReadValue<Vector2>().x > 0 ? 4f : -4f * (context.ReadValue<Vector2>().x == 0 ? 0 : 1) ) * Time.deltaTime, transform.position.y) ;
    }
}