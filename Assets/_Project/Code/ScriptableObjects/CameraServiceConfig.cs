using UnityEngine;

namespace Project.Code.Config
{
    [CreateAssetMenu(fileName = nameof(CameraServiceConfig), menuName = "Config/Service/Camera")]
    public class CameraServiceConfig : ScriptableObject
    {
        [field: SerializeField] public Camera CameraPrefab { get; private set; }
        [field: SerializeField] public Vector3 CameraOffset { get; private set; }
        [field: SerializeField] public float SmoothSpeed { get; private set; }
    }
}