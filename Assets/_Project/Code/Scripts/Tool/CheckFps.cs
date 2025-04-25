using TMPro;
using UnityEngine;

namespace Project.Scripts.Tools
{
    public class CheckFps : MonoBehaviour
    {
        [SerializeField] private TMP_Text _textFps;
        
        private float _timeLeft = 0f;
        private ushort _frameCount;
        private ushort _currentFPS;

        private void Update()
        {
            _timeLeft += Time.unscaledDeltaTime;
            _frameCount++;

            _currentFPS = CalculateCurrentFPS();
            _textFps.SetText($"{_currentFPS.ToString()} fps");
        }

        private ushort CalculateCurrentFPS()
        {
            return (ushort)Mathf.RoundToInt(_frameCount / _timeLeft);
        }
    }
}