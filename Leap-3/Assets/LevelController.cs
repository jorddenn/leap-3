using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{

    public Material cubeColor;
    public Material backgroundColor;
    public GameObject cube;

    float insTime;
    float r = 255f;
    float g, b = 0;

    // Use this for initialization
    void Start()
    {
        insTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {

        if ((Time.time - insTime) > 2f)//every 2 seconds
        {
            insTime = Time.time;
            StartCoroutine(CubeRotate((int)Mathf.Round(Random.Range(1, 4))));//rotate cube in random direction
        }
    }

    IEnumerator CubeRotate(int direction)
    {
        float rotation = 0;
        while (true)
        {
            if (rotation == 91)
                break;
            else
                rotation++;

            switch (direction)
            {
                case 1:
                    cube.transform.rotation = Quaternion.Euler(rotation, 0, 0);
                    break;
                case 2:
                    cube.transform.rotation = Quaternion.Euler(-rotation, 0, 0);
                    break;
                case 3:
                    cube.transform.rotation = Quaternion.Euler(0, rotation, 0);
                    break;
                case 4:
                    cube.transform.rotation = Quaternion.Euler(0, -rotation, 0);
                    break;
            }
            cubeColor.color = ColorTick();
            backgroundColor.color = ColorComp(cubeColor.color);
            yield return new WaitForSeconds(0.01f);
        }

    }
    Color ColorTick()
    {
        if (r == 255f && g != 255 && b == 0)
        {
            g += 5f;
        }
        else if (r != 0 && g == 255f && b == 0)
        {
            r -= 5f;
        }
        else if (r == 0 && g == 255f && b != 255f)
        {
            b += 5f;
        }
        else if (r == 0 && g != 0 && b == 255f)
        {
            g -= 5f;
        }
        else if (r != 255f && g == 0 && b == 255f)
        {
            r += 5f;
        }
        else if (r == 255f && g == 0 && b != 0)
        {
            b -= 5f;
        }
        return new Color(r/255, g/255, b/255);
    }

    Color ColorComp(Color color) {
        return new Color(1f - color.r, 1f - color.g, 1f - color.b);
    }

}
