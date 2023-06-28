using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coagulation : MonoBehaviour
{
    public float divisor;
    public float store;
    GameObject EnemyManager;
    GameObject[] players;
    GameObject[] enemys;
    void Start()
    {
        transform.localScale = Vector2.zero;
        EnemyManager = GameObject.Find("EnemysManager");
        players[0] = GameObject.FindGameObjectsWithTag("Player")[0];
        players[1] = GameObject.FindGameObjectsWithTag("Player")[1];
    }
    void Update()
    {
        float alpha = (Static.scores[0] + Static.scores[1]) / divisor;
        transform.localScale += new Vector3(alpha - store, alpha - store, 0);
        if (transform.localScale.x >= 7) { 
            gameObject.GetComponent<SpriteRenderer>().color = new Color(gameObject.GetComponent<SpriteRenderer>().color.r, gameObject.GetComponent<SpriteRenderer>().color.g, gameObject.GetComponent<SpriteRenderer>().color.b, gameObject.GetComponent<SpriteRenderer>().color.a + alpha - store);
        }

        store = alpha;

        if (transform.localScale == new Vector3(10, 10, 0)) {
            for (int i = 0; i <= GameObject.FindGameObjectsWithTag("Enemy").Length; i++) { 
                 enemys[i] = GameObject.FindGameObjectsWithTag("Enemy")[i];
                Destroy(enemys[i].gameObject);
            }
            gameObject.GetComponent<CircleCollider2D>().enabled = true;
            Destroy(EnemyManager);

        }
    }
}
