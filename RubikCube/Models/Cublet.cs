using System.ComponentModel;

namespace RubikCube.Models
{
    public class Cublet : INotifyPropertyChanged
    {
        private string? _cubletColor;
        private int? _cubletRow;
        private int? _cubletColumn;

        public event PropertyChangedEventHandler? PropertyChanged;

        public string? CubletColor
        {
            get => _cubletColor;
            set
            {
                _cubletColor = value;
                OnPropertyChanged(nameof(CubletColor));
            }
        }

        public int? CubletRow
        {
            get => _cubletRow;
            set
            {
                _cubletRow = value;
                OnPropertyChanged(nameof(CubletRow));
            }
        }

        public int? CubletColumn
        {
            get => _cubletColumn;
            set
            {
                _cubletColumn = value;
                OnPropertyChanged(nameof(CubletColumn));
            }
        }

        protected void OnPropertyChanged(string propertyName)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
