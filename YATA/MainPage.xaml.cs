﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;
using YATA.Model;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace YATA
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public ObservableCollection<Note> localListOfTasks;
        private string title = "Notes";
        public MainPage()
        {
            this.InitializeComponent();
            localListOfTasks = Note.listOfTasks;
        }

        private void AddTaskButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.ContentTransitions = new TransitionCollection();
            var navThemeTransition = new NavigationThemeTransition();
            navThemeTransition.DefaultNavigationTransitionInfo = new EntranceNavigationTransitionInfo();
            Frame.ContentTransitions.Add(navThemeTransition);
            Frame.Navigate(typeof(CreateTaskPage));
        }

        private void tasksListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var clickedTask = (Note)e.ClickedItem;
            clickedTask.changeIsCompletedState();
            
        }
    }
}
