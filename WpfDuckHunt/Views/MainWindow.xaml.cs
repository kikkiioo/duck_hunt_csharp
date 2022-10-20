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
using WpfDuckHunt.Controllers;

namespace WpfDuckHunt.Views
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

        private void uiButtonNewGame_Click(object sender, RoutedEventArgs e)
        {
            GameController.newGame();
            
        }

        private void uiButtonPauseGame_Click(object sender, RoutedEventArgs e)
        {
<<<<<<< HEAD
            if (GameController.getGame().paused == false)
            {
                GameController.getGame().paused = true;
            }
            else
            {
                GameController.getGame().paused = false;
=======
            if (GameController.game.paused == false)
            {
                GameController.game.paused = true;
            }
            else
            {
                GameController.game.paused = false;
>>>>>>> 4934e7196b7086046a0e676e5f080319d00ff878
            }
        }

        private void uiButtonSaveGame_Click(object sender, RoutedEventArgs e)
        {
<<<<<<< HEAD
            GameController.saveGame();
        }
        private void uiButtonLoadGame_Click(object sender, RoutedEventArgs e)
        {

        }

=======

        }
   
>>>>>>> 4934e7196b7086046a0e676e5f080319d00ff878
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Point point;
            point = e.GetPosition(this);
            GameController.checkCollision(point.X,point.Y);
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Point point;
            point = e.GetPosition(this);
            GameController.checkCollision(point.X,point.Y);

        }
    }
}
