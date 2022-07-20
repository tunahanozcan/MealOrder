using MealOrder.Shared.DTO;
using MealOrder.Shared.ResponseModels;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace MealOrder.Client.Pages.Users
{
    public class UserListProcess:ComponentBase
    {
        [Inject]
        public HttpClient Client { get; set; }

        protected List<UserDTO> userList = new List<UserDTO>();


        protected async override Task OnInitializedAsync()
        {
            await LoadList();
        }

        protected async Task LoadList()
        {
            var serviceResponse=await Client.GetFromJsonAsync<ServiceResponse<List<UserDTO>>>("api/User/Users");

            if (serviceResponse.Success)
                userList = serviceResponse.Value;
        }

    }
}
