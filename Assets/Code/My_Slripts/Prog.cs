using UnityEngine;
using TMPro;

public class Prog : MonoBehaviour
{
    // parametrs
    public int Score;
    // song
    public bool SongWorked = true;
    //flags
    public bool flagScene_2, flagScene_3;
    //  text
    public TextMeshProUGUI ScoreText;
    private GameObject[] G1;
    //
    public static Prog Inst;
    private void Awake()
    {
        FaindText();
        if (Inst != null && Inst != this)
        {
            Destroy(gameObject);
            return;
        }
        Inst = this;
        DontDestroyOnLoad(gameObject);
        OutputSave();
    }

    public void FaindText()
    {
        G1 = GameObject.FindGameObjectsWithTag("ScoreText");
        if (G1.Length > 0 && G1[0] != null)
        {
            ScoreText = G1[0].GetComponent<TextMeshProUGUI>();
        }
        UpdateText();
    }
    public void UpdateText()
    {
        OutputSave();
        if (ScoreText != null)
        {
            ScoreText.text = "Score: " + Score.ToString();
        }
    }
    public void SwitchFlag()
    {
        if (SongWorked) { SongWorked = false; }
        else { SongWorked = true; }
        SaveSettings();
    }
    public void SaveSettings()
    {
        int SongValue = SongWorked ? 1 : 0;
        PlayerPrefs.SetInt("SongPerformance", SongValue);
        // menuManager
        int openScene_2 = flagScene_2 ? 1 : 0;
        PlayerPrefs.SetInt("FlagScene_2", openScene_2);
        int openScene_3 = flagScene_3 ? 1 : 0;
        PlayerPrefs.SetInt("FlagScene_3", openScene_3);
        //
    }
    public void OutputSave()
    {
        if (PlayerPrefs.HasKey("SongPerformance"))
        {
            int songValue = PlayerPrefs.GetInt("SongPerformance");
            SongWorked = songValue == 1 ? true : false;
        }
    }
}
