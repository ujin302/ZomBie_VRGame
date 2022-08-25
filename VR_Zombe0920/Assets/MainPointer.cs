using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainPointer : MonoBehaviour // ���� ���̱�, ���� �װ� �� ���� ���� 
{
    public Image loadingImage;
    public AudioClip[] gunSound;
    public int maxBullet; // �ִ� �Ѿ� ��
    public TextMeshProUGUI bulletText;
    private int nowBullet; // ���� �Ѿ� �� 
    
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
                    // �� ���
                    nowBullet--;
                    bulletText.text = nowBullet + " / " + maxBullet;
                    audioSource.PlayOneShot(gunSound[0]);

                    //hit.collider.gameObject.SetActive(false);
                    // ��ȿ���� -> �޸� ����! GetComponent�� start�Լ���! 
                    hit.collider.GetComponent<Animator>().SetTrigger("Die"); // Die �ൿ
                    hit.collider.GetComponent<ZombieMove>().ZombieSpeed = 0; // �ӵ� 0
                    hit.collider.GetComponent<CapsuleCollider>().radius = 0; // Ÿ�� x
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
        yield return new WaitForSeconds(2f); // 2�ʵ��� ��ٸ���
        audioSource.PlayOneShot(gunSound[1]);
        yield return new WaitForSeconds(0.1f); 
        nowBullet = maxBullet;
        bulletText.text = nowBullet + " / " + maxBullet;
    }
}
