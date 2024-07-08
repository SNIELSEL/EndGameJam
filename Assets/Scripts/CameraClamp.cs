using UnityEngine;

public class CameraClamp : MonoBehaviour
{
    public GameObject player;

    public Clamps clamps;
    public void Start()
    {
        clamps.up = GameObject.Find("Up").transform.position.z;
        clamps.down = GameObject.Find("Down").transform.position.z;
        clamps.left = GameObject.Find("Left").transform.position.x;
        clamps.right = GameObject.Find("Right").transform.position.x;
    }

    public void Update()
    {
        transform.position = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, clamps.left, clamps.right), transform.position.y, Mathf.Clamp(transform.position.z, clamps.down, clamps.up));
    }
}
