namespace TestTask.WebApi;

public static class AppConstants
{
	public const string JwtSectionName = "Jwt";
	public static class SwaggerConstants
	{
		public const string UnauthorizedMessage = "If account is not authorized.";
		public const string InternalServerError = "If there is an internal server error.";
		public const string InvalidRequestMessage = "If the request is malformed or invalid.";
		public const string OpenApiSecuritySchemeName = "Authorization";
		public const string OpenApiSecuritySchemeBearerFormat = "JWT";
		public const string OpenApiSecurityScheme = "Bearer";
		public static readonly string SwaggerJwtAuthorizationDescription =
		$"JWT Authorization header using the {OpenApiSecurityScheme} scheme. \r\n\r\n Enter '{OpenApiSecurityScheme}' [space] [your token value].";
	}
}
