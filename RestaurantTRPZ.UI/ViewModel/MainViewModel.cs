using RestaurantTRPZ.BLL.Abstr.Services;
using RestaurantTRPZ.DTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;

namespace RestaurantTRPZ.UI.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly IDishService dishService;
        private readonly IOrderService orderService;
        private DishDTO selectDish;
        private DishDTO selectedDishInOrder;
        public ObservableCollection<DishDTO> Dishes { get; set; }
        public ObservableCollection<DishDTO> DishesInOrder { get; set; }
        public RelayCommand DoOrderCommand { get; private set; }
        public RelayCommand AddToOrderCommand { get; private set; }
        public RelayCommand DelFromOrderCommand { get; private set; }
        public RelayCommand CleanOrderCommand { get; private set; }

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

        public MainViewModel(IDishService dishService, IOrderService orderService)
        {
            this.dishService = dishService;
            this.orderService = orderService;
            Dishes = new ObservableCollection<DishDTO>(this.dishService.GetAllDishes());
            DishesInOrder = new ObservableCollection<DishDTO>();

            DoOrderCommand = new RelayCommand(obj => DoOrder());
            AddToOrderCommand = new RelayCommand(obj => AddToOrder());
            DelFromOrderCommand = new RelayCommand(obj => DelFromOrder());
            CleanOrderCommand = new RelayCommand(obj => CleanOrder());
        }

        private void DoOrder()
        {
            OrderDTO orderDTO = orderService.DoOrder(DishesInOrder);
            DishesInOrder.Clear();
            selectedDishInOrder = null;
            
            MessageBox.Show(GenerateMessage(orderDTO));
        }

        private string GenerateMessage(OrderDTO orderDTO)
        {
            String message = "Start order : " + orderDTO.BeginOfOrder + "\n";
            message += "Name : Price : Preparing time \n";
            foreach(DishOrderDTO dishOrderDTO in orderDTO.DishOrderDTOs)
            {
                message += dishOrderDTO.DishDTO.Name + " : " + dishOrderDTO.DishDTO.Price + " : " + dishOrderDTO.PreparingTime + "\n";
            }
            return message;
        }

        private void AddToOrder()
        {
            DishesInOrder.Add(SelectDish);
        }

        private void DelFromOrder()
        {
            DishesInOrder.Remove(SelectedDishInOrder);
        }

        private void CleanOrder()
        {
            DishesInOrder.Clear();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
