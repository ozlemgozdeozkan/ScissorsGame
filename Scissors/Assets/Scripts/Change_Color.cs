using UnityEngine;

public class Change_Color : MonoBehaviour
{
    public Color[] colors;

    public Material floor_mat;

    Color secondColor;
    int first_color;
    void Start()
    {
        first_color = Random.Range(0, colors.Length);//indis 5 olduðu için 5.renge kadar alýcak demek
        secondColor = colors[second_Color()];
        floor_mat.color = colors[first_color];//zemin materyaline dizideki rastgele rengi atamak.
        Camera.main.backgroundColor = colors[first_color]; //Kameradaki arkaplan ile zemin ile ayný renk yap

    }

    // Update is called once per frame
    void Update()
    {
        Color difference = floor_mat.color - secondColor; //birinci renk ile ikinci renk arasýndaki fark rgb (255, 0, 0) - (0,0,255) => (255,0,255)yeni renk
        if((Mathf.Abs(difference.r) + Mathf.Abs(difference.g) + Mathf.Abs(difference.b)) < 0.2f)
        {
            secondColor = colors[second_Color()];
        }
        floor_mat.color = Color.Lerp(floor_mat.color, secondColor, 0.003f);
        Camera.main.backgroundColor = Color.Lerp(floor_mat.color, secondColor, 0.0007f);
    }
    int second_Color()
    {
        int second_color;
        second_color = Random.Range(0, colors.Length);
        while(second_color == first_color)
        {
            second_color = Random.Range(0, colors.Length);
        }
        return second_color;
    }
}
