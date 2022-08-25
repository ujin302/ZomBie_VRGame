using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour // ���� ����, ��ġ ����

{
    public GameObject Zombie;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("CreateZombie", 1.0f, 2.0f); // 1�� ��, 2�ʸ��� ȣ��
    }

    void CreateZombie()
    {
        Vector3 positionValue = new Vector3
            (Random.Range(-8f, 8f), 0.5f, Random.Range(28.0f, 18.0f));
        GameObject temp = Instantiate(Zombie, positionValue, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
