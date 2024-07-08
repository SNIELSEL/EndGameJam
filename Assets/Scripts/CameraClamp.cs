using UnityEngine;

public class CameraClamp : MonoBehaviour
{
    public GameObject player;
    public GameObject mainCamera;

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
        mainCamera.transform.position = new Vector3(player.transform.position.x, mainCamera.transform.position.y, player.transform.position.z);

        mainCamera.transform.position = new Vector3(Mathf.Clamp(mainCamera.transform.position.x, clamps.left, clamps.right), mainCamera.transform.position.y, Mathf.Clamp(mainCamera.transform.position.z, clamps.down, clamps.up));
    }
}
