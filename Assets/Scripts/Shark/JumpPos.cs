using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPos : MonoBehaviour
{
    public Transform parent;

    public void High()
    {
        parent.position = new Vector3(parent.position.x, 4.5f, parent.position.z);
    }

    public void Low()
    {
        parent.position = new Vector3(parent.position.x, 0, parent.position.z);
    }
}
