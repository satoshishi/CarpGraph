using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEditor;
using Table.MasterData;

public class CSVtoPlayerRepository : MonoBehaviour
{
    [SerializeField]
    private PlayerRepository target;

    void Start()
    {
        int index = 0;
        for (int i = 0; i <= 9; i++)
        {
            TextAsset csvFile = Resources.Load((2010 + i).ToString()) as TextAsset; // Resouces下のCSV読み込み
            StringReader reader = new StringReader(csvFile.text);
            reader.ReadLine();
            while (reader.Peek() != -1) // reader.Peaekが-1になるまで
            {
                string line = reader.ReadLine(); // 一行ずつ読み込み
                string[] splited = line.Split(',');
                target.DataStore[index].DataYear = 2010 + i;
                target.DataStore[index].Name = splited[2];
                target.DataStore[index].Origin = splited[11];
                // target.List[index].Value.Position = splited[3];
                // target.List[index].Value.Birthday = splited[4];
                target.DataStore[index].Age = int.Parse(splited[5].Replace("歳", ""));
                target.DataStore[index].Height = int.Parse(splited[7].Replace("cm",""));
                target.DataStore[index].Weight = int.Parse(splited[8].Replace("kg", ""));
                target.DataStore[index].BloodType = splited[9];
                target.DataStore[index].AnnualSalary = int.Parse(splited.Length > 13 ? splited[12] + splited[13].Replace("万円","") : splited[12].Replace("万円", ""));
                target.DataStore[index].FullData = 
                    target.DataStore[index].DataYear+"_"+
                    target.DataStore[index].Name +"_"+
                    target.DataStore[index].Origin + "_" +
                    target.DataStore[index].Age + "_" +
                    target.DataStore[index].Height + "_" +
                    target.DataStore[index].Weight + "_" +
                    target.DataStore[index].BloodType + "_" +
                    target.DataStore[index].AnnualSalary;
                ++index;
                /*
                            string line = reader.ReadLine(); // 一行ずつ読み込み
                            string[] splited = line.Split(‘,’);
                            Debug.Log(“名前 “+splited[2]);
                            Debug.Log(“ポジション “+splited[3]);
                            Debug.Log(“生年月日 “+splited[4]);
                            Debug.Log(“年齢 “+splited[5]);
                            Debug.Log(“年数 “+splited[6]);
                            Debug.Log(“身長 “+splited[7]);
                            Debug.Log(“体重 “+splited[8]);
                            Debug.Log(“血液型 “+splited[9]);
                            Debug.Log(“投打 “+splited[10]);
                            Debug.Log(“出身 “+splited[11]);
                            Debug.Log(“年俸 “+(splited.Length>13 ? splited[12]+splited[13] : splited[12]));
                            Debug.Log(“_________________________“);
                */
            }
        }
        EditorUtility.SetDirty(target);
        AssetDatabase.SaveAssets();
    }
}
