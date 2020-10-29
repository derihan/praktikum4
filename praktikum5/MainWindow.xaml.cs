using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace praktikum5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Calculator calc;

        public MainWindow()
        {
            InitializeComponent();
            calc = new Calculator();
            listBox.ItemsSource = calc.getListItem();
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            string title = itemNameBox.Text;
            int quantity = int.Parse(quantityBox.Text);
            string type = typeBox.Text;
            double price = double.Parse(priceBox.Text);
            double total = calc.getTotal();

            Item item = new Item(new Random().Next(), title, quantity, price, total , type);
            calc.addItem(item);
            

            totalLabel.Content = string.Format("Rp. {0}", total);
            listBox.Items.Refresh();

        }
    }

    class Item{
        private int id;
        public string title { get; set; }
        public int quantity { get; set; }
        public double price { get; set; }
        public double subtotal { get; set; }
        private string type;
        
        public Item(int id, string title, int quantity, double price, double subtotal, string type)
        {
            this.id = id;
            this.title = title;
            this.quantity = quantity;
            this.price = price;
            this.subtotal = 0;
            this.type = type;
        }

        public string getTitle() 
        {
            return this.title;
        }

        public int getQuantity()
        {
            return this.quantity;
        }

        public string getType()
        {
            return this.type;
        }

        public double getPrice()
        {
            return this.price;
        }

        public double getSubtotal()
        {
            subtotal = this.price * this.quantity;
            return subtotal;
        }


    }

    class Calculator
    {
        private List<Item> listItem;
        private double total = 0;

        public Calculator()
        {
            this.listItem = new List<Item>();
        }

        public void addItem(Item item)
        {
            listItem.Add(item);
            this.total += item.getSubtotal();
        }

        public double getTotal()
        {
            return this.total;
        }

        public List<Item> getListItem()
        {
            return this.listItem;
        }

    }
}
