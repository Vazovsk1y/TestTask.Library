﻿using TestTask.Domain.Entities;

namespace TestTask.Application.Implementations;

internal static class Errors
{
	public static string EntityWithPassedIdIsNotExists(string entityName) => $"{entityName} with passed id is not exists.";

	internal static class Book
	{
		public const string BookWithPassedISBNIsNotExists = "Book with passed isnb is not exists.";
	}
}