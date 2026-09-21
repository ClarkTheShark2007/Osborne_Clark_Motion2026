using System.Collections.Generic;
using UnityEngine;

public class ListExample : MonoBehaviour
{
    public List<string> animalCollection;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animalCollection.Add("penquin");
        animalCollection.Add("dino");
        animalCollection.Add("shark");

        animalCollection.Remove("dino");

        Debug.Log(animalCollection[1]);

        for(int i = 0; i < animalCollection.Count; i++ ) 
        {
            
        }
        //is also
        foreach(string currentAnimal in animalCollection) 
        {

        }


        //Go backwards
        for (int i = animalCollection.Count - 1; i >= 0; i--)
        {

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
