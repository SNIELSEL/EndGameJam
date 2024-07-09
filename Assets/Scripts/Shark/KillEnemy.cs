using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class KillEnemy : MonoBehaviour
{
    public ParticleSystem killParticle;
    public float killSpeed, haaiTime;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (collision.GetComponent<Rigidbody>().velocity.magnitude > killSpeed)
            {
                killParticle.Play();

                Timer.killCount++;
                StartCoroutine("WaitToDestroy");
            }
            else
            {
                Timer.time -= haaiTime;
            }
        }
    }

    IEnumerator WaitToDestroy()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
