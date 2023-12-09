using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Zombi : MonoBehaviour {

    Animator animator;
    public float destroyTime = 1.0f;
    // 射程距離
    public float rangeDistance = 0.5f; 
    GameObject player;
    public float gameoverTime = 1.0f;

    public bool CanWalk { get; private set; }

    public static int zombiCount = 0;
    public const int zombiGoal = 9; // ゴールのゾンビの数
    public static bool isGameClear = false; // ゲームクリアフラグ

    // Use this for initialization
    void Start () {

        animator = GetComponent<Animator>();
        player = GameObject.FindWithTag("Player");

        CanWalk = true;
		
	}
	
	// Update is called once per frame
	void Update () {

        // プレイヤーの位置
        var playerPosition = player.transform.position;

        // ゾンビの位置
        var zombiPosition = transform.position;

        // ゾンビとプレイヤーがどれだけ離れているか
        var offset = Mathf.Abs(playerPosition.z - zombiPosition.z);

        // プレイヤーとゾンビの距離が近くなったら攻撃
        if(offset <= rangeDistance)
        {
            Attack();
        }

        // ゲームがクリアされたら
        if (isGameClear)
        {
            Debug.Log("Game Cleared!");
            GameClear(); // GameClearを直接呼ぶ
        }

        Debug.Log(isGameClear);
        Debug.Log(zombiCount);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            // ゾンビが倒れる
            FallDown();
            zombiCount++;
            //if (zombiCount >= zombiGoal)
            //{
            //Invoke("GameClear", gameoverTime);
            //}
            if (zombiCount >= zombiGoal)
            {
                isGameClear = true; // ゲームクリアフラグを立てる
            }
        }
    }

    void Attack()
    {
        // 攻撃するアニメーションを流す
        animator.SetTrigger("Attack");

        // ゲームオーバー画面に移動する
        Invoke("Gameover", gameoverTime);
    }

    void FallDown()
    {
        // 動きを止める
        CanWalk = false;

        // 倒れるアニメーションを流す
        animator.SetTrigger("FallDown");

        // ゾンビを消す
        Invoke("DestroyZombi", destroyTime);
    }

    void Gameover()
    {
        SceneManager.LoadScene("GameOver");
    }

    void GameClear()
    {
        SceneManager.LoadScene("GameClear");
    }

    void DestroyZombi()
    {
        Destroy(gameObject);
    }
}
