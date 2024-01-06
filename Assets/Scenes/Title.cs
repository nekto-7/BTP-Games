using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Title : MonoBehaviour
{
    [SerializeField] private float time = 1f;
    [SerializeField] private int indexScene = 1;
    private void Start()
    {
        StartCoroutine(NextScene());
    }
    private IEnumerator NextScene()
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(indexScene);
    }
}
