using System.Collections;
using System.Collections.Generic;
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
    private void Start()
    {
        new WaitForSeconds(2);
        cellType = Static.bloodTypes[Random.Range(0, 8)];
        Debug.Log(cellType);
    }

    private void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * leftOrRight);
        position = transform.position.x;
        if (position >= 4)
        {
            transform.position = new Vector2(position, transform.position.y - 1);
            leftOrRight = -1;
        }
        else if (position <= -4)
        {
            transform.position = new Vector2(position, transform.position.y - 1);
            leftOrRight = 1;
        }
        locatorY = transform.position.y;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        bullet bulletScript = collision.gameObject.GetComponent<bullet>();
        if (bulletScript == null) return;
        if ((cellType.Contains("A")) && bulletScript.type == 0 && !Static.playerBloodType.Contains("A"))
        {
            Static.scores[bulletScript.type] += 250;
            Destroy(gameObject);
        }
        if ((cellType.Contains("B")) && bulletScript.type == 0 && !Static.playerBloodType.Contains("B"))
        {
            Static.scores[bulletScript.type] += 250;
            Destroy(gameObject);
        }
        if (cellType.Contains("+") && bulletScript.type == 1)
        {
            Static.scores[bulletScript.type] += 250;
            Destroy(gameObject);
        }
        if (cellType.Contains("AB") && bulletScript.type == 0)
        {
            Static.scores[bulletScript.type] += 250;
            Destroy(gameObject);
        }
        Destroy(collision.gameObject);
    }
}
