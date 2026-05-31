using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] public List<LevelEquation> levelEquations = new List<LevelEquation>();
    int n;
    bool gameFinished = false;

    void Awake() 
    {
        instance = this;
    }
    
    public void CompareOperator(char input) 
    {
        if (n >= levelEquations.Count) return;

        if(input == levelEquations[n].correctOperator)
        {
            Debug.Log($"indeks ke : {n} udah bener");
            LevelUIManager.instance.UpdateOperatorUI(n, input);
            n++; 
        }
        else
        {
            Debug.Log("Salah, gak dapet ayam malay");
        }
    }

    void Update()
    {
        if (n >= levelEquations.Count && levelEquations.Count > 0 && !gameFinished)
        {
            gameFinished = true;
            Debug.Log("Ayam Malay");
        }
    }
}