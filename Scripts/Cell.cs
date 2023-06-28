using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class Cell : MonoBehaviour
{
    public string cellType = null;
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
        if (cellType.Contains("+"))
        {
            transform.GetChild(4).gameObject.GetComponent<SpriteRenderer>().enabled = true;
        }
        if (cellType.Contains("0")) {
            transform.GetChild(5).gameObject.GetComponent<SpriteRenderer>().enabled = true;
            return;
        }
        if (cellType.Contains("AB")) {
            transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>().enabled = true;
        } else if (cellType.Contains("A")) {
            transform.GetChild(2).gameObject.GetComponent<SpriteRenderer>().enabled = true;
        }
        else if (cellType.Contains("B"))
        {
            transform.GetChild(3).gameObject.GetComponent<SpriteRenderer>().enabled = true;
        }

    }

    private void Update()
    {
        if (Speed < 6) {
            Speed += 0.9f * Time.deltaTime;
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
        Static.newParticle(0, gameObject);
    }
}
