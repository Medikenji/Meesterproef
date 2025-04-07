using System.Collections;
using UnityEngine;

public abstract class Station : MonoBehaviour
{
    private bool _playerInRange = false;

    protected void Start()
    {
        CheckCollider();
    }

    public abstract void OnClick(); // override this class

    private void CheckCollider()
    {
        if (GetComponent<Collider2D>() == null)
        {
            Debug.LogError($"No Collider2D found on '{gameObject.name}'!");
        }
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && _playerInRange)
        {
            OnClick();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        print($"Collided with: {collision.gameObject.name}");
        if (collision.CompareTag("Player"))
        {
            _playerInRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        print($"Stopped colliding with: {collision.gameObject.name}");
        if (collision.CompareTag("Player"))
        {
            _playerInRange = false;
        }
    }
}
