using UnityEngine;
public class SharkBehaviour : MonoBehaviour
{
    public Transform Player;
    int MoveSpeed = 12;
    int MinDist = 1;

    void Start()
    {
        Player = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        transform.LookAt(Player);

        if (Vector3.Distance(transform.position, Player.position) >= MinDist)
        {
            transform.position += transform.forward * MoveSpeed * Time.deltaTime;
        }
    }
}