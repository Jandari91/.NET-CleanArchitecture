using CommunityToolkit.Mvvm.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Client.Presentation.ViewModels.Employee.Models
{
    public partial class EmployeeModel : ObservableValidator
    {
        private string _id = string.Empty;

        [ObservableProperty]
        [NotifyDataErrorInfo]
        [Required(ErrorMessage = "이름을 입력하세요.")]
        [MinLength(1, ErrorMessage = "이름을 입력하세요.")]
        [MaxLength(20, ErrorMessage = "이름은 최대 20자까지 입력 가능합니다.")]
        private string _name = default!;

        [ObservableProperty]
        [NotifyDataErrorInfo]
        [Required(ErrorMessage = "이메일을 입력하세요.")]
        [MaxLength(20, ErrorMessage = "이메일은 최대 20자까지 입력 가능합니다.")]
        [EmailAddress(ErrorMessage = "올바른 이메일 주소를 입력하세요.")]
        [DataType(DataType.EmailAddress)]
        private string _email = default!;

        public EmployeeModel(string id, string name, string email)
        {
            id = id ?? throw new ArgumentNullException(nameof(id));
            Name = name;
            Email = email;
        }
    }
}
