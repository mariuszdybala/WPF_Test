﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Janek.Tools;
using System.Windows.Input;
using Janek.Model;
using System.Windows;
using Janek.Animation;
//using System.Threading;
using System.Windows.Threading;
using System.Threading;

namespace Janek
{
    class MenuMaker:INotifyPropertyChanged, IEnabled
    {
      public ICommand buttonClickCommand { get; set; }
      public ICommand SelectionChangedCommand { get; set; }
      public ICommand CheckedCommand { get; set; }
      public ICommand buttonStartAnimationsCommand { get; set; }

        private Random random = new Random();
        private List<String> meats = new List<string>() { "Pieczona wołowina", "Salami", "Indyk", "Szynka", "Karkówka" };
        private List<String> condiments = new List<String>() { "żółta musztarda", 
            "brązowa musztarda", "musztarda miodowa", "majonez", "przyprawa", "sos francuski" };
        private List<String> breads = new List<String>() { "chleb ryżowy", 
            "chleb biały", "chleb zbożowy", "pumpernikiel", "chleb włoski", "bułka" };
        public ObservableCollection<MenuItem> Menu { get; private set;}
        public ObservableCollection<BoolStringClass> TheList { get; set;}


        public DateTime GeneratedDate { get;  set; }
        public int NumberOfItems { get; set; }

        private int bubbleHeight = 50;
        public int BubbleHeight { get { return bubbleHeight; } set { } }

        Visibility animationsEnabled = Visibility.Collapsed;
        public Visibility AnimationsEnabled 
         {
             set
             {
                 animationsEnabled = value;
                 OnPropertyCheanged("AnimationsEnabled");}
             get { return animationsEnabled; }
         }

        bool setEnableWindow = true;
        public bool SetEnableWindow
        {
            set
            {
                setEnableWindow = value;
                OnPropertyCheanged("SetEnableWindow");
            }
            get { return setEnableWindow; }
        }

        string readyText = "";
        public string ReadyText
        {
            set
            {
                readyText = value;
                OnPropertyCheanged("ReadyText");
            }
            get { return readyText; }
        }


        public string SelectedMeal { get; set; }

        //private string textToValidate;
        //public string TextToValidate 
        //{ 
        //        get 
        //        {
        //            return textToValidate;
        //        }
        //        set
        //        {
        //            textToValidate = value;
        //            OnPropertyCheanged("TextToValidate");
        //        }
        //    }


        public string TextToValidate { get; set; }



        public MenuMaker()
        {
            buttonClickCommand = new MyCommand(view_buttonClickCommand);
            SelectionChangedCommand = new MyCommand(view_SelectionChangedCommand);
            CheckedCommand = new MyCommand(view_CheckedCommand);
            buttonStartAnimationsCommand = new MyCommand(buttonStartAnimations);
            Menu = new ObservableCollection<MenuItem>();
            CreateCheckBoxList();
            NumberOfItems = 10;
            TextToValidate = "dupa";
            UpdateMenu();
        }

        private void buttonStartAnimations(object obj)
        {
            Start();
          
        }

        private void view_CheckedCommand(object obj)
        {
                
        }

        private void view_SelectionChangedCommand(object obj)
        {
           
        }

        private MenuItem CreateMenuItem()
        {
            string randomMeat = meats[random.Next(meats.Count)];
            string randomCondiment = condiments[random.Next(condiments.Count)];
            string randomBread = breads[random.Next(breads.Count)];
            return new MenuItem(randomMeat, randomCondiment, randomBread);
        }
        public void UpdateMenu()
        {
            Menu.Clear();
            for (int i = 0; i < NumberOfItems; i++)
            {
                Menu.Add(CreateMenuItem());
            }
            GeneratedDate = DateTime.Now;
            OnPropertyCheanged(GeneratedDate.ToString());
        }
        private void OnPropertyCheanged(string propertyName)
        {
            PropertyChangedEventHandler propertyChangedEvent = PropertyChanged;
            if (propertyChangedEvent != null)
            {
                propertyChangedEvent(this, new PropertyChangedEventArgs(propertyName));
            
            }      
        
        }
        public event PropertyChangedEventHandler PropertyChanged;


        private void view_buttonClickCommand(object obj)
        {
            UpdateMenu();
        }

        public void CreateCheckBoxList()
        {
            TheList = new ObservableCollection<BoolStringClass>();
            TheList.Add(new BoolStringClass { TheText = "EAST", TheValue = 1 });
            TheList.Add(new BoolStringClass { TheText = "WEST", TheValue = 2 });
            TheList.Add(new BoolStringClass { TheText = "NORTH", TheValue = 3 });
            TheList.Add(new BoolStringClass { TheText = "SOUTH", TheValue = 4 });
        }

        //LoadingWindow loading = new LoadingWindow();

        BackgroundWorker loading = new BackgroundWorker();

        SplashScreenWindow splash = new SplashScreenWindow();
       

        public void Start()
        {
            int p = ProgressManager.StartProgressManager();
            try 
            {
                MainThreadMethod();
            }
            catch
            { }
            finally
            {
                ProgressManager.StopExecuting(p);
            }
        }

      

        public void MainThreadMethod()
        { 
           

        for (int i = 0; i < 5; i++)
			{
			Thread.Sleep(1000);
			}
        ReadyText = "OK, Zrobione";
        
        }

    }
}
