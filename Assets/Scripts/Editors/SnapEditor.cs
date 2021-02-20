using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
public class SnapEditor : MonoBehaviour
{
    [SerializeField] TextMesh coordLabel = null;
    Vector3 snapPos;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!Application.isPlaying)
        {
            SnapToGrid();
        }

        if (coordLabel)
        {
            UpdateLabel();
        }
    }

    private void SnapToGrid()
    {
        snapPos.x = Mathf.RoundToInt(transform.position.x / GameConst.GRID_SIZE) * GameConst.GRID_SIZE;
        snapPos.z = Mathf.RoundToInt(transform.position.z / GameConst.GRID_SIZE) * GameConst.GRID_SIZE;
        transform.position = snapPos;
    }

    private void UpdateLabel()
    {
        coordLabel.text = snapPos.x / GameConst.GRID_SIZE + "," + snapPos.z / GameConst.GRID_SIZE;
        name = coordLabel.text;
    }
}
