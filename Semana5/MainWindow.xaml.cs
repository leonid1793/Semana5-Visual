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
using Business;
using Entity;

namespace Semana5
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent(); 
        }

        private void BtnConsultar_Click(object sender, RoutedEventArgs e)
        {
            Cargar();
        }

        public void Cargar()
        {
            BCategoria bCategoria = null;
            try
            {
                bCategoria = new BCategoria();
                dgvCategoria.ItemsSource = bCategoria.Listar(0);
            }
            catch (Exception)
            {
                MessageBox.Show("Comunicarse con el Administrador");
            }
            finally
            {
                bCategoria = null;
            }
        }

        private void BtnNuevo_Click(object sender, RoutedEventArgs e)
        {
            ManCategoria manCategoria = new ManCategoria(0);
            manCategoria.ShowDialog();
            Cargar();
        }

        private void DgvCategoria_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int idCategoria;
            var item = (Categoria)dgvCategoria.SelectedItem;
            if (null == item) return;
            idCategoria = Convert.ToInt32(item.IdCategoria);
            ManCategoria manCategoria = new ManCategoria(idCategoria);
            manCategoria.ShowDialog();
            Cargar();
        }
    }
}
