using RestaurantTRPZ.BLL.Abstr.Services;
using RestaurantTRPZ.DTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace RestaurantTRPZ.UI.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly IDishService dishService;
        private readonly IOrderService orderService;
        public ObservableCollection<DishDTO> Dishes { get; set; }
        public ObservableCollection<DishDTO> DishesInOrder { get; set; }
        private DishDTO selectDish;
        private DishDTO selectedDishInOrder;

        public DishDTO SelectDish
        {
            get { return selectDish; }
            set
            {
                selectDish = value;
                OnPropertyChanged("SelectDish");
            }
        }

        public DishDTO SelectedDishInOrder
        {
            get { return selectedDishInOrder; }
            set
            {
                selectedDishInOrder = value;
                OnPropertyChanged("SelectedDishInOrder");
            }
        }

        public RelayCommand DoOrderCommand { get; private set; }

        private void DoOrder()
        {
            OrderDTO orderDTO = orderService.DoOrder(DishesInOrder);
            DishesInOrder.Clear();
            selectedDishInOrder = null;
        }

        public RelayCommand AddToOrderCommand { get; private set; }

        private void AddToOrder()
        {
            DishesInOrder.Add(SelectDish);
        }

        public RelayCommand DelFromOrderCommand { get; private set; }

        private void DelFromOrder()
        {
            DishesInOrder.Remove(SelectedDishInOrder);
        }

        public RelayCommand CleanOrderCommand { get; private set; }

        private void CleanOrder()
        {
            DishesInOrder.Clear();
        }

        public MainViewModel(IDishService dishService, IOrderService orderService)
        {
            this.dishService = dishService;
            this.orderService = orderService;
            Dishes = new ObservableCollection<DishDTO>(this.dishService.GetAllDishes());
            DishesInOrder = new ObservableCollection<DishDTO>();

            DoOrderCommand = new RelayCommand(_ => DoOrder());
            AddToOrderCommand = new RelayCommand(_ => AddToOrder());
            DelFromOrderCommand = new RelayCommand(_ => DelFromOrder());
            CleanOrderCommand = new RelayCommand(_ => CleanOrder());
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
