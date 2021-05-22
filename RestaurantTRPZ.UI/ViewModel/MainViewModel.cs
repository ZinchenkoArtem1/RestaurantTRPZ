using RestaurantTRPZ.BLL.Abstr.Services;
using RestaurantTRPZ.Models;
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
        private DishModel selectDish;
        private DishModel selectedDishInOrder;
        public ObservableCollection<DishModel> Dishes { get; set; }
        public ObservableCollection<DishModel> DishesInOrder { get; set; }
        public RelayCommand DoOrderCommand { get; private set; }
        public RelayCommand AddToOrderCommand { get; private set; }
        public RelayCommand DelFromOrderCommand { get; private set; }
        public RelayCommand CleanOrderCommand { get; private set; }

        public DishModel SelectDish
        {
            get { return selectDish; }
            set
            {
                selectDish = value;
                OnPropertyChanged("SelectDish");
            }
        }

        public DishModel SelectedDishInOrder
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
            Dishes = new ObservableCollection<DishModel>(this.dishService.GetAllDishes());
            DishesInOrder = new ObservableCollection<DishModel>();

            DoOrderCommand = new RelayCommand(obj => DoOrder());
            AddToOrderCommand = new RelayCommand(obj => AddToOrder());
            DelFromOrderCommand = new RelayCommand(obj => DelFromOrder());
            CleanOrderCommand = new RelayCommand(obj => CleanOrder());
        }

        private void DoOrder()
        {
            OrderModel orderModel = orderService.DoOrder(DishesInOrder);
            DishesInOrder.Clear();
            selectedDishInOrder = null;
            
            MessageBox.Show(GenerateMessage(orderModel));
        }

        private string GenerateMessage(OrderModel orderModel)
        {
            String message = "Start order : " + orderModel.BeginOfOrder + "\n";
            message += "Name : Price : Preparing time \n";
            foreach(DishOrderModel dishOrderModel in orderModel.DishOrderModels)
            {
                message += dishOrderModel.DishModel.Name + " : " 
                    + dishOrderModel.DishModel.Price + " : " 
                    + dishOrderModel.PreparingTime + "\n";
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
