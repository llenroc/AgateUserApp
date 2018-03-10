using System;
using System.Collections.Generic;
using System.Linq;

using Xamarin.Forms;

namespace TripleZerooo
{


    public static class UIFactory
    {
        public static Grid Grid(RowDefinition[] rows = null, ColumnDefinition[] columns = null, params View[] children)
        {
            var grid = new Grid();

            if (columns != null)
            {
                foreach (var column in columns)
                {
                    grid.ColumnDefinitions.Add(column);
                }
            }

            if (rows != null)
            {
                foreach (var row in rows)
                {
                    grid.RowDefinitions.Add(row);
                }
            }

            foreach (var child in children)
            {
                grid.Children.Add(child);
            }

            return grid;
        }

        public static StackLayout StackLayout(StackOrientation orientation, params View[] children)
        {
            var stacklayout = new StackLayout();
            stacklayout.Orientation = orientation;

            foreach (var child in children)
            {
                stacklayout.Children.Add(child);
            }

            return stacklayout;
        }

        public static StackLayout Vertical(params View[] children) => StackLayout(StackOrientation.Vertical, children);

        public static StackLayout Horizontal(params View[] children) => StackLayout(StackOrientation.Horizontal, children);

        public static ColumnDefinition[] CreateColumns(params GridLength[] widths) =>
            widths.Select(x => new ColumnDefinition { Width = x }).ToArray();

        public static RowDefinition[] CreateRows(params GridLength[] heights) =>
            heights.Select(x => new RowDefinition { Height = x }).ToArray();

        public static Image Image(string filename) => new Image { Source = ImageSource.FromFile(filename) };

        public static Button Button(string caption) => new Xamarin.Forms.Button { Text = caption };

        public static Label Label(string text) => new Label { Text = text };

        public static T Design<T>(this T view, Action<T> action)
            where T : BindableObject
        {
            action(view);
            return view;
        }
        public static T At<T>(this T view, int row, int column)
            where T : BindableObject
        {
            Xamarin.Forms.Grid.SetColumn(view, column);
            Xamarin.Forms.Grid.SetRow(view, row);
            return view;
        }
        public static T AtRow<T>(this T view, int row)
            where T : BindableObject
            => view.Design(v => Xamarin.Forms.Grid.SetRow(view, row));

        public static T AtColumn<T>(this T view, int column)
            where T : BindableObject
            => view.Design(v => Xamarin.Forms.Grid.SetColumn(view, column));

        public static T VerticalOptions<T>(this T view, LayoutOptions verticalOptions)
            where T : View => view.Design(v => v.VerticalOptions = verticalOptions);

        public static T HorizontalOptions<T>(this T view, LayoutOptions horizontalOptions)
            where T : View => view.Design(v => v.HorizontalOptions = horizontalOptions);

        public static Func<View, View> At(int row, int column) =>
            view => { Xamarin.Forms.Grid.SetRow(view, row); Xamarin.Forms.Grid.SetColumn(view, column); return view; };

        public static Func<View, View> AtRow(int row)
            => view => view.Design(v => Xamarin.Forms.Grid.SetRow(view, row));

        public static Func<View, View> AtColumn(int column)
            => view => view.Design(v => Xamarin.Forms.Grid.SetColumn(v, column));

        public static T SpanColumns<T>(this T view, int columnSpan)
            where T : View
            => view.Design(v => Xamarin.Forms.Grid.SetColumnSpan(v, columnSpan));

        public static T Size<T>(this T view, float width, float height)
            where T : View
        {
            view.WidthRequest = width;
            view.HeightRequest = height;
            return view;
        }

        public static T Width<T>(this T view, float width)
            where T : View => Design(view, v => v.WidthRequest = width);

        public static T Height<T>(this T view, float height)
            where T : View => Design(view, v => v.HeightRequest = height);

        public static T Margin<T>(this T view, Thickness margin)
            where T : View => Design(view, v => v.Margin = margin);
    }
}