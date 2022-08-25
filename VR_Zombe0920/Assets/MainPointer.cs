using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainPointer : MonoBehaviour // 좀비 죽이기, 좀비가 죽고 난 후의 설정 
{
    public Image loadingImage;
    public AudioClip[] gunSound;
    public int maxBullet; // 최대 총알 수
    public TextMeshProUGUI bulletText;
    private int nowBullet; // 현재 총알 수 
    
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        nowBullet = maxBullet;
        audioSource = GetComponent<AudioSource>();
        bulletText.text = nowBullet + " / " + maxBullet;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.forward, out hit, 500f))
        {
            if (hit.collider.CompareTag("Zombie") && nowBullet > 0)
            {
                loadingImage.fillAmount += 1.0f / 2 * Time.deltaTime;
                if(loadingImage.fillAmount == 1)
                {
                    // 총 쏘기
                    nowBullet--;
                    bulletText.text = nowBullet + " / " + maxBullet;
                    audioSource.PlayOneShot(gunSound[0]);

                    //hit.collider.gameObject.SetActive(false);
                    // 비효율적 -> 메모리 증가! GetComponent는 start함수에! 
                    hit.collider.GetComponent<Animator>().SetTrigger("Die"); // Die 행동
                    hit.collider.GetComponent<ZombieMove>().ZombieSpeed = 0; // 속도 0
                    hit.collider.GetComponent<CapsuleCollider>().radius = 0; // 타겟 x
                    Destroy(hit.collider.gameObject, 2.0f);

                    loadingImage.fillAmount = 0;

                    if (nowBullet == 0) StartCoroutine(ReloadGun());
                }
            }
        } else
        {
            loadingImage.fillAmount = 0;
        }
    }

    IEnumerator ReloadGun()
    {
        bulletText.text = "Reloading......";
        yield return new WaitForSeconds(2f); // 2초동안 기다리기
        audioSource.PlayOneShot(gunSound[1]);
        yield return new WaitForSeconds(0.1f); 
        nowBullet = maxBullet;
        bulletText.text = nowBullet + " / " + maxBullet;
    }
}
