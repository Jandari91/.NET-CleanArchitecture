using Client.Application.Features.Employees.Queries;
using Client.Presentation.Abstractions.Dialogs;
using Client.Presentation.ViewModels.Employee.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Shared.Adapter.Messaging;

namespace Client.Presentation.ViewModels.Employee
{
    public partial class EmployeeViewModel : ObservableObject
    {
        private readonly IQueryBus _queryBus = default!;

        [ObservableProperty]
        public IEnumerable<EmployeeModel> _employees = default!;

        public EmployeeViewModel(IQueryBus queryBus)
        {
            _queryBus = queryBus ?? throw new ArgumentNullException(nameof(queryBus));
        }

        [RelayCommand]
        private async Task LoadedAsync() => await GetEmployees();

        [RelayCommand]
        private async Task RefreshEmployeesAsync() => await GetEmployees();

        private async Task GetEmployees()
        {
            var response = await _queryBus.SendAsync(new GetEmployeesQuery(), CancellationToken.None);
            if (response.IsSuccess)
            {
                var employees = response.Value;
                Employees = employees.Select(dto => new EmployeeModel(dto.Id, dto.Name, dto.Email));
            }
        }
    }
}
