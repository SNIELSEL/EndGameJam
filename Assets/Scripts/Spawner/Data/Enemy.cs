using UnityEngine;

[System.Serializable]
public class Enemy
{
    public RewardType rewardType;
    public float rewardAmmount;
    public GameObject shark;
    public float probability;

    public Enemy(GameObject shark, float probability, RewardType reward, float rewardAmmount)
    {
        this.shark = shark;
        this.probability = probability;
        this.rewardType = reward;
        this.rewardAmmount = rewardAmmount;
    }
}
