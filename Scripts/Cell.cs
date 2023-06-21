using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor.Build;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class Cell : MonoBehaviour
{
    private string cellType = null;
    int leftOrRight;
    float position;
    float locatorY;
    float Ye;
    float Speed = 0;
    bool Y;
    private void Start()
    {
        new WaitForSeconds(2);
        cellType = Static.bloodTypes[Random.Range(0, 8)];
        Debug.Log(cellType);
        locatorY = transform.position.y;
        position = transform.position.x;
    }

    private void Update()
    {
        if (Speed < 3) {
            Speed += 0.5f * Time.deltaTime;
        }
        if (position >= 4)
        {
            transform.Translate(Vector3.down * Time.deltaTime * 2);
            leftOrRight = -1;
            Y = true;
            Ye += 1 * Time.deltaTime;
        }
        else if (position <= -4)
        {
            transform.Translate(Vector3.down * Time.deltaTime * 2);
            leftOrRight = 1;
            Y = true;
            Ye += 1 * Time.deltaTime;
        }
        if (Ye >= 0.5f) {
            Y = false;
            Ye = 0;
        }
        if (Y) return;
        transform.Translate(Vector3.right * Time.deltaTime * leftOrRight * 3 * Speed);
        locatorY = transform.position.y;
        position = transform.position.x;
        if (locatorY < -6) { 
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        bullet bulletScript = collision.gameObject.GetComponent<bullet>();
        if (bulletScript == null) return;
        if ((cellType.Contains("A")) && bulletScript.type == 0 && !Static.playerBloodType.Contains("A"))
        {
            hitted(bulletScript, collision);
        }
        if ((cellType.Contains("B")) && bulletScript.type == 0 && !Static.playerBloodType.Contains("B"))
        {
            hitted(bulletScript, collision);
        }
        if (cellType.Contains("+") && bulletScript.type == 1)
        {
            hitted(bulletScript, collision);
        }
        if (cellType.Contains("AB") && bulletScript.type == 0)
        {
            hitted(bulletScript, collision);
        }
    }

    private void hitted(bullet bulletScript, Collision2D collision)
    {
        Static.scores[bulletScript.type] += 250;
        Destroy(gameObject); 
        Destroy(collision.gameObject);
        if (collision.gameObject.name == "CellDestroy") return;
        Static.newParticle(1, gameObject);
        Static.newParticle(0, gameObject);
    }
}
