using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace WPF_CRUD
{
    public class AddSubViewModel
    {
        public AddSubViewModel()
        {
            firstNumberCommand = new RelayCommand(FirstNumber);
            secondNumberCommand = new RelayCommand(SecondNumber);
            operatorCommand = new RelayCommand(Operator);
        }
        public ObservableCollection<ImageData> operatorImages { get; set; } = new ObservableCollection<ImageData>
        {
            new ImageData { Name = "Addition", ImagePath = "Images/Operators/addition.png", Category="Operator",  },
            new ImageData { Name = "Subtraction", ImagePath = "Images/Operators/subtraction.png", Category="Operator" },
            new ImageData { Name = "Multiplication", ImagePath = "Images/Operators/multiplication.png", Category="Operator" },
            new ImageData { Name = "Division", ImagePath = "Images/Operators/division.png", Category="Operator" }
        };

        private RelayCommand firstNumberCommand;

		public RelayCommand FirstNumberCommand
        {
			get { return firstNumberCommand; }
		}
		private void FirstNumber()
		{
            PopUpSelectData data = new PopUpSelectData
            {
                Title = "First Number",
                Message = "Please enter the first number",
                OperationType = "Enter",
                Background = Brushes.LightGreen
            };
            PopUpSelect pop = new PopUpSelect(data);
            pop.Show(data);
        }

        private RelayCommand secondNumberCommand;

        public RelayCommand SecondNumberCommand
        {
            get { return secondNumberCommand; }
        }
        private void SecondNumber()
        {           
            PopUpSelectData data = new PopUpSelectData
            {
                Title = "Second Number",
                Message = "Please enter the second number",
                OperationType = "Enter",
                Background = Brushes.LightGreen
            };
            PopUpSelect pop = new PopUpSelect(data);
            pop.Show(data);
        }

        private RelayCommand operatorCommand;
        
        public RelayCommand OperatorCommand
        {
            get { return operatorCommand; }
        }
        private void Operator()
        {            
            PopUpSelectData data = new PopUpSelectData
            {
                Title = "Operator",
                Message = "Please select the operation",
                OperationType = "Select",
                Options = operatorImages,
                Background = Brushes.LightGreen
            };
            PopUpSelect pop = new PopUpSelect(data);
            pop.Show(data);
        }

    }
    public class PopUpSelectData
    {
        public string Title { get; set; }
        public string Message { get; set; }
        public string OperationType { get; set; }
        public ObservableCollection<ImageData> Options { get; set; }
        public SolidColorBrush Background { get; set; }
        public bool ShowOkButton { get; set; } = true;
    }
}
