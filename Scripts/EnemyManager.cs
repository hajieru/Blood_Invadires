using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    float i;
    double delay = 10;
    private void Update()
    {
        i += 1 * Time.deltaTime;
        delay -= 0.01 * Time.deltaTime;
        if (i >= delay) {
            Static.newEnemy();
            new WaitForSecondsRealtime(2);
            i = 0;
        }
    }
}
