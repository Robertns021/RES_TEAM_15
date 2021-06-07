using DataBase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using DAKlijent;

namespace Client1
{
    /// <summary>
    /// Interaction logic for View.xaml
    /// </summary>
    public partial class View : Window
    {
        /*private DataIO serializer = new DataIO();
        public static BindingList<Common.Racunanje> DataSet { get; set; }
        DataAccess da = new DataAccess();*/
        DataAccessKlijent da = new DataAccessKlijent();
        public View()
        {
            dataGrid.ItemsSource = da.Procitaj();
            /*DataSet = serializer.DeSerializeObject<BindingList<Common.Racunanje>>("dataset.xml");
            if (DataSet == null)
            {
                DataSet = new BindingList<Common.Racunanje>();
            }*/
            InitializeComponent();
            DataContext = this;
        }
    }
}
