using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour
{
    public int type;
    float f;
    void Start()
    {
        if (type == 0)
        {
            transform.rotation = Quaternion.Euler(-155, 0, 0);
        }
        else { 
            transform.rotation = Quaternion.Euler(155, 0, 0);
        }
    }
    private void Update()
    {
        if (gameObject.GetComponent<ParticleSystem>().isStopped) { 
            Destroy(gameObject);
        }
    }
}
