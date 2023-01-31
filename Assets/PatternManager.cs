using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternManager : MonoBehaviour
{   
    public Node current;

    public int numberOfNodes;
    private Node head;

    public string[] types = new string[]{"Red", "Blue", "Green", "Yellow"};

    [SerializeField]
    private int treshold;

    private int patternsCompleted = 0;

    Health playerHealth; 

    void Start()
    {
        playerHealth = GameObject.FindWithTag("Player").GetComponent<Health>();
        CreatePattern();
    }

    void Update()
    {
        if (patternsCompleted == treshold) 
        {   
            patternsCompleted = 0;
            CreatePattern();
        }  
    }

    public void CreatePattern()
    {
        Node previousNode = null;

        for (int i = 0; i < numberOfNodes; i++)
        {
            Node currentNode = new Node();

            string randomType = types[Random.Range(0, types.Length)];

            currentNode.type = randomType;

            Debug.Log(currentNode.type);

            if (previousNode != null)
            {
                previousNode.next = currentNode;
            }

            previousNode = currentNode;

            if (i == 0)
            {
                head = currentNode;
                current = head;
            }
        }
    }

    public void CheckSelection(string selection)
    {   
        if (selection == current.type)  
        {   
            Debug.Log("CORRECT");
            current = current.next;
        }
        else 
        {   
            Debug.Log("Failure");
            current = head;
        }

        if (current == null)
        {
            current = head;  
            patternsCompleted++;
            playerHealth.Inscrease();
        }
    }

    public void SelectA()
    {
        CheckSelection(types[0]);
    }

    public void SelectB()
    {
        CheckSelection(types[1]);
    }

    public void SelectC()
    {
        CheckSelection(types[2]);
    }

    public void SelectD()
    {
        CheckSelection(types[3]);
    }
}
