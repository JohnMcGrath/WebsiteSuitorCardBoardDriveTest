using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class CSVHandler : MonoBehaviour
{
    public TextAsset file;
    public Text testBox;

    public GameObject questionBoard;
    public GameObject answerA;
    public GameObject answerB;
    public GameObject answerC;
    public GameObject answerD;
    public GameObject imagePanel;

    public string questionString;

    Texture2D imagePanalText;

    //The string to represent which question is being used
    string tempString = "405";

    string correctAnswer;

    void Start()
    {
        //Load in the CSV File
        Load(file);

        //Make the image panel the image texture
        imagePanalText = (Texture2D)Resources.Load("dttImages/dttimg" + questionString);

        //If their is an image, load the texture
        if (imagePanalText != null)
        {
            imagePanel.GetComponent<Renderer>().material.mainTexture = imagePanalText;
        }

        //if not, remove the panel
        else
        {
            imagePanel.SetActive(false);
        }

        //Check which answer is correct
        correctAnswer = Find_id(questionString).correctAnswer;

        //Set each panels text to the string from the CSV
        TextMesh quesT = (TextMesh)questionBoard.GetComponent(typeof(TextMesh));
        quesT.text = Find_id(questionString).question;

        TextMesh ansA = (TextMesh)answerA.GetComponent(typeof(TextMesh));
        ansA.text = Find_id(questionString).answerA;

        TextMesh ansB = (TextMesh)answerB.GetComponent(typeof(TextMesh));
        ansB.text = Find_id(questionString).answerB;

        TextMesh ansC = (TextMesh)answerC.GetComponent(typeof(TextMesh));
        ansC.text = Find_id(questionString).answerC;

        TextMesh ansD = (TextMesh)answerD.GetComponent(typeof(TextMesh));
        ansD.text = Find_id(questionString).answerD;
    }

    //Gets which answer is correct
    public string GetAnswer()
    {
        return correctAnswer;
    }

    public class Row
    {
        public string id;
        public string catagory;
        public string hasImage;
        public string imageName;
        public string question;
        public string answerA;
        public string answerB;
        public string answerC;
        public string answerD;
        public string correctAnswer;

    }

    List<Row> rowList = new List<Row>();
    bool isLoaded = false;

    public bool IsLoaded()
    {
        return isLoaded;
    }

    public List<Row> GetRowList()
    {
        return rowList;
    }

    public void Load(TextAsset csv)
    {
        rowList.Clear();
        string[][] grid = CsvParser2.Parse(csv.text);
        for (int i = 1; i < grid.Length; i++)
        {
            Row row = new Row();
            row.id = grid[i][0];
            row.catagory = grid[i][1];
            row.hasImage = grid[i][2];
            row.imageName = grid[i][3];
            row.question = grid[i][4];
            row.answerA = grid[i][5];
            row.answerB = grid[i][6];
            row.answerC = grid[i][7];
            row.answerD = grid[i][8];
            row.correctAnswer = grid[i][9];

            rowList.Add(row);
        }
        isLoaded = true;
    }

    public int NumRows()
    {
        return rowList.Count;
    }

    public Row GetAt(int i)
    {
        if (rowList.Count <= i)
            return null;
        return rowList[i];
    }

    public Row Find_id(string find)
    {
        return rowList.Find(x => x.id == find);
    }
    public List<Row> FindAll_id(string find)
    {
        return rowList.FindAll(x => x.id == find);
    }
    public Row Find_catagory(string find)
    {
        return rowList.Find(x => x.catagory == find);
    }
    public List<Row> FindAll_catagory(string find)
    {
        return rowList.FindAll(x => x.catagory == find);
    }
    public Row Find_hasImage(string find)
    {
        return rowList.Find(x => x.hasImage == find);
    }
    public List<Row> FindAll_hasImage(string find)
    {
        return rowList.FindAll(x => x.hasImage == find);
    }
    public Row Find_imageName(string find)
    {
        return rowList.Find(x => x.imageName == find);
    }
    public List<Row> FindAll_imageName(string find)
    {
        return rowList.FindAll(x => x.imageName == find);
    }
    public Row Find_question(string find)
    {
        return rowList.Find(x => x.question == find);
    }
    public List<Row> FindAll_question(string find)
    {
        return rowList.FindAll(x => x.question == find);
    }
    public Row Find_answerA(string find)
    {
        return rowList.Find(x => x.answerA == find);
    }
    public List<Row> FindAll_answerA(string find)
    {
        return rowList.FindAll(x => x.answerA == find);
    }
    public Row Find_answerB(string find)
    {
        return rowList.Find(x => x.answerB == find);
    }
    public List<Row> FindAll_answerB(string find)
    {
        return rowList.FindAll(x => x.answerB == find);
    }
    public Row Find_answerC(string find)
    {
        return rowList.Find(x => x.answerC == find);
    }
    public List<Row> FindAll_answerC(string find)
    {
        return rowList.FindAll(x => x.answerC == find);
    }
    public Row Find_answerD(string find)
    {
        return rowList.Find(x => x.answerD == find);
    }
    public List<Row> FindAll_answerD(string find)
    {
        return rowList.FindAll(x => x.answerD == find);
    }
    public Row Find_correctAnswer(string find)
    {
        return rowList.Find(x => x.correctAnswer == find);
    }
    public List<Row> FindAll_correctAnswer(string find)
    {
        return rowList.FindAll(x => x.correctAnswer == find);
    }

}
