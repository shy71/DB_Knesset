﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DB_Project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ViewTables_Button(object sender, RoutedEventArgs e)
        {
            new PickTable().Show();
            Close();
           

        }
        private void FuncProc_Button(object sender, RoutedEventArgs e)
        {
            new PickFunc().Show();
            Close();

        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            new SearchBill().Show();
            Close();
        }
    }
}
