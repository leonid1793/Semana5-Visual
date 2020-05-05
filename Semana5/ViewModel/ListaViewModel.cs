using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;

namespace Semana5.ViewModel
{
    public class ListaViewModel : ViewModelBase
    {
        public ObservableCollection<Categoria> Categorias { get; set; }
        public ICommand NuevoCommand { set; get; }
        public ICommand ConsultarCommand { set; get; }

        public ListaViewModel()
        {
            Categorias = new Model.CategoriaModel().Categorias;

            NuevoCommand = new RelayCommand<Window>(
                param => Abrir()
                );
            ConsultarCommand = new RelayCommand<object>(
                o => { Categorias = (new Model.CategoriaModel()).Categorias; }
                );

            void Abrir()
            {
                View.ManCategoria window = new View.ManCategoria();
                window.ShowDialog();
                //Categorias = (new Model.CategoriaModel()).Categorias;
            }
        }
    }
}
