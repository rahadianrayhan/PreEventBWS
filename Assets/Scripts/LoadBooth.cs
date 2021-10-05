using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;
using SimpleJSON;

public class LoadBooth : MonoBehaviour
{
    public static LoadBooth instance = null;
    private static string url = ReqURL.base_url;
    private static BoothFill booth;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            booth.SetUpProps();
        }
    }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        booth = FindObjectOfType<BoothFill>();
        /*
        else if(instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
        */
     }

    public static void LoadAPI()
    {
        instance.StopAllCoroutines();
        instance.StartCoroutine(GetRequest());

        //int index = int.Parse(BoothID.Slot);
        //instance.StartCoroutine(GetDummy(index - 1));
    }

    private static IEnumerator GetRequest()
    {
        int type = 0;
        int stand = 0; 
        int props = 0;
        string color = "";

        WWWForm form = new WWWForm();
        form.AddField("slot", BoothID.Slot);

#region Individual Booth
        UnityWebRequest req_booth = UnityWebRequest.Post(url + "booth/individual/", form);

        //request.SetRequestHeader("Authorization", "Bearer " + UserToken.Token);
        //request.SetRequestHeader("X-Key", "dnhwbzIwMjA=");
        //request.SetRequestHeader("X-Secreate", "2ab0def3a63befc0d82fd766c84898dd75afdb23cef70035221c17af3d9007ea");

        booth.ClearBooth();

        using (req_booth)
        {
            // Request and wait for the desired page.
            yield return req_booth.SendWebRequest();

            string[] pages = url.Split('/');
            int page = pages.Length - 1;

            if (req_booth.isNetworkError)
            {
                Debug.Log(pages[page] + ": Error: " + req_booth.error + "\n try to refresh");
                //if(request.error = Netw)
                instance.StartCoroutine(GetRequest());
            }
            else
            {
                Debug.Log(pages[page] + ":\nReceived: " + req_booth.downloadHandler.text);
                JSONNode dataBooth = JSON.Parse(req_booth.downloadHandler.text);

                // DO Something On Success

                booth.Id = dataBooth["id_booth"].AsInt;
                booth.Brand = dataBooth["brand"];
                booth.CompanyName = dataBooth["company_name"];

                //int type = dataBooth["tipe"].AsInt;
                type = BoothID.TipeInt;

                stand = dataBooth["stand"];
                if(stand == 0)
                {
                    stand = 1;
                }

                props = dataBooth["property"];
                if(props == 0)
                {
                    props = 1;
                }

                color = dataBooth["color"];

                //Debug.Log(type + " - " + stand + " - " + props + " - " + color);
                booth.SetupBooth(type, stand, props, color);
            }
        }

        #endregion
        #region Attribute
        UnityWebRequest req_attr = UnityWebRequest.Post(url + "booth/attribute/", form);

        using (req_attr)
        {
            yield return req_attr.SendWebRequest();

            string[] pages = url.Split('/');
            int page = pages.Length - 1;

            if (req_attr.isNetworkError)
            {
                Debug.Log(pages[page] + ": Error: " + req_booth.error + "\n try to refresh");
                //if(request.error = Netw)
                instance.StartCoroutine(GetRequest());
            }
            else
            {
                Debug.Log(pages[page] + ":\nReceived: " + req_attr.downloadHandler.text);
                JSONNode attribute = JSON.Parse(req_attr.downloadHandler.text);

                booth.Information = attribute["desc"];
                string phone = attribute["phone"];
                if (phone.StartsWith("08"))
                {
                    phone = phone.Remove(0, 2).Insert(0, "62");
                }

                booth.Phone_number = phone;
                booth.Url_website = attribute["website"];
                booth.VideoUrl =  attribute["video"];

                string url_logo = attribute["logo"];
                
                if (url_logo != null)
                {
                    Texture logo = null;
                    yield return instance.StartCoroutine(LoadTexture(url_logo, value => logo = value));
                    booth.TextureLogo = logo;
                }
                   
                JSONNode url_banner = attribute["banner"].AsArray;

                if(url_banner != null)
                {
                    int bannerCount = 0;
                    switch (BoothID.TipeInt)
                    {
                        case 3:
                            bannerCount = 1;
                            break;
                        case 2:
                            bannerCount = 2;
                            break;
                        case 1:
                            bannerCount = 4;
                            break;
                    }
                    for (int i = 0; i < bannerCount; i++)
                    {
                        Texture banner = null;
                        yield return instance.StartCoroutine(LoadTexture(url_banner[i], value => banner = value));
                        booth.AddBannerTexture(banner);
                    }
                }

                booth.SetUpProps();

            }
        }

        #endregion

        FindObjectOfType<PlayerSpawner>().reSpawn(type);
    }

    private static IEnumerator LoadTexture(string _url, System.Action<Texture> result)
    {
        Texture texture = null;

        UnityWebRequest req_texture = UnityWebRequestTexture.GetTexture(_url);
        
        //req_texture.SetRequestHeader("Authorization", "Bearer " + UserToken.Token);
        //req_texture.SetRequestHeader("X-Key", "dnhwbzIwMjA=");
        //req_texture.SetRequestHeader("X-Secreate", "2ab0def3a63befc0d82fd766c84898dd75afdb23cef70035221c17af3d9007ea");

        yield return req_texture.SendWebRequest();

        if (req_texture.isNetworkError || req_texture.isHttpError)
        {
            Debug.Log(req_texture.error+ "\n try to reconnect");
            result(null);
            //instance.StartCoroutine(LoadTexture(_url, value => texture = value));
        }
        else
        {
            texture = ((DownloadHandlerTexture)req_texture.downloadHandler).texture;
        }
        result(texture);
    }
/*
    private static IEnumerator GetDummy(int _idx)
    {
        DummyFill.instance.Fill();

        booth.ClearBooth();

        FindObjectOfType<PlayerSpawner>().reSpawn(Dummy.Type[_idx]);

        booth.Id = Dummy.Id[_idx];
        booth.Slot = Dummy.Slot[_idx];
        booth.Brand = Dummy.Brand[_idx];
        booth.VideoUrl = Dummy.Url_video[_idx];
        booth.Information = Dummy.Information[_idx];
        booth.Phone_number = Dummy.Phone[_idx];
        booth.Url_website = Dummy.Website[_idx];

        booth.SetupBooth(Dummy.Type[_idx], Dummy.Stand[_idx], Dummy.PropertyId[_idx], Dummy.Color[_idx]);

        FeatureContainer.instance.SetupAll();

        Texture logo = null;
        yield return instance.StartCoroutine(LoadTexture(Dummy.Url_logo[_idx], value => logo = value));
        booth.TextureLogo = logo;

        int bannerCount = 0;
        switch (Dummy.Type[_idx])
        {
            case 1:
                bannerCount = 1;
                break;
            case 2:
                bannerCount = 2;
                break;
            case 3:
                bannerCount = 4;
                break;
        }
        for(int i=0; i< bannerCount; i++)
        {
            Texture banner = null;
            yield return instance.StartCoroutine(LoadTexture(Dummy.Url_banner[_idx,i], value => banner = value));
            booth.AddBannerTexture(banner);
        }

        //booth.Props = FindObjectOfType<BoothProps>();
        booth.SetUpProps();
    }
*/
}