using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gameover : MonoBehaviour {

    public float backTime = 1.0f;

	// Use this for initialization
	void Start () {
        ResetZombiCount(); // zombiCountとisGameClearをリセット
        Invoke("BackScene", backTime);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void BackScene()
    {
		SceneManager.LoadScene("Map_v1");
    }

    void ResetZombiCount()
    {
        // Zombiクラスのインスタンスを取得
        //Zombi zombiScript = FindObjectOfType<Zombi>();

        // Zombiのインスタンスが見つかったかを確認してからリセットする
        //if (zombiScript != null)
        //{
            // zombiCountを0にリセットし、isGameClearをfalseにする
            Zombi.zombiCount = 0;
            Zombi.isGameClear = false;
        //}
    }
}
