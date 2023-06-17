using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public int type;
    private void Start()
    {
        switch (type)
        {

            case 0:
                gameObject.GetComponent<Renderer>().material.color = Color.red;
                break;
            case 1:
                gameObject.GetComponent<Renderer>().material.color = Color.blue;
                break;
        }
    }
    void Update()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 9);
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.name == "RedCell") {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        Destroy(gameObject);
    }
}
