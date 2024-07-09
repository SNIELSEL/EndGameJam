using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDataManager : MonoBehaviour
{
    public float killSpeed, haaiTime;

    public List<EnemyData> enemyList = new();

    public void Awake()
    {
        SharkData.killSpeed = killSpeed;
        SharkData.haaiTime = haaiTime;

        SharkData.enemyList = enemyList;
    }
}

public class SharkData: MonoBehaviour
{
    public static float killSpeed, haaiTime;

    public static List<EnemyData> enemyList = new();
}