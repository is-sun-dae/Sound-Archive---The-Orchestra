using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpNote : MonoBehaviour
{
    private NoteGenerator note;
    private Vector3 desPos;

    private Rigidbody2D rigid;
    [SerializeField] private float speed;

    private void Start()
    {
        note = GameObject.Find("NoteGenerator").GetComponent<NoteGenerator>();
        speed = note.scrollSpeed;
    }

    private void Update()
    {
        transform.Translate(Vector3.up * speed * Time.smoothDeltaTime);
    }

    public void OnBecameInvisible()
    {
        if (gameObject.transform.position.y >= 5f)
        {
            Destroy(gameObject);
        }
    }
}
