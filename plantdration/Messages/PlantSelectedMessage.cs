using CommunityToolkit.Mvvm.Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using plantdration.Models;

namespace plantdration.Messages
{
    public class PlantSelectedMessage(UserPlant selectedUserPlant) : ValueChangedMessage<UserPlant>(selectedUserPlant)
    {
    }
}
