using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    [SerializeField]
    private Text movesText;
    [HideInInspector]
    public int moves;
    [SerializeField]
    private Text energyText;
    [HideInInspector]
    public int energy;
    public Toggle extension;

    private void Start()
    {
        StartValue();
    }

    private void OnEnable()
    {
        StartValue();
    }

    private void StartValue()
    {
        moves = 0;
        energy = 3;
        ChangeTextMoves();
        ChangeTextEnergy();
    }

    public void ChangeTextMoves()
    {
        movesText.text = "Moves: " + moves.ToString();
    }

    public void ChangeTextEnergy()
    {
        energyText.text = "Energy: " + energy.ToString();
    }
}
