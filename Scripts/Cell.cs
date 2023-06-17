using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class Cell : MonoBehaviour
{
    private string cellType = null;
    float i;
    bool leftOrRight;
    float position;
    private void Start()
    {
        new WaitForSeconds(2);
        cellType = Static.bloodTypes[Random.Range(0, 8)];
        Debug.Log(cellType);
    }

    private void Update()
    {
        i += 1 * Time.deltaTime;
        position = transform.position.x;
        if (position == 4)
        {
            leftOrRight = true;
        }
        if (position == -4) { 
            leftOrRight= false;
        }
        if (i > 5) {
            if (leftOrRight)
            {
                transform.Translate(-1, 0, 0);
            }
            else { 
                transform.Translate(1, 0,0);
            }
            if (position == 4)
            {
                transform.position = new Vector2(position, transform.position.y - 1);
                transform.position = new Vector2(position - 1, transform.position.y);
            }
            else if (position == -4)
            {
                transform.position = new Vector2(position, transform.position.y - 1);
                transform.position = new Vector2(position + 1, transform.position.y);
            }
            i = 0;
        }
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
