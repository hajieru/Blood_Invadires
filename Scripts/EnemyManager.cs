using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    float i;
    float p;
    float e;
    bool newA;
    double delay = 10f;
    private void Update()
    {
        if (newA)
        {
            e += 1 * Time.deltaTime;
            if (e >= 1.2f)
            {
                Static.newEnemy();
                e = 0;
                p--;
                if (p == 0)
                {
                    newA = false;
                    return;
                }
            }
        }
        i += 1f * Time.deltaTime;
        delay -= 0.03f * Time.deltaTime;
        if (i >= delay) {
            i = 0;
            Static.newEnemy();
            p = Random.Range(1,4);
            newA = true;
        }
    }
}
