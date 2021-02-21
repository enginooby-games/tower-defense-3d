using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

[ExecuteInEditMode]
public class ModelSwitchEditor : MonoBehaviour
{
    [SerializeField] List<GameObject> models = new List<GameObject>();
    [Range(0, 2)] public int activeModelIndex = 0;


    // Start is called before the first frame update
    void Start()
    {
        // Undo.RecordObject(gameObject, "descriptive name of this operation");
        // Undo.RecordObject(gameObject.GetComponent<ModelSwitchEditor>(), "Switch model");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnValidate()
    {

        for (int i = 0; i < models.Count; i++)
        {
            models[i].SetActive(i == activeModelIndex);
        }

        // TODO: Apply prefab when make changes on instances
        // UnityEditor.PrefabUtility.RecordPrefabInstancePropertyModifications(this);
        // PrefabUtility.ApplyPrefabInstance(gameObject, InteractionMode.UserAction); // freeze editor!
    }
}
