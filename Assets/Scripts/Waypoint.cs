using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public Vector2Int GetCoord()
    {
        return new Vector2Int(Mathf.RoundToInt(transform.position.x / GameConst.GRID_SIZE), Mathf.RoundToInt(transform.position.z / GameConst.GRID_SIZE));
    }
}
