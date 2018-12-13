using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowPrefabs : MonoBehaviour
{
    public float rainForward = 10f;
    public int rainObjects = 25;
    public GameObject[] rocks;
    public float impulse = 10f;



    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            toss(Camera.main.transform.position, Camera.main.transform.forward, rocks);
        }
        if (Input.GetMouseButtonDown(1))
        {
            rain(Camera.main.transform.position + Camera.main.transform.forward * rainForward, rocks);
        }
    }

    private void rain(Vector3 start, GameObject[] objects)
    {
        for(int x = 0; x<rainObjects; x++)
        {
            Vector3 rainStart = start + new Vector3(Random.Range(-50.0f, 50.0f), Camera.main.transform.position.y, Random.Range(-10.0f, 10.0f));
            int randomPropIndex = Random.Range(0, objects.Length);
            GameObject generatedProp = Instantiate(objects[randomPropIndex], rainStart, Quaternion.identity);
            Rigidbody rb = generatedProp.GetComponent<Rigidbody>();
        }
    }

    private void toss(Vector3 start, Vector3 direction, GameObject[] objects)
    {
        int randomPropIndex = Random.Range(0, objects.Length);
        GameObject generatedProp = Instantiate(objects[randomPropIndex], start, Quaternion.identity);
        Rigidbody rb = generatedProp.GetComponent<Rigidbody>();
        rb.AddForce(direction * impulse, ForceMode.Impulse);

    }
}
