using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField]
    List<GameObject> players = new List<GameObject>();
    [SerializeField]
    List<GameObject> bounds = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        if (players.Count != 2 || bounds.Count != 2)
            enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        float halfWayX = (players[0].transform.position.x + players[1].transform.position.x) / 2f;
        transform.position = new Vector3(halfWayX, transform.position.y, transform.position.z);

        bounds[0].transform.position = transform.position + Vector3.left * 9.4f;
        bounds[1].transform.position = transform.position + Vector3.right * 9.4f;
    }
}
