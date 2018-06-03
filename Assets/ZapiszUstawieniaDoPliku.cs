using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;
using System.Collections;
using System.Collections.Generic;

public class ZapiszUstawieniaDoPliku : MonoBehaviour
{
        public  WczytajListePlikow zmienTryb;
    public Toggle PokazOsie;
    public Toggle PokazSlad;
    public InputField CzasTrwaniaSladu;
    public Toggle        PokazWspXYZ;
    public Toggle ustawQiRecznie;
    public Dropdown  WczytanyPlik;
    public Toggle radiany;
    public InputField dlugoscramienia1;
    public InputField dlugoscramienia2;
    public InputField kompresjaczasu;
    public InputField deltaT;
    public InputField czuloscMyszy;
    public InputField czuloscZoom;
    public InputField czuloscObrotow;
    
    public void Zapisz()
    {

        string fileName = "settings.dat";
        string path = Application.dataPath; //katalog do assets
        //path = Path.GetFullPath(Path.Combine(path, @"..\"));
        StreamWriter out_stm = new StreamWriter(path + fileName);
        out_stm.Close();
        out_stm.Dispose();

        out_stm = new StreamWriter(path + fileName);
        out_stm = File.CreateText(fileName);
        out_stm.WriteLine("Symgraph settings:");
        out_stm.WriteLine(PokazOsie.isOn);
        out_stm.WriteLine(PokazSlad.isOn);
        out_stm.WriteLine(CzasTrwaniaSladu.text);
        out_stm.WriteLine(PokazWspXYZ.isOn);
        out_stm.WriteLine(ustawQiRecznie.isOn);
        out_stm.WriteLine(WczytanyPlik.captionText.text);
        out_stm.WriteLine(radiany.isOn);
        out_stm.WriteLine(dlugoscramienia1.text);
        out_stm.WriteLine(dlugoscramienia2.text);
        out_stm.WriteLine(kompresjaczasu.text);
        out_stm.WriteLine(deltaT.text);
        out_stm.WriteLine(czuloscMyszy.text);
        out_stm.WriteLine(czuloscZoom.text);
        out_stm.WriteLine(czuloscObrotow.text);
        out_stm.Close();
        out_stm.Dispose();
        Debug.Log(out_stm);
        
    }
    public List<string> settings;
    public void Wczytaj()
    {

        string fileName = "settings.dat";
        string path = Application.dataPath; //katalog do assets
        path = Path.GetFullPath(Path.Combine(path, @"..\"));
        StreamReader inp_stm = new StreamReader(path + fileName);
        settings = new List<string>();

        if (inp_stm != null)
        {
            while (!inp_stm.EndOfStream)
            {
                string inp_ln = inp_stm.ReadLine();
                settings.Add(inp_ln);
            }

            PokazOsie.isOn = Convert.ToBoolean(settings[1]);
            PokazSlad.isOn = Convert.ToBoolean(settings[2]);
            CzasTrwaniaSladu.text = settings[3];
            PokazWspXYZ.isOn = Convert.ToBoolean(settings[4]);
            ustawQiRecznie.isOn = Convert.ToBoolean(settings[5]);
            WczytanyPlik.captionText.text = settings[6];
            radiany.isOn = Convert.ToBoolean(settings[7]);
            dlugoscramienia1.text = settings[8];
            dlugoscramienia2.text = settings[9];
            kompresjaczasu.text = settings[10];
            deltaT.text = settings[11];
            czuloscMyszy.text = settings[12];
            czuloscMyszy.transform.parent.transform.GetComponent<Slider>().value = Int16.Parse(czuloscMyszy.text);
            czuloscZoom.text = settings[13];
            czuloscZoom.transform.parent.transform.GetComponent<Slider>().value = Int16.Parse(czuloscZoom.text);
            czuloscObrotow.text = settings[14];
            czuloscObrotow.transform.parent.transform.GetComponent<Slider>().value = Int16.Parse(czuloscObrotow.text);

        }

            inp_stm.Close();
        inp_stm.Dispose();
        zmienTryb.Zmianatrybu();
    }
  
}