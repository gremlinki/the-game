using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Dbg
{
    public class DebugLog : MonoBehaviour
    {
        public enum LogType_e
        {
            DEBUG = 0,
            INFO = 1,
            WARN = 2,
            ERROR = 3
        }

        [SerializeField] private Sprite[] logIcons;
        [SerializeField] private Image logIcon;
        [SerializeField] private TMP_Text logText;

        public void show(LogType_e type, string message)
        {
            logIcon.sprite = logIcons[(int)type];
            logText.text = message;
        }
    }   
}
