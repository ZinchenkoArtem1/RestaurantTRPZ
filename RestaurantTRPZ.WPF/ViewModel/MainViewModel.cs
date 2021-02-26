using RestaurantTRPZ.BLL.DTO_s;
using RestaurantTRPZ.BLL.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace RestaurantTRPZ.WPF.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly IDishService _dishService;

        private ObservableCollection<DishDTO> dishes;
        public ObservableCollection<DishDTO> Dishes
        {
            get => dishes;
            set
            {
                dishes = value;
                OnPropertyChanged("Dishes");
            }
        }

        private DishDTO selectedDish;
        public DishDTO SelectedDish
        {
            get { return selectedDish; }
            set
            {
                selectedDish = value;
                OnPropertyChanged(nameof(SelectedDish));
            }
        }

        public MainViewModel(IDishService dishService)
        {
            _dishService = dishService;
            IEnumerable<DishDTO> dishes = _dishService.GetAllDishes();
            foreach(DishDTO dish in dishes)
            {
                Console.WriteLine(dish.Name);
            }
            
            Dishes = new ObservableCollection<DishDTO>(dishes);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
