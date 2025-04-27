using System.Windows;
using System.Windows.Controls;
using RubikCube.Enums;
using RubikCube.Interfaces;
using RubikCube.ViewModels;

namespace RubikCube
{
    public partial class MainWindow : Window
    {
        private IRubikCubeViewModel _viewModel = new RubikCubeViewModel();

        public MainWindow()
        {
            InitializeComponent();

            DataContext = _viewModel;
        }

        private void Direction_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            Direction direction = (string)button.Tag == "Clockwise" ? Direction.Clockwise : Direction.CounterClockwise;

            switch (button.Content)
            {
                case "Front":
                    _viewModel.RotateFront(direction);
                    break;
                case "Right":
                    _viewModel.RotateRight(direction);
                    break;
                case "Up":
                    _viewModel.RotateUp(direction);
                    break;
                case "Bottom":
                    _viewModel.RotateBack(direction);
                    break;
                case "Left":
                    _viewModel.RotateLeft(direction);
                    break;
                case "Down":
                    _viewModel.RotateDown(direction);
                    break;
                default:
                    throw new ArgumentException("Invalid Button Click!!!");
            }
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.Reset();
        }
    }
}