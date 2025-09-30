using CommunityToolkit.Mvvm.ComponentModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Client.Business.Core.Domain.Models.Users;

public partial class UserModel : ObservableValidator
{
    public long Id { get; set; } = default!;

    private string _name = default!;

    [Required(ErrorMessage = "이름을 입력하세요.")]
    [MinLength(1, ErrorMessage = "이름을 입력하세요.")]
    [MaxLength(20, ErrorMessage = "이름은 최대 20자까지 입력 가능합니다.")]
    public string Name
    {
        get => _name;
        set
        {
            SetProperty(ref _name, value);
            ValidateProperty(value);
        }
    }


    private string _email = default!;
    [Required(ErrorMessage = "이메일을 입력하세요.")]
    [MaxLength(20, ErrorMessage = "이메일은 최대 20자까지 입력 가능합니다.")]
    [EmailAddress(ErrorMessage = "올바른 이메일 주소를 입력하세요.")]
    [DataType(DataType.EmailAddress)]
    public string Email
    {
        get => _email;
        set
        {
            SetProperty(ref _email, value);
            ValidateProperty(value);
        }
    }

    private string _password = default!;
    [Required(ErrorMessage = "비밀번호를 입력하세요.")]
    [MaxLength(20, ErrorMessage = "비밀번호는 최대 20자까지 입력 가능합니다.")]
    [DataType(DataType.Password)]
    public string Password
    {
        get => _password;
        set
        {
            SetProperty(ref _password, value);
            ValidateProperty(value);
        }
    }
}
