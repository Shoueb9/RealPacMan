using UnityEngine;
using System.Collections;
using UnityEngine.AI;
using UnityEngine.UI;

[RequireComponent(typeof(NavMeshAgent))]
public class PacManController : MonoBehaviour
{
    public Camera cam;
    public Transform target;
    public AudioSource dotCollect;
    public AudioSource ghostTouch;
    public Text scoreText;
    public int score;
    Vector3 destination;
    NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        destination = agent.destination;

        score = 0;
        setScoreText();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                destination = hit.transform.position;
                agent.destination = destination;
                Debug.Log("Raycasting");

                // Do something with the object that was hit by the raycast.
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("dot"))
        {
            //Instantiate(explody, transform.position, transform.rotation);
            //bombExplosion.Play();
            dotCollect.Play();
            Destroy(other.gameObject);

            score = score + 10;
            setScoreText();
            //gameObject.GetComponent<AudioSource>().Play();
        }

        if (other.tag.Equals("ghost"))
        {
            //Instantiate(explody, transform.position, transform.rotation);
            //bombExplosion.Play();
            ghostTouch.Play();

            score = score - 10;
            setScoreText();
            //gameObject.GetComponent<AudioSource>().Play();
        }

    }

    void setScoreText()
        {
            scoreText.text = "Score: " + score.ToString();
        }
    }