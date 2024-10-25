using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace plantdration.Services
{
    public interface INavigationService
    {
        Task NavigateToDetailsPageAsync();
        Task NavigateToHomePageAsync();
        Task NavigateBackAsync();
    }
}
