using UnityEngine;

public abstract class Station : MonoBehaviour
{
    void Start()
    {
        CheckCollider();
    }

    void Update()
    {
        if (ClickedOnCollider())
        {
            OnClick();
        }
    }

    public abstract void OnClick(); // override this class

    private void CheckCollider()
    {
        if (GetComponent<Collider2D>() == null)
        {
            Debug.LogError($"No Collider2D found on '{gameObject.name}'!");
        }
    }

    private bool ClickedOnCollider()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D hit = Physics2D.OverlapPoint(mousePosition);

            if (hit != null && hit.gameObject == gameObject)
            {
                return true;
            }
        }
        return false;
    }
}
