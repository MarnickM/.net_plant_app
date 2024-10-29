using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace plantdration.Models
{
    public class UserPlant : ObservableObject
    {
        private int id;
        private int userId;
        private int plantId;
        private DateTime dateAssigned;
        public DateTime lastWatered;

        public int Id
        {
            get => id;
            set => SetProperty(ref id, value);
        }

        public int UserId
        {
            get => userId;
            set => SetProperty(ref userId, value);
        }

        public int PlantId
        {
            get => plantId;
            set => SetProperty(ref plantId, value);
        }

        public DateTime DateAssigned
        {
            get => dateAssigned;
            set => SetProperty(ref dateAssigned, value);
        }

        public DateTime LastWatered
        {
            get => lastWatered;
            set => SetProperty(ref lastWatered, value);
        }

    }
}
