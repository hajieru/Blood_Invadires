using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class debug : MonoBehaviour
{

    int canWhile = -1;
    // Update is called once per frame
    void Awake()
    {
        InputSystem.onAnyButtonPress.Call(ctx => {
            var action = new InputAction(binding: "<Keyboard>/f3");
            action.AddBinding("<Keyboard>/enter");
            action.Enable();
            action.started += context => Debug.Log("F3");
            action.performed += context => {
                canWhile *= -1;
            };
            action.canceled += context => Debug.Log("F3");

        });
    }

    private void Update()
    {
        if (canWhile == 1)
        {
            TextMeshProUGUI canvasText = gameObject.transform.GetChild(0).GetComponents<TextMeshProUGUI>()[0];
            canvasText.text = $"Score_0: {Static.scores[0]} \n Score_1: {Static.scores[1]} \n BloodType: {Static.playerBloodType} ";
        }
        else {
            TextMeshProUGUI canvasText = gameObject.transform.GetChild(0).GetComponents<TextMeshProUGUI>()[0];
            canvasText.text = "";
        }
    }
}
