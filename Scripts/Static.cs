using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Static : MonoBehaviour
{
    public static GameObject Bullet;
    public static GameObject Enemy;
    public static GameObject Particle;
    public static InputDevice gamepad_0;
    public static InputDevice gamepad_1;
    public static int[] scores = new int[2];
    public static string[] bloodTypes = new string[8];
    public static string playerBloodType;
    public static int Coagulation;
    private void Awake()
    {
        Bullet = Resources.Load("Objects/Bullet", typeof(GameObject)) as GameObject;
        Enemy = Resources.Load("Objects/AG_0", typeof(GameObject)) as GameObject;
        Particle = Resources.Load("Objects/Particles", typeof(GameObject)) as GameObject;
        bloodTypes[0] = "A-"; 
        bloodTypes[1] = "B-";
        bloodTypes[2] = "0+";
        bloodTypes[3] = "B+";
        bloodTypes[4] = "AB-";
        bloodTypes[5] = "AB+";
        bloodTypes[6] = "0-";
        bloodTypes[7] = "A+";
        playerBloodType = bloodTypes[Random.Range(0, 2)];
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

    public static void newEnemy() {
        GameObject B = Instantiate(Enemy, new Vector2((Random.Range(0, 2) == 0 ? -4 : 4), 6), Quaternion.identity);
    }

    public static void newParticle(int type, GameObject that) {
        GameObject p = Instantiate(Particle, new Vector2(that.transform.position.x, that.transform.position.y ), Quaternion.identity);
        Particle pe = p.GetComponent<Particle>();
        switch (type) {
            case 0: pe.type = 0;
                break;
            case 1: pe.type = 1; break;
        }
    }
}
