using System.Collections;
using System.Collections.Generic;
using System.Net.Security;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameManager _gameManager;
    // Start is called before the first frame update

    void Start()
    {
        if (_gameManager == null)
            _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    void OnTriggerEnter(Collider collider)
    {
        if (!collider.isTrigger && collider.tag == "Player")
            if (!_gameManager.InFever)
                _gameManager.RestartLevel();
        if (_gameManager.InFever)
            Destroy(gameObject);
    }
}
