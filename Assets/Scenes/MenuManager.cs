using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject[] butonScene;
    public Prog progress = Prog.Inst;
    private void Awake()
    {
        progress.flagScene_2 = PlayerPrefs.GetInt("FlagScene_2") == 1 ? true : false;
        progress.flagScene_3 = PlayerPrefs.GetInt("FlagScene_3") == 1 ? true : false;
        Debug.Log(progress.flagScene_3);
        Debug.Log(progress.flagScene_2);
        
        if (!progress.flagScene_2)
        {
            butonScene[0].SetActive(false);
        }
        else
        {
            butonScene[0].SetActive(true);
        }
        if (!progress.flagScene_3)
        {
            butonScene[1].SetActive(false);
        }
        else
        {
            butonScene[1].SetActive(true);
        }
    }
    public void GoScene_1()
    {
        progress.Score = 0; 
        SceneManager.LoadScene(1);
    }
    public void GoScene_2()
    {
        progress.Score = 0;
        if (progress.flagScene_2 )
        {
            SceneManager.LoadScene(3);
        }
    }
    public void GoScene_3()
    {
        progress.Score = 0;
        if (progress.flagScene_3)
        {
            SceneManager.LoadScene(4);
        }
    }
}
