using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bird : MonoBehaviour
{
    private Vector3 _initialPosition;
    private bool _birdWasLanched = false;
    private float _timeSittingAround;
    [SerializeField] private float _lanchPower;
    private void Awake()
    {
        _initialPosition = transform.position;
    }
    private void Update()
    {
        GetComponent<LineRenderer>().SetPosition(1, _initialPosition);
        GetComponent<LineRenderer>().SetPosition(0, transform.position);

        if (_birdWasLanched && GetComponent<Rigidbody2D>().velocity.magnitude <= 0.1)
        {
            _timeSittingAround += Time.deltaTime;
        }
        if (transform.position.y > 20 || transform.position.y < -20 || transform.position.x > 20 || transform.position.x < -20 || _timeSittingAround >= 3)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

    }
    private void OnMouseDown()
    {

        GetComponent<SpriteRenderer>().color = Color.red;
        GetComponent<LineRenderer>().enabled = true;

    }
    private void OnMouseUp()
    {

        GetComponent<SpriteRenderer>().color = Color.white;
        Vector2 directionToInitialPosition = _initialPosition - transform.position;

        GetComponent<Rigidbody2D>().AddForce(directionToInitialPosition * _lanchPower);
        GetComponent<Rigidbody2D>().gravityScale = 1;
        _birdWasLanched = true;
        GetComponent<LineRenderer>().enabled = false;
    }
    private void OnMouseDrag()
    {
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(newPosition.x, newPosition.y);
    }

}
