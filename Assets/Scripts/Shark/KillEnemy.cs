using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class KillEnemy : MonoBehaviour
{
    public int sharkID;
    public ParticleSystem killParticle;

    private float killSpeed, haaiTime;

    private RewardType rewardType;
    private float Reward;

    public TextMeshProUGUI minTime, plusPoint;
    public Animator minTimeAnimation, plusPointAnimation;

    public void Start()
    {
        minTime = GameObject.Find("plus tijd5").GetComponent<TextMeshProUGUI>();
        plusPoint = GameObject.Find("plus punt1").GetComponent<TextMeshProUGUI>();

        minTimeAnimation = GameObject.Find("plus tijd5").GetComponent<Animator>();
        plusPointAnimation = GameObject.Find("plus punt1").GetComponent <Animator>();

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
                        plusPointAnimation.SetTrigger("Point");
                        Timer.killCount += (int)Reward;

                        plusPoint.SetText("+" + Reward.ToString());
                        plusPointAnimation.Play("pluspunt1");
                        plusPointAnimation.SetTrigger("terug");

                        break;

                    case RewardType.Time:
                        minTimeAnimation.SetTrigger("Plus");
                        Timer.time += (int)Reward;

                        minTime.SetText("+" + Reward.ToString());
                        minTimeAnimation.Play("plustijd5");
                        minTimeAnimation.SetTrigger("terug");

                        break;
                    default:
                        Debug.LogError("Cant give reward");
                        break;
                }

                StartCoroutine("WaitToDestroy");
            }
            else
            {
                minTimeAnimation.SetTrigger("Plus");
                Timer.time -= haaiTime;

                minTime.SetText("-" + haaiTime.ToString());
                minTimeAnimation.Play("plustijd5");

                minTimeAnimation.SetTrigger("terug");

                StartCoroutine("WaitToDestroy");
            }
        }
    }

    IEnumerator WaitToDestroy()
    {
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
