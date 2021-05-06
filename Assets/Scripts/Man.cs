using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Man : MonoBehaviour
{
    public Text DeathCount;
    private Transform target;
    public GameManager _gameManager;

    void Start()
    {
        if (DeathCount == null)
            DeathCount = GameObject.Find("Death text").GetComponent<Text>();
    }
    void Update()
    {
        if (target!=null)
            transform.position = Vector3.MoveTowards(transform.position, target.position, 0.2f);
    }
    void OnTriggerEnter(Collider collider)
    {
        if (collider.isTrigger && collider.tag == "Player")
        {
            
            target = collider.gameObject.transform;
        }
        if (!collider.isTrigger && collider.tag == "Player")
        {   
           
            if (collider.gameObject.GetComponent<Renderer>().material.name == gameObject.GetComponent<Renderer>().material.name)
            {
               
                DeathCount.text = Convert.ToString(Convert.ToInt32(DeathCount.text) + 1);
                Destroy(gameObject);
                collider.gameObject.GetComponent<Snake>().Grow();
            }
            else
            {
               if (!_gameManager.InFever)
                _gameManager.RestartLevel();
               else
               {
                   Destroy(gameObject);
                   DeathCount.text = Convert.ToString(Convert.ToInt32(DeathCount.text) + 1);
               }
            }
        }
    }
}
