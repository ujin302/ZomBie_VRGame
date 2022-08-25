using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour // 좀비 생성, 위치 설정

{
    public GameObject Zombie;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("CreateZombie", 1.0f, 2.0f); // 1초 후, 2초마다 호출
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
