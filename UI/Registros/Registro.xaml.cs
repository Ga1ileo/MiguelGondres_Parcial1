using MiguelGondres_Parcial1.BLL;
using MiguelGondres_Parcial1.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MiguelGondres_Parcial1.UI.Registros
{
    /// <summary>
    /// Interaction logic for Registro.xaml
    /// </summary>
    public partial class Registro : Window
    {
        public Registro()
        {
            InitializeComponent();
        }

        public void Limpiar()
        {
            ProductoIdTextBox.Text = string.Empty;
            DescripcionTextBox.Text = string.Empty;
            ExistenciaTextBox.Text = string.Empty;
            CostoTextBox.Text = string.Empty;
            ValorInventarioTextBox.Text = string.Empty;
        }
        private Articulo LlenaClase()
        {
            Articulo articulo = new Articulo();
            articulo.ProductoId = Convert.ToInt32(ProductoIdTextBox.Text);
            articulo.Descripcion = DescripcionTextBox.Text;
            articulo.Existencia = ExistenciaTextBox.Text;
            articulo.Costo = Convert.ToDecimal(CostoTextBox.Text);
            articulo.ValorInventario = Convert.ToDecimal(ValorInventarioTextBox.Text);
         
            return articulo;

        }

        private void LlenaCampo(Articulo articulo)
        {
            ProductoIdTextBox.Text = Convert.ToString(ProductoIdTextBox);
            DescripcionTextBox.Text = articulo.Descripcion;
            ExistenciaTextBox.Text = articulo.Existencia;
            CostoTextBox.Text = Convert.ToString(CostoTextBox);
            ValorInventarioTextBox.Text = Convert.ToString(ValorInventarioTextBox);

        }

        private bool ExisteEnLaBaseDeDatos()
        {
            Articulo articullo = ArticulosBLL.Buscar(Convert.ToInt32(ProductoIdTextBox.Text));
            return (articullo != null);
        }

        private bool Validar()
        {
            bool paso = true;

            if (ProductoIdTextBox.Text == string.Empty)
            {
                ProductoIdTextBox.Focus();
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(DescripcionTextBox.Text))
            {
                DescripcionTextBox.Focus();
            }

            if (string.IsNullOrWhiteSpace(ExistenciaTextBox.Text))
            {
                ExistenciaTextBox.Focus();
                paso = false;
            }

            return paso;
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            Articulo articulo = new Articulo();

            Limpiar();

            articulo = ArticulosBLL.Buscar(Convert.ToInt32(ProductoIdTextBox.Text));

            if(articulo != null)
            {
                MessageBox.Show("Persona No Encontrada");
                LlenaCampo(articulo);
            }
            else
            {
                MessageBox.Show("Persona No Encontrada");
                
            }
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            Articulo articulo;
            bool paso = false;

            if (!Validar())
                return;

            articulo = LlenaClase();

            if (Convert.ToInt32(ProductoIdTextBox.Text) == 0)
                paso = ArticulosBLL.Guardar(articulo);
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {
                    MessageBox.Show("NO SE PUEDE MODIFICAR, la persona No la han creado", "Fallo", MessageBoxButton.OK);
                    return;
                }
                paso = ArticulosBLL.Modificar(articulo);
            }

            if (paso)
            {
                Limpiar();
                MessageBox.Show("Guardado!!", "Existo", MessageBoxButton.OK);
            }
            else
                MessageBox.Show("No fue posible guardar!!", "Fallo", MessageBoxButton.OK);

        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            int id;
            int.TryParse(ProductoIdTextBox.Text, out id);

            Limpiar();

            if (ArticulosBLL.Eliminar(id))
                MessageBox.Show("Eliminado");
            else
                MessageBox.Show("No se puede eliminar");
        }
    }
}
