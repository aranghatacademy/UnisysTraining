using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using MyFavToDoApp.Model;
using MyFavToDoApp.Services;

namespace MyFavToDoApp.ViewModel
{
    public class ToDoViewModel : INotifyPropertyChanged
    {
        public AuthStatus AuthStatus { get; set; } = new AuthStatus();
        public string ToDoItemTitle { get; set; } = string.Empty;   
        public event PropertyChangedEventHandler? PropertyChanged;
        public ObservableCollection<ToDoItem> _toDoItems = new ObservableCollection<ToDoItem>();

        public ObservableCollection<ToDoItem> ToDoItems
        {
            get => _toDoItems;
            set
            {
                if (_toDoItems != value)
                {
                    _toDoItems = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ToDoItems)));
                }
            }
        }

        public ToDoViewModel()
        {
            //LoadAllToDoItems();
        }

        private async Task LoadAllToDoItems()
        {
            // await Task.Delay(5000);
            if (AuthStatus.IsAuthenticated)
            {
                ApiService.Http.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", AuthStatus.Token);

                var response = await ApiService.Http.GetAsync("api/todo");
                if (response.IsSuccessStatusCode)
                {
                    var items = await response.Content
                                              .ReadFromJsonAsync<List<ToDoItem>>();
                    if (items != null)
                    {
                        ToDoItems.Clear();
                        foreach (var item in items)
                        {
                            ToDoItems.Add(item);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Error loading tasks");
                }
            }
        }


        public ICommand RereshToDoItemCommand => new RelayCommand(async () =>
        {
            await LoadAllToDoItems();
        });
        public ICommand NewToDoItemCommand => new RelayCommand(async () =>
        {
            if(!string.IsNullOrEmpty(ToDoItemTitle))
            {
                var toDoItem = new ToDoItem
                {
                    Title = ToDoItemTitle,
                    IsCompleted = false
                };

                //Sent it to server
                var response = await ApiService.Http.PostAsJsonAsync("api/todo", toDoItem);
                if (response.IsSuccessStatusCode)
                {
                // Add the new item to the list
                    await LoadAllToDoItems();
                    // Clear the input field
                    ToDoItemTitle = string.Empty;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ToDoItemTitle)));
                }
                else
                {
                    MessageBox.Show("Error creating the task");
                }
            }
            else
            {
                MessageBox.Show("Please enter the task title");
            }
        });
   
        public void RefreshAuthStatus()
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AuthStatus)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AuthStatus.IsAuthenticated)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AuthStatus.Token)));
        }
    
    }

    public class RelayCommand : ICommand
    {
        private readonly Action execute;
        private readonly Func<bool> canExecute;
        public RelayCommand(Action execute, Func<bool> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }
        public event EventHandler CanExecuteChanged;
        public bool CanExecute(object parameter)
        {
            return canExecute == null || canExecute();
        }

        public void Execute(object parameter)
        {
            execute();
        }
    }
}
