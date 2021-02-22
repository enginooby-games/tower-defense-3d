using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using Sirenix.OdinInspector;

[ExecuteInEditMode]
public class FxVolumeEditor : MonoBehaviour
{
    [SerializeField] List<VolumeProfile> profiles;

    [ValueDropdown("profiles")]
    [SerializeField] VolumeProfile activeProfile;
    [SerializeField] Volume volume;

    private void OnValidate()
    {
        volume.profile = activeProfile;
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
}
