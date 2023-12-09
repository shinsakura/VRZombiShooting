using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{

    Animator animator;
    //�˒�����
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

        //player�̈ʒu
        var playerPosition = player.transform.position;

        //zombie�̈ʒu
        var zombiePosition = transform.position;

        //player��zombie�̋���
        var offset = Mathf.Abs(playerPosition.z - zombiePosition.z);

        //player��zombie���߂��Ȃ�����U��
        if(offset <= rangeDistance)
        {
            Attack();
        }
    }

    void Attack()
    {
        //�U���A�j���[�V����
        animator.SetTrigger("Attack");

        //�Q�[���I�[�o�[�Ɉڍs
    }
}
