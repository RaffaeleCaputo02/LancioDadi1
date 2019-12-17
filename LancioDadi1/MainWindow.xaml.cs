﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace LancioDadi1
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Random rnd = new Random();

        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void Brn_Lancia_Click(object sender, RoutedEventArgs e)
        {
            var dado1 = Task.Factory.StartNew(Lancio);

            var dado2 = Task.Factory.StartNew(Lancio);

            var somma=Dispatcher.Invoke(() => Somma(dado1.Result, dado2.Result));
            

            Lbl_Risultato.Content = $"La somma dei dadi è {somma}";
        }

        public int Lancio()
        {
            return rnd.Next(1, 7);
           
        }

        

        private static int Somma(int dado1, int dado2)
        {
            
            return dado1+dado2;
        }
    }
}
