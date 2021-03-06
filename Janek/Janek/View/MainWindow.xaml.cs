﻿using Janek.Animation;
using System;
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

namespace Janek
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IDisposable
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MenuMaker();
        }

        private void StartLoadingBar_Click(object sender, RoutedEventArgs e)
        {
            LoadingWindow window = new LoadingWindow();
            window.ShowDialog();
        }




        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    MenuMaker menuMaker = new MenuMaker();
        //    menuMaker.UpdateMenu();
        //}

        public void Dispose()
        {
            this.Dispose();
        }
    }
}
