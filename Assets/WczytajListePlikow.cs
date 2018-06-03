using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

public class WczytajListePlikow : MonoBehaviour {
    private List<string> ListaPlikow;
    public Canvas WczytanoDane;
    public Dropdown ddListaPlikow;
    public Text lblMainAktualnyTryb;
    public Text lblUstawieniaAktualnyTryb;
    private int aktualnyTryb;
    private string[] nazwyTrybow = { "zero",
            "RUCH PŁASKI KONFIGURACYJNY",
    "RUCH PRZESTRZENNY KONFIGURACYJNY",
    "RUCH PŁASKI KINEMATYKA",
    "RUCH PRZESTRZENNY KINEMATYKA",
    "RUCH PŁASKI DYNAMIKA",
    "RUCH PRZESTRZENNY DYNAMIKA",
    "RUCH PŁASKI ZADANIOWY",
    "RUCH PRZESTRZENNY ZADANIOWY"};
    List<string> listaRozszerzen;
    public obracaj skrypt;
    public string aktualnyPlik;

    // Use this for initialization
    void Start () {
        string[] temp = { "zero",".pos2", ".pos3", ".kin2", ".kin3", ".dyn2", ".dyn3", ".tsk2", ".tsk3" };
        listaRozszerzen = new List<string>(temp);
        WczytajListe();
        ddListaPlikow.value = 1;
        ddListaPlikow.value = 0;
        Zmianatrybu();

    }

    // Update is called once per frame
    void Update () {
	
	}

    public void WczytajListe()
    {
        string path = Application.dataPath; //katalog do assets
        path = Path.GetFullPath(Path.Combine(path, @"..\Dane\")); //katalog w gore do execa
        //Debug.Log(path);
        
        //termsList.Add(value);
        //You can convert it back to an array if you would like to
        //int[] terms = termsList.ToArray();

        ListaPlikow = new List<string>();
        //List<string> listaRozszerzen1 = temp.ToList();

        ddListaPlikow.options.Clear();
        foreach (string file in System.IO.Directory.GetFiles(path))
        {
            foreach (string ext in listaRozszerzen)
            {
                if (Path.GetExtension(file) == ext) {
                    ListaPlikow.Add(file);
                    ddListaPlikow.options.Add(new Dropdown.OptionData(Path.GetFileName(file)));
                }
            }
        }

        //ddListaPlikow.value = 0;
        //ddListaPlikow.transform.FindChild("Label").GetComponent<Text>().text = Path.GetFileName(ListaPlikow.First());
    }

    public void Zmianatrybu()
    {
        aktualnyPlik = GetComponent<Dropdown>().captionText.text;
        string aktualneRozszerzenie = Path.GetExtension(aktualnyPlik);
        int i = 0;
        foreach (string ext in listaRozszerzen) {
            if (aktualneRozszerzenie == ext) {
                aktualnyTryb = i;
            }
            i++;
        }

        lblMainAktualnyTryb.text = "Aktualny tryb:\n" + nazwyTrybow[aktualnyTryb]+"\nplik: "+ Path.GetFileNameWithoutExtension(aktualnyPlik);
        lblUstawieniaAktualnyTryb.text = "Aktualny tryb: " + nazwyTrybow[aktualnyTryb];
        skrypt.Wczytaj(aktualnyTryb, aktualnyPlik);
    }

}

// using System.IO;
// DirectoryInfo dir = new DirectoryInfo(myPath);
//FileInfo[] info = dir.GetFiles("*.*");
// foreach (FileInfo f in info) 
// { ... }



//FileInfo[] fileInfo = levelDirectoryPath.GetFiles("*.*", SearchOption.AllDirectories);
                 
// foreach (FileInfo file in fileInfo) {
//     // file name check
//     if (file.Name == "something") {
//         ...
//     }
//     // file extension check
//     if (file.Extension == ".ext") {
//         ...
//     }
//     // etc.
// }