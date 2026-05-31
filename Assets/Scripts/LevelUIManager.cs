using System.Collections.Generic;
using UnityEngine;
using TMPro;

[System.Serializable]
public struct LevelEquation
{
    public int leftNumber;
    public int rightNumber;
    public char correctOperator;
}

public class LevelUIManager : MonoBehaviour
{
    public static LevelUIManager instance;

    [SerializeField] private Transform verticalLayoutParent;
    [SerializeField] private GameObject equationRowPrefab;
    
    private List<GameObject> spawnedRows = new List<GameObject>();

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        GenerateLevelUI();
    }

    private void GenerateLevelUI()
    {
        foreach (Transform child in verticalLayoutParent)
        {
            Destroy(child.gameObject);
        }
        spawnedRows.Clear();

        for (int i = 0; i < GameManager.instance.levelEquations.Count; i++)
        {
            GameObject newRow = Instantiate(equationRowPrefab, verticalLayoutParent);
            
            TMP_Text leftNumText = newRow.transform.GetChild(0).GetComponent<TMP_Text>();
            TMP_Text operatorText = newRow.transform.GetChild(1).GetComponent<TMP_Text>();
            TMP_Text rightNumText = newRow.transform.GetChild(2).GetComponent<TMP_Text>();

            leftNumText.text = GameManager.instance.levelEquations[i].leftNumber.ToString();
            rightNumText.text = GameManager.instance.levelEquations[i].rightNumber.ToString();
            operatorText.text = "?";

            spawnedRows.Add(newRow);
        }
    }

    public void UpdateOperatorUI(int rowIndex, char opSymbol)
    {
        if (rowIndex >= 0 && rowIndex < spawnedRows.Count)
        {
            GameObject currentRow = spawnedRows[rowIndex];
            TMP_Text operatorText = currentRow.transform.GetChild(1).GetComponent<TMP_Text>();
            operatorText.text = opSymbol.ToString();
        }
    }
}