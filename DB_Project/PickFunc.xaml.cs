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
using System.Windows.Shapes;

namespace DB_Project
{
    /// <summary>
    /// Interaction logic for PickFunc.xaml
    /// </summary>
    public partial class PickFunc : Window
    {
        public PickFunc()
        {
            InitializeComponent();
        }

        private void Bonus_For_Assistent(object sender, RoutedEventArgs e)
        {
            new Bonus_For_Assistent().Show();
        }
    }
}