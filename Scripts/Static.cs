using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Static : MonoBehaviour
{
    public static GameObject Bullet;
    public static InputDevice gamepad_0;
    public static InputDevice gamepad_1;
    public static int[] scores = new int[2];
    private void Awake()
    {
        Bullet = transform.GetChild(0).GameObject();
    }
    public static void CreateNewBullet(GameObject creator, int type)
    {
        GameObject B =  Instantiate(Bullet, new Vector2(creator.transform.position.x, creator.transform.position.y + 1), Quaternion.identity);
        bullet bulletScript = B.GetComponent<bullet>();
        bulletScript.type = type;
    }

    public static void plusVariables(int type) {
        scores[type] += 300; 
    }
}
