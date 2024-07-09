using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PisHaai : MonoBehaviour
{
    public ParticleSystem killParticle;
    public float killSpeed, haaiTime, pisHaaiTime;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (collision.GetComponent<Rigidbody>().velocity.magnitude > killSpeed)
            {
                killParticle.Play();

                Timer.time += pisHaaiTime;
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
