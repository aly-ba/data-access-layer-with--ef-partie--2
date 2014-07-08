using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using Repository;
using SalesModel.DomainClasses;

namespace WpfSales
{

  public partial class MainWindow : Window
  {
    private ObjectDataProvider _customerViewSource;
    private ObjectDataProvider _contactDetailViewSource;
    private Customer _currentCustomer;
    readonly SimpleRepository _repository = new SimpleRepository();
    private bool _isLoading;
    public MainWindow()
    {
      InitializeComponent();
      Style = (Style)FindResource(typeof(Window));
    }

    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
      _isLoading = true;
      customerListBox.ItemsSource = _repository.CustomersInMemory();
      SortList();
      _customerViewSource = ((ObjectDataProvider)(FindResource("customerViewSource")));
      _contactDetailViewSource = ((ObjectDataProvider)(FindResource("contactDetailViewSource")));
      customerListBox.SelectedIndex = 0;
      _isLoading = false;
    }

    private void SortList()
    {
      ICollectionView dataView =
        CollectionViewSource.GetDefaultView(customerListBox.ItemsSource);
      dataView.SortDescriptions.Clear();
      var sd = new SortDescription("FullName", ListSortDirection.Ascending);
      dataView.SortDescriptions.Add(sd);
      dataView.Refresh();
      customerListBox.SelectedItem = _currentCustomer;
    }

    private void customerListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      bool continueProcess;
      if (_isLoading)
      {
        continueProcess = true;
      }
      else
      {
        continueProcess = ShouldRefresh;
      }
      if (!continueProcess) return;
      _currentCustomer = _repository.GetCustomerGraph(
                            ((int)customerListBox.SelectedValue)
                            );
      RefreshCustomer();
    }

    private void RefreshCustomer()
    {
      _customerViewSource.ObjectInstance = _currentCustomer;
      _contactDetailViewSource.ObjectInstance = _currentCustomer.ContactDetail;
      orderDataGrid.ItemsSource = _currentCustomer.Orders;
      _currentCustomer.IsDirty = false;
      _currentCustomer.ContactDetail.IsDirty = false;
    }

    private void btnSave_Click(object sender, RoutedEventArgs e)
    {
      _repository.Save();
      SortList();
    }

    private void btnNewCustomer_Click(object sender, RoutedEventArgs e)
    {
      if (ShouldRefresh)
      {
        _currentCustomer = _repository.NewCustomerWithContactDetail();
        RefreshCustomer();
      }
    }

    private bool ShouldRefresh
    {
      get
      {

        bool continueProcess = true;
        if (_currentCustomer != null)
        {
          if (_currentCustomer.IsDirty || _currentCustomer.ContactDetail.IsDirty)
          {
            switch (MessageBox.Show("Save current customer?", "Customer Entry", MessageBoxButton.YesNoCancel))
            {
              case MessageBoxResult.Cancel:
                continueProcess = false;
                break;
              case MessageBoxResult.Yes:
                _repository.Save();
                break;
              case MessageBoxResult.No:
                break;
            }
          }
        }
        return
        continueProcess;
      }
    }

    private void DeleteCustomer(object sender, RoutedEventArgs e)
    {
      switch (MessageBox.Show("Delete? Really?", "Customer Entry", MessageBoxButton.YesNo))
      {
        case MessageBoxResult.Yes:
          var custToDelete = _currentCustomer;
          customerListBox.SelectedIndex = 0;
          _repository.DeleteCurrentCustomer(custToDelete);
          break;
        case MessageBoxResult.No:
          break;
      }
    }
  }
}
