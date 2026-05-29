using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Operator : MonoBehaviour
{

    [Header("= 1, > 2, < 3")]
    [SerializeField]int OperationType = 0;
    public static Operator instance;
    void Awake() {
        instance = this;
    }

    void OnCollisionEnter2D(Collision2D col) {
        if(col.gameObject.CompareTag("Player")) {
            Debug.Log("Collide");
            if (OperationType == 1)
                GameManager.instance.CompareOperator('=');
            else if (OperationType == 2)
                GameManager.instance.CompareOperator('>');
            else if (OperationType == 3)
                GameManager.instance.CompareOperator('<');
        Destroy(this.gameObject);
        }
    }

}
