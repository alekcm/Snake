using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeBody : MonoBehaviour
{
    public Transform Head;
    public SnakeBody Tail;
    private Vector3 MoveTo;
    public int FeverMultiplier = 1;
    private float distance;
    
    // Start is called before the first frame update
    void Start()
    {
        
        StartCoroutine(MoveToObject());
    }
    public IEnumerator MoveToObject()
    {
        
        MoveTo = Head.position;
        yield return new WaitForSecondsRealtime(0.002f);
        StartCoroutine(MoveToObject());
        yield break;
    }
    // Update is called once per frame
 
    void FixedUpdate()
    {   distance = (Head.position - transform.position).magnitude;
        transform.rotation = Quaternion.LookRotation(Head.position - transform.position, Vector3.up);
        transform.position = Vector3.MoveTowards(transform.position, Head.position, distance/1.5f*FeverMultiplier);
        
        

    }
    
}
