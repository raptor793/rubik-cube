using System.Collections.ObjectModel;
using RubikCube.Common;
using RubikCube.Enums;
using RubikCube.Interfaces;
using RubikCube.Models;

namespace RubikCube.ViewModels
{
    public class RubikCubeViewModel : IRubikCubeViewModel
    {
        #region Cube Sides
        private string[,] _topSide = new string[3, 3];
        private string[,] _frontSide = new string[3, 3];
        private string[,] _bottomSide = new string[3, 3];
        private string[,] _leftSide = new string[3, 3];
        private string[,] _rightSide = new string[3, 3];
        private string[,] _backSide = new string[3, 3];
        private Dictionary<Face, string[,]> _cube = new();
        #endregion

        public ObservableCollection<Cublet> TopFace { get; } = new();
        public ObservableCollection<Cublet> FrontFace { get; } = new();
        public ObservableCollection<Cublet> LeftFace { get; } = new();
        public ObservableCollection<Cublet> RightFace { get; } = new();
        public ObservableCollection<Cublet> BackFace { get; } = new();
        public ObservableCollection<Cublet> BottomFace { get; } = new();

        public RubikCubeViewModel()
        {
            Initialize();
            InitializeCube();
            InitiateSides();
        }

        #region Cube Controls
        //Method for rotating the top side of the cube
        public void RotateUp(Direction direction)
        {
            RotateCubeFace(Face.Top, direction);

            var front = _cube[Face.Front];
            var right = _cube[Face.Right];
            var left = _cube[Face.Left];
            var back = _cube[Face.Back];

            var temp = GetRow(front, 0);

            if (direction == Direction.Clockwise)
            {
                SetRow(front, 0, GetRow(right, 0));
                SetRow(right, 0, GetRow(back, 0));
                SetRow(back, 0, GetRow(left, 0));
                SetRow(left, 0, temp);
            }
            else
            {
                SetRow(front, 0, GetRow(left, 0));
                SetRow(left, 0, GetRow(back, 0));
                SetRow(back, 0, GetRow(right, 0));
                SetRow(right, 0, temp);
            }

            InitializeSide(FrontFace, front);
            InitializeSide(RightFace, right);
            InitializeSide(LeftFace, left);
            InitializeSide(BackFace, back);
        }
        //Method for rotating the down side of the cube
        public void RotateDown(Direction direction)
        {
            RotateCubeFace(Face.Bottom, direction);

            var front = _cube[Face.Front];
            var right = _cube[Face.Right];
            var left = _cube[Face.Left];
            var back = _cube[Face.Back];

            var temp = GetRow(front, 2);

            if (direction == Direction.Clockwise)
            {
                SetRow(front, 2, GetRow(left, 2));
                SetRow(left, 2, GetRow(back, 2));
                SetRow(back, 2, GetRow(right, 2));
                SetRow(right, 2, temp);
            }
            else
            {
                SetRow(front, 2, GetRow(right, 2));
                SetRow(right, 2, GetRow(back, 2));
                SetRow(back, 2, GetRow(left, 2));
                SetRow(left, 2, temp);
            }

            InitializeSide(FrontFace, front);
            InitializeSide(RightFace, right);
            InitializeSide(LeftFace, left);
            InitializeSide(BackFace, back);
        }
        //Method for rotating the left side of the cube
        public void RotateLeft(Direction direction)
        {
            RotateCubeFace(Face.Left, direction);

            var front = _cube[Face.Front];
            var top = _cube[Face.Top];
            var back = _cube[Face.Back];
            var bottom = _cube[Face.Bottom];

            var temp = GetColumn(front, 0);

            if (direction == Direction.Clockwise)
            {
                SetColumn(front, 0, GetColumn(top, 0));
                SetColumn(top, 0, GetColumn(back, 2, true));
                SetColumn(back, 2, GetColumn(bottom, 0, true));
                SetColumn(bottom, 0, temp);
            }
            else
            {
                SetColumn(front, 0, GetColumn(bottom, 0));
                SetColumn(bottom, 0, GetColumn(back, 2, true));
                SetColumn(back, 2, GetColumn(top, 0, true));
                SetColumn(top, 0, temp);
            }


            InitializeSide(FrontFace, front);
            InitializeSide(TopFace, top);
            InitializeSide(BackFace, back);
            InitializeSide(BottomFace, bottom);
        }
        //Method for rotating the back right of the cube
        public void RotateRight(Direction direction)
        {
            RotateCubeFace(Face.Right, direction);

            var front = _cube[Face.Front];
            var top = _cube[Face.Top];
            var back = _cube[Face.Back];
            var bottom = _cube[Face.Bottom];

            var temp = GetColumn(front, 2);

            if (direction == Direction.Clockwise)
            {
                SetColumn(front, 2, GetColumn(bottom, 2));
                SetColumn(bottom, 2, GetColumn(back, 0, true));
                SetColumn(back, 0, GetColumn(top, 2, true));
                SetColumn(top, 2, temp);
            }
            else
            {
                SetColumn(front, 2, GetColumn(top, 2));
                SetColumn(top, 2, GetColumn(back, 0, true));
                SetColumn(back, 0, GetColumn(bottom, 2, true));
                SetColumn(bottom, 2, temp);
            }

            InitializeSide(FrontFace, front);
            InitializeSide(TopFace, top);
            InitializeSide(BackFace, back);
            InitializeSide(BottomFace, bottom);
        }
        //Method for rotating the front side of the cube
        public void RotateFront(Direction direction)
        {
            RotateCubeFace(Face.Front, direction);

            var top = _cube[Face.Top];
            var right = _cube[Face.Right];
            var left = _cube[Face.Left];
            var bottom = _cube[Face.Bottom];

            var temp = GetRow(top, 2);

            if (direction == Direction.Clockwise)
            {
                SetRow(top, 2, GetColumn(left, 2, true));
                SetColumn(left, 2, GetRow(bottom, 0));
                SetRow(bottom, 0, GetColumn(right, 0, true));
                SetColumn(right, 0, temp);
            }
            else
            {
                SetRow(top, 2, GetColumn(right, 0));
                SetColumn(right, 0, GetRow(bottom, 0, true));
                SetRow(bottom, 0, GetColumn(left, 2));
                SetColumn(left, 2, temp);
            }

            InitializeSide(TopFace, top);
            InitializeSide(RightFace, right);
            InitializeSide(LeftFace, left);
            InitializeSide(BottomFace, bottom);
        }
        //Method for rotating the back side of the cube
        public void RotateBack(Direction direction)
        {
            RotateCubeFace(Face.Back, direction);

            var top = _cube[Face.Top];
            var right = _cube[Face.Right];
            var left = _cube[Face.Left];
            var bottom = _cube[Face.Bottom];

            var temp = GetRow(top, 0);

            if (direction == Direction.Clockwise)
            {
                SetRow(top, 0, GetColumn(right, 2));
                SetColumn(right, 2, GetRow(bottom, 2, true));
                SetRow(bottom, 2, GetColumn(left, 0));
                SetColumn(left, 0, temp.Reverse().ToArray());
            }
            else
            {
                SetRow(top, 0, GetColumn(left, 0, true));
                SetColumn(left, 0, GetRow(bottom, 2));
                SetRow(bottom, 2, GetColumn(right, 2, true));
                SetColumn(right, 2, temp);
            }

            InitializeSide(TopFace, top);
            InitializeSide(RightFace, right);
            InitializeSide(LeftFace, left);
            InitializeSide(BottomFace, bottom);
        }
        //Method for reseting the cube
        public void Reset()
        {
            Initialize();
            InitializeCube();
            InitiateSides();
        }
        #endregion

        #region Initialization
        //Initializes the (3x3) arrays or all faces from the cube 
        private void Initialize()
        {
            _topSide = new string[3, 3]
            {
                { "W", "W", "W" },
                { "W", "W", "W" },
                { "W", "W", "W" }
            };

            _frontSide = new string[3, 3]
            {
                { "G", "G", "G" },
                { "G", "G", "G" },
                { "G", "G", "G" }
            };

            _bottomSide = new string[3, 3]
            {
                { "Y", "Y", "Y" },
                { "Y", "Y", "Y" },
                { "Y", "Y", "Y" }
            };

            _leftSide = new string[3, 3]
            {
                { "O", "O", "O" },
                { "O", "O", "O" },
                { "O", "O", "O" }
            };

            _rightSide = new string[3, 3]
            {
                { "R", "R", "R" },
                { "R", "R", "R" },
                { "R", "R", "R" }
            };

            _backSide = new string[3, 3]
            {
                { "B", "B", "B" },
                { "B", "B", "B" },
                { "B", "B", "B" }
            };
        }

        //Clears and fills the dictionary with all faces from the cube (3x3) arrays 
        private void InitializeCube()
        {
            _cube.Clear();
            _cube.Add(Face.Front, _frontSide);
            _cube.Add(Face.Left, _leftSide);
            _cube.Add(Face.Right, _rightSide);
            _cube.Add(Face.Bottom, _bottomSide);
            _cube.Add(Face.Back, _backSide);
            _cube.Add(Face.Top, _topSide);
        }

        private void InitiateSides()
        {
            InitializeSide(TopFace, _cube[Face.Top]);
            InitializeSide(LeftFace, _cube[Face.Left]);
            InitializeSide(FrontFace, _cube[Face.Front]);
            InitializeSide(BackFace, _cube[Face.Back]);
            InitializeSide(RightFace, _cube[Face.Right]);
            InitializeSide(BottomFace, _cube[Face.Bottom]);
        }

        private void InitializeSide(ObservableCollection<Cublet> side, string[,] face)
        {
            side.Clear();

            for (int row = 0; row < 3; row++)
            {
                for (int column = 0; column < 3; column++)
                {
                    side.Add(new Cublet()
                    {
                        CubletColor = GetColor(face[row, column]),
                        CubletRow = row,
                        CubletColumn = column
                    });
                }
            }
        }
        #endregion

        #region Helpers
        //Rotate specific cube face alongside with it's UI face
        private void RotateCubeFace(Face face, Direction direction)
        {
            string[,] original = _cube[face];
            string[,] rotated = new string[3, 3];

            for (int row = 0; row < 3; row++)
            {
                for (int column = 0; column < 3; column++)
                {
                    if (direction == Direction.Clockwise)
                    {
                        rotated[column, 2 - row] = original[row, column];
                    }
                    else
                    {
                        rotated[2 - column, row] = original[row, column];
                    }
                }
            }

            _cube[face] = rotated;

            RotateFace(face, rotated);
        }

        //Rotate specific UI face
        private void RotateFace(Face face, string[,] rotated)
        {
            switch (face)
            {
                case Face.Front:
                    InitializeSide(FrontFace, rotated);
                    break;
                case Face.Left:
                    InitializeSide(LeftFace, rotated);
                    break;
                case Face.Right:
                    InitializeSide(RightFace, rotated);
                    break;
                case Face.Bottom:
                    InitializeSide(BottomFace, rotated);
                    break;
                case Face.Top:
                    InitializeSide(TopFace, rotated);
                    break;
                case Face.Back:
                    InitializeSide(BackFace, rotated);
                    break;
                default:
                    break;
            }
        }

        //GetRow, SetRow, GetColumn, SetColumn - these methods are helpers for performing rotations for each button click
        private string[] GetRow(string[,] face, int row, bool reverse = false)
        {
            var result = new string[3];

            for (int i = 0; i < 3; i++)
            {
                result[i] = face[row, reverse ? 2 - i : i];
            }

            return result;
        }

        private void SetRow(string[,] face, int row, string[] values, bool reverse = false)
        {
            for (int i = 0; i < 3; i++)
            {
                face[row, reverse ? 2 - i : i] = values[i];
            }
        }

        private string[] GetColumn(string[,] face, int col, bool reverse = false)
        {
            var result = new string[3];

            for (int i = 0; i < 3; i++)
            {
                result[i] = face[reverse ? 2 - i : i, col];
            }

            return result;
        }

        private void SetColumn(string[,] face, int col, string[] values, bool reverse = false)
        {
            for (int i = 0; i < 3; i++)
            {
                face[reverse ? 2 - i : i, col] = values[i];
            }
        }

        //Get specific color by a symbol from the array sides
        private string GetColor(string symbol)
        {
            string color = string.Empty;

            switch (symbol)
            {
                case "G":
                    color = CubletColors.Green;
                    break;
                case "W":
                    color = CubletColors.White;
                    break;
                case "O":
                    color = CubletColors.Orange;
                    break;
                case "Y":
                    color = CubletColors.Yellow;
                    break;
                case "R":
                    color = CubletColors.Red;
                    break;
                case "B":
                    color = CubletColors.Blue;
                    break;
                default:
                    break;
            }

            return color;
        }
    }
    #endregion
}
