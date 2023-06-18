using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    float i;
    private void Update()
    {
        i += 1 * Time.deltaTime;
        if (i >= 10) {
            Static.newEnemy();
            new WaitForSecondsRealtime(2);
            i = 0;
        }
    }
}
