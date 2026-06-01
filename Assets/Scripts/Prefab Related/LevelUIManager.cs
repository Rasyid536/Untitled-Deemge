using System.Collections.Generic;
using UnityEngine;
using TMPro;

[System.Serializable]
public struct LevelEquation {
    public int leftNumber;
    public int rightNumber;
    public char correctOperator;
}

public class LevelUIManager : MonoBehaviour {
    public static LevelUIManager instance;

    [SerializeField] private Transform verticalLayoutParent;
    [SerializeField] private GameObject equationRowPrefab;
    
    private List<EquationRow> spawnedRows = new List<EquationRow>();

    void Awake() {
        instance = this;
    }

    void Start() {
        GenerateLevelUI();
    }

    private void GenerateLevelUI() {
        foreach (Transform child in verticalLayoutParent) {
            Destroy(child.gameObject);
        }
        spawnedRows.Clear();

        for (int i = 0; i < GameManager.instance.levelEquations.Count; i++) {
            GameObject newRow = Instantiate(equationRowPrefab, verticalLayoutParent);
            EquationRow rowScript = newRow.GetComponent<EquationRow>();

            if (rowScript != null) {
                rowScript.leftNumText.text = GameManager.instance.levelEquations[i].leftNumber.ToString();
                rowScript.rightNumText.text = GameManager.instance.levelEquations[i].rightNumber.ToString();
                rowScript.operatorText.text = "?";

                spawnedRows.Add(rowScript);
            }
        }
    }

    public void UpdateOperatorUI(int rowIndex, char opSymbol) {
        if (rowIndex >= 0 && rowIndex < spawnedRows.Count)
            spawnedRows[rowIndex].operatorText.text = opSymbol.ToString();
    }
}