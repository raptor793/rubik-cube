using System.Collections.ObjectModel;
using RubikCube.Enums;
using RubikCube.Models;

namespace RubikCube.Interfaces
{
    public interface IRubikCubeViewModel
    {
        public ObservableCollection<Cublet> TopFace { get; }
        public ObservableCollection<Cublet> FrontFace { get; }
        public ObservableCollection<Cublet> LeftFace { get; }
        public ObservableCollection<Cublet> RightFace { get; }
        public ObservableCollection<Cublet> BackFace { get; }
        public ObservableCollection<Cublet> BottomFace { get; }
        public void RotateUp(Direction direction);
        public void RotateDown(Direction direction);
        public void RotateLeft(Direction direction);
        public void RotateRight(Direction direction);
        public void RotateFront(Direction direction);
        public void RotateBack(Direction direction);
        public void Reset();
    }
}
