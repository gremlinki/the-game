using TMPro;
using UnityEngine;

namespace Dbg
{
    public class DebugConsole : MonoBehaviour
    {
        public static DebugConsole instance;
    
        [SerializeField] private GameObject consolePanel;
        [SerializeField] private TMP_InputField consoleInput;
        [SerializeField] private GameObject consoleLogs;
        [SerializeField] private GameObject consoleLog;
        private bool visible;

        public void ParseCommand()
        {
            string cmd = consoleInput.text;
            if (!BaseDebugCommand.commands.ContainsKey(cmd))
            {
                GameObject log = Instantiate(consoleLog, consoleLogs.transform, false);
                log.GetComponent<DebugLog>().show(DebugLog.LogType_e.WARN, $"Command {cmd} does not exist");
                return;
            }
        }

        public void Toggle()
        {
            if (visible) Hide();
            else Show();
        }

        public void Show()
        {
            visible = true;
            consolePanel.SetActive(visible);
        }

        public void Hide()
        {
            visible = false;
            consolePanel.SetActive(visible);
        }

        public bool isVisible()
        {
            return visible;
        }
    }

}