using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeBody : MonoBehaviour
{
    public Transform Head;
    public SnakeBody Tail;
    private Vector3 MoveTo;
    public int FeverMultiplier = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        
        StartCoroutine(MoveToObject());
    }
    public IEnumerator MoveToObject()
    {
        
        MoveTo = Head.position;
        yield return new WaitForSeconds(0.001f);
        StartCoroutine(MoveToObject());
        yield break;
    }
    // Update is called once per frame
    void Update()
    {
        var distance = (MoveTo - transform.position).magnitude;
        transform.position = Vector3.MoveTowards(transform.position, MoveTo, distance/Time.deltaTime/1200*FeverMultiplier);
        transform.rotation = Quaternion.LookRotation(MoveTo - transform.position, Vector3.up);

    }
    
}
