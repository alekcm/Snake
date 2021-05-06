using System.Collections;
using System.Collections.Generic;
using System.Net.Security;
using UnityEngine;
using UnityEngine.UI;

public class Snake : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Tail, BodyPart;
    public GameManager manager;
    private Vector3 prevpos;
    public bool Fever = false;
    public Transform Left, Right;
    private float center;
    private int food = 0;
    public Collider def, fev;

    void Start()
    {
        prevpos = transform.position;
        center = (Left.position.x + Right.position.x) / 2;
    }

    void Update() {
       
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if (Fever)
                {
                    transform.position = Vector3.MoveTowards(transform.position, new Vector3(center, manager.PlayerPosition.y,
                        manager.PlayerPosition.z - 8.21f), 0.5f);
                }
                else
                {
                    transform.position = Vector3.MoveTowards(transform.position, hit.point, 0.5f);
                    transform.position = new Vector3(transform.position.x, manager.PlayerPosition.y,
                        manager.PlayerPosition.z - 8.21f);
                    if (transform.position.x < manager.LeftBoard.position.x + 1)
                    {
                        transform.position = new Vector3(manager.LeftBoard.position.x + 1, transform.position.y,
                            transform.position.z);

                    }
                    else if (transform.position.x > manager.RightBoard.position.x - 1)
                    {
                        transform.position = new Vector3(manager.RightBoard.position.x - 1, transform.position.y,
                            transform.position.z);

                    }

                    transform.rotation = Quaternion.LookRotation(prevpos - transform.position, Vector3.up);
                    prevpos = transform.position;
                }
            }
        
    }

    public void Grow()
    {
        if (food < 5)
            food++;
        else
        {
            GameObject _bodyPart = Instantiate(BodyPart, Tail.transform.position, Tail.transform.rotation);
            _bodyPart.GetComponent<SnakeBody>().Head = Tail.transform;
            _bodyPart.transform.parent = Tail.transform.parent;
            _bodyPart.GetComponent<Renderer>().material = GetComponent<Renderer>().material;
            Tail.GetComponent<SnakeBody>().Tail = Tail.GetComponent<SnakeBody>();
            Tail = _bodyPart;
            food = 0;
        }
    }
}
