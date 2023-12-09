using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{

    Animator animator;
    //射程距離
    public float rangeDistance = 0.8f;
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

        //playerの位置
        var playerPosition = player.transform.position;

        //zombieの位置
        var zombiePosition = transform.position;

        //playerとzombieの距離
        var offset = Mathf.Abs(playerPosition.z - zombiePosition.z);

        //playerとzombieが近くなったら攻撃
        if(offset <= rangeDistance)
        {
            Attack();
        }
    }

    void Attack()
    {
        //攻撃アニメーション
        animator.SetTrigger("Attack");

        //ゲームオーバーに移行
    }
}
