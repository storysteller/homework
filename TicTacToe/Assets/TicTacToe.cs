using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TicTacToe : MonoBehaviour
{
    private int[,] board= new int[3, 3];
    private int winner = 0;
    private int turn = 1;
    private int step = 0;
    private string tips;

    void Reset()
    {
        for (int i=0; i < 3;i++)
            for (int j = 0; j < 3; j++)
                board[i, j] = 0;
        winner = 0;
        turn = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        Reset();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    int Win()
    {
        for(int i=0;i<3;i++)
        {
            if (board[i, 0] == board[i, 1] && board[i, 0] == board[i, 2])
                return board[i, 0];
            if (board[0, i] == board[1, i] && board[0, i] == board[2, i])
                return board[0, i];
        }
        if ((board[0, 0] == board[1, 1] && board[0, 0] == board[2, 2])|| (board[2, 0] == board[1, 1] && board[0, 2] == board[2, 0]))
            return board[1, 1];
        if (step == 9) return 3;
        else return 0;
    }

    void OnGUI()
    {
        GUI.skin.button.fontSize = 50;
        GUI.skin.label.fontSize = 20;

        if (GUI.Button(new Rect(100, 200, 200, 50), "START"))
            Reset();

        if (Win() != 0)
        {
            if (Win() == 1) tips = "X方获胜";
            else if (Win() == 2) tips = "O方获胜";
            else tips = "平局";
            GUI.Label(new Rect(400, 50, 100, 100), tips);
        }

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (board[i, j] == 1)
                {
                    GUI.Button(new Rect(i * 80 + 400, j * 80 + 100, 80, 80), "X");
                }
                else if (board[i, j] == 2)
                {
                    GUI.Button(new Rect(i * 80 + 400, j * 80 + 100, 80, 80), "O");
                }
                else if (GUI.Button(new Rect(i * 80 + 400, j * 80 + 100, 80, 80), ""))
                {
                    if (Win() == 0)
                    {
                        if (turn == 0)
                        {
                            board[i, j] = 1;
                        }
                        else board[i, j] = 2;
                        turn = 1 - turn;
                        step++;
                    }
                }
            }
        }
    }
}
