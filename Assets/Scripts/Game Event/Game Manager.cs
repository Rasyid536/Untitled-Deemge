using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] public List<LevelEquation> levelEquations = new List<LevelEquation>();
    int n;
    bool gameFinished = false;
    public GameObject LoseUI;

    void Awake() {
        instance = this;
    }

    void Start() {
        Time.timeScale = 1;
    }
    
    public void CompareOperator(char input) {
        if (n >= levelEquations.Count) return;

        if(input == levelEquations[n].correctOperator) {
            Debug.Log($"indeks ke : {n} udah bener");
            LevelUIManager.instance.UpdateOperatorUI(n, input);
            n++; 
        }
        else {
            Debug.Log("Salah, gak dapet ayam malay");
            // logika lose entar disini
            Lose();
        }
    }

    void Update() {
        if (n >= levelEquations.Count && levelEquations.Count > 0 && !gameFinished) {
            gameFinished = true;
            Debug.Log("Ayam Malay");
        }

        if (Input.GetKeyDown(KeyCode.Z))
            PlayerMovement.instance.DeadAnim();

        if (gameFinished) {
            LoadNextLevel();
        }
    }

    void Lose() {
        PlayerMovement.instance.DeadAnim();
    }

















    // Scene Management system

    public void LoadNextLevel() {
        string currentScene = SceneManager.GetActiveScene().name;

        int levelNumber = int.Parse(currentScene.Replace("Level ", ""));

        levelNumber++;

        if (levelNumber > 5) {
            SceneManager.LoadScene("Start");
            return;
        }

        string nextScene = "Level " + levelNumber;
        SceneManager.LoadScene(nextScene);
    }

    public void ReloadCurrentLevel() {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void LoadStartLevel() {
        SceneManager.LoadScene("Start"); }

    public void Exit() {
        Application.Quit(); }
}