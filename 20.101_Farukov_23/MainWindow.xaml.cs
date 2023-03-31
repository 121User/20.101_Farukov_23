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

namespace _20._101_Farukov_23
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private Entity.EntitiesLibrary database = Helper.getContex();

        private void btn_Search_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var listGroups = database.Group.ToList();

                string titleSpec = "15.02.09 Аддитивные технологии";
                int idSpeciality = Helper.getIdSpeciality(titleSpec); //ID нужной специальности

                listGroups = listGroups.Where(group => group.IdSpeciality.Equals(idSpeciality)).ToList(); //Поиск группы по номеру специальности

                listGroups = listGroups.OrderByDescending(group => group.Title).ToList(); //Сортировка по убыванию

                //Вызов исключения, если нет нужных групп
                if (listGroups.Count == 0)
                {
                    throw new Exception();
                }

                LoadData.ItemsSource = listGroups; //Вывод результата
            }
            catch
            {
                //Вывод сообщения
                MessageBox.Show("Нет нужных групп!", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
