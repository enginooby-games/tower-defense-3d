using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPoint : MonoBehaviour
{

    bool isOccupied = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnMouseDown()
    {
        if (!isOccupied)
        {
            TowerFactory.Instance.Build(transform.position);
            isOccupied = true;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
