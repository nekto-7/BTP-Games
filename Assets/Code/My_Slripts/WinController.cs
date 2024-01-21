using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinController : MonoBehaviour
{
    public int scene;
    public int time = 10;
    private GameObject[] massiveObject;
    public SimpleEnemySpowner spowner;
    public SimpleEnemySpowner spowner1;
    private void Start()
    {
        StartCoroutine(Timer());
    }
    public void NextScene()
    {
        massiveObject = GameObject.FindGameObjectsWithTag("Emeny");
        if (massiveObject == null && spowner.amountToSpawn <= 0)
        {
            SceneManager.LoadScene(scene);
        }
    }
    private IEnumerator Timer()
    {
        while (true)
        {
            StartCoroutine(Timer());
            yield return new WaitForSeconds(time);
        }
    }
}
