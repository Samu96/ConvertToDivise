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
using servicioConversion;

namespace AplicacionWPF
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        servicio servicio = new servicio();
        Boolean activator = false;

        public MainWindow()
        {
            InitializeComponent();
            servicio.crearMonedasCambios();
            foreach (var valor in servicio.obtenerMonedas())
            {
                comboBox1.Items.Add(valor);
                comboBox2.Items.Add(valor);
                Console.WriteLine(valor);
            }
            aux(servicio.obtenerMonedas());
        }
        private void aux(List<Dom.Moneda> Monedas)
        {
            var method = from m in Monedas
                         orderby m.Id
                         group m by m.nombre
                         into groups
                         select new { id= groups.Key, total = groups.Count()};
            foreach (var value in method)
            {
                Console.WriteLine(value.id+" Total "+value.total);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           showText.Text = "La converción es: " + servicio.convertir(comboBox1.SelectedValue.ToString(), comboBox2.SelectedValue.ToString(), double.Parse(txtStatus.Text)).ToString() + " " + comboBox2.SelectedValue.ToString();
            

        }
        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            

            try
            {
                comprueba();
                alertaDestino.Visibility = Visibility.Hidden;
                
            }
            catch (NullReferenceException)
            {

                Console.WriteLine(e.ToString());
                boton1.IsEnabled = false;
                if (comboBox2.SelectedValue.ToString() == "") { alertaDestino.Visibility = Visibility.Hidden; }
                showText.Text = "La converción es: ";
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Console.WriteLine(comboBox1.Text);
            switch (comboBox1.Text)
            {
                case "EUR":
                    simbolo.Text = "€";
                    break;
                case "USD":
                    simbolo.Text = "$";
                    break;
                case "GBP":
                    simbolo.Text = "£";
                    break;
                case "CNY":
                    simbolo.Text = "¥";
                    break;
            }
            try
            {
                comprueba();
                alertaOrigen.Visibility = Visibility.Hidden; 
            }
            catch (NullReferenceException)
            {
                
                Console.WriteLine(e.ToString());
                boton1.IsEnabled = false;
                if (comboBox1.SelectedValue.ToString() == "") { alertaOrigen.Visibility = Visibility.Hidden; }
                showText.Text = "La converción es: ";
            }

        }

        private void TxtStatus_TextChanged(object sender, TextChangedEventArgs e)
        {
            comprueba();
            try
            {
                if (int.Parse(txtStatus.Text) >= 0)
                {
                    alertaText.Visibility = Visibility.Hidden;
                }
            }
            catch (Exception) { }
        }
        private void comprueba()
        {
            try {
                if ( int.Parse(txtStatus.Text)>=0 && comboBox1.SelectedValue.ToString() != "" && comboBox2.SelectedValue.ToString() != "")
                {
                    boton1.IsEnabled = true;
                    alertaText.Visibility = Visibility.Hidden;
                }
                if (comboBox1.SelectedValue.ToString() == "") { alertaDestino.Visibility = Visibility.Hidden; }
                if (comboBox2.SelectedValue.ToString() == "") { alertaOrigen.Visibility = Visibility.Hidden; }
            }
            catch (FormatException e)
            {
                boton1.IsEnabled = false;
                alertaText.Visibility = Visibility.Visible;
                showText.Text = "La converción es: ";
            }
            catch (NullReferenceException e)
            {
                boton1.IsEnabled = false;
                alertaOrigen.Visibility = Visibility.Visible;
                alertaDestino.Visibility = Visibility.Visible;
                showText.Text = "La converción es: ";
            }
        }
    }
}
