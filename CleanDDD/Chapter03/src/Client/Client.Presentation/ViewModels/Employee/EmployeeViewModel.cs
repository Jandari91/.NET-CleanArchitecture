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
        private readonly IDialogService _dialogService = default!;

        [ObservableProperty]
        public IEnumerable<EmployeeModel> _employees = default!;

        public EmployeeViewModel(IQueryBus queryBus, IDialogService dialogService)
        {
            _queryBus = queryBus ?? throw new ArgumentNullException(nameof(queryBus));
            _dialogService = dialogService ?? throw new ArgumentNullException(nameof(dialogService));
        }

        [RelayCommand]
        private async Task LoadEmployeesAsync()
        {
            var response = await _queryBus.SendAsync(new GetEmployeesQuery(), CancellationToken.None);
            if(response.IsSuccess)
            {
                var employees = response.Value;
                Employees = employees.Select(dto => new EmployeeModel(dto.Id, dto.Name, dto.Email));
            }
        }
    }
}
