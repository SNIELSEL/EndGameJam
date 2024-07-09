using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class KillEnemy : MonoBehaviour
{

    public ParticleSystem killParticle;

    private void Awake()
    {
        Timer.killCount = 0;
    }


    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //if(collision.GetComponent<Ri>)
            killParticle.Play();

            Timer.killCount++;
            StartCoroutine("WaitToDestroy");
        }
    }

    IEnumerator WaitToDestroy()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
