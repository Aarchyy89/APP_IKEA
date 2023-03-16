using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShareImage : MonoBehaviour
{
    public bool estoyhaciendofoto;

    private void Start()
    {
        estoyhaciendofoto = false;
    }


    public void Share()
    {
        estoyhaciendofoto = true;

        if (estoyhaciendofoto == true)
        {

            UIMANAGER.UIM.PANEL_scroll_SILLAS.SetActive(false);
            UIMANAGER.UIM.panel_scroll_mesas.SetActive(false);
            UIMANAGER.UIM.panel_scroll_mesillas.SetActive(false);
            UIMANAGER.UIM.panel_scroll_sillon.SetActive(false);
            UIMANAGER.UIM.panel_scroll_sofas.SetActive(false);
            //UIManager.UIM.Takepic.SetActive(false);
            UIMANAGER.UIM.PANEL_vertical_muebles.SetActive(false);
            UIMANAGER.UIM.position_but.gameObject.SetActive(false);
            UIMANAGER.UIM.rotate_BUT.gameObject.SetActive(false);
            UIMANAGER.UIM.quit_MUEBLE_BUT.gameObject.SetActive(false);
            UIMANAGER.UIM.escale_BUT.gameObject.SetActive(false);

            StartCoroutine(TakeScreendShotAndShare());

        }

    }


    private IEnumerator TakeScreendShotAndShare()
    {
        yield return new WaitForEndOfFrame();

        Texture2D ss = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        ss.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);

        string filePath = System.IO.Path.Combine(Application.temporaryCachePath, "share.png");
        System.IO.File.WriteAllBytes(filePath, ss.EncodeToPNG());

        Destroy(ss);

        new NativeShare().AddFile(filePath).SetSubject("").SetText("").SetUrl("").SetCallback((res, target) => Debug.Log($"result {res}, target app: {target}")).Share();


        yield return new WaitForSeconds(1f);

        estoyhaciendofoto = false;

        if (estoyhaciendofoto == false)
        {

            UIMANAGER.UIM.PANEL_scroll_SILLAS.SetActive(true);
            UIMANAGER.UIM.panel_scroll_mesas.SetActive(true);
            UIMANAGER.UIM.panel_scroll_mesillas.SetActive(true);
            UIMANAGER.UIM.panel_scroll_sillon.SetActive(true);
            UIMANAGER.UIM.panel_scroll_sofas.SetActive(true);
            //UIManager.UIM.Takepic.SetActive(false);
            UIMANAGER.UIM.PANEL_vertical_muebles.SetActive(true);
            UIMANAGER.UIM.position_but.gameObject.SetActive(true);
            UIMANAGER.UIM.rotate_BUT.gameObject.SetActive(true);
            UIMANAGER.UIM.quit_MUEBLE_BUT.gameObject.SetActive(true);
            UIMANAGER.UIM.escale_BUT.gameObject.SetActive(true);
        }
    }

}
