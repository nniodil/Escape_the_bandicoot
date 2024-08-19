using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private Vector3 offset = new Vector3(0.64f, 2.06f, -2.56f);
    public GameObject player;

    void FixedUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}
