using UnityEngine;

public class BGM: MonoBehaviour
{
    public static BGM instance;

    void Awake()
    {
        // Cek apakah sudah ada BGM Manager lain yang aktif
        if (instance == null)
        {
            // Kalau belum ada, jadikan ini yang utama dan jangan dihancurkan
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // Kalau ternyata sudah ada BGM yang nyala dari scene sebelumnya, 
            // hancurkan objek yang baru ini biar suaranya gak dobel/tumpang tindih.
            Destroy(gameObject);
        }
    }
}