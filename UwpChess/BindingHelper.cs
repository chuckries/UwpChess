using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;

namespace UwpChess
{
    public class BindingHelper
    {
        public static readonly DependencyProperty GridColumnBindingPathProperty =
            DependencyProperty.RegisterAttached(
                "GridColumnBindingPath", typeof(string), typeof(BindingHelper),
                new PropertyMetadata(null, GridBindingPathPropertyChanged));

        public static readonly DependencyProperty GridRowBindingPathProperty =
            DependencyProperty.RegisterAttached(
                "GridRowBindingPath", typeof(string), typeof(BindingHelper),
                new PropertyMetadata(null, GridBindingPathPropertyChanged));

        public static readonly DependencyProperty CanvasZIndexBindingPathProperty =
            DependencyProperty.RegisterAttached(
                "CanvasZIndexBindingPath", typeof(string), typeof(BindingHelper),
                new PropertyMetadata(null, CanvasBindingPathPropertyChanged));


        public static string GetGridColumnBindingPath(DependencyObject obj)
        {
            return (string)obj.GetValue(GridColumnBindingPathProperty);
        }

        public static void SetGridColumnBindingPath(DependencyObject obj, string value)
        {
            obj.SetValue(GridColumnBindingPathProperty, value);
        }

        public static string GetGridRowBindingPath(DependencyObject obj)
        {
            return (string)obj.GetValue(GridRowBindingPathProperty);
        }

        public static void SetGridRowBindingPath(DependencyObject obj, string value)
        {
            obj.SetValue(GridRowBindingPathProperty, value);
        }

        public static string GetCanvasZIndexBindingPath(DependencyObject obj)
        {
            return (string)obj.GetValue(CanvasZIndexBindingPathProperty);
        }

        public static void SetCanvasZIndexBindingPath(DependencyObject obj, string value)
        {
            obj.SetValue(CanvasZIndexBindingPathProperty, value);
        }

        private static void GridBindingPathPropertyChanged(
            DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            var propertyPath = e.NewValue as string;

            if (propertyPath != null)
            {
                DependencyProperty property = null;
                if (e.Property == GridColumnBindingPathProperty)
                {
                    property = Grid.ColumnProperty;
                }
                else if (e.Property == GridRowBindingPathProperty)
                {
                    property = Grid.RowProperty;
                }

                BindingOperations.SetBinding(
                    obj,
                    property,
                    new Binding { Path = new PropertyPath(propertyPath) });
            }
        }

        private static void CanvasBindingPathPropertyChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            var propertyPath = e.NewValue as string;

            if (propertyPath != null)
            {
                DependencyProperty property = Canvas.ZIndexProperty;

                BindingOperations.SetBinding(
                    obj,
                    property,
                    new Binding { Path = new PropertyPath(propertyPath), Converter = new BooleanToZIndexConverter() });
            }
        }
    }
}
