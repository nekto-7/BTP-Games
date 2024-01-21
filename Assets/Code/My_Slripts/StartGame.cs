using UnityEngine;

public class StartGame : MonoBehaviour
{
    public int startCoins;
    void Start()
    {
        Prog.Inst.Score = startCoins;
    }
}
