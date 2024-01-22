using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinController : MonoBehaviour
{
    public int scene;
    public int time = 10;
    public SimpleEnemySpowner spowner;
    public SimpleEnemySpowner spowner1;
    public SimpleEnemySpowner spowner2;
    public SimpleEnemySpowner spowner3;
    public bool flag = true;
    private void Start()
    {
        StartCoroutine(Timer());
    }

    public void NextScene()
    {
        GameObject[] massiveObject = GameObject.FindGameObjectsWithTag("Enemy");
        if(flag)
        {
            if (massiveObject.Length == 0 && spowner != null && spowner1 != null)
            {
                if (spowner.amountToSpawn <= 0 && spowner1.amountToSpawn <= 0)
                {
                    Debug.Log(spowner.amountToSpawn); Debug.Log(spowner1.amountToSpawn);
                    Prog.Inst.flagScene_2 = true;
                    Prog.Inst.SaveSettings();
                    Prog.Inst.OutputSave();
                    Debug.Log(spowner.amountToSpawn); Debug.Log(spowner1.amountToSpawn);
                    SceneManager.LoadScene(scene);
                }
            }
        }
        else
        {
            if (massiveObject.Length == 0 && spowner != null && spowner1 != null && spowner2 != null && spowner3 != null)
            {
                if (spowner.amountToSpawn <= 0 && spowner1.amountToSpawn <= 0 && spowner2.amountToSpawn <= 0 && spowner3.amountToSpawn <= 0)
                {
                    Prog.Inst.flagScene_2 = true;
                    Prog.Inst.SaveSettings();
                    Prog.Inst.OutputSave();
                    Debug.Log(spowner.amountToSpawn); Debug.Log(spowner1.amountToSpawn);
                    SceneManager.LoadScene(scene);

                }
            }
        }
    }

    private IEnumerator Timer()
    {
        while (true)
        {
            yield return new WaitForSeconds(time);
            NextScene();
            Debug.Log("/////////////////////////////////////////////////////////////////////");
        }
    }
}
