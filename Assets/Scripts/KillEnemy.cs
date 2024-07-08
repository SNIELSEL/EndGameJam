using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillEnemy : MonoBehaviour
{
    public static int killCount;

    private ParticleSystem killParticle;
    GameObject enemy;

    private void Awake()
    {
        killCount = 0;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            killParticle = collision.gameObject.GetComponentInChildren<ParticleSystem>();
            killParticle.Play();

            enemy = collision.gameObject;

            killCount++;
            Destroy(collision.gameObject);
        }
    }

    IEnumerator WaitToDestroy()
    {
        yield return new WaitForSeconds(1);
        killCount++;
        Destroy(enemy);
        enemy = null;
    }
}
