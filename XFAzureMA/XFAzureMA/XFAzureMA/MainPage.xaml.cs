using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XFAzureMA
{
    public partial class MainPage : ContentPage
    {
        MobileServiceClient client;
        IMobileServiceTable<DoggyTodo> todoTable;

        public MainPage()
        {
            InitializeComponent();

            this.client = new MobileServiceClient("http://doggylab.azurewebsites.net");
            this.todoTable = client.GetTable<DoggyTodo>();

            todoList.Refreshing += TodoList_Refreshing;
            buttonAdd.Clicked += async (s, e) =>
            {
               await todoTable.InsertAsync(new DoggyTodo
                {
                    Name = DateTime.Now.ToString()
                });
                await Refresh();
            };
            buttonDel.Clicked += async (s, e) =>
            {
                if(todoList.SelectedItem != null)
                {
                    var fooItem = (DoggyTodo)todoList.SelectedItem;
                    await todoTable.DeleteAsync(fooItem);
                    await Refresh();
                }
            };
        }

        private async void TodoList_Refreshing(object sender, EventArgs e)
        {
            await Refresh();
        }

        public async Task Refresh()
        {

            List<DoggyTodo> items = await todoTable.ToListAsync();

            todoList.ItemsSource = items;

            todoList.EndRefresh();
        }
    }
}
