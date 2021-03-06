﻿using SportBets.Core.Contracts;
using SportBets.Services.Interfaces;
using SportBets.Win10.Bihevior;
using System.Threading.Tasks;

namespace SportBets.Win10.ViewModels
{
	public class SignInViewModel : BaseViewModel
	{
		private string USER_NOT_FOUNT = "User not found";

		private IUserService _userService;
		private INagvigationManager _navigationManager;
		private AuthUserManager _userAuthManager;

		private string _login;
		private string _password;
		private string _errorMessage;

		public string Login
		{
			get => _login;
			set
			{
				_login = value;
				OnPropertyNotified(nameof(Login));
			}
		}

		public string Password
		{
			get => _password;
			set
			{
				_password = value;
				OnPropertyNotified(nameof(Password));
			}
		}

		public string ErrorMessage
		{
			get => _errorMessage;
			set
			{
				_errorMessage = value;
				OnPropertyNotified(nameof(ErrorMessage));
			}
		}

		public SignInViewModel(IUserService userService,
			INagvigationManager navigationManager,
			AuthUserManager userAuthManager)
		{
			_userService = userService;
			_userAuthManager = userAuthManager;
			_navigationManager = navigationManager;
		}

		public async Task SignIn()
		{
			if (!string.IsNullOrEmpty(Login) && !string.IsNullOrEmpty(Password))
			{
				var user = await _userService.SignIn(Login, Password);

				if (user == null)
				{
					ErrorMessage = USER_NOT_FOUNT;
					return;
				}

				_userAuthManager.User = user;
				Login = Password = string.Empty;

				_navigationManager.NavigateTo(Page.Home);
			}
		}

		public async Task SignUp()
		{
			Login = "q222";
			Password = "1111";
			await SignIn();
			NavigationManager.Instanse.NavigateTo(Page.SignUp);
		}
	}
}