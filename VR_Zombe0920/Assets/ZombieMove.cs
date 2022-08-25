using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMove : MonoBehaviour // 좀비 움직이기
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

        audioSource.PlayOneShot(zombieSound[Random.Range(0,2)]); // 한번 실행 배열 0 또는 1에서 랜덤으로 
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Player);
        transform.position = Vector3.MoveTowards(
            transform.position, Player, ZombieSpeed * Time.deltaTime); // 현재 위치에서 플레이어 위치로 좀비 스피드만큼 이동
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
