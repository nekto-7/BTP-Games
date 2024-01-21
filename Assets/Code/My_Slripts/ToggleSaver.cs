using UnityEngine;
using UnityEngine.UI;
public class ToggleSaver : MonoBehaviour
{
    private Toggle toggle;
    public Prog progressScript;

    private void Awake()
    {
        toggle = GetComponent<Toggle>();
        progressScript = FindObjectOfType<Prog>();

        if (PlayerPrefs.HasKey("SongPerformance"))
        {
            bool isToggleOn = PlayerPrefs.GetInt("SongPerformance") == 1;
            toggle.isOn = isToggleOn;
        }
        ///toggle.onValueChanged.AddListener(OnToggleValueChanged);
    }

    private void OnEnable()
    {
        toggle.onValueChanged.AddListener(OnToggleValueChanged);
    }

    private void OnDisable()
    {
        toggle.onValueChanged.RemoveListener(OnToggleValueChanged);

    }

    private void OnDestroy()
    {
        int toggleValue = toggle.isOn ? 1 : 0;
        PlayerPrefs.SetInt("SongPerformance", PlayerPrefs.GetInt("SongPerformance"));
    }

    private void OnToggleValueChanged(bool isOn)
    {
        progressScript.SwitchFlag();
        int toggleValue = isOn ? 1 : 0;
        PlayerPrefs.SetInt("SongPerformance", toggleValue);
        progressScript.OutputSave();
        progressScript.SaveSettings();
    }
}