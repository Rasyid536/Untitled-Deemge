Arsitektur : 

Script Operator.cs

[Header("= 1, > 2, < 3")]
[SerializeField]int OperationType = 0;

jenis objek, kalau 1 artinya dia sama dengan, 2 lebih dari, 3 kurang dari.
setiap instance bisa dispesifikasi jenisnya.

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

Panggil fungsi CompareOperator dengan parameter sesuai jenis objek. 

Script GameManager.cs

public void CompareOperator(char input) { // fungsi buat compare dari input yang didapat, dengan isi data dari operator list ke n
        if(input == operatorList[n]){
            Debug.Log($"indeks ke : {n} udah bener");
            n++; }
        else
            Debug.Log("Salah, gak dapet ayam malay");
    }

OperatorList ke n adalah jawaban yang benar jadi, kalo input sama dengan OperatorList ke n, dia bernilai benar.
