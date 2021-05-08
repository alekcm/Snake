using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Crystal : MonoBehaviour
{
    public Text CrystalCount;
    private Transform target;
    public GameManager _gameManager;

    void Start()
    {
        if (CrystalCount == null)
            CrystalCount = GameObject.Find("Crystal text").GetComponent<Text>();
        if (_gameManager == null)
            _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    void FixedUpdate()
    {
        if (target!=null)
            transform.position = Vector3.MoveTowards(transform.position, target.position, 0.6f);
    }
    void OnTriggerEnter(Collider collider)
    {
        if (collider.isTrigger && collider.tag == "Player")
        {
            target = collider.gameObject.transform;
        }
        if (!collider.isTrigger && collider.tag == "Player")
        {
            CrystalCount.text = Convert.ToString(Convert.ToInt32(CrystalCount.text) + 10);
            Destroy(gameObject);
            _gameManager.FeverCount++;
            if (_gameManager.FeverCount == 1)
                _gameManager.StartCrystalStreak();
            if (_gameManager.FeverCount==4)
                _gameManager.StartFever();
        }
    }
}
