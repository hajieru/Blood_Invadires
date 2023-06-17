using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AC_1_PlayerSprite : MonoBehaviour
{
    private AC ac1;
    private void Awake()
    {
        if (GameObject.FindGameObjectsWithTag("Player").GetLength(0) > 1)
        {

            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            transform.GetChild(0).gameObject.SetActive(true);
            ac1 = GetComponent<AC>();
            ac1.c = 1;
        }
    }
}
