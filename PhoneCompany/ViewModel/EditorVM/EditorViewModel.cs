﻿using System.Windows.Controls;

namespace PhoneCompany.ViewModel.EditorVM;

public class EditorViewModel
{
    public static Page CurrentPage { get; set; }
    public EditorViewModel(Page currentPage)
    {
        CurrentPage = currentPage;
    }
}