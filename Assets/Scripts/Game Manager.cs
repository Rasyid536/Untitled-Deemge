using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField]List<char> operatorList;
    int n;

    void Awake() {
        instance = this;
    }
    
    public void CompareOperator(char input) {
        if(input == operatorList[n]){
            Debug.Log($"indeks ke : {n} udah bener");
            n++; }
        else
            Debug.Log("Salah, gak dapet ayam malay");
    }

    void Update()
    {
        if (n >= operatorList.Count)
        {
            Debug.Log("Ayam Malay");
        }
    }
}
