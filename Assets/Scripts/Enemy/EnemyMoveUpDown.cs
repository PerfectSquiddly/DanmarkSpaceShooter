using UnityEngine;
using System.Collections;

public class EnemyMoveUpDown : MonoBehaviour
{
    int direction = 1; //När 0 så är den i mitten och 1 är up 0ch -1 är ner
    int top = 3;
    int bottom = -3;

    float speed = 5;


    void Update()
    {
        //Rör sig upp och ner
        if (transform.position.y >= top)
            direction = -1;

        if (transform.position.y <= bottom)
            direction = 1;

        transform.Translate(0, speed * direction * Time.deltaTime, 0);
    }
}
