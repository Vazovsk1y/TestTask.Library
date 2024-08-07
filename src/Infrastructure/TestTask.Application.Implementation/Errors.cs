﻿namespace TestTask.Application.Implementation;

internal static class Errors
{
	public static string EntityWithPassedIdIsNotExists(string entityName) => $"{entityName} with passed id is not exists.";

	internal static class Book
	{
		public const string BookWithPassedISBNIsNotExists = "Book with passed isnb is not exists.";

		public const string BookWithPassedISBNIsAlreadyExists = "Book with passed isbn is already exists.";
	}

	internal static class User
	{
		public const string EmailIsAlreadyTaken = "Email is already taken.";
	}

	internal static class Auth
	{
		public const string InvalidCredentials = "Incorrect password or email passed.";
	}
}