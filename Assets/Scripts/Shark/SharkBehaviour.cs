using UnityEngine;

public class SharkBehaviour : MonoBehaviour
{
    public Transform Player;
    public float MoveSpeed = 12f;
    public float MinDist = 1f;

    public Animator animator;

    private RaycastHit hit;

    void Start()
    {
        Player = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        // Look at the player
        transform.LookAt(Player);

        // If the shark is far enough from the player, move towards the player
        if (Vector3.Distance(transform.position, Player.position) >= MinDist)
        {
            transform.position += transform.forward * MoveSpeed * Time.deltaTime;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            animator.SetTrigger("Jump");
        }
    }
}
