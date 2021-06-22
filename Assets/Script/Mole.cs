using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Mole : MonoBehaviour, IPointerClickHandler
{
    public float speed = 3f;
    bool isWait = false;
    bool isHidden = false;
    bool isCoins = true;

    public Transform Point;
    public Transform posMole;
    public GameObject _Camera;
    public GameObject FantasyHammer;
    public Transform PosHammer;
    public soundMeneger sm;


    void Start()
    {
        Point.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }

    void Update()
    {
       

        if (isWait == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, Point.position, speed * Time.deltaTime);
        }

        if (transform.position == Point.position)
        {
            if (isHidden)
            {
                Point.transform.position = new Vector3(transform.position.x, transform.position.y - 0.8f, transform.position.z);
                isHidden = false;
            }
            else
            {
                Point.transform.position = new Vector3(transform.position.x, transform.position.y + 0.8f, transform.position.z);
                isHidden = true;
            }
            isWait = true;
            StartCoroutine(Waiting());

        }

    }
    IEnumerator Waiting()
    {
        yield return new WaitForSeconds(Random.Range(2f,3f));
        isWait = false;
        if (isCoins) { _Camera.GetComponent<UI>().Coins -= 2;}
        else { isCoins = true; }
      
    }


    public void OnPointerClick(PointerEventData eventData)
    {
        isCoins = false;
        StopCoroutine(Waiting());
        FantasyHammer.transform.position = PosHammer.position + new Vector3 (0.62f, 0, -0.72f);
        FantasyHammer.GetComponent<Animator>().SetTrigger("attack");
        StartCoroutine(Waiting2());
    }


    IEnumerator Waiting2()
    {
        sm.PlaySound(Random.Range(0,2));
        yield return new WaitForSeconds(0.1f);
        _Camera.GetComponent<Animator>().SetTrigger("shake");
        isWait = false;
        sm.PlaySound(2);
        _Camera.GetComponent<UI>().blows += 1;
        yield return new WaitForSeconds(0.2f);
        FantasyHammer.transform.position = new Vector3(1.85f, 0f, -1.8f);
        StopCoroutine(Waiting2());
    }
}
