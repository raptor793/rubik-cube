using System.Collections.ObjectModel;
using RubikCube.Common;
using RubikCube.Enums;
using RubikCube.Interfaces;
using RubikCube.Models;
using RubikCube.ViewModels;

namespace RubikCube.Tests
{
    public class CubeTests
    {
        private readonly IRubikCubeViewModel _viewModel;
        private ObservableCollection<Cublet> _topFace { get; } = new();
        private ObservableCollection<Cublet> _frontFace { get; } = new();
        private ObservableCollection<Cublet> _leftFace { get; } = new();
        private ObservableCollection<Cublet> _rightFace { get; } = new();
        private ObservableCollection<Cublet> _backFace { get; } = new();
        private ObservableCollection<Cublet> _bottomFace { get; } = new();

        public CubeTests()
        {
            _viewModel = new RubikCubeViewModel();

            InitiateCube();
        }

        [Fact]
        public void RubicCube_Initial_State_Success()
        {
            // Assert
            AssertCube();
        }

        [Fact]
        public void RubicCube_Rotate_Up_Clockwise_Success()
        {
            // Arrange
            SetFirsRowFor(_frontFace, CubletColors.Red);
            SetFirsRowFor(_rightFace, CubletColors.Blue);
            SetFirsRowFor(_backFace, CubletColors.Orange);
            SetFirsRowFor(_leftFace, CubletColors.Green);

            // Act
            _viewModel.RotateUp(Direction.Clockwise);

            // Assert
            AssertCube();
        }

        [Fact]
        public void RubicCube_Rotate_Up_Counter_Clockwise_Success()
        {
            // Arrange
            SetFirsRowFor(_frontFace, CubletColors.Orange);
            SetFirsRowFor(_rightFace, CubletColors.Green);
            SetFirsRowFor(_backFace, CubletColors.Red);
            SetFirsRowFor(_leftFace, CubletColors.Blue);

            // Act
            _viewModel.RotateUp(Direction.CounterClockwise);

            // Assert
            AssertCube();
        }

        [Fact]
        public void RubicCube_Rotate_Down_Clockwise_Success()
        {
            // Arrange
            SetLastRowFor(_frontFace, CubletColors.Orange);
            SetLastRowFor(_rightFace, CubletColors.Green);
            SetLastRowFor(_backFace, CubletColors.Red);
            SetLastRowFor(_leftFace, CubletColors.Blue);

            // Act
            _viewModel.RotateDown(Direction.Clockwise);

            // Assert
            AssertCube();
        }

        [Fact]
        public void RubicCube_Rotate_Down_Counter_Clockwise_Success()
        {
            // Arrange
            SetLastRowFor(_frontFace, CubletColors.Red);
            SetLastRowFor(_rightFace, CubletColors.Blue);
            SetLastRowFor(_backFace, CubletColors.Orange);
            SetLastRowFor(_leftFace, CubletColors.Green);

            // Act
            _viewModel.RotateDown(Direction.CounterClockwise);

            // Assert
            AssertCube();
        }

        [Fact]
        public void RubicCube_Rotate_Left_Clockwise_Success()
        {
            // Arrange
            SetFirstColumnFor(_topFace, CubletColors.Blue);
            SetFirstColumnFor(_frontFace, CubletColors.White);
            SetFirstColumnFor(_bottomFace, CubletColors.Green);
            SetLastColumnFor(_backFace, CubletColors.Yellow);

            // Act
            _viewModel.RotateLeft(Direction.Clockwise);

            // Assert
            AssertCube();
        }

        [Fact]
        public void RubicCube_Rotate_Left_Counter_Clockwise_Success()
        {
            // Arrange
            SetFirstColumnFor(_topFace, CubletColors.Green);
            SetFirstColumnFor(_frontFace, CubletColors.Yellow);
            SetFirstColumnFor(_bottomFace, CubletColors.Blue);
            SetLastColumnFor(_backFace, CubletColors.White);

            // Act
            _viewModel.RotateLeft(Direction.CounterClockwise);

            // Assert
            AssertCube();
        }

        [Fact]
        public void RubicCube_Rotate_Right_Clockwise_Success()
        {
            // Arrange
            SetLastColumnFor(_topFace, CubletColors.Green);
            SetLastColumnFor(_frontFace, CubletColors.Yellow);
            SetLastColumnFor(_bottomFace, CubletColors.Blue);
            SetFirstColumnFor(_backFace, CubletColors.White);

            // Act
            _viewModel.RotateRight(Direction.Clockwise);

            // Assert
            AssertCube();
        }

        [Fact]
        public void RubicCube_Rotate_Right_Counter_Clockwise_Success()
        {
            // Arrange
            SetLastColumnFor(_topFace, CubletColors.Blue);
            SetLastColumnFor(_frontFace, CubletColors.White);
            SetLastColumnFor(_bottomFace, CubletColors.Green);
            SetFirstColumnFor(_backFace, CubletColors.Yellow);

            // Act
            _viewModel.RotateRight(Direction.CounterClockwise);

            // Assert
            AssertCube();
        }

        [Fact]
        public void RubicCube_Rotate_Front_Clockwise_Success()
        {
            // Arrange
            SetLastRowFor(_topFace, CubletColors.Orange);
            SetFirstColumnFor(_rightFace, CubletColors.White);
            SetLastColumnFor(_leftFace, CubletColors.Yellow);
            SetFirsRowFor(_bottomFace, CubletColors.Red);

            // Act
            _viewModel.RotateFront(Direction.Clockwise);

            // Assert
            AssertCube();
        }

        [Fact]
        public void RubicCube_Rotate_Front_Counter_Clockwise_Success()
        {
            // Arrange
            SetLastRowFor(_topFace, CubletColors.Red);
            SetFirstColumnFor(_rightFace, CubletColors.Yellow);
            SetLastColumnFor(_leftFace, CubletColors.White);
            SetFirsRowFor(_bottomFace, CubletColors.Orange);

            // Act
            _viewModel.RotateFront(Direction.CounterClockwise);

            // Assert
            AssertCube();
        }

        [Fact]
        public void RubicCube_Rotate_Back_Clockwise_Success()
        {
            // Arrange
            SetFirsRowFor(_topFace, CubletColors.Red);
            SetLastColumnFor(_rightFace, CubletColors.Yellow);
            SetFirstColumnFor(_leftFace, CubletColors.White);
            SetLastRowFor(_bottomFace, CubletColors.Orange);

            // Act
            _viewModel.RotateBack(Direction.Clockwise);

            // Assert
            AssertCube();
        }

        [Fact]
        public void RubicCube_Rotate_Back_Counter_Clockwise_Success()
        {
            // Arrange
            SetFirsRowFor(_topFace, CubletColors.Orange);
            SetLastColumnFor(_rightFace, CubletColors.White);
            SetFirstColumnFor(_leftFace, CubletColors.Yellow);
            SetLastRowFor(_bottomFace, CubletColors.Red);

            // Act
            _viewModel.RotateBack(Direction.CounterClockwise);

            // Assert
            AssertCube();
        }

        private void AssertCube()
        {
            AssertCubeSides(_topFace, _viewModel.TopFace);
            AssertCubeSides(_frontFace, _viewModel.FrontFace);
            AssertCubeSides(_rightFace, _viewModel.RightFace);
            AssertCubeSides(_backFace, _viewModel.BackFace);
            AssertCubeSides(_leftFace, _viewModel.LeftFace);
            AssertCubeSides(_bottomFace, _viewModel.BottomFace);
        }

        private void AssertCubeSides(ObservableCollection<Cublet> expected, ObservableCollection<Cublet> actual)
        {
            for (int i = 0; i < expected.Count; i++)
            {
                Assert.Equal(expected[i].CubletColor, actual[i].CubletColor);
                Assert.Equal(expected[i].CubletRow, actual[i].CubletRow);
                Assert.Equal(expected[i].CubletColumn, actual[i].CubletColumn);
            }
        }

        private void InitiateCube()
        {
            InitializeSide(_frontFace, CubletColors.Green);
            InitializeSide(_topFace, CubletColors.White);
            InitializeSide(_leftFace, CubletColors.Orange);
            InitializeSide(_rightFace, CubletColors.Red);
            InitializeSide(_bottomFace, CubletColors.Yellow);
            InitializeSide(_backFace, CubletColors.Blue);
        }

        private void InitializeSide(ObservableCollection<Cublet> side, string color)
        {
            for (int row = 0; row < 3; row++)
            {
                for (int column = 0; column < 3; column++)
                {
                    side.Add(new Cublet()
                    {
                        CubletColor = color,
                        CubletRow = row,
                        CubletColumn = column
                    });
                }
            }
        }

        private void SetFirsRowFor(ObservableCollection<Cublet> side, string color)
        {
            side[0].CubletColor = color;
            side[1].CubletColor = color;
            side[2].CubletColor = color;
        }

        private void SetLastRowFor(ObservableCollection<Cublet> side, string color)
        {
            side[8].CubletColor = color;
            side[7].CubletColor = color;
            side[6].CubletColor = color;
        }

        private void SetFirstColumnFor(ObservableCollection<Cublet> side, string color)
        {
            side[0].CubletColor = color;
            side[3].CubletColor = color;
            side[6].CubletColor = color;
        }

        private void SetLastColumnFor(ObservableCollection<Cublet> side, string color)
        {
            side[8].CubletColor = color;
            side[5].CubletColor = color;
            side[2].CubletColor = color;
        }
    }
}