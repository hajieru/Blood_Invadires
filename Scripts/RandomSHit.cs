using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSHit : MonoBehaviour
{
    int speed;
    GameObject that;
    void Start()
    {
        switch (gameObject.name)
        {
            case "Bigs": speed = 2; break;
            case "Smalls": speed = 1; break;
        }
        that = Resources.Load("Objects/RandomShit", typeof(GameObject)) as GameObject;
    }

    void Update()
    {
        float positionX = transform.position.x;
        float positionY = transform.position.y;
        transform.position = new Vector2(positionX, positionY - 1f * Time.deltaTime * speed);
        if (transform.position.y <= -16.5f && speed == 1) { 
            Instantiate(that, new Vector2(2, 9), Quaternion.identity);
            Destroy(transform.parent.gameObject);
            Destroy(transform.parent.GetChild(0).gameObject);
            Destroy(gameObject);
        }
    }
}
