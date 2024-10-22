using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;

namespace plantdration.Models
{
    public class User : ObservableObject
    {
        private int id;
        private string name = string.Empty;

        public int Id
        {
            get => id;
            set => SetProperty(ref id, value);
        }

        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }

        public User(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public User()
        {
        }
    }
}

