﻿using CoreTier.SystemAdministration;
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
using System.Windows.Shapes;
using WpfApp.ViewModels.Tools;

namespace WpfApp.UserControlsAndWindows.Tools
{
    /// <summary>
    /// Interaction logic for AdmTipoHerramientas.xaml
    /// </summary>
    public partial class AdmToolTypes : Window
    {
        private AdmToolTypesViewModel _viewModel { get; set; }
        public AdmToolTypes()
        {
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            InitializeComponent();
            _viewModel = new AdmToolTypesViewModel();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = _viewModel;
        }

        private void btn_Actualizar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (listView.SelectedItem != null)
                {
                    btn_Borrar.IsEnabled = false;
                    btn_Actualizar.IsEnabled = false;
                    var tipo = (ToolType)listView.SelectedItem;

                    _viewModel.Nombre = tipo.Name;
                    _viewModel.Descripcion = tipo.Description;
                    _viewModel.IdHerramienta = tipo.IdToolType;
                }
                else
                {
                    MessageBoxResult result = MessageBox.Show("Debe Seleccionar Un Tipo de Herramienta Para Poder Actualizarla", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            catch (Exception ex)
            {
                Logger.Log.Error("btn_Actualizar_Click", ex);
            }
        }

        private void btn_Guardar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _viewModel.GuardarTipoHerramienta();
                btn_Borrar.IsEnabled = true;
                btn_Actualizar.IsEnabled = true;
            }
            catch (Exception ex)
            {
                Logger.Log.Error("btn_Guardar_Click", ex);
            }
        }

        private void btn_Cancelar_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.LimpiarViewModel();
            btn_Borrar.IsEnabled = true;
            btn_Actualizar.IsEnabled = true;
            listView.SelectedItem = null;
        }

        private void btn_Borrar_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
