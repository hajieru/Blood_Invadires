using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coagulation : MonoBehaviour
{
    float score;
    int a;
    float store;
    void Start()
    {
        switch (gameObject.name) {
            case "Coagulacion_0":
                score = 1;
                a = 0;
                break;
            case "Coagulacion_1":
                score = -1;
                a = 1;
                break;
        }
    }
    void Update()
    {
        transform.position = new Vector3(transform.position.x + score * (Static.scores[a])/2500 - store, transform.position.y);
        store = score * (Static.scores[a]) / 2500;
    }
}
