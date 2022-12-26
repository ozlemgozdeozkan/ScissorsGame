using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Ground_Building create_ground;

    public float speed_up;

    Vector3 direction;

    public static bool falling = true;

    [SerializeField]
    float speed;

    public Text scoreText, bestScoreText;

    float score;
    float increase = 1f;

    int bestScore;

    public GameObject playGamePanel, restartGamePanel;

    void Start()
    {
        if (RestartGame.isRestart == true)
        {
            playGamePanel.SetActive(false);
            falling = false;
        }
        FirstMove();
        bestScore = PlayerPrefs.GetInt("bestScore");//veriyi almak
        bestScoreText.text = "Best Score: " + bestScore.ToString();
    }

    void Update()
    {
        Death();

        if (falling)
        {
            return;
        }

        MoverController();
    }

    public void PlayGame()
    {
        falling = false;
        playGamePanel.SetActive(false);
    }
    private void FixedUpdate()
    {
        if (falling)
        {
            return;
        }

        Mover();
        SpeedandPrint();
    }

    void SpeedandPrint()
    {
        speed += speed_up * Time.deltaTime;//H�zlanma

        score += increase * speed * Time.deltaTime;
        scoreText.text = ((int)score).ToString();//int d�n��t�y�p �yle to string yapmak
    }
    void Death()
    {
        if (transform.position.y <= 0.1f)
        {
            if (bestScore < score)
            {
                bestScore = (int)score;
                PlayerPrefs.SetInt("bestScore", bestScore);
                PlayerPrefs.Save();
            }
            falling = true;
            restartGamePanel.SetActive(true);
            Destroy(gameObject, 4f);
        }
    }
    private void OnCollisionExit(Collision collision)//collision: ��k�� yapt���m�z nesnedir. ek zemin getirmek i�in
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            StartCoroutine(Remove(collision.gameObject));
            create_ground.Create_Ground();
        }
    }
    IEnumerator Remove(GameObject obj)
    {
        yield return new WaitForSeconds(0.3f);//g�rsellik i�in
        obj.AddComponent<Rigidbody>();//Zemin d��medeki yer�ekimi i�lemi

        yield return new WaitForSeconds(1f);//optimizasyon i�in
        Destroy(obj.gameObject);
    }
    void FirstMove()
    {
        direction = Vector3.back;
    }
    void Mover()
    {
        Vector3 move = direction * speed * Time.deltaTime;
        transform.position += move;
    }
    void MoverController()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (direction.x == 0)
            {
                direction = Vector3.right;
            }
            else
            {
                direction = Vector3.back;
            }
        }
    }
}

