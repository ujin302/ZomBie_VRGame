using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    public Image HP;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Zombie")) HP.fillAmount -= 1.0f / 5.0f;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
