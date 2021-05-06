using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
    // Start is called before the first frame update
    public GameManager _gameManager;
    public Renderer Father;

    void Start()
    {
        if (_gameManager == null)
            _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    void OnTriggerEnter(Collider collider)
    {
        if ((!collider.isTrigger && collider.tag == "Player") || (collider.isTrigger && collider.tag == "Body"))
        {

            collider.gameObject.GetComponent<Renderer>().material = Father.material;
            collider.gameObject.GetComponent<Renderer>().material.name = Father.material.name;
            StartCoroutine(Immortality());

        }
    }

    IEnumerator Immortality()
    {
        if (!_gameManager.InFever)
        {
            _gameManager.InFever = true;
            yield return new WaitForSeconds(0.5f);
            _gameManager.InFever = false;
            
        }
        yield break;
    }
}
