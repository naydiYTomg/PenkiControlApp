using System.Windows;

namespace PenkiControlApp.UI;

public partial class Calcul : Window
{
    public Calcul()
    {
        InitializeComponent();
    }
    private enum Operator
    {
        Plus,
        Minus,
        Div,
        Mul
    }
    private int _firstValue = 0;
    private Operator? _operator = null;
    private void Zero_OnClick(object sender, RoutedEventArgs e)
    {
        if (Output.Content as string != "0")
        {
            Output.Content += "0";
        }
    }

    private void Clear_OnClick(object sender, RoutedEventArgs e)
    {
        Output.Content = "0";
    }

    private void Eq_OnClick(object sender, RoutedEventArgs e)
    {
        throw new NotImplementedException();
    }

    private void One_OnClick(object sender, RoutedEventArgs e)
    {
        if (Output.Content as string == "0")
        {
            Output.Content = "1";
        }
        else
        {
            Output.Content += "1";
        }
    }
    private void Two_OnClick(object sender, RoutedEventArgs e)
    {
        if (Output.Content as string == "0")
        {
            Output.Content = "2";
        }
        else
        {
            Output.Content += "2";
        }
    }
    private void Three_OnClick(object sender, RoutedEventArgs e)
    {
        if (Output.Content as string == "0")
        {
            Output.Content = "3";
        }
        else
        {
            Output.Content += "3";
        }
    }
    private void Four_OnClick(object sender, RoutedEventArgs e)
    {
        if (Output.Content as string == "0")
        {
            Output.Content = "4";
        }
        else
        {
            Output.Content += "4";
        }
    }
    private void Five_OnClick(object sender, RoutedEventArgs e)
    {
        if (Output.Content as string == "0")
        {
            Output.Content = "5";
        }
        else
        {
            Output.Content += "5";
        }
    }
    private void Six_OnClick(object sender, RoutedEventArgs e)
    {
        if (Output.Content as string == "0")
        {
            Output.Content = "6";
        }
        else
        {
            Output.Content += "6";
        }
    }
    private void Seven_OnClick(object sender, RoutedEventArgs e)
    {
        if (Output.Content as string == "0")
        {
            Output.Content = "7";
        }
        else
        {
            Output.Content += "7";
        }
    }
    private void Eight_OnClick(object sender, RoutedEventArgs e)
    {
        if (Output.Content as string == "0")
        {
            Output.Content = "8";
        }
        else
        {
            Output.Content += "8";
        }
    }
    private void Nine_OnClick(object sender, RoutedEventArgs e)
    {
        if (Output.Content as string == "0")
        {
            Output.Content = "9";
        }
        else
        {
            Output.Content += "9";
        }
    }

    private void Plus_OnClick(object sender, RoutedEventArgs e)
    {
        if (_operator is not null) return;
        _firstValue = int.Parse(Output.Content as string);
        Output.Content = "0";
        _operator = Operator.Plus;

    }
    private void Minus_OnClick(object sender, RoutedEventArgs e)
    {
        if (_operator is not null) return;
        _firstValue = int.Parse(Output.Content as string);
        Output.Content = "0";
        _operator = Operator.Minus;

    }
    private void Mul_OnClick(object sender, RoutedEventArgs e)
    {
        if (_operator is not null) return;
        _firstValue = int.Parse(Output.Content as string);
        Output.Content = "0";
        _operator = Operator.Mul;

    }
    private void Div_OnClick(object sender, RoutedEventArgs e)
    {
        if (_operator is not null) return;
        _firstValue = int.Parse(Output.Content as string);
        Output.Content = "0";
        _operator = Operator.Div;

    }

    private void EqualsPreform(object sender, RoutedEventArgs e)
    {
        if (_operator is null) return;
        switch (_operator)
        {
            case Operator.Plus:
                Output.Content = (int.Parse(Output.Content as string) + _firstValue).ToString();
                _operator = null;
                break;
            case Operator.Minus:
                Output.Content = (_firstValue - int.Parse(Output.Content as string) ).ToString();
                _operator = null;
                break;
            case Operator.Mul:
                Output.Content = (int.Parse(Output.Content as string) * _firstValue).ToString();
                _operator = null;
                break;
            case Operator.Div:
                try
                {
                    Output.Content = (_firstValue / int.Parse(Output.Content as string)  ).ToString();
                }
                catch (DivideByZeroException)
                {
                    Output.Content = "Division by zero";
                }
                _operator = null;
                break;
        }
    }
}