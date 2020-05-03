using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ScenarioSelector : MonoBehaviour
{
    public Transform[] Children;
    //Transform[] obstaclesSelectedTemp = new Transform[42];
    public GameObject Obstacles;
    public int scenarioNumber;
    // Start is called before the first frame update
    void Start()
    {
        //Children = gameObject.GetComponentsInChildren<Transform>();
        //Obstacles.SetActive(false);
        foreach (Transform i in Children)
        {
            i.gameObject.SetActive(false);
        }
        
        switch (scenarioNumber)
        {
            case 1:
                Children[0].gameObject.SetActive(true);
                Children[7].gameObject.SetActive(true);
                Children[22].gameObject.SetActive(true);
                Children[30].gameObject.SetActive(true);
                Children[41].gameObject.SetActive(true);
                break;

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
