using CommunityToolkit.Mvvm.Messaging.Messages;
using plantdration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace plantdration.Messages
{
    public class UserSelectedMessage(User user) : ValueChangedMessage<User>(user)
    {
    }
}
