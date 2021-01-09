using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    // ボールが見える可能性のあるz軸の最大値
    private float visiblePosZ = -6.5f;

    // ゲームオーバーを表示するテキスト
    private GameObject gameoverText;

    // 点数を表示するテキスト
    private GameObject scoreText;

    private int score = 0;

    // Start is called before the first frame update
    void Start()
    {

        //シーン中のGameOverTextオブジェクトを取得
        this.gameoverText = GameObject.Find("GameOverText");

        //シーン中のScoreTextオブジェクトを取得
        this.scoreText = GameObject.Find("ScoreText");

        // 点数の初期化
        this.scoreText.GetComponent<Text>().text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        //ボールが画面外に出た場合
        if(this.transform.position.z < this.visiblePosZ)
        {
            //GameoverTextにゲームオーバーを表示
            this.gameoverText.GetComponent<Text>().text = "Game Over";

        }
        
    }
    
    // 衝突時に呼ばれる関数
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag.ToString() == "SmallStarTag")
        {
            score += 10;
        }else if(collision.gameObject.tag.ToString() == "LargeStarTag")
        {
            score += 100;
        }else if(collision.gameObject.tag.ToString() == "SmallCloudTag")
        {
            score += 20;
        }else if(collision.gameObject.tag.ToString() == "LargeCloudTag")
        {
            score += 40;
        }
        this.scoreText.GetComponent<Text>().text = score.ToString();

    }
    
}
