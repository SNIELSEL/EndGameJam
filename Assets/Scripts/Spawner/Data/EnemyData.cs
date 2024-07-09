using UnityEngine;
using static UnityEditor.Progress;

[System.Serializable]
public class EnemyData
{
    public RewardType rewardType;
    public float rewardAmmount;

    public EnemyData(float probability, RewardType reward, float rewardAmmount)
    {
        this.rewardType = reward;
        this.rewardAmmount = rewardAmmount;
    }
}

public enum RewardType
{
    Points,
    Time
}