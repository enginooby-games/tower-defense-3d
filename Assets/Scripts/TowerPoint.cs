using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPoint : MonoBehaviour
{
    [SerializeField] GameObject towerPrefab;

    bool isOccupied = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnMouseDown()
    {
        if (!isOccupied)
        {
            GameObject tower = Instantiate(towerPrefab, transform.position, Quaternion.identity);
            isOccupied = true;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
