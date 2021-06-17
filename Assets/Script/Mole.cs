using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Mole : MonoBehaviour, IPointerClickHandler
{
    public float speed = 4f;
    public float Ckick;

    bool isWait = false;
    bool isHidden = false;

    public Transform Point;
    public GameObject UI;

    void Start()
    {
        Point.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }

    void Update()
    {
        if (isWait == false)
            transform.position = Vector3.MoveTowards(transform.position, Point.position, speed * Time.deltaTime);

        if (transform.position == Point.position)
        {
            if (isHidden)
            {
                Point.transform.position = new Vector3(transform.position.x, transform.position.y - 1, transform.position.z);
                isHidden = false;
            }
            else
            {
                Point.transform.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
                isHidden = true;
            }
            isWait = true;
            StartCoroutine(Waiting());

        }

    }
    IEnumerator Waiting()
    {
        yield return new WaitForSeconds(Random.Range(3f, 5f));
        isWait = false;
        
    }

   
    public void OnPointerClick(PointerEventData eventData)
    {
        StopCoroutine(Waiting());
        isWait = false;
        Debug.Log(Ckick);
        UI.GetComponent<UI>().Kill += 1;
    }

}
