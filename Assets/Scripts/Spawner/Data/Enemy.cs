using UnityEngine;
using static UnityEditor.Progress;

[System.Serializable]
public class Enemy
{
    public GameObject shark;
    public float probability;

    public Enemy(GameObject shark, float probability)
    {
        this.shark = shark;
        this.probability = probability;
    }
}
