using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMove : MonoBehaviour // ���� �����̱�
{
    public float ZombieSpeed;
    public AudioClip[] zombieSound;

    private Vector3 Player;
    private Animator ani;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        Player = new Vector3(0, 0, -5);
        ZombieSpeed = 1.5f;

        audioSource.PlayOneShot(zombieSound[Random.Range(0,2)]); // �ѹ� ���� �迭 0 �Ǵ� 1���� �������� 
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Player);
        transform.position = Vector3.MoveTowards(
            transform.position, Player, ZombieSpeed * Time.deltaTime); // ���� ��ġ���� �÷��̾� ��ġ�� ���� ���ǵ常ŭ �̵�
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            audioSource.PlayOneShot(zombieSound[2]);
            ani.SetTrigger("Attack");
            ZombieSpeed = 0;
        }
    }
}
