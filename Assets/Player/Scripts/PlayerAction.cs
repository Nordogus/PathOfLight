using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    [SerializeField] private GameObject orbPrefab;
    [SerializeField] private float cooldawn = 1;
    [SerializeField] private bool cooldawnEnd = true;

    [SerializeField] private Transform target;
    [SerializeField] private GameObject winCanvas;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1) && cooldawnEnd)
        {
            cooldawnEnd = false;
            StartCoroutine(Cooldawn());
            GameObject newOrb = Instantiate(orbPrefab, transform.position, transform.rotation);
            newOrb.GetComponent<Unit>().target = target;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Finish")
        {
            Cursor.lockState = CursorLockMode.None;
            cooldawnEnd = false;
            winCanvas.SetActive(true);
            other.gameObject.SetActive(false);
            MenuManager.instance.PauseGame();
        }
    }

    private IEnumerator Cooldawn()
    {
        yield return new WaitForSeconds(cooldawn);
        cooldawnEnd = true;
    }
}
