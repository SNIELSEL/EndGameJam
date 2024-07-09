using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class KillEnemy : MonoBehaviour
{
    public int sharkID;
    public ParticleSystem killParticle;

    private float killSpeed, haaiTime;

    private RewardType rewardType;
    private float Reward;

    public void Start()
    {
        Reward = SharkData.enemyList[sharkID].rewardAmmount;
        rewardType = SharkData.enemyList[sharkID].rewardType;
        killSpeed = SharkData.killSpeed;
        haaiTime = SharkData.haaiTime;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (collision.GetComponent<Rigidbody>().velocity.magnitude > killSpeed)
            {
                killParticle.Play();

                switch (rewardType)
                {
                    case RewardType.Points:
                        Timer.killCount += (int)Reward;
                        Debug.LogError("Gave Points");
                        break;
                    case RewardType.Time:
                        Timer.time += (int)Reward;
                        Debug.LogError("Gave Time");
                        break;
                    default:
                        Debug.LogError("Cant give reward");
                        break;
                }

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
