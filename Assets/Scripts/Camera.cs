using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField]
    List<GameObject> players = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (players.Count == 2)
        {
            float halfWayX = (players[0].transform.position.x + players[1].transform.position.x) / 2f;
            transform.position = new Vector3(halfWayX, transform.position.y, transform.position.y);
        }
    }
}
