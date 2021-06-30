using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class PhotoImage : MonoBehaviour
{

    //image�̓X�v���C�g���g���ĕ`�悵�Ă���̂�
    Sprite sprite;
    //�摜�����N����摜���e�N�X�`���ɂ���
    Texture2D texture;
   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PhotoUpload()
    {
        //var texture = Resources.Load<Texture2D>("cooktest");
        Texture2D texture = Resources.Load("cooktest") as Texture2D;
        //texture����sprite�ɕϊ�
        sprite = Sprite.Create(texture, new Rect(0.0f, 0.0f, texture.width, texture.height), Vector2.zero);
        //Image��sprite�𒣂�t����
        gameObject.GetComponent<Image>().sprite = sprite;
    }

    //�e�N�X�`����ǂݍ���
    IEnumerator Connect()
    {

        //�摜�����N
        string url = "Assets/cooktest.jpg";


        UnityWebRequest www = UnityWebRequestTexture.GetTexture(url);

        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
        }
        else
        {
            //texture�ɉ摜�i�[
            texture = ((DownloadHandlerTexture)www.downloadHandler).texture;
            //texture����sprite�ɕϊ�
            sprite = Sprite.Create(texture, new Rect(0.0f, 0.0f, texture.width, texture.height), Vector2.zero);
            //Image��sprite�𒣂�t����
            gameObject.GetComponent<Image>().sprite = sprite;
        }
    }

}