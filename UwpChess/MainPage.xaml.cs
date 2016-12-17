using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UwpChess
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public static MainPage Instance { get; private set; }
        private TileViewModel _selectedSquare;

        public BoardViewModel ViewModel { get; private set; }

        public MainPage()
        {
            Instance = this;
            this.InitializeComponent();
            ViewModel = new BoardViewModel();
        }

        private void ItemsControl_Tapped(object sender, TappedRoutedEventArgs e)
        {
            ItemsControl itemControl = sender as ItemsControl;
            ContentPresenter container = e.OriginalSource as ContentPresenter;
            TileViewModel viewModel = itemControl.ItemFromContainer(container) as TileViewModel;

            if (_selectedSquare == null && viewModel.Piece != null)
            {
                viewModel.IsSelected = true;
                _selectedSquare = viewModel;
            }
            else if (viewModel == _selectedSquare)
            {
                viewModel.IsSelected = false;
                _selectedSquare = null;
            }
            else if (_selectedSquare != null && _selectedSquare.Piece != null)
            {
                // move piece and hope stuff works
                viewModel.Piece = _selectedSquare.Piece;
                _selectedSquare.IsSelected = false;
                _selectedSquare.Piece = null;
                _selectedSquare = null;
            }
        }
    }

    public class BoardViewModel
    {
        public IReadOnlyCollection<TileViewModel> Tiles { get; private set; }

        public Position Position { get; private set; } = new Position();

        public BoardViewModel()
        {
            List<TileViewModel> tiles = new List<TileViewModel>(64);
            for (int i = 0; i < 64; i++)
            {
                tiles.Add(new TileViewModel(this, i));
            }
            Tiles = tiles.AsReadOnly();
        }
    }

    public enum TileColor
    {
        Light,
        Dark
    }

    public class TileCoordinate
    {
        public int Id { get; private set; }
        public int Row { get; private set; }
        public int Col { get; private set; }
        public TileColor Color { get; private set;}
        public string Notation { get; private set; }

        private static string[] Ranks = { "8", "7", "6", "5", "4", "3", "2", "1" };
        private static string[] Files = { "A", "B", "C", "D", "E", "F", "G", "H" };

        public TileCoordinate(int id)
        {
            Id = id;
            Row = Id / 8;
            Col = Id % 8;
            Color = (Row + Col) % 2 == 0 ? TileColor.Light : TileColor.Dark;
            Notation = Files[Col] + Ranks[Row];
        }
    }

    public class TileViewModel : BindableBase
    {
        public BoardViewModel Board { get; private set; }
        public TileCoordinate Coordinate { get; private set; }
        public int Id { get { return Coordinate.Id; } }

        private bool _isSelected;
        public bool IsSelected
        {
            get { return _isSelected; }
            set { SetPropertyValue(ref _isSelected, value); }
        }

        private ChessPiece _piece;

        public ChessPiece Piece
        {
            get { return _piece; }
            set { SetPropertyValue(ref _piece, value); }
        }

        public TileViewModel(BoardViewModel board, int id)
        {
            Board = board;
            Coordinate = new TileCoordinate(id);
            Piece = board.Position.Pieces[id];
        }
    }

    public class TileStyleSelector : StyleSelector
    {
        public Style Light { get; set; }
        public Style Dark { get; set; }
        protected override Style SelectStyleCore(object item, DependencyObject container)
        {
            TileViewModel tile = item as TileViewModel;

            if (tile.Coordinate.Color == TileColor.Dark) return Dark;
            if (tile.Coordinate.Color == TileColor.Light) return Light;

            return base.SelectStyleCore(item, container);
        }
    }

    public class VisiblilityValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            bool visible = (bool)value;
            if (visible)
                return Visibility.Visible;
            else
                return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }

    public enum PieceType
    {
        Pawn,
        Knight,
        Bishop,
        Rook,
        Queen,
        King
    }

    public enum PieceColor
    {
        White,
        Black
    }

    public class ChessPiece : BindableBase
    {
        private PieceType _type;
        private PieceColor _color;

        public PieceType Type
        {
            get { return _type; }
            set { SetPropertyValue(ref _type, value); }
        }

        public PieceColor Color
        {
            get { return _color; }
            set { SetPropertyValue(ref _color, value); }
        }
    }

    public class BindableBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual bool SetPropertyValue<T>(ref T originalValue, T newValue, [CallerMemberName] string propertyName = null)
        {
            if (!EqualityComparer<T>.Default.Equals(originalValue, newValue))
            {
                originalValue = newValue;
                OnPropertyChanged(propertyName);
                return true;
            }
            return false;
        }

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
