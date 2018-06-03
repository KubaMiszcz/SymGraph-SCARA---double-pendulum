using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using System.Globalization;

public class obracaj : MonoBehaviour
{

    public GameObject Ramie1, Ramie2, Efektor;
    private List<int> licznik;
    public int maxLicznik;
    public int aktLicznik = 0;
    private List<float> dlugosciRamion;
    private List<float> tablicaCzas;
    private List<float> tablicaTh1;
    private List<float> tablicaTh2;
    private List<float> tablicaTh3;
    private List<float> tablicaOmega1;
    private List<float> tablicaOmega2;
    private List<float> tablicaOmega3;
    private List<float> tablicaStanNarzedzia;
    public float czasSpowolnienia;
    public float wspKompresjiCzasu = 1f;
    public bool wahadloDziala = false;
    public float aktCzas, maxCzas;
    private GameObject[] Menusy;
    private float czas0, czas1;
    private Vector3 lineStart, lineEnd;
    Color kolorSladu = new Color(1, 0, 0, 1); //czerwony
    public GameObject czasSladu;
    private GameObject[] WylaczNaStarcie;
    public Canvas WczytanoDane;
    public string plikZDanymi;
    public int aktualnyTryb;
    public Toggle radiany;
    public InputField DeltaT;


    // Use this for initialization
    void Start()
    {
        Menusy = GameObject.FindGameObjectsWithTag("Menusy");
        WylaczNaStarcie = GameObject.FindGameObjectsWithTag("WylNaStarcie");
        aktLicznik = 0;
        WylaczMenusy();
        //Wczytaj();
        Debug.ClearDeveloperConsole();
    }

    // Update is called once per frame
    void Update()
    {
        if (wahadloDziala)
        {
            czas1 = (Time.time - czas0) * wspKompresjiCzasu;  //
            if (czas1 <= 0) czas1 = 0;
            if (czas1 >= maxCzas) czas1 = maxCzas;

            if (wahadloDziala)
            {
                aktLicznik = WyznaczIndex(czas1);
                aktCzas = tablicaCzas[aktLicznik];
                ObrotWahadla();
                lineEnd = Efektor.transform.position;
                //DrawLine(lineStart, lineEnd, kolorSladu , 1);
                //lineStart = lineEnd;
            }
        }
    }

    void DrawLine(Vector3 start, Vector3 end, Color color, float duration = 0.2f)  //Line Renderer
    {
        GameObject myLine = new GameObject();
        myLine.transform.position = start;
        myLine.AddComponent<LineRenderer>();
        LineRenderer lr = myLine.GetComponent<LineRenderer>();
        lr.material = new Material(Shader.Find("Particles/Alpha Blended Premultiply"));
        lr = myLine.GetComponent<LineRenderer>();
        lr.SetColors(color, color);
        lr.SetWidth(0.001f, 0.001f);
        lr.SetPosition(0, start);
        lr.SetPosition(1, end);
        GameObject.Destroy(myLine, duration);
    }

    void DrawTrail(Vector3 start, Vector3 end, Color color, float duration = 0.2f)
    {
        GameObject myLine = new GameObject();
        myLine.transform.position = start;
        myLine.AddComponent<TrailRenderer>();
        TrailRenderer lr = myLine.GetComponent<TrailRenderer>();
        lr.material = new Material(Shader.Find("Particles/Alpha Blended Premultiply"));
        lr = myLine.GetComponent<TrailRenderer>();
        //lr.SetColors(color, color);
        lr.startWidth = 0.001f;
        lr.endWidth = 0.001f;
        lr.time = 3f;
        //lr.SetPosition(0, start);
        //lr.SetPosition(1, end);
        GameObject.Destroy(myLine, duration);
    }


    public void ObrotWahadla()
    {
        float kat;
        kat = tablicaTh1[aktLicznik];
        ObrocRamie(Ramie1, new Vector3(0, kat, 0));

        kat = tablicaTh2[aktLicznik];
        ObrocRamie(Ramie1, new Vector3(0, 0, kat));

        kat = tablicaTh3[aktLicznik];
        ObrocRamie(Ramie2, new Vector3(0, 0, kat));
    }

    private void ObrocRamie(GameObject Ramie, Vector3 newEuler) {
        if (newEuler.x == 0) newEuler.x = Ramie.transform.localEulerAngles.x;
        if (newEuler.y == 0) newEuler.y = Ramie.transform.localEulerAngles.y;
        if (newEuler.z == 0) newEuler.z = Ramie.transform.localEulerAngles.z;
        Ramie.transform.localEulerAngles = newEuler;
    }

    private int WyznaczIndex(float czas) {
        int index = 0;
        while (tablicaCzas[index] < czas) {
            index++;
        }
        return index; //zeby zlapalo ostania klatke
    }


    IEnumerator ZgasSlad()
    {
        Efektor.transform.Find("Trail").GetComponent<TrailRenderer>().time = 0;
        yield return new WaitForSeconds(.001f);
        Efektor.transform.Find("Trail").GetComponent<TrailRenderer>().time = float.Parse(czasSladu.GetComponent<Text>().text);
    }


    public void StartWahadla()
    {
        czas0 = Time.time;
        wahadloDziala = true;
        Time.timeScale = 1;
        StartCoroutine(ZgasSlad());
        //Efektor.GetComponent<TrailRenderer>().time = float.Parse(czasSladu.GetComponent<Text>().text);
    }

    public void StopWahadla()
    {
        wahadloDziala = false;
        Time.timeScale = 0;
    }

    public void ResetWahadla()
    {
        StopWahadla();
        Time.timeScale = 1;
        //Efektor.transform.Find("Trail").GetComponent<TrailRenderer>().time = 0f;
        Efektor.transform.Find("Trail").GetComponent<TrailRenderer>().GetComponent<ResetujSlad>().Resetuj();
        aktLicznik = 0;
        Ramie1.transform.localEulerAngles = new Vector3(0, 0, 0);
        Ramie2.transform.localEulerAngles = new Vector3(0, 0, 0);
        aktCzas = 0f;
    }

    public void Wczytaj(int aktualnyTryb, string aktualnyPlik)
    {
        WczytanoDane.enabled = true;
        WczytanoDane.transform.Find("Title").GetComponent<Text>().text = "Wczytywanie Danych z pliku:\n" + aktualnyPlik;
        string path = Application.dataPath; //katalog do assets
        path = Path.GetFullPath(Path.Combine(path, @"..\Dane\")); //katalog w gore do execa
                                                                  //Debug.Log(path);

        licznik = new List<int>();
        dlugosciRamion = new List<float>();
        tablicaCzas = new List<float>();
        tablicaTh1 = new List<float>();
        tablicaTh2 = new List<float>();
        tablicaTh3 = new List<float>();
        tablicaOmega1 = new List<float>();
        tablicaOmega2 = new List<float>();
        tablicaOmega3 = new List<float>();
        tablicaStanNarzedzia = new List<float>();
        int i = 0;
        float Rad = 1;
        if (radiany.isOn) Rad = Mathf.Rad2Deg;


        //    termsList.Add(value);
        // You can convert it back to an array if you would like to
        //int[] terms = termsList.ToArray();

        StreamReader inp_stm = new StreamReader(path + aktualnyPlik);
        //        Debug.Log(path + aktualnyPlik);
        //Debug.Log(Path.GetFileName(path + "/""/Some/File/At/foo.extension"));

        bool naglowek = true;
        float czas = 0f;
        while (!inp_stm.EndOfStream)
        {
            string inp_ln = inp_stm.ReadLine();
            if (inp_ln.Substring(0, 1) != "#" && inp_ln.Substring(0, 1) != "%" 
                && inp_ln.Substring(0, 1) != "\n" && inp_ln.Substring(0, 1) != "\r"
                && inp_ln.Substring(0, 1) != null && inp_ln.Substring(0, 1) != ""
                && inp_ln.Substring(0, 1) != "\r\n" && inp_ln.Substring(0, 1) != "\n\r"
                )
            {
                if (naglowek)
                {
                    dlugosciRamion.Add(float.Parse(inp_ln));
                    if (dlugosciRamion.Count >= 2) naglowek = false;
                }
                else {
                    //////////////////////
                    //poczatek trybu 1 pos2
                    if (aktualnyTryb == 1)
                    {
                        DeltaT.gameObject.SetActive(true);
                        DeltaT.enabled = true;
                        string[] kolumnyztxt = inp_ln.Split('\t');
                        czas += float.Parse(DeltaT.text) / 1000f;
                        float Th1 = 0;
                        float Th2 = float.Parse(kolumnyztxt[0], CultureInfo.InvariantCulture.NumberFormat) * Rad;
                        float Th3 = float.Parse(kolumnyztxt[1], CultureInfo.InvariantCulture.NumberFormat) * Rad;
                        licznik.Add(i); i++;
                        tablicaCzas.Add(czas);
                        tablicaTh1.Add(Th1);
                        tablicaTh2.Add(Th2);
                        tablicaTh3.Add(Th3);
                    }
                    //////////////////////
                    //poczatek trybu 2 pos3
                    if (aktualnyTryb == 2)
                    {
                        DeltaT.gameObject.SetActive(true);
                        string[] kolumnyztxt = inp_ln.Split('\t');
                        czas += float.Parse(DeltaT.text) / 1000f;
                        float Th1 = float.Parse(kolumnyztxt[0], CultureInfo.InvariantCulture.NumberFormat) * Rad;
                        float Th2 = float.Parse(kolumnyztxt[1], CultureInfo.InvariantCulture.NumberFormat) * Rad;
                        float Th3 = float.Parse(kolumnyztxt[2], CultureInfo.InvariantCulture.NumberFormat) * Rad;
                        licznik.Add(i); i++;
                        tablicaCzas.Add(czas);
                        tablicaTh1.Add(Th1);
                        tablicaTh2.Add(Th2);
                        tablicaTh3.Add(Th3);
                    }
                    //////////////////////
                    //poczatek trybu 3 kin2
                    if (aktualnyTryb == 3)
                    {
                        DeltaT.gameObject.SetActive(false);
                        string[] kolumnyztxt = inp_ln.Split('\t');
                        czas = float.Parse(kolumnyztxt[0], CultureInfo.InvariantCulture.NumberFormat);
                        float Th1 = 0f;
                        float Th2 = float.Parse(kolumnyztxt[1], CultureInfo.InvariantCulture.NumberFormat) * Rad;
                        float Th3 = float.Parse(kolumnyztxt[2], CultureInfo.InvariantCulture.NumberFormat) * Rad;
                        float Omega1 = 0f;
                        float Omega2 = float.Parse(kolumnyztxt[3], CultureInfo.InvariantCulture.NumberFormat) * Rad;
                        float Omega3 = float.Parse(kolumnyztxt[4], CultureInfo.InvariantCulture.NumberFormat) * Rad;
                        tablicaTh1.Add(Th1);
                        tablicaTh2.Add(Th2);
                        tablicaTh3.Add(Th3);
                        tablicaOmega1.Add(Omega1);
                        tablicaOmega2.Add(Omega2);
                        tablicaOmega3.Add(Omega3);
                        tablicaCzas.Add(czas);
                        licznik.Add(i);
                        i++;

                    }
                    //////////////////////
                    //poczatek trybu 4 kin3
                    if (aktualnyTryb == 4)
                    {
                        DeltaT.gameObject.SetActive(false);
                        string[] kolumnyztxt = inp_ln.Split('\t');
                        czas = float.Parse(kolumnyztxt[0], CultureInfo.InvariantCulture.NumberFormat);
                        float Th1 = float.Parse(kolumnyztxt[1], CultureInfo.InvariantCulture.NumberFormat) * Rad;
                        float Th2 = float.Parse(kolumnyztxt[2], CultureInfo.InvariantCulture.NumberFormat) * Rad;
                        float Th3 = float.Parse(kolumnyztxt[3], CultureInfo.InvariantCulture.NumberFormat) * Rad;
                        float Omega1 = float.Parse(kolumnyztxt[4], CultureInfo.InvariantCulture.NumberFormat) * Rad;
                        float Omega2 = float.Parse(kolumnyztxt[5], CultureInfo.InvariantCulture.NumberFormat) * Rad;
                        float Omega3 = float.Parse(kolumnyztxt[6], CultureInfo.InvariantCulture.NumberFormat) * Rad;
                        tablicaTh1.Add(Th1);
                        tablicaTh2.Add(Th2);
                        tablicaTh3.Add(Th3);
                        tablicaOmega1.Add(Omega1);
                        tablicaOmega2.Add(Omega2);
                        tablicaOmega3.Add(Omega3);
                        tablicaCzas.Add(czas);
                        licznik.Add(i);
                        i++;
                        
                    }

                    //if (aktualnyTryb == 4)
                    //{
                    //    DeltaT.gameObject.SetActive(false);
                    //    string[] kolumnyztxt = inp_ln.Split('\t');
                    //    float Th1 = float.Parse(kolumnyztxt[0], CultureInfo.InvariantCulture.NumberFormat) * Rad;
                    //    float Th2 = float.Parse(kolumnyztxt[1], CultureInfo.InvariantCulture.NumberFormat) * Rad;
                    //    float Th3 = float.Parse(kolumnyztxt[2], CultureInfo.InvariantCulture.NumberFormat) * Rad;
                    //    float Omega1 = float.Parse(kolumnyztxt[3], CultureInfo.InvariantCulture.NumberFormat) * Rad;
                    //    float Omega2 = float.Parse(kolumnyztxt[4], CultureInfo.InvariantCulture.NumberFormat) * Rad;
                    //    float Omega3 = float.Parse(kolumnyztxt[5], CultureInfo.InvariantCulture.NumberFormat) * Rad;
                    //    tablicaTh1.Add(Th1);
                    //    tablicaTh2.Add(Th2);
                    //    tablicaTh3.Add(Th3);
                    //    tablicaOmega1.Add(Omega1);
                    //    tablicaOmega2.Add(Omega2);
                    //    tablicaOmega3.Add(Omega3);
                    //    if (i == 0) czas = 0;//pierweszy element
                    //    else {
                    //        if ((tablicaOmega2[i] - tablicaOmega2[i - 1]) == 0)  //gdy dzielenie przez 0
                    //        { czas = Mathf.Abs(tablicaCzas[i - 1]); Debug.Log(czas); }
                    //        else {
                    //            czas += Mathf.Abs((tablicaTh2[i] - tablicaTh2[i - 1]) / (tablicaOmega2[i] - tablicaOmega2[i - 1]));
                    //            Debug.Log(czas);
                    //        }
                    //    }
                    //    licznik.Add(i);
                    //    i++;
                    //    tablicaCzas.Add(czas);
                    //}
                    //////////////////////
                    //poczatek trybu 5 dyn2
                    if (aktualnyTryb == 5)
                    {
                        DeltaT.gameObject.SetActive(false);
                        string[] kolumnyztxt = inp_ln.Split('\t');
                        czas = float.Parse(kolumnyztxt[0], CultureInfo.InvariantCulture.NumberFormat);
                        float Th1 = 0f;
                        float Th2 = float.Parse(kolumnyztxt[1], CultureInfo.InvariantCulture.NumberFormat) * Rad;
                        float Th3 = float.Parse(kolumnyztxt[2], CultureInfo.InvariantCulture.NumberFormat) * Rad;
                        //float Omega1 = 0f;
                        //float Omega2 = float.Parse(kolumnyztxt[3], CultureInfo.InvariantCulture.NumberFormat) * Rad;
                        //float Omega3 = float.Parse(kolumnyztxt[4], CultureInfo.InvariantCulture.NumberFormat) * Rad;
                        licznik.Add(i); i++;
                        tablicaCzas.Add(czas);
                        tablicaTh1.Add(Th1);
                        tablicaTh2.Add(Th2);
                        tablicaTh3.Add(Th3);
                        //tablicaOmega1.Add(Omega1);
                        //tablicaOmega2.Add(Omega2);
                        //tablicaOmega3.Add(Omega3);
                    }
                    //////////////////////
                    //poczatek trybu 6 dyn3
                    if (aktualnyTryb == 6)
                    {
                        DeltaT.gameObject.SetActive(false);
                        string[] kolumnyztxt = inp_ln.Split('\t');
                        czas = float.Parse(kolumnyztxt[0], CultureInfo.InvariantCulture.NumberFormat);
                        float Th1 = float.Parse(kolumnyztxt[1], CultureInfo.InvariantCulture.NumberFormat) * Rad;
                        float Th2 = float.Parse(kolumnyztxt[2], CultureInfo.InvariantCulture.NumberFormat) * Rad;
                        float Th3 = float.Parse(kolumnyztxt[3], CultureInfo.InvariantCulture.NumberFormat) * Rad;
                        licznik.Add(i); i++;
                        tablicaCzas.Add(czas);
                        tablicaTh1.Add(Th1);
                        tablicaTh2.Add(Th2);
                        tablicaTh3.Add(Th3);
                    }

                    //////////////////////
                    //poczatek trybu 7 tsk2
                    if (aktualnyTryb == 7)
                    {
                        DeltaT.gameObject.SetActive(false);
                        string[] kolumnyztxt = inp_ln.Split('\t');
                        czas = float.Parse(kolumnyztxt[0], CultureInfo.InvariantCulture.NumberFormat);
                        float Th1 = 0f;
                        float Th2 = float.Parse(kolumnyztxt[1], CultureInfo.InvariantCulture.NumberFormat) * Rad;
                        float Th3 = float.Parse(kolumnyztxt[2], CultureInfo.InvariantCulture.NumberFormat) * Rad;
                        float stanNarzedzia = float.Parse(kolumnyztxt[3], CultureInfo.InvariantCulture.NumberFormat) * Rad;
                        licznik.Add(i); i++;
                        tablicaCzas.Add(czas);
                        tablicaTh1.Add(Th1);
                        tablicaTh2.Add(Th2);
                        tablicaTh3.Add(Th3);
                        tablicaStanNarzedzia.Add(stanNarzedzia);
                    }

                    //////////////////////
                    //poczatek trybu 8 tsk3
                    if (aktualnyTryb == 8)
                    {
                        DeltaT.gameObject.SetActive(false);
                        string[] kolumnyztxt = inp_ln.Split('\t');
                        czas = float.Parse(kolumnyztxt[0], CultureInfo.InvariantCulture.NumberFormat);
                        float Th1 = float.Parse(kolumnyztxt[1], CultureInfo.InvariantCulture.NumberFormat) * Rad;
                        float Th2 = float.Parse(kolumnyztxt[2], CultureInfo.InvariantCulture.NumberFormat) * Rad;
                        float Th3 = float.Parse(kolumnyztxt[3], CultureInfo.InvariantCulture.NumberFormat) * Rad;
                        float stanNarzedzia = float.Parse(kolumnyztxt[4], CultureInfo.InvariantCulture.NumberFormat) * Rad;
                        licznik.Add(i); i++;
                        tablicaCzas.Add(czas);
                        tablicaTh1.Add(Th1);
                        tablicaTh2.Add(Th2);
                        tablicaTh3.Add(Th3);
                        tablicaStanNarzedzia.Add(stanNarzedzia);
                    }
                }
            }
        }
        inp_stm.Close();
        maxLicznik = licznik.Count - 1;
        maxCzas = tablicaCzas[maxLicznik];
        lineStart = Efektor.transform.position;
        DeltaT.gameObject.SetActive(true);
        WczytanoDane.transform.Find("Title").GetComponent<Text>().text = "Wczytano Dane z pliku:\n"+ aktualnyPlik;
    }

    public void WylaczMenusy() {
        foreach (GameObject go in Menusy) {
            go.GetComponent<Canvas>().enabled = false;
        }
        foreach (GameObject go in WylaczNaStarcie)
        {
            go.SetActive(false);
        }
    }

    IEnumerator CzekajNaKoniecKlatki() {
        yield return new WaitForEndOfFrame();
    }


    public void navPause()
    {
        wahadloDziala = !wahadloDziala;
        if (Time.timeScale > 0) Time.timeScale = 0; else Time.timeScale = 1;
    }

    public void navPlay()
    {
        navStop();
        ResetWahadla();
        //Efektor.transform.Find("Trail").GetComponent<TrailRenderer>().time = float.Parse(czasSladu.GetComponent<Text>().text);
        StartWahadla();
    }

    public void navStop()
    {
        ResetWahadla();
    }

    public void navRewind()
    {
        czas0 = czas0 + (maxCzas / 10f);
    }
    public void navForward()
    {
        czas0 = czas0 - (maxCzas / 10f);
    }

    public void AktualizujDeltaT()
    {
        float dt = float.Parse(DeltaT.text) / 1000f;
        float czas = 0f;
        int i = 0;
        for (i = 0; i < tablicaCzas.Count; i++)
        {
            tablicaCzas[i] = czas;
            czas += dt;
        }
        maxLicznik = licznik.Count - 1;
        maxCzas = tablicaCzas[maxLicznik];
        lineStart = Efektor.transform.position;
    }

  
}//koniec klasy
