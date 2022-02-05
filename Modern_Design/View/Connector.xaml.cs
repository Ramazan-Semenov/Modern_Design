using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Modern_Design.View
{
    /// <summary>
    /// Логика взаимодействия для Connector.xaml
    /// </summary>
    public partial class Connector : UserControl
    {
        public Connector()
        {
            InitializeComponent();
            selfWatcher.ChangeTarget(this);

            selfWatcher.Changed += RecalcLine;
            fromWatcher.Changed += RecalcLine;
            toWatcher.Changed += RecalcLine;
            RecalcLine(null, null);
        }

        LayoutWatcher selfWatcher = new LayoutWatcher(),
                      fromWatcher = new LayoutWatcher(),
                      toWatcher = new LayoutWatcher();

        #region dp FrameworkElement From
        public FrameworkElement From
        {
            get { return (FrameworkElement)GetValue(FromProperty); }
            set { SetValue(FromProperty, value); }
        }

        public static readonly DependencyProperty FromProperty =
            DependencyProperty.Register("From", typeof(FrameworkElement), typeof(Connector),
                new FrameworkPropertyMetadata((o, args) =>
                { var self = (Connector)o; self.fromWatcher.ChangeTarget(self.From); }));
        #endregion

        #region dp FrameworkElement To
        public FrameworkElement To
        {
            get { return (FrameworkElement)GetValue(ToProperty); }
            set { SetValue(ToProperty, value); }
        }

        public static readonly DependencyProperty ToProperty =
            DependencyProperty.Register("To", typeof(FrameworkElement), typeof(Connector),
                new FrameworkPropertyMetadata((o, args) =>
                { var self = (Connector)o; self.toWatcher.ChangeTarget(self.To); }));
        #endregion

        void RecalcLine(object sender, LayoutChangeEventArgs e)
        {
            if (From == null || To == null)
            {
                ConnectingLine.Visibility = Visibility.Collapsed;
                return;
            }

            ConnectingLine.Visibility = Visibility.Visible;

            var fromRect = LayoutWatcher.ComputeRenderRect(From, this);
            var toRect = LayoutWatcher.ComputeRenderRect(To, this);

            ConnectingLine.X1 = fromRect.Right + 5;
            ConnectingLine.Y1 = fromRect.Top + fromRect.Height / 2;

            ConnectingLine.X2 = toRect.Left - 5;
            ConnectingLine.Y2 = toRect.Top + toRect.Height / 2;
        }
    }
}
