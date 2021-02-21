using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

[ExecuteInEditMode]
public class ModelSwitchManager : MonoBehaviour
{
    [Range(0, 2)] [SerializeField] int activeModelIndex = 0;
    [SerializeField] List<ModelSwitchEditor> prefabs;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnValidate()
    {
        foreach (ModelSwitchEditor prefab in prefabs)
        {
            prefab.activeModelIndex = activeModelIndex;
        }

        // TODO: auto save scene after make change on this manager
        // EditorSceneManager.SaveScene(SceneManager.GetActiveScene());
    }
}
