using System;
using System.Collections.Generic;

public class User
{
    public static User CurrentUser;
    private string _name;
    private int _userID;
    private float _progressScore = 0;
    private string _currentSequence = "";
    private List<string> _selectedChoicesList;

    #region properties
    public string Name { get => _name; set => _name = value; }
    public int UserID { get => _userID; set => _userID = value; }
    public float ProgressScore { get => _progressScore; set => _progressScore = value; }
    public string CurrentSequence { get => _currentSequence; set => _currentSequence = value; }
    public List<string> SelectedChoicesList { get => _selectedChoicesList; set => _selectedChoicesList = value; }
    #endregion
}